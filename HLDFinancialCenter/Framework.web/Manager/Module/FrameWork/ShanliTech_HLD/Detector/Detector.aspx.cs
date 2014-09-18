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
using ShanliTech_HLD_Business;
using ShanliTech_HLD_Business.Components;
using FrameWork.Components;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using ShanliTech_HLD_Business.DetectComponents;
using System.Threading;
using ShanliTech.LogLib;

namespace FrameWork.web.Manager.Module.ShanliTech_HLD.Detector
{
    public partial class Detector : System.Web.UI.Page,IAbleCallJS
    {
        DetectManager _myDetectManager = null;
        Dictionary<int, DetectResult> _DetectRecordState = null;
        Int32 IDX = (Int32)Common.sink("IDX", MethodType.Get, 10, 0, DataType.Int);
        string CMD = (string)Common.sink("CMD", MethodType.Get, 10, 0, DataType.Str);
        Int32 FID = (Int32)Common.sink("FID", MethodType.Get, 10, 0, DataType.Int);
        string VAL = (string)Common.sink("VAL", MethodType.Get, 100, 0, DataType.Str);

        protected void Page_Load(object sender, EventArgs e)
        {
            //AppLogger.Instance.Log.Info(Request.RawUrl);
            if (Session["DetectManager"] != null)
            {
                _myDetectManager = (DetectManager)Session["DetectManager"];
            }
            if (!IsPostBack)
            {
                InitDeviceList(); //初始化标准设备和被检设备的下拉列表。
            }
            if ("Fun".Equals(CMD) && FID > 0) 
            {
                DeviceFunctionEntity tmp = _myDetectManager.DetectFunctionList.Find((x) => { return x.ID == FID; });
                //if (tmp != null) { _myDetectManager.CurrentShowDetectPointFunction = tmp; }
                if (tmp != null) { _myDetectManager.DeviceDetectAdapter.ChangeCurrentDetectFunction(tmp); }
            }

            if (!IsPostBack)
            {
                InitControls();
            }
            #region 执行JS推动检定流程
            if (_myDetectManager != null && _myDetectManager.State == ExcuteState.Started )
            {
                string js = _myDetectManager.DoDetect();
                
                if (string.IsNullOrEmpty(js)) { js = "ERROR"; }
                if ("TheEnd".Equals(js)) //检定结束时处理
                { 
                    //Session["DetectManager"] = null; 
                    js = "alert('检定结束!');";
                }
                else if (js.StartsWith("DetectEnd")) 
                {
                    _myDetectManager.Stop();
                    js = js.Replace("DetectEnd", "");
                    if(js.Trim().Equals(string.Empty))
                        js = "window.reload();";
                }
                else if ("ERROR".Equals(js)) 
                {
                    js = "alert('无效指令，请与管理员联系!');";
                }
                AppLogger.Instance.Log.Info("=====>JS:" + js);
                if (js.IndexOf("<script") < 0)
                {
                    js = string.Format("<script>{0}</script>", js);
                }
                ClientScript.RegisterStartupScript(ClientScript.GetType(), "", js);
            }
            else if (_myDetectManager != null && _myDetectManager.State == ExcuteState.Stoped )
            {
                string js = _myDetectManager.DoDetect();
                
                if (string.IsNullOrEmpty(js)) { js = "ERROR"; }
                if ("TheEnd".Equals(js)) //检定结束时处理
                { 
                    //Session["DetectManager"] = null; 
                    js = "alert('检定结束!');";
                }
                else if ("ERROR".Equals(js))
                {
                    js = "alert('无效指令，请与管理员联系!');";
                }
                else 
                {
                    js = "";
                }
                AppLogger.Instance.Log.Info("=====>JS:"+js);
                if (!string.IsNullOrEmpty(js))
                {
                    if (js.IndexOf("<script") < 0)
                    {
                        js = string.Format("<script>{0}</script>", js);
                    }
                    ClientScript.RegisterStartupScript(ClientScript.GetType(), "", js);
                }
            }
            #endregion
        }

        #region 初始化操作方法
        private void InitControls() 
        {
            InistDeviceSelectedValue();
            InitDetectFunctionSilde();
            IniDetectFunctionDetectPointList();
            InitDetectWorkType();
            InitControlButtonState();
        }

        private void InitDetectFunctionSilde()
        {
            if (_myDetectManager == null) { return; }
            List<ProgressBaritem> itmlst =  _myDetectManager.GetProgressBarItemList();
            if (itmlst == null || itmlst.Count <= 0) { return; }
            Repeater_funtion.DataSource = itmlst;
            Repeater_funtion.DataBind();
        }

        private void InistDeviceSelectedValue() 
        {
            if (_myDetectManager == null) { return; }
            StandardDevice_DropDown.SelectedIndex = StandardDevice_DropDown.Items.IndexOf(StandardDevice_DropDown.Items.FindByValue(_myDetectManager.StandardDevice.ID.ToString()));
            DetectDevice_DropDown.SelectedIndex = DetectDevice_DropDown.Items.IndexOf(DetectDevice_DropDown.Items.FindByValue(_myDetectManager.DetectDevice.ID.ToString()+"|"+_myDetectManager.DetectDevice.Department_DeviceID.ToString()));
        }

        private void InitDeviceList()
        {

            ToolMethods.InitDropDownDeviceByType(StandardDevice_DropDown, "请选择标准设备", "DEVICE_DETECT_STANDARD");
            if (_myDetectManager != null)
            {
                InitDetectDeviceDropDownList(_myDetectManager.StandardDevice.DeviceCategoryID);
            }
        }

        private void IniDetectFunctionDetectPointList()
        {
            if (_myDetectManager == null) { return; }
            List<DetectResultDataItem> elst = null;
            List<DetectResultDataItem> plst = null;
            if ("DEVICE_CATE_P".Equals(_myDetectManager.DeviceCategory)||"DEVICE_CATE_AP".Equals(_myDetectManager.DeviceCategory)) 
            {
                plst = _myDetectManager.GetDetectResultList();
                GridView2.Visible = false;
                GridView1.Visible = true;
                GridView1.DataSource = plst;
                GridView1.DataBind();
            }
            else if ("DEVICE_CATE_E".Equals(_myDetectManager.DeviceCategory)) 
            {
                elst = _myDetectManager.GetDetectResultList();
                //
                //foreach (DetectResultDataItem item in elst)
                //{
                //    string first = ToolMethods.GetFormatScienceHTML(item.ValuePerMissibleError);
                //    string second = ToolMethods.GetFormatScienceHTMLAndSign(item.TestedPerissibleError);
                //}
                //
                GridView1.Visible = false;
                GridView2.Visible = true ;
                GridView2.DataSource = elst;
                GridView2.DataBind();
            }
            
        }

        private void InitDetectWorkType() 
        {
            if (_myDetectManager == null)
            {
                Rbtn_Auto.Enabled = false;
                Rbtn_Manual.Enabled = false;
                return;
            }

            if (_myDetectManager.DetectWorkType == DetectWorkType.Auto)
            {
                Rbtn_Auto.Enabled = true;
                Rbtn_Manual.Enabled = true;
                Rbtn_Auto.Checked = true;
                Rbtn_Manual.Checked = false;
            }
            else
            {
                Rbtn_Auto.Enabled = true;
                Rbtn_Manual.Enabled = true;
                Rbtn_Auto.Checked = false;
                Rbtn_Manual.Checked = true;

            }
        }

        private void InitControlButtonState() 
        {
            if (_myDetectManager == null)
            {
                SetDetectBtnDisable();
            }
            else if (_myDetectManager.DetectFunctionList == null || _myDetectManager.DetectFunctionList.Count <= 0)
            {
                SetDetectBtnDisable();
                Page.ClientScript.RegisterStartupScript(typeof(string), "alert1", "<script>alert('没有可检定功能数据！');</script>");
            }
            else if (_myDetectManager.GetDetectResultList() == null || _myDetectManager.GetDetectResultList().Count <= 0)
            {
                SetDetectBtnDisable();
                Page.ClientScript.RegisterStartupScript(typeof(string), "alert1", "<script>alert('没有可检定点数据！');</script>");
            }
            else
            {
                switch (_myDetectManager.State)
                {
                    case ExcuteState.Default:
                        {
                            ibtn_start.Enabled = true;
                            ibtn_start.ImageUrl = "~/Manager/images/PageIcon/btnstart.png";
                            Ibtn_Pause.Enabled = false;
                            Ibtn_Pause.ImageUrl = "~/Manager/images/PageIcon/Pause_d.png";
                            ibtn_Stop.Enabled = false;
                            ibtn_Stop.ImageUrl = "~/Manager/images/PageIcon/stop_d.png";
                            break;
                        }
                    case ExcuteState.Started:
                        {
                            ibtn_start.Enabled = false;
                            ibtn_start.ImageUrl = "~/Manager/images/PageIcon/btnstart_d.png";
                            Ibtn_Pause.Enabled = true;
                            Ibtn_Pause.ImageUrl = "~/Manager/images/PageIcon/Pause.png";
                            ibtn_Stop.Enabled = true;
                            ibtn_Stop.ImageUrl = "~/Manager/images/PageIcon/stop.png";
                            break;
                        }
                    case ExcuteState.Paused:
                        {
                            ibtn_start.Enabled = true;
                            ibtn_start.ImageUrl = "~/Manager/images/PageIcon/btnstart.png";
                            Ibtn_Pause.Enabled = false;
                            Ibtn_Pause.ImageUrl = "~/Manager/images/PageIcon/Pause_d.png";
                            ibtn_Stop.Enabled = true;
                            ibtn_Stop.ImageUrl = "~/Manager/images/PageIcon/stop.png";
                            break;
                        }
                    case ExcuteState.Stoped:
                        {
                            ibtn_start.Enabled = true;
                            ibtn_start.ImageUrl = "~/Manager/images/PageIcon/btnstart.png";
                            Ibtn_Pause.Enabled = false;
                            Ibtn_Pause.ImageUrl = "~/Manager/images/PageIcon/Pause_d.png";
                            ibtn_Stop.Enabled = false;
                            ibtn_Stop.ImageUrl = "~/Manager/images/PageIcon/stop_d.png";
                            break;
                        }
                }
            }
        }

        private void SetDetectBtnDisable()
        {
            ibtn_start.Enabled = false;
            ibtn_start.ImageUrl = "~/Manager/images/PageIcon/btnstart_d.png";
            Ibtn_Pause.Enabled = false;
            Ibtn_Pause.ImageUrl = "~/Manager/images/PageIcon/Pause_d.png";
            ibtn_Stop.Enabled = false;
            ibtn_Stop.ImageUrl = "~/Manager/images/PageIcon/stop_d.png";
        }

        private int GetStandardDeviceCategoryID()
        {
            string sv = StandardDevice_DropDown.SelectedValue;
            int svalue = 0;
            int DeviceCategoryID = 0;
            try
            {
                svalue = Convert.ToInt32(sv);
            }
            catch { svalue = 0; }
            if (svalue <= 0) { return DeviceCategoryID; }
            DeviceEntity tmpdevice = BusinessFacadeShanliTech_HLD_Business.DeviceDisp(svalue);
            if (tmpdevice != null) { DeviceCategoryID = tmpdevice.DeviceCategoryID; }
            if (DeviceCategoryID <= 0) { DeviceCategoryID = 0; }
            return DeviceCategoryID;
        }

        private void InitDetectDeviceDropDownList(int DeviceCategoryID)
        {

            ToolMethods.InitDropDownDeviceByType(DetectDevice_DropDown, "请选择被检设备", "DEVICE_DETECT_DETECTED", DeviceCategoryID);
        }

        #endregion

        public string GetProgressBarImg(string state,string type) 
        {
            string _r = "";
            if (string.IsNullOrEmpty(state) || string.IsNullOrEmpty(type)) { return _r; }

            if ("Start".Equals(type) || "End".Equals(type)) 
           {
               _r = "../../../Images/PageIcon/be.png";
           }
            else if ("Function".Equals(type)) 
           {
               if ("Standard".Equals(state)) 
               {
                     _r = "../../../Images/PageIcon/fun.png";
               }
               else if ("Current".Equals(state) || "Detected".Equals(state)) 
               {
                   _r = "../../../Images/PageIcon/fun_ed.png";
               }
               else if ("DetectFailed".Equals(state))
               {
                   _r = "../../../Images/PageIcon/error.png";
               }
           }
            else if ("DetectPoint".Equals(type))
           {
               if ("Standard".Equals(state))
               {
                   _r = "../../../Images/PageIcon/p.png";
               }
               else if ("Current".Equals(state))
               {
                   _r = "../../../Images/PageIcon/pc.png";
               }
               else if ("Detected".Equals(state))
               {
                   _r = "../../../Images/PageIcon/p_ed.png";
               }
               else if ("DetectFailed".Equals(state))
               {
                   _r = "../../../Images/PageIcon/error.png";
               }
           }
         
           return _r;
 
        }

        public string GetProgressBarImgNavUrl(string ID, string type) 
        {
            string _r = "#";
            if (string.IsNullOrEmpty(ID) || string.IsNullOrEmpty(type)) { return _r; }
            if ("Function".Equals(type)) 
            {
                _r = "./Detector.aspx?ID=0&CMD=Fun&FID=" + ID;
            }
            return _r;
        }

        private static string RemoveLastStr(string str)
        {
            int last = str.LastIndexOf(",");
            int len = str.Length;
            if (last == len - 1)
            {
                str = str.Substring(0, last);
            }
            return str;
        }

        #region 数据表格
        protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
        {
            #region OLD
            //if (e.Row.RowType == DataControlRowType.Header)
            //{
            //    TableCell cell = new TableCell();
            //    cell.Width = Unit.Pixel(20);
            //    cell.Text = "状态";
            //    e.Row.Cells.AddAt(0, cell);
            //}
            //else
            //{
            //    int DataIDX = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "ID"));

            //    TableCell cell = new TableCell();
            //    cell.Width = Unit.Pixel(20);
            //    string text = string.Empty;
            //    if(_DetectRecordState==null)
            //        _DetectRecordState = ((Dictionary<int, DetectResult>)Session["DetectRecordState"]);
            //    if (_DetectRecordState.ContainsKey(DataIDX))
            //    {
            //        DetectResult dr = _DetectRecordState[DataIDX];
            //        if (dr == DetectResult.None)
            //            text = "未检测";
            //        else if (dr == DetectResult.Start)
            //            text = "开始";
            //        else if (dr == DetectResult.Ing)
            //            text = "检测中";
            //        else if (dr == DetectResult.Waiting)
            //            text = "等待";
            //        else if (dr == DetectResult.Complete)
            //            text = "完成";
            //        else if (dr == DetectResult.Error)
            //            text = "错误";
            //    }
            //    else
            //    {
            //        _DetectRecordState.Add(DataIDX, DetectResult.None);
            //        text = "未检测";
            //    }
            //    cell.Text = text;
            //    e.Row.Cells.AddAt(0, cell);
            //}
            #endregion

            #region 表头绘制
            if (e.Row.RowType == DataControlRowType.Header)
            {
                //总表头                
                TableCellCollection tcHeader = e.Row.Cells;                
                tcHeader.Clear();
                
                //标准压力
                tcHeader.Add(new TableHeaderCell());
                tcHeader[0].Attributes.Add("rowspan", "2");
                tcHeader[0].Text = "标准压力";

                //第一行表头
                tcHeader.Add(new TableHeaderCell());
                //tcHeader[0].Attributes.Add("bgcolor", "DarkSeaBlue");
                tcHeader[1].Attributes.Add("colspan", "4");
                tcHeader[1].Text = "被检表轻敲后的示值";

                tcHeader.Add(new TableHeaderCell());
                //tcHeader[0].Attributes.Add("bgcolor", "DarkSeaBlue");
                tcHeader[2].Attributes.Add("colspan", "4");
                tcHeader[2].Text = "轻敲指针变动量";

                tcHeader.Add(new TableHeaderCell());
                //tcHeader[0].Attributes.Add("bgcolor", "DarkSeaBlue");
                tcHeader[3].Attributes.Add("colspan", "3");
                tcHeader[3].Text = "回程误差";

                tcHeader.Add(new TableHeaderCell());
                tcHeader[4].Attributes.Add("rowspan", "2");
                tcHeader[4].Text = "操作</th></tr><tr>";

                //第二行表头
                tcHeader.Add(new TableHeaderCell());
                tcHeader[5].Attributes.Add("bgcolor", "#7898A8");
                tcHeader[5].Attributes.Add("style", "color:white");
                tcHeader[5].Text = "升压";
                tcHeader.Add(new TableHeaderCell());
                tcHeader[6].Attributes.Add("bgcolor", "#7898A8");
                tcHeader[6].Attributes.Add("style", "color:white");
                tcHeader[6].Text = "降压";
                tcHeader.Add(new TableHeaderCell());
                tcHeader[7].Attributes.Add("bgcolor", "#7898A8");
                tcHeader[7].Attributes.Add("style", "color:white");
                tcHeader[7].Text = "允许误差";
                tcHeader.Add(new TableHeaderCell());
                tcHeader[8].Attributes.Add("bgcolor", "#7898A8"); 
                tcHeader[8].Attributes.Add("style", "color:white");
                tcHeader[8].Text = "结论";
                tcHeader.Add(new TableHeaderCell());
                tcHeader[9].Attributes.Add("bgcolor", "#7898A8");
                tcHeader[9].Attributes.Add("style", "color:white");
                tcHeader[9].Text = "升压";
                tcHeader.Add(new TableHeaderCell());
                tcHeader[10].Attributes.Add("bgcolor", "#7898A8");
                tcHeader[10].Attributes.Add("style", "color:white");
                tcHeader[10].Text = "降压";
                tcHeader.Add(new TableHeaderCell());
                tcHeader[11].Attributes.Add("bgcolor", "#7898A8");
                tcHeader[11].Attributes.Add("style", "color:white");
                tcHeader[11].Text = "允许值";
                tcHeader.Add(new TableHeaderCell());
                tcHeader[12].Attributes.Add("bgcolor", "#7898A8");
                tcHeader[12].Attributes.Add("style", "color:white");
                tcHeader[12].Text = "结论";
                tcHeader.Add(new TableHeaderCell());
                tcHeader[13].Attributes.Add("bgcolor", "#7898A8");
                tcHeader[13].Attributes.Add("style", "color:white");
                tcHeader[13].Text = "测量值";
                tcHeader.Add(new TableHeaderCell());
                tcHeader[14].Attributes.Add("bgcolor", "#7898A8");
                tcHeader[14].Attributes.Add("style", "color:white");
                tcHeader[14].Text = "允许值";
                tcHeader.Add(new TableHeaderCell());
                tcHeader[15].Attributes.Add("bgcolor", "#7898A8");
                tcHeader[15].Attributes.Add("style", "color:white");
                tcHeader[15].Text = "结论";

                
            }
            #endregion
        }
        protected void GridView2_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (Session["DetectManager"] != null)
            {
                _myDetectManager = (DetectManager)Session["DetectManager"];

            }
            if (_myDetectManager.CurrentShowDetectPointFunction == null) { return; }
            string FuncCode = _myDetectManager.CurrentShowDetectPointFunction.FunctionCode;
            if (e.Row.RowType == DataControlRowType.Header)
            {

                if (_myDetectManager.CurrentShowDetectPointFunction.IsAC==1)
                {
                    TableCell cell = new TableCell();
                    cell.Width = Unit.Pixel(80);
                    cell.Text = "频率";
                    e.Row.Cells.AddAt(2, cell);
                }
            }
            else
            {

                //交流数据，显示频率列
                if (_myDetectManager.CurrentShowDetectPointFunction.IsAC==1)
                {
                    string text = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Frequency")) + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "FrequencyUnit"));
                    TableCell cell = new TableCell();
                    cell.Width = Unit.Pixel(80);
                    cell.Text = text;
                    e.Row.Cells.AddAt(2, cell);
                }
            }
        }
        /// <summary>
        /// 排序字段
        /// </summary>
        public string Orderfld
        {
            get
            {
                if (ViewState["sortOrderfld"] == null)
                    ViewState["sortOrderfld"] = "OrderID";
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
        #endregion

        #region IAbleCallJS 成员

        public void ExecuteJS(string func, object[] args)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "js", "<script>"+func+";</script>");
        }

        public void RefeshPage(UpdateDetectResult udr)
        {
            if (_DetectRecordState == null)
                _DetectRecordState = ((Dictionary<int, DetectResult>)Session["DetectRecordState"]);
            if (_DetectRecordState.ContainsKey(udr.DetectPointID))
                _DetectRecordState[udr.DetectPointID] = udr.Result;
            Session["DetectRecordState"] = _DetectRecordState;
            GridView1.DataSource = null;
            GridView1.DataSourceID = null;
            
            Btn_Refresh_Click(null, null);
        }


        #endregion

        #region 页面控件操作处理
        //protected void Btn_FUNC_Click(object sender, EventArgs e)
        //{
        //    Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('asdf');</script>");
        //}

        protected void Btn_Refresh_Click(object sender, EventArgs e)
        {
            if (Session["DetectManager"] == null && _myDetectManager == null)
            {
                int sid = Convert.ToInt32(StandardDevice_DropDown.SelectedValue);
                int did=0,deptDeviceID=0;

                string value = DetectDevice_DropDown.SelectedValue;
                //特殊处理：DetectDevice_DropDown取得的Value格式为：设备自增编号|设备管理自增编号
                if (value.IndexOf("|") > 0)
                {
                    string[] idarray = value.Split('|');
                    if (idarray.Length >= 2)
                    {
                        did = Convert.ToInt32(idarray[0]);
                        deptDeviceID = Convert.ToInt32(idarray[1]);
                    }
                }
                DeviceEntity standard = BusinessFacadeShanliTech_HLD_Business.DeviceDisp(sid);
                DeviceEntity detect = BusinessFacadeShanliTech_HLD_Business.DeviceDisp(did);
                detect.Department_DeviceID = deptDeviceID;
                _myDetectManager = DetectManager.GetInstance(standard, detect);
                Session["DetectManager"] = _myDetectManager;
            }
            if (_myDetectManager.State == ExcuteState.Started)
            {
                _myDetectManager.Stop();
            }
            InitControls();
        }

        protected void StandardDevice_DropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            int DeviceCategoryID = GetStandardDeviceCategoryID();
            InitDetectDeviceDropDownList(DeviceCategoryID);
        }

        protected void ibtn_start_Click(object sender, ImageClickEventArgs e)
        {
            //if(
            if (_myDetectManager != null) { _myDetectManager.Start(); }
            Response.Redirect("Detector.aspx");
        }

        protected void Ibtn_Pause_Click(object sender, ImageClickEventArgs e)
        {
            if (_myDetectManager != null) { _myDetectManager.Pause(); }
            Response.Redirect("Detector.aspx");
        }

        protected void ibtn_Stop_Click(object sender, ImageClickEventArgs e)
        {
            if (_myDetectManager != null) { _myDetectManager.Stop(); }
            Response.Redirect("Detector.aspx");
        }

        protected void Rbtn_Manual_CheckedChanged(object sender, EventArgs e)
        {
            //if (_myDetectManager != null) { _myDetectManager.DetectWorkType = DetectWorkType.Auto; }
            DetectWorkType _worktype = DetectWorkType.Manual;
            try 
            {
                RadioButton rb = (RadioButton)sender;
                if (rb != null) 
                {
                    if (rb.Checked == true)
                    { _worktype = DetectWorkType.Manual; }
                }
            }
            catch (Exception ex)
            { throw ex; }
            chanageWorkType(_worktype);
            Response.Redirect("Detector.aspx");
        }

        protected void Rbtn_Auto_CheckedChanged(object sender, EventArgs e)
        {
            //if (_myDetectManager != null) { _myDetectManager.DetectWorkType = DetectWorkType.Manual; }
            DetectWorkType _worktype = DetectWorkType.Manual;
            try
            {
                RadioButton rb = (RadioButton)sender;
                if (rb != null)
                {
                    if (rb.Checked == true)
                    { _worktype = DetectWorkType.Auto; }
                }
            }
            catch (Exception ex)
            { throw ex; }
            chanageWorkType(_worktype);
            Response.Redirect("Detector.aspx");
        }
        
        private void chanageWorkType(DetectWorkType _worktype) 
        {
            if (_myDetectManager != null)
            {
                if (_worktype == DetectWorkType.Auto)
                {
                    _myDetectManager.DetectWorkType = DetectWorkType.Auto;
                }
                else if (_worktype == DetectWorkType.Manual)
                {
                    _myDetectManager.DetectWorkType = DetectWorkType.Manual;
                }
            }
        }

        /// <summary>
        /// 确认设备
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            //是否选择设备
            if ("0".Equals(StandardDevice_DropDown.SelectedValue) || "0".Equals(DetectDevice_DropDown.SelectedValue))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "alert1", "<script>alert('请确定已选择合适的标准设备或被检设备！');</script>");
                return;
            }
            //确认所选择的设备
            if (Session["DetectManager"] == null && _myDetectManager == null)
            {
                int sid = Convert.ToInt32(StandardDevice_DropDown.SelectedValue);
                int did = 0, deptDeviceID = 0;

                string value = DetectDevice_DropDown.SelectedValue;
                //特殊处理：DetectDevice_DropDown取得的Value格式为：设备自增编号|设备管理自增编号
                if (value.IndexOf("|") > 0)
                {
                    string[] idarray = value.Split('|');
                    if (idarray.Length >= 2)
                    {
                        did = Convert.ToInt32(idarray[0]);
                        deptDeviceID = Convert.ToInt32(idarray[1]);
                    }
                }
                DeviceEntity standard = BusinessFacadeShanliTech_HLD_Business.DeviceDisp(sid);
                DeviceEntity detect = BusinessFacadeShanliTech_HLD_Business.DeviceDisp(did);
                detect.Department_DeviceID = deptDeviceID;
                _myDetectManager = DetectManager.GetInstance(standard, detect);
                Session["DetectManager"] = _myDetectManager;
            }
            if (_myDetectManager.State == ExcuteState.Started)
            {
                _myDetectManager.Stop();
            }
            InitControls();
        }

        /// <summary>
        /// 结束检定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            //结束检定
            //_myDetectManager = null;
            if (Session["DetectManager"] != null)
            {
                _myDetectManager = (DetectManager)Session["DetectManager"];
                _myDetectManager.Dispose();
                _myDetectManager = null;
                Session["DetectManager"] = null;
            }
            Response.Redirect("Detector.aspx");
        }
        #endregion

    }
}
