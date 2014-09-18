using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using ShanliTech_HLD_Business.Components;
using ShanliTech_HLD_Business;
using System.Collections.Generic;
using System.Drawing;
using ShanliTech_HLD_Business.PermitErrorCalculate;
using ShanliTech.LogLib;

namespace FrameWork.web.Manager.Module.ShanliTech_HLD.DeviceTemplate
{
    public partial class CreateDetectPoint : System.Web.UI.Page
    {
        Int32 IDX = (Int32)Common.sink("IDX", MethodType.Get, 10, 0, DataType.Int);
        DeviceTemplateEntity _Device = null;
        List<DeviceFunctionTemplateEntity> _DeviceFuncList = null;
        List<Device_Permition_DataEntity> _RangeList = null;
        List<DetectPointTemplateEntity> _DetectPointList = null;
        List<CommandAssembleEntity> _DeviceCMDList = null;
        List<DetectPointTemplateEntity> _CreatedDetectPointList = null;
        int idnum = -1;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["CreatedDetectPointList"] != null)
            {
                _CreatedDetectPointList = (List<DetectPointTemplateEntity>)Session["CreatedDetectPointList"];
            }
            else 
            {
                _CreatedDetectPointList = new List<DetectPointTemplateEntity>();
            }

            _Device = BusinessFacadeShanliTech_HLD_Business.DeviceTemplateDisp(IDX);
            if (_Device == null || _Device.ID <= 0) { return; }

            _DeviceFuncList = ToolMethods.GetFunctionsByDeviceTemplateID(_Device.ID);
            if (_DeviceFuncList == null || _DeviceFuncList.Count <= 0) { return; }
            _DeviceFuncList.Sort((x, y) => { return x.OrderID.CompareTo(y.OrderID); });

           

            _RangeList = ToolMethods.GetRangeList(_Device.DeviceNum, _Device.DeviceModel);
            _RangeList.Sort((x, y) => { return x.RangeEnd.CompareTo(y.RangeEnd); });
            _DeviceCMDList = ToolMethods.GetDeviceCmdAssembleList(_Device.DeviceModel);

            if (!IsPostBack)
            {
                BindDeviceFunction();
                _DetectPointList = GetDetectPointList();
                BindDetectPointList(_DetectPointList);
            }
            Label1.Text ="提示信息！";
        }

        private void BindDetectPointList(List<DetectPointTemplateEntity> dplst)
        {
            GridView1.DataSource = dplst;
            GridView1.DataBind();
        }

        private List<DetectPointTemplateEntity> GetDetectPointList() 
        {
            List<DetectPointTemplateEntity> _r = new List<DetectPointTemplateEntity>();
            List<DeviceFunctionTemplateEntity> _CheckFunctionList = GetCheckedFunctionlist();

            foreach (DeviceFunctionTemplateEntity item in _CheckFunctionList)
            {
                if (item == null || item.DetectPointList == null || item.DetectPointList.Count <= 0) { continue; }
                item.DetectPointList.Sort((x, y) => { return x.OrderID.CompareTo(y.OrderID); });
                foreach (DetectPointTemplateEntity ditem in item.DetectPointList)
                {
                    if (ditem != null) { _r.Add(ditem); }
                }
            }
            if (_CreatedDetectPointList == null || _CreatedDetectPointList.Count <= 0) { return _r; }
            foreach (DetectPointTemplateEntity item in _CreatedDetectPointList)
            {
                _r.Add(item);
            }
            return _r;
        }

        private List<DeviceFunctionTemplateEntity> GetCheckedFunctionlist() 
        {
            List<DeviceFunctionTemplateEntity> _r = new List<DeviceFunctionTemplateEntity>();
            DeviceFunctionTemplateEntity _tmpfunction = null;
            foreach (ListItem item in CheckBoxList1.Items)
            {
                if (item.Selected) 
                {
                    _tmpfunction = _DeviceFuncList.Find((x) => { return x.ID.ToString().Equals(item.Value); });
                    if (_tmpfunction != null)
                    {
                        _r.Add(_tmpfunction);
                    }
                }
            }
            return _r;
        }

        private void BindDeviceFunction()
        {
            CheckBoxList1.DataSource = _DeviceFuncList;
            CheckBoxList1.DataTextField = "FunctionName";
            CheckBoxList1.DataValueField = "ID";
            CheckBoxList1.DataBind();
            foreach (ListItem item in CheckBoxList1.Items)
            {
                item.Selected = true;
            }
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {
            _DetectPointList = GetDetectPointList();
            BindDetectPointList(_DetectPointList);
        }
        /// <summary>
        /// 生成
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button2_Click(object sender, EventArgs e)
        {

            List<DeviceFunctionTemplateEntity> _CFunction = GetCreateFunctionList();
            _CFunction.Sort((x, y) => { return x.OrderID.CompareTo(y.OrderID); });
            bool IsHaveAC = CheckIsHaveACFunction(_CFunction);
            #region 检查参数
            double ps = GetCreateParam(TextBox1.Text);
            if (ps < 0 || ps > 1) { Label1.Text = "您输入了一个无效的起始值，起始值取值应为0-100之间"; return; }
            double pi = GetCreateParam(TextBox2.Text);
            if (pi < 0 || pi > 1) { Label1.Text = "您输入了一个无效的间隔值，起始值取值应为1-100之间"; return; }
            double pe = GetCreateParam(TextBox3.Text);
            if (pe < 0 || pe > 1) { Label1.Text = "您输入了一个无效的结束值，起始值取值应为1-100之间"; return; }
             List<String> pf = new List<string>();
            if (IsHaveAC)
            {
                if (string.IsNullOrEmpty(TextBox4.Text))
                {
                    Label1.Text = "您没有输入交流频率选项，将无法对生成交流检定点的频率数据！"; return;
                }
                pf = GetCreatePFParem(TextBox4.Text);
                if (pf == null || pf.Count <= 0)
                {
                    Label1.Text = "您没有输入交流频率选项无效，请参照如下格式：50|Hz,1|kHz,2|mHz"; return;
                }
            }
            bool haveReage = CheckFunctionRange(_CFunction);
            if (!haveReage) 
            {
                Label1.Text = "当前设备某些功能没有输入量程数据，请先填写设备的“量程误差数据”再生成检定点！"; return;
            }

            if (_DeviceCMDList == null || _DeviceCMDList.Count <= 0) 
            {
                Label1.Text = "当前设备没有输入设备指令数据，请先填写设备的“设备指令数据”再生成检定点！"; return;
            }
            bool pzf = CheckBox1.Checked;
            #endregion

            _CreatedDetectPointList.Clear();
            List<DetectPointTemplateEntity> tmplst = new List<DetectPointTemplateEntity>();
            foreach (DeviceFunctionTemplateEntity item in _CFunction)
            {
                if (item.IsAC == 0) //直流
                {
                    tmplst = CreateDCDetectPointList(_RangeList, _DeviceCMDList, item, ps, pi, pe, pzf);
                    foreach (DetectPointTemplateEntity ditem in tmplst)
                    {
                        _CreatedDetectPointList.Add(ditem);
                    }
                }
                else if (item.IsAC == 1) //交流
                {
                    tmplst = CreateACDetectPointList(_RangeList, _DeviceCMDList, item, ps, pi, pe,pf);
                    foreach (DetectPointTemplateEntity ditem in tmplst)
                    {
                        _CreatedDetectPointList.Add(ditem);
                    }
                }
                else if (item.IsAC == 2) //电阻
                {
                    tmplst = CreateOHMDetectPointList(_RangeList, _DeviceCMDList, item, ps, pi, pe);
                    foreach (DetectPointTemplateEntity ditem in tmplst)
                    {
                        _CreatedDetectPointList.Add(ditem);
                    }
                }
            }
            Session["CreatedDetectPointList"] = _CreatedDetectPointList;
            _DeviceFuncList = ToolMethods.GetFunctionsByDeviceTemplateID(_Device.ID);
            _DetectPointList = GetDetectPointList();
            BindDetectPointList(_DetectPointList);
        }

        private List<DetectPointTemplateEntity> CreateDCDetectPointList(List<Device_Permition_DataEntity> rengelst, List<CommandAssembleEntity> cmdlst, DeviceFunctionTemplateEntity fun, double ps, double pi, double pe, bool pzf) 
        {
            List<DetectPointTemplateEntity> _r = new List<DetectPointTemplateEntity>();
            string cmdfun = "";
            string cmdrang = "";
            string cmdres = "";
            string cmdoutcode = "";
            string unit = "";
            double standardvalue = 0;
            int count = 0;
            List<Device_Permition_DataEntity> myranges = rengelst.FindAll((x) => { return x.FunctionCode.Equals(fun.FunctionCode); });

            foreach (Device_Permition_DataEntity item in myranges)
            {
                unit = item.RangeUnitOriginal;
                standardvalue = item.RangeEndOriginal * ps;
                cmdoutcode = GetCMDCode(standardvalue, unit, 0, "Hz");
                cmdrang = item.RangeCode;
                cmdfun = GetCmd(fun.FunctionCode + "_SwitchFuncCmdCode", cmdlst);
                cmdres = GetCmd(fun.FunctionCode + "_SwitchRESCmdCode", cmdlst);
                count = 0;
                while (standardvalue<item.RangeEndOriginal && ps + pi * count <= pe)
                {
                    DetectPointTemplateEntity _t = CreateDCDectectPoint(fun, cmdoutcode, standardvalue, cmdrang, cmdfun, cmdres, item.RangeEndOriginal, unit, idnum);
                    fun.DetectPointList.Add(_t);
                    _r.Add(_t);
                    if (pzf) 
                    {
                        _t = CreateDCDectectPoint(fun, cmdoutcode, (standardvalue * -1), cmdrang, cmdfun, cmdres, item.RangeEndOriginal, unit,idnum);
                        fun.DetectPointList.Add(_t);
                        _r.Add(_t);
                    }
                    count++;
                    standardvalue = item.RangeEndOriginal * (ps + pi * count);
                    cmdoutcode = GetCMDCode(standardvalue, unit, 0, "Hz");
                }
            }
            return _r;
        }

        private List<DetectPointTemplateEntity> CreateACDetectPointList(List<Device_Permition_DataEntity> rengelst, List<CommandAssembleEntity> cmdlst, DeviceFunctionTemplateEntity fun, double ps, double pi, double pe, List<string> pf)
        {
            List<DetectPointTemplateEntity> _r = new List<DetectPointTemplateEntity>();
            string cmdfun = "";
            string cmdrang = "";
            string cmdres = "";
            string cmdoutcode = "";
            string unit = "";
            double standardvalue = 0;
            double fvalue = 0;
            string funit = "";
            int count = 0;
            List<Device_Permition_DataEntity> myranges = rengelst.FindAll((x) => { return x.FunctionCode.Equals(fun.FunctionCode); });

            foreach (Device_Permition_DataEntity item in myranges)
            {
                unit = item.RangeUnitOriginal;
                cmdrang = item.RangeCode;
                cmdfun = GetCmd(fun.FunctionCode + "_SwitchFuncCmdCode", cmdlst);
                cmdres = GetCmd(fun.FunctionCode + "_SwitchRESCmdCode", cmdlst);
                  
                count = 0;
                while (standardvalue < item.RangeEndOriginal && ps + pi * count <= pe)
                {
                    standardvalue = item.RangeEndOriginal * (ps + pi * count);
                    foreach (string fitem in pf)
                    {
                        fvalue = GetFvalue(fitem);
                        funit = GetFUnit(fitem);
                        cmdoutcode = GetCMDCode(standardvalue, unit, fvalue, funit);

                        DetectPointTemplateEntity _t = CreateACDectectPoint(fun, cmdoutcode, standardvalue, cmdrang, cmdfun, cmdres, item.RangeEndOriginal, unit, idnum, fvalue, funit);
                        fun.DetectPointList.Add(_t);
                        _r.Add(_t);
                    }
                    count++;
                }
               
            }
            return _r;
        }

        private List<DetectPointTemplateEntity> CreateOHMDetectPointList(List<Device_Permition_DataEntity> rengelst, List<CommandAssembleEntity> cmdlst, DeviceFunctionTemplateEntity fun, double ps, double pi, double pe)
        {
            List<DetectPointTemplateEntity> _r = new List<DetectPointTemplateEntity>();
            string cmdfun = "";
            string cmdrang = "";
            string cmdres = "";
            string cmdoutcode = "";
            string unit = "";
            double standardvalue = 0;
            int count = 0;
            List<Device_Permition_DataEntity> myranges = rengelst.FindAll((x) => { return x.FunctionCode.Equals(fun.FunctionCode); });

            foreach (Device_Permition_DataEntity item in myranges)
            {
                unit = item.RangeUnitOriginal;
                standardvalue = item.RangeEndOriginal * ps;
                cmdoutcode = GetOHMCMDCode(standardvalue, unit);
                cmdrang = item.RangeCode;
                cmdfun = GetCmd(fun.FunctionCode + "_SwitchFuncCmdCode", cmdlst);
                cmdres = GetCmd(fun.FunctionCode + "_SwitchRESCmdCode", cmdlst);
                count = 0;
                while (standardvalue < item.RangeEndOriginal && ps + pi * count <= pe)
                {
                    DetectPointTemplateEntity _t = CreateDCDectectPoint(fun, cmdoutcode, standardvalue, cmdrang, cmdfun, cmdres, item.RangeEndOriginal, unit, idnum);
                    fun.DetectPointList.Add(_t);
                    _r.Add(_t);
                    
                    count++;
                    standardvalue = item.RangeEndOriginal * (ps + pi * count);
                    cmdoutcode = GetCMDCode(standardvalue, unit, 0, "Hz");
                }
            }
            return _r;
        }

        private double GetFvalue(string val) 
        {
            double _r = 0;
            if (string.IsNullOrEmpty(val)) { return _r; }
            string[] strarrary = val.Split('|');
            try {
                _r = double.Parse(strarrary[0]);
            }
            catch { _r = 0; }
            return _r;
        }

        private string GetFUnit(string val)
        {
            string _r = "Hz";
            if (string.IsNullOrEmpty(val)) { return _r; }
            string[] strarrary = val.Split('|');
            _r = strarrary[1];
            return _r;
        }

        private string GetCmd(string key, List<CommandAssembleEntity> cmdlst) 
        {
            string _r = string.Empty;
            CommandAssembleEntity tmp = cmdlst.Find((x) => { return x.CommandIdentity.Equals(key); });
            if (tmp == null) { return _r; }
            _r = tmp.CommandCode;
            return _r;
        }

        private string GetCMDCode(double standardvalue, string unit, double pl, string plunit) 
        {
            string _r = string.Empty;
            _r = standardvalue.ToString() + unit + "," + pl.ToString() + plunit;
            return _r;
        }

        private string GetOHMCMDCode(double standardvalue, string unit)
        {
            string _r = string.Empty;
            double v = standardvalue;
            if (unit.ToUpper().Equals("KOHM")) 
            {
                v = v * 1000;
            }
            else if (unit.ToUpper().Equals("MOHM")) 
            {
                v = v * 1000 * 1000;
            }
            _r = v.ToString() + "OHM;ZCOMP WIRE4";
            return _r;
        }

        private DetectPointTemplateEntity CreateDCDectectPoint(DeviceFunctionTemplateEntity fun, string cmdcode, double standardvalue, string cmdrange, string cmdfun, string cmdres, double testrange, string unit, int idnum) 
        {
            DetectPointTemplateEntity _r = new DetectPointTemplateEntity();
            _r.DataTable_Action_ = DataTable_Action.Insert;
            _r.ID = idnum;
            _r.DelFlag = false;
            _r.Frequency = 0;
            _r.FrequencyUnit = "Hz";
            _r.FunctionCode = fun.FunctionCode;
            _r.FunctionID = fun.ID;
            _r.H_PerMissibleError = 0;
            _r.ChangePerMissibleError = 0;
            _r.Inputter = UserData.GetUserDate.UserID;
            _r.InputTime = DateTime.Now;
            _r.MissibleErrorSymbol = "±";
            _r.OrderID = GetNewDetectcPointOrderID(fun);
            _r.RoundLen = _Device.RoundLen;
            _r.SetCmdPerfix = _Device.SetCmdPerfix;
            _r.SetCmdSuffix = _Device.SetCmdSuffix;
            _r.CommandCode = cmdcode;
            _r.State = 1;
            _r.StandardValue = standardvalue;
            _r.SwichRangeCmdCode = cmdrange;
            _r.SwitchFuncCmdCode = cmdfun;
            _r.SwitchRESCmdCode = cmdres;
            _r.TestRange = testrange;
            _r.Unit = unit;
            PermitErrorCalculator calculator = new PermitErrorCalculator();
            _r.ValuePerMissibleErrorName = calculator.GetPermitError(_Device, _r);
            idnum--;
            return _r;
        }

        private DetectPointTemplateEntity CreateACDectectPoint(DeviceFunctionTemplateEntity fun, string cmdcode, double standardvalue, string cmdrange, string cmdfun, string cmdres, double testrange, string unit, int idnum, double fvalue, string funit)
        {
            DetectPointTemplateEntity _r = new DetectPointTemplateEntity();
            _r.DataTable_Action_ = DataTable_Action.Insert;
            _r.ID = idnum;
            _r.DelFlag = false;
            _r.Frequency = fvalue;
            _r.FrequencyUnit = funit;
            _r.FunctionCode = fun.FunctionCode;
            _r.FunctionID = fun.ID;
            _r.H_PerMissibleError = 0;
            _r.ChangePerMissibleError = 0;
            _r.Inputter = UserData.GetUserDate.UserID;
            _r.InputTime = DateTime.Now;
            _r.MissibleErrorSymbol = "±";
            _r.OrderID = GetNewDetectcPointOrderID(fun);
            _r.RoundLen = _Device.RoundLen;
            _r.SetCmdPerfix = _Device.SetCmdPerfix;
            _r.SetCmdSuffix = _Device.SetCmdSuffix;
            _r.CommandCode = cmdcode;
            _r.State = 1;
            _r.StandardValue = standardvalue;
            _r.SwichRangeCmdCode = cmdrange;
            _r.SwitchFuncCmdCode = cmdfun;
            _r.SwitchRESCmdCode = cmdres;
            _r.TestRange = testrange;
            _r.Unit = unit;
            PermitErrorCalculator calculator = new PermitErrorCalculator();
            _r.ValuePerMissibleErrorName = calculator.GetPermitError(_Device, _r);
            idnum--;
            return _r;
        }

        private int GetNewDetectcPointOrderID(DeviceFunctionTemplateEntity fun) 
        {
            int _r = 0;
            if (fun.DetectPointList == null || fun.DetectPointList.Count <= 0) { _r = 1; return _r; }
            foreach (DetectPointTemplateEntity item in fun.DetectPointList)
            {
                if (item.OrderID > _r) { _r = item.OrderID; }
            }
            _r = _r + 1;
            return _r;
        }

        private bool CheckFunctionRange(List<DeviceFunctionTemplateEntity> flst) 
        {
            bool _r = false;
            foreach (DeviceFunctionTemplateEntity item in flst)
            {
                if (!IsHavaRangeData(item.FunctionCode)) { break; }
            }
            _r = true;
            return _r;
        }

        private bool IsHavaRangeData(string funcode) 
        {
            bool _r = false;
            _r = _RangeList.Exists((x) => { return x.FunctionCode.Equals(funcode); });
            return _r;
        }

        private bool CheckIsHaveACFunction(List<DeviceFunctionTemplateEntity> flst) 
        {
            bool _r = false;
            foreach (DeviceFunctionTemplateEntity item in flst)
            {
                if (item.IsAC == 1) { _r = true; break; }
            }
            return _r;
        }

        private List<DeviceFunctionTemplateEntity> GetCreateFunctionList()
        {
            List<DeviceFunctionTemplateEntity> _CFunction = null;
            if (RadioButton1.Checked == true)
            {
                _CFunction = GetCheckedFunctionlist();
            }
            else if (RadioButton2.Checked == true)
            {
                _CFunction = _DeviceFuncList;
            }
            return _CFunction;
        }

        private double GetCreateParam(string val) 
        {
            double _r = -1;
            if (string.IsNullOrEmpty(val)) { return _r; }
            try
            {
                _r = double.Parse(val);
                _r = _r / 100;
            }
            catch 
            {
                _r = -1;
            }
            return _r;
        }

        private List<string> GetCreatePFParem(string val) 
        {
            List<string> _r = new List<string>();
            string[] _tmp = val.Split(',');
            if (_tmp == null || _tmp.Length <= 0) { return _r; }
            foreach (string item in _tmp)
            {
                _r.Add(item);
            }
            return _r;
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button3_Click(object sender, EventArgs e)
        {
            if (_CreatedDetectPointList == null || _CreatedDetectPointList.Count <= 0) { return; }
            foreach (DetectPointTemplateEntity item in _CreatedDetectPointList)
            {
                item.ID = 0;
                item.State = 0;
                item.DataTable_Action_ = DataTable_Action.Insert;
                try
                {
                    BusinessFacadeShanliTech_HLD_Business.DetectPointTemplateInsertUpdateDelete(item);
                }
                catch (Exception ex) 
                {
                    AppLogger.Instance.Log.Error("保存快速生成检定点时发生异常！", ex);
                    throw ex;
                }
            }
            Session["CreatedDetectPointList"] = null;
            _CreatedDetectPointList.Clear();
            _DeviceFuncList = ToolMethods.GetFunctionsByDeviceTemplateID(_Device.ID);
            _DetectPointList = GetDetectPointList();
            BindDetectPointList(_DetectPointList);
        }

        protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
        {
            Int32 DataIDX = 0;
            if (e.Row.RowType == DataControlRowType.Header)
            {
                //if (FrameWorkPermission.CheckButtonPermission(PopedomType.Delete))
                //{
                    Button2.Visible = true;
                    //增加check列头全选
                    TableCell cell = new TableCell();
                    cell.Width = Unit.Pixel(5);
                    cell.Text = " <input id='CheckboxAll' value='0' type='checkbox' onclick='SelectAll()'/>";
                    e.Row.Cells.AddAt(0, cell);
                //}

               
            }
            else
            {
                bool IsAdd = false;
                //if (FrameWorkPermission.CheckButtonPermission(PopedomType.Delete))
                //{
                    IsAdd = true;
                    //增加行选项
                    DataIDX = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "ID"));
                    TableCell cell = new TableCell();
                    cell.Width = Unit.Pixel(5);
                    cell.Text = string.Format(" <input name='Checkbox' id='Checkbox' value='{0}' type='checkbox' />", DataIDX);
                    e.Row.Cells.AddAt(0, cell);
                //}
                if (Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "State")) > 0)
                {
                    TableCell SerialCell = null;
                    if (IsAdd)
                        SerialCell = e.Row.Cells[1];
                    else
                        SerialCell = e.Row.Cells[0];
                    SerialCell.BackColor = Color.Chocolate;
                }
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button4_Click(object sender, EventArgs e)
        {
            string Checkbox_Value = (string)Common.sink("Checkbox", MethodType.Post, 2000, 1, DataType.Str);
            string[] Checkbox_Value_Array = Checkbox_Value.Split(',');
            Int32 IDX = 0;
            for (int i = 0; i < Checkbox_Value_Array.Length; i++)
            {
                if (Int32.TryParse(Checkbox_Value_Array[i], out IDX))
                {
                    if (IDX > 0)
                    {
                        DetectPointTemplateEntity et = BusinessFacadeShanliTech_HLD_Business.DetectPointTemplateDisp(IDX);
                        et.DataTable_Action_ = DataTable_Action.Update;
                        et.ID = IDX;
                        et.DelFlag = true;
                        BusinessFacadeShanliTech_HLD_Business.DetectPointTemplateInsertUpdateDelete(et);
                    }
                    else 
                    {
                        DetectPointTemplateEntity t = _CreatedDetectPointList.Find((x) => { return x.ID == IDX; });
                        if (t != null) 
                        {
                            _CreatedDetectPointList.Remove(t);
                        }
                    }
                }
            }
            _DetectPointList = GetDetectPointList();
            BindDetectPointList(_DetectPointList);
        }

        /// <summary>
        /// 清临时数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button5_Click(object sender, EventArgs e)
        {
            Session["CreatedDetectPointList"] = null;
            _DeviceFuncList = ToolMethods.GetFunctionsByDeviceTemplateID(_Device.ID);
            _DetectPointList = GetDetectPointList();
            BindDetectPointList(_DetectPointList);
        }
    }
}
