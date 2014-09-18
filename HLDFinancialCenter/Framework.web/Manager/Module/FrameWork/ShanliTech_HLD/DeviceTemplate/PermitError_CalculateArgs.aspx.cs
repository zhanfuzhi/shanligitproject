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
using FrameWork.Components;
using System.Collections.Generic;
using ShanliTech_HLD_Business.PermitErrorCalculate;
using System.Text.RegularExpressions;

namespace FrameWork.web.Manager.Module.ShanliTech_HLD.DeviceTemplate
{
    public partial class PermitError_CalculateArgs : System.Web.UI.Page
    {
        public Int32 FunctionID = (Int32)Common.sink("FunctionID", MethodType.Get, 10, 0, DataType.Int);
        Int32 IDX = (Int32)Common.sink("IDX", MethodType.Get, 10, 0, DataType.Int);
        string CMD = (string)Common.sink("CMD", MethodType.Get, 10, 0, DataType.Str);

        DeviceFunctionTemplateEntity _Function = new DeviceFunctionTemplateEntity();
        DeviceTemplateEntity _Device = new DeviceTemplateEntity();
        protected void Page_Load(object sender, EventArgs e)
        {

            _Function = BusinessFacadeShanliTech_HLD_Business.DeviceFunctionTemplateDisp(FunctionID);
            _Device = BusinessFacadeShanliTech_HLD_Business.DeviceTemplateDisp(_Function.DeviceID);
            if (!Page.IsPostBack)
            {
                BindDataList(_Function, _Device);
                OnStart(_Function, _Device);
            }
            if (string.IsNullOrEmpty(CMD)) CMD = "New";
        }

        private void OnStart(DeviceFunctionTemplateEntity _Function, DeviceTemplateEntity _Device)
        {
            
            Device_Permition_DataEntity ut = BusinessFacadeShanliTech_HLD_Business.Device_Permition_DataDisp(IDX);
            OnStartData(ut,_Function,_Device);
            HiddenColumnsByPermitType(_Device.PermitType);
            switch (CMD)
            {
                case "New":
                    HideDisp();
                    break;
                case "List":
                    //HideInput();
                    HideDisp();
                    break;
                case "Edit":
                    HideDisp();
                    break;
                case "Delete":
                    #region 删除
                    
                    //ToolMethods.FunctionAndPointDeleteByDeviceID(IDX);  //级联删除相关功能及功能测试点

                    //ut.DataTable_Action_ = DataTable_Action.Update;
                    //ut.DelFlag = true;
                    //if (BusinessFacadeShanliTech_HLD_Business.DeviceInsertUpdateDelete(ut) > 0)
                    //{
                    //    EventMessage.MessageBox(1, "删除成功", string.Format("删除ID:{0}成功!", IDX), Icon_Type.OK, Common.GetHomeBaseUrl("Default.aspx"));
                    //}
                    //else
                    //{
                    //    EventMessage.MessageBox(1, "删除失败", string.Format("删除ID:{0}失败!", IDX), Icon_Type.Error, Common.GetHomeBaseUrl("Default.aspx"));
                    //}

                    #endregion
                    break;
            }
            HiddenFreqByFuncCode();
        }

        private void HiddenColumnsByPermitType(int _PermitType)
        {
            if (_PermitType == 1)   //ConstValue
            {
                ArgText_Label.Text = "数值";
                ConstValue_TD.Visible = true;
                Ratio1_TD.Visible = false;
                Precision_TD.Visible=false;
            }
            else if (_PermitType == 2)  //满度
            {
                ArgText_Label.Text = "满度值系数";
                ConstValue_TD.Visible = false;
                Ratio1_TD.Visible = true;
                Precision_TD.Visible = false;
            }
            else if (_PermitType == 3)  //字数
            {
                ArgText_Label.Text = "字数";
                ConstValue_TD.Visible = false;
                Ratio1_TD.Visible = false;
                Precision_TD.Visible = true;
            }
            else    //其他
            {
                ArgText_Label.Text = "数值";
                ConstValue_TD.Visible = true;
                Ratio1_TD.Visible = false;
                Precision_TD.Visible = false;
            }
            
        }
        private void HiddenFreqByFuncCode()
        {
            if (_Function.IsAC==1)
            {
                FreqStart_Text_TD.Visible = true;
                FreqStart_Input_TD.Visible = true;
                FreqEnd_Text_TD.Visible = true;
                FreqEnd_Input_TD.Visible = true;
            }
            else
            {
                FreqStart_Text_TD.Visible = false;
                FreqStart_Input_TD.Visible = false;
                FreqEnd_Text_TD.Visible = false;
                FreqEnd_Input_TD.Visible = false;
            }
        }
        private void HideInput()
        {
            Unit_Input.Visible = false;   //默认显示单位的输入框
            MinGraduation_Input.Visible = false;
            MinUnit_Input.Visible = false;
        }
        private void HideDisp()
        {
            Unit_Disp.Visible = false;
            MinGraduation_Disp.Visible = false;
            MinUnit_Disp.Visible = false;
        }
        private void OnStartData(Device_Permition_DataEntity ut, DeviceFunctionTemplateEntity _Function, DeviceTemplateEntity _Device)
        {
            //FuncCode_Disp.Text = _Function.FunctionCode;
            //FuncRange_Disp.Text = _Function.TestRange;
            Unit_Disp.Text = Unit_Input.Text = ut.RangeUnitOriginal;
            Range_Input.Text = ut.RangeEndOriginal.ToString();
            RangeCode_Input.Text = ut.RangeCode;
            RangeFull_Input.Text = ut.RangeFull.ToString();
            FrequencyStart_Input.Text = ut.FreqStartOriginal.ToString();
            FrequencyEnd_Input.Text = ut.FreqEndOriginal.ToString();
            FreqStartUnit_DropDown.SelectedValue = ut.FreqStartUnitOriginal;
            FreqEndUnit_DropDown.SelectedValue = ut.FreqEndUnitOriginal;
            Ratio0_Input.Text = (100 * ut.Ratio0).ToString();
            Ratio1_Input.Text = (100 * ut.Ratio1).ToString();
            ConstValue_Input.Text = ut.ConstValueOriginal.ToString();
            ConstValueUnit_Input.Text = ut.ConstValueUnitOriginal;
            MinGraduation_Input.Text = MinGraduation_Disp.Text = ut.MinimumGraduationOriginal.ToString();
            MinUnit_Disp.Text = MinUnit_Input.Text = ut.MinimumUnitOriginal;
            PrecisionCount_Input.Text = ut.PrecisionCount.ToString();
        }

        /// <summary>
        /// 绑定数据
        /// </summary>
        private void BindDataList(DeviceFunctionTemplateEntity _Function, DeviceTemplateEntity _Device)
        {
            QueryParam qp = new QueryParam();
            qp.Where = string.Format("Where DeviceNum = '{0}' And DeviceModel = '{1}' And FunctionCode = '{2}'", _Device.DeviceNum, _Device.DeviceModel, _Function.FunctionCode);
            qp.PageIndex = AspNetPager1.CurrentPageIndex;
            qp.PageSize = AspNetPager1.PageSize;
            qp.Orderfld = Orderfld;
            qp.OrderType = OrderType;
            int RecordCount = 0;
            List<Device_Permition_DataEntity> lst = BusinessFacadeShanliTech_HLD_Business.Device_Permition_DataList(qp, out RecordCount);
            GridView1.DataSource = lst;
            GridView1.DataBind();
            this.AspNetPager1.RecordCount = RecordCount;
        }

        /// <summary>
        /// 点击分页事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            
            BindDataList(_Function, _Device);
        }
        /// <summary>
        /// 查询条件
        /// </summary>
        private string SearchTerms
        {
            get
            {
                if (ViewState["SearchTerms"] == null)
                    ViewState["SearchTerms"] = " Where 1=1 ";
                return (string)ViewState["SearchTerms"];
            }
            set { ViewState["SearchTerms"] = value; }
        }
        #region "排序"
        protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
        {
            if (Orderfld == e.SortExpression)
            {
                if (OrderType == 0)
                {
                    OrderType = 1;
                }
                else
                {
                    OrderType = 0;
                }
            }
            Orderfld = e.SortExpression;
            //BindDataList();
        }

        /// <summary>
        /// 排序字段
        /// </summary>
        public string Orderfld
        {
            get
            {
                if (ViewState["sortOrderfld"] == null)

                    ViewState["sortOrderfld"] = "ID";

                return (string)ViewState["sortOrderfld"];
            }
            set
            {
                ViewState["sortOrderfld"] = value;
            }
        }

        /// <summary>
        /// 排序类型 1:降序 0:升序
        /// </summary>
        public int OrderType
        {

            get
            {

                if (ViewState["sortOrderType"] == null)
                    ViewState["sortOrderType"] = 1;

                return (int)ViewState["sortOrderType"];


            }

            set { ViewState["sortOrderType"] = value; }

        }
        /// <summary>
        /// 排序事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
        {
            Int32 DataIDX = 0;
            TableCell cell=null;
            if (e.Row.RowType == DataControlRowType.Header)
            {
                #region 多选框

                cell = new TableCell();
                cell.Width = Unit.Pixel(5);
                cell.Text = " <input id='CheckboxAll' value='0' type='checkbox' onclick='SelectAll()'/>";
                e.Row.Cells.AddAt(0, cell);

                #endregion

                foreach (TableCell var in e.Row.Cells)
                {
                    if (var.Controls.Count > 0 && var.Controls[0] is LinkButton)
                    {
                        string Colume = ((LinkButton)var.Controls[0]).CommandArgument;
                        if (Colume == Orderfld)
                        {

                            LinkButton l = (LinkButton)var.Controls[0];
                            l.Text += string.Format("<img src='{0}' border='0'>", (OrderType == 0) ? Page.ResolveUrl("~/Manager/images/sort_asc.gif") : Page.ResolveUrl("~/Manager/images/sort_desc.gif"));
                        }
                    }
                }

                //增加频率列头
                if (_Function.IsAC==1)
                {
                    cell = new TableCell();
                    //cell.Width = Unit.Pixel(15);
                    cell.Text = "频率";
                    e.Row.Cells.AddAt(4, cell);
                }
                //公式相关参数列
                int colCount = e.Row.Cells.Count;
                cell = new TableCell();
                //cell.Width = Unit.Pixel(15);
                cell.Text = "1年";
                e.Row.Cells.AddAt(colCount - 1, cell);

            }
            else
            {
                #region 多选框
                
                DataIDX = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "ID"));
                cell = new TableCell();
                cell.Width = Unit.Pixel(5);
                cell.Text = string.Format(" <input name='Checkbox' id='Checkbox' value='{0}' type='checkbox' />", DataIDX);
                e.Row.Cells.AddAt(0, cell);

                #endregion

                //增加频率列
                if (_Function.IsAC==1)
                {

                    double FreqStart = Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "FreqStartOriginal"));
                    double FreqEnd = Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "FreqEndOriginal"));
                    string FreqStartUnit = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "FreqStartUnitOriginal"));
                    string FreqEndUnit = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "FreqEndUnitOriginal"));

                    cell = new TableCell();
                    //cell.Width = Unit.Pixel(15);
                    cell.Text = string.Format("{0}{1} - {2}{3}", FreqStart, FreqStartUnit, FreqEnd, FreqEndUnit);
                    e.Row.Cells.AddAt(4, cell);
                }

                double ratio0 = Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "Ratio0"));
                string text = string.Empty;
                if (_Device.PermitType == 1)
                {
                    double constValue = Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "ConstValueOriginal"));
                    string constValueUnit = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "ConstValueUnitOriginal"));
                    text = string.Format("±（{0}% + {1}{2}）", ratio0 * 100, constValue, constValueUnit);
                }
                else if (_Device.PermitType == 2)
                {
                    double ratio1 = Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "Ratio1"));
                    text = string.Format("±（{0}% + {1}%）", ratio0 * 100, ratio1 * 100);
                }
                else if (_Device.PermitType == 3)
                {
                    int precisionCount = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "PrecisionCount"));
                    text = string.Format("±（{0}% + {1}）", ratio0 * 100, precisionCount);
                }

                int colCount = e.Row.Cells.Count;
                cell = new TableCell();
                //cell.Width = Unit.Pixel(15);
                cell.Text = text;
                e.Row.Cells.AddAt(colCount-1, cell);
            }
        }
        #endregion

        //保存
        protected void Button1_Click(object sender, EventArgs e)
        {
            string UnitOrig_Value = ((string)Common.sink(Unit_Input.UniqueID, MethodType.Post, 50, 0, DataType.Str)).Trim();
            double RangeStart_Value = 0f;   // Convert.ToDouble(Common.sink(RangeStart_Input.UniqueID, MethodType.Post, 53, 0, DataType.Double));
            double RangeEndOrig_Value = Convert.ToDouble(Common.sink(Range_Input.UniqueID, MethodType.Post, 53, 0, DataType.Double));
            string RangeFull_Value = ((string)Common.sink(RangeFull_Input.UniqueID, MethodType.Post, 50, 0, DataType.Str)).Trim();
            double FrequencyStartOrig_Value = Convert.ToDouble(Common.sink(FrequencyStart_Input.UniqueID, MethodType.Post, 53, 0, DataType.Double));
            string FreqStartUnitOrig_Value = FreqStartUnit_DropDown.SelectedValue;
            double FrequencyEndOrig_Value = Convert.ToDouble(Common.sink(FrequencyEnd_Input.UniqueID, MethodType.Post, 53, 0, DataType.Double));
            string FreqEndUnitOrig_Value = FreqEndUnit_DropDown.SelectedValue; //(string)Common.sink(FrequencyUnit_Input.UniqueID, MethodType.Post, 50, 0, DataType.Str);
            double Ratio0_Value = Convert.ToDouble(Common.sink(Ratio0_Input.UniqueID, MethodType.Post, 53, 0, DataType.Double));
            //值是按百分数填入
            double Ratio1_Value = Convert.ToDouble(Common.sink(Ratio1_Input.UniqueID, MethodType.Post, 53, 0, DataType.Double));
            //值是按百分数填入
            double ConstValueOrig_Value = Convert.ToDouble(Common.sink(ConstValue_Input.UniqueID, MethodType.Post, 53, 0, DataType.Double));
            string ConstValueUnitOrig_Value = (string)Common.sink(ConstValueUnit_Input.UniqueID, MethodType.Post, 50, 0, DataType.Str);
            string RangeCode_Value = ((string)Common.sink(RangeCode_Input.UniqueID, MethodType.Post, 50, 0, DataType.Str)).Trim();
            double MinimumGraduationOrig_Value = Convert.ToDouble(Common.sink(MinGraduation_Input.UniqueID, MethodType.Post, 53, 0, DataType.Double));
            string MinimumUnitOrig_Value = (string)Common.sink(MinUnit_Input.UniqueID, MethodType.Post, 50, 0, DataType.Str);
            int PrecisionCount_Value = (int)Common.sink(PrecisionCount_Input.UniqueID, MethodType.Post, 10, 0, DataType.Int);

            //单位微伏等由u替换µ
            UnitOrig_Value = UnitOrig_Value.Replace("u", "µ");

            if (string.IsNullOrEmpty(UnitOrig_Value))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "alert1", "<script>alert('请填写单位字段！');</script>");
                return;
            }
            string ReverseUnit = string.Empty;
            double RangeEnd_Value = PermitErrorCalculator.ReverseValueByFuncCode(_Function.FunctionCode, RangeEndOrig_Value, UnitOrig_Value, ref ReverseUnit);
            RangeFull_Value = (string.IsNullOrEmpty(RangeFull_Value) ? RangeEndOrig_Value.ToString() : RangeFull_Value);

            ConstValueUnitOrig_Value = ConstValueUnitOrig_Value.Replace("u", "µ");
            double ConstValue_Value = PermitErrorCalculator.ReverseValueByFuncCode(_Function.FunctionCode, ConstValueOrig_Value, ConstValueUnitOrig_Value);
            MinimumUnitOrig_Value = MinimumUnitOrig_Value.Replace("u", "µ");
            double MinimumGraduation_Value = PermitErrorCalculator.ReverseValueByFuncCode(_Function.FunctionCode, MinimumGraduationOrig_Value, MinimumUnitOrig_Value);
            double FrequencyStart_Value = CommonUtils.ConvertHertz(FrequencyStartOrig_Value, FreqStartUnitOrig_Value, "Hz");
            double FrequencyEnd_Value = CommonUtils.ConvertHertz(FrequencyEndOrig_Value, FreqEndUnitOrig_Value, "Hz");

            Device_Permition_DataEntity ut = BusinessFacadeShanliTech_HLD_Business.Device_Permition_DataDisp(IDX);
            ut.DeviceNum = _Device.DeviceNum;
            ut.DeviceModel = _Device.DeviceModel;
            ut.FunctionCode = _Function.FunctionCode;
            ut.RangeStart = RangeStart_Value;
            ut.RangeEnd = RangeEnd_Value;
            ut.RangeUnit = ReverseUnit;
            ut.RangeCode = RangeCode_Value;
            ut.FrequencyStart = FrequencyStart_Value;
            ut.FrequencyEnd = FrequencyEnd_Value;
            ut.FrequencyUnit = "Hz";
            ut.Ratio0 = Ratio0_Value/100;
            ut.Ratio1 = Ratio1_Value/100;
            ut.ConstValue = ConstValue_Value;
            ut.RangeFull = RangeFull_Value;
            ut.MinimumGraduation = MinimumGraduation_Value;
            ut.PrecisionCount = PrecisionCount_Value;

            ut.RangeUnitOriginal = UnitOrig_Value;
            ut.RangeEndOriginal = RangeEndOrig_Value;
            ut.FreqStartOriginal = FrequencyStartOrig_Value;
            ut.FreqStartUnitOriginal = FreqStartUnitOrig_Value;
            ut.FreqEndOriginal = FrequencyEndOrig_Value;
            ut.FreqEndUnitOriginal = FreqEndUnitOrig_Value;
            ut.MinimumGraduationOriginal = MinimumGraduationOrig_Value;
            ut.MinimumUnitOriginal = MinimumUnitOrig_Value;
            ut.ConstValueOriginal = ConstValueOrig_Value;
            ut.ConstValueUnitOriginal = ConstValueUnitOrig_Value;

            if (CMD == "New")
            {
                ut.DataTable_Action_ = DataTable_Action.Insert;
            }
            else if (CMD == "Edit")
            {
                ut.DataTable_Action_ = DataTable_Action.Update;
            }
            else
            {
                EventMessage.MessageBox(2, "不存在操作字符串!", "不存在操作字符串!", Icon_Type.Error, Common.GetHomeBaseUrl("PermitError_CalculateArgs.aspx?CMD=New&FunctionID=" + FunctionID));
            }
            Int32 rInt = BusinessFacadeShanliTech_HLD_Business.Device_Permition_DataInsertUpdateDelete(ut);
            if (rInt > 0)
            {
                string OpTxt = string.Format("增加计算设备检定点允许误差的数据字典成功!(ID:{0})", rInt);
                if (ut.DataTable_Action_ == DataTable_Action.Update)
                    OpTxt = string.Format("修改计算设备检定点允许误差的数据字典成功!(ID:{0})", IDX);
                EventMessage.MessageBox(1, "操作成功", OpTxt, Icon_Type.OK, Common.GetHomeBaseUrl("PermitError_CalculateArgs.aspx?CMD=New&FunctionID=" + FunctionID));
            }
            else if (rInt == -2)
            {
                EventMessage.MessageBox(1, "操作失败", "操作失败,存在相同的键值(用户名/数据)!", Icon_Type.Alert, Common.GetHomeBaseUrl("PermitError_CalculateArgs.aspx?CMD=New&FunctionID=" + FunctionID));
            }
            else
            {
                EventMessage.MessageBox(1, "操作失败", string.Format("操作失败,返回值:{0}!", rInt), Icon_Type.Error, Common.GetHomeBaseUrl("PermitError_CalculateArgs.aspx?CMD=New&FunctionID=" + FunctionID));
            }
        }

        private string FormatRangeFullValue(string _RangeFullValue)
        {
            return string.Empty;
            //string digits = _RangeFull_Value.Replace(".", "");
            //Match matches = Regex.Match(digits, "0+$");
            //if (matches.Success)
            //{
            //    digits = matches.ToString();
            //}
            //else
            //{
            //    digits = string.Empty;
            //}
            //RangeFull_Value = PermitErrorCalculator.ReverseValueByFuncCode(_Function.FunctionCode, Convert.ToDouble(RangeFull_Value), Unit_Value).ToString();
            //matches=Regex.Match(
        }
        //新增
        protected void Button2_Click(object sender, EventArgs e)
        {
            Unit_Input.Text = string.Empty;
            MinGraduation_Input.Text = string.Empty;
            MinUnit_Input.Text = string.Empty;
            Range_Input.Text = string.Empty;
            RangeFull_Input.Text = string.Empty;
            FrequencyStart_Input.Text = string.Empty;
            FrequencyEnd_Input.Text = string.Empty;
            Ratio0_Input.Text = string.Empty;
            ConstValue_Input.Text = string.Empty;
            ConstValueUnit_Input.Text = string.Empty;
            Ratio1_Input.Text = string.Empty;
            PrecisionCount_Input.Text = string.Empty;
            CMD = "New";
        }
        //删除
        protected void Button3_Click(object sender, EventArgs e)
        {
            string Checkbox_Value = (string)Common.sink("Checkbox", MethodType.Post, 2000, 1, DataType.Str);
            string[] Checkbox_Value_Array = Checkbox_Value.Split(',');
            Int32 IDX = 0;
            for (int i = 0; i < Checkbox_Value_Array.Length; i++)
            {
                if (Int32.TryParse(Checkbox_Value_Array[i], out IDX))
                {
                    Device_Permition_DataEntity et = new Device_Permition_DataEntity();
                    et.DataTable_Action_ = DataTable_Action.Delete;
                    et.ID = IDX;
                    BusinessFacadeShanliTech_HLD_Business.Device_Permition_DataInsertUpdateDelete(et);
                }
            }

            EventMessage.MessageBox(1, "批量删除成功", string.Format("批量删除({0})成功!", Checkbox_Value), Icon_Type.OK, Common.GetHomeBaseUrl("PermitError_CalculateArgs.aspx?CMD=New&FunctionID=" + FunctionID));
        }
    }
}
