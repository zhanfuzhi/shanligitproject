/********************************************************************************
     File:																
            Default.aspx.cs                         
     Description:
            设备检测列表
     Author:									
            DDBuildTools
            http://FrameWork.supesoft.com
     Finish DateTime:
            2012/12/26 11:58:00
     History:
*********************************************************************************/
using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;

using ShanliTech_HLD_Business;
using ShanliTech_HLD_Business.Components;
using FrameWork;
using FrameWork.Components;
using ShanliTech_HLD_Business.CustomComponents;
using Microsoft.Office.Interop.Word;
using ShanliTech_HLD_Business.OfficWord;

namespace ShanliTech_HLD_Business.Web.Module.ShanliTech_HLD_Business.DeviceDetect
{
    public partial class Default : System.Web.UI.Page
    {
        OfficeWordManager owm = OfficeWordManager.Instance();

        string CMD = (string)Common.sink("CMD", MethodType.Get, 10, 0, DataType.Str);
        int DetectID = (int)Common.sink("DetectID", MethodType.Get, 10, 0, DataType.Int);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //生成检定记录doc
                if (!string.IsNullOrEmpty(CMD))
                {
                    Random g = new Random();
                    string rad = g.Next(10000).ToString();
                    string number = "" + System.DateTime.Now.Year.ToString() + "" + System.DateTime.Now.Month.ToString() + "" + System.DateTime.Now.Day.ToString() + "" + System.DateTime.Now.Hour.ToString() + "" + System.DateTime.Now.Minute.ToString() + "" + System.DateTime.Now.Second.ToString() + "" + System.DateTime.Now.Millisecond.ToString() + "" + rad + "";
                    string filename = number + DetectID + ".doc";
                    string fullfile = Server.MapPath("~/") + "\\CertifyDocs\\" + filename;

                    int rInt = 0;
                    AbsOfficeWord aow = AbsOfficeWord.GetInstance(DetectID);
                    try
                    {
                        if ("Record".Equals(CMD))
                        {
                            rInt = aow.CreateDetectRecordDoc(fullfile);
                        }
                        else if ("Regulate".Equals(CMD))
                        {
                            rInt = aow.CreateRegulateRecordDoc(fullfile);
                        }

                        if (rInt > 0)
                        {
                            OfficeWordApis owa = OfficeWordApis.Instance();
                            string _SignPicFileName = ToolMethods.GetSignPicFileByDetectID(DetectID);
                            owa.InsertFooterPic(fullfile, "Foot_Verifier_SignPicture", Server.MapPath("~/Manager/Public/SignPictures/") + _SignPicFileName, 40.0f, 18.0f);

                            DeviceDetectEntity ddt = BusinessFacadeShanliTech_HLD_Business.DeviceDetectDisp(DetectID);
                            ddt.DetectRecordPath = filename;
                            ddt.DataTable_Action_ = DataTable_Action.Update;
                            BusinessFacadeShanliTech_HLD_Business.DeviceDetectInsertUpdateDelete(ddt);
                        }
                    }
                    finally
                    {
                        aow.KillWordProcess();
                    }

                }
                BindDataList();
            }
        }
       
        /// <summary>
        /// 绑定数据
        /// </summary>
        private void BindDataList()
        {
            QueryParam qp = new QueryParam();
            qp.Where = SearchTerms;
            qp.PageIndex = AspNetPager1.CurrentPageIndex;
            qp.PageSize = AspNetPager1.PageSize;
            qp.Orderfld = Orderfld;
            qp.OrderType = OrderType;
            int RecordCount = 0;
            List<DeviceDetectEntity> lst = BusinessFacadeShanliTech_HLD_Business.DeviceDetectList(qp, out RecordCount);
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
            BindDataList();
        }

        /// <summary>
        /// 查询条件
        /// </summary>
        private string SearchTerms
        {
            get
            {
                if (ViewState["SearchTerms"] == null)
                {
                    string sql = "Where DetectUserID = {0}";
                    ViewState["SearchTerms"] = string.Format(sql, UserData.GetUserDate.UserID);
                }
                return (string)ViewState["SearchTerms"];
            }
            set { ViewState["SearchTerms"] = value; }
        }

        /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {
            string StandardDeviceID_Value = ((string)Common.sink(StandardDeviceID_Input.UniqueID, MethodType.Post, 10, 0, DataType.Str)).Trim();
            string WillTestDeviceID_Value = ((string)Common.sink(WillTestDeviceID_Input.UniqueID, MethodType.Post, 10, 0, DataType.Str)).Trim();
            string CertificateNum_Value = ((string)Common.sink(CertificateNum_Input.UniqueID, MethodType.Post, 50, 0, DataType.Str)).Trim();

            string DetectLocation_Value = ((string)Common.sink(DetectLocation_Input.UniqueID, MethodType.Post, 50, 0, DataType.Str)).Trim();
            string DetectResult_Value = DetectResult_Drop.SelectedValue;

            string DetectDate_Start_Value = (string)Common.sink(DetectDate_Start_Input.UniqueID, MethodType.Post, 50, 0, DataType.Str);
            string DetectDate_End_Value = (string)Common.sink(DetectDate_End_Input.UniqueID, MethodType.Post, 50, 0, DataType.Str);
            
            StringBuilder sb = new StringBuilder();
            UserRole ur = ToolMethods.GetCurrentUserRole();

            //限定于当前用户所拥有角色
            if (ur == UserRole.Checker)
                sb.AppendFormat("Where VerifierID = {0} ", UserData.GetUserDate.UserID);
            else if (ur == UserRole.Approver)
                sb.AppendFormat("Where ApproverID = {0} ", UserData.GetUserDate.UserID);
            else
                sb.AppendFormat("Where DetectUserID = {0} ", UserData.GetUserDate.UserID);
            
            //
            if (!string.IsNullOrEmpty(DetectDate_Start_Value) && string.IsNullOrEmpty(DetectDate_End_Value))
            {
                sb.AppendFormat(" And DetectDate > '{0}'", DetectDate_Start_Value);
            }
            else if (string.IsNullOrEmpty(DetectDate_Start_Value) && !string.IsNullOrEmpty(DetectDate_End_Value))
            {
                sb.AppendFormat(" And DetectDate < '{0}'", DetectDate_End_Value);
            }
            else if (!string.IsNullOrEmpty(DetectDate_Start_Value) && !string.IsNullOrEmpty(DetectDate_End_Value))
            {
                sb.AppendFormat(" And DetectDate between '{0}' and '{1}'",DetectDate_Start_Value, DetectDate_End_Value);
            }
            if (StandardDeviceID_Value != string.Empty)
            {
                sb.AppendFormat(" AND StandardDeviceName like '%{0}%' ", Convert.ToInt32(StandardDeviceID_Value));
            }

            if (WillTestDeviceID_Value != string.Empty)
            {
                sb.AppendFormat(" AND WillTestDeviceName like '%{0}%' ", Convert.ToInt32(WillTestDeviceID_Value));
            }
                    
if (CertificateNum_Value != string.Empty)
{
    sb.AppendFormat(" AND CertificateNum like '%{0}%' ", Common.inSQL(CertificateNum_Value));
}
                    
//if (CertificateType_Value != string.Empty)
//{
//    sb.AppendFormat(" AND CertificateType = {0} ", Convert.ToInt32(CertificateType_Value));
//}
                    
                    
if (DetectLocation_Value != string.Empty)
{
    sb.AppendFormat(" AND DetectLocation like '%{0}%' ", Common.inSQL(DetectLocation_Value));
}
                    
if (DetectResult_Value != string.Empty)
{
    sb.AppendFormat(" AND DetectResult = '{0}' ", Common.inSQL(DetectResult_Value));
}
                    
//if (DetectUser_Value != string.Empty)
//{
//    sb.AppendFormat(" AND DetectUser like '%{0}%' ", Common.inSQL(DetectUser_Value));
//}
                    
//if (EnvironmentNote_Value != string.Empty)
//{
//    sb.AppendFormat(" AND EnvironmentNote like '%{0}%' ", Common.inSQL(EnvironmentNote_Value));
//}
                    
                    
//if (HumidityUnit_Value != string.Empty)
//{
//    sb.AppendFormat(" AND HumidityUnit like '%{0}%' ", Common.inSQL(HumidityUnit_Value));
//}
                    
                    
//if (TemperatureUnit_Value != string.Empty)
//{
//    sb.AppendFormat(" AND TemperatureUnit like '%{0}%' ", Common.inSQL(TemperatureUnit_Value));
//}
                    
                    
//if (DetectNote_Value != string.Empty)
//{
//    sb.AppendFormat(" AND DetectNote like '%{0}%' ", Common.inSQL(DetectNote_Value));
//}
            ViewState["SearchTerms"] = sb.ToString();
            BindDataList();
            TabOptionWebControls1.SelectIndex = 0;
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
            BindDataList();
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
            if (e.Row.RowType == DataControlRowType.Header)
            {
                if (FrameWorkPermission.CheckButtonPermission(PopedomType.Delete))
                {
                    Button2.Visible = true;
                    //增加check列头全选
                    TableCell cell = new TableCell();
                    cell.Width = Unit.Pixel(5);
                    cell.Text = " <input id='CheckboxAll' value='0' type='checkbox' onclick='SelectAll()'/>";
                    e.Row.Cells.AddAt(0, cell);
                }
                
                foreach (TableCell var in e.Row.Cells)
                {
                    if (var.Controls.Count > 0 && var.Controls[0] is LinkButton)
                    {
                        string Colume = ((LinkButton)var.Controls[0]).CommandArgument;
                        if (Colume == Orderfld)
                        {

                            LinkButton l = (LinkButton)var.Controls[0];
                            l.Text += string.Format("<img src='{0}' border='0'>", (OrderType == 0) ? Page.ResolveUrl("~/Manager/images/sort_asc.gif") : Page.ResolveUrl("~/Manager/images/sort_desc.gif"));
                            //Image Img = new Image();
                            //SortDirection a = GridView1.SortDirection;
                            //Img.ImageUrl = (a == SortDirection.Ascending) ? "i_p_sort_asc.gif" : "i_p_sort_desc.gif";
                            //var.Controls.Add(Img);
                        }
                    }
                }
            }
            else
            {
                if (FrameWorkPermission.CheckButtonPermission(PopedomType.Delete))
                {
                    //增加行选项
                    DataIDX = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "ID"));
                    TableCell cell = new TableCell();
                    cell.Width = Unit.Pixel(5);
                    cell.Text = string.Format(" <input name='Checkbox' id='Checkbox' value='{0}' type='checkbox' />", DataIDX);
                    e.Row.Cells.AddAt(0, cell);
                }
            }
        }
        #endregion
        
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        [PopedomTypeAttaible(PopedomType.Delete)]
        [System.Security.Permissions.PrincipalPermission(System.Security.Permissions.SecurityAction.Demand, Role = "OR")]
        protected void Button2_Click(object sender, EventArgs e)
        {
            string Checkbox_Value = (string)Common.sink("Checkbox", MethodType.Post, 2000, 1, DataType.Str);
            string[] Checkbox_Value_Array = Checkbox_Value.Split(',');
            Int32 IDX = 0;
            for (int i = 0; i < Checkbox_Value_Array.Length; i++)
            {
                if (Int32.TryParse(Checkbox_Value_Array[i], out IDX))
                {
                    DeviceDetectEntity et = new DeviceDetectEntity();
                    et.DataTable_Action_ = DataTable_Action.Delete;
                    et.ID = IDX;
                    BusinessFacadeShanliTech_HLD_Business.DeviceDetectInsertUpdateDelete(et);
                }
            }

            EventMessage.MessageBox(1, "批量删除成功", string.Format("批量删除({0})成功!", Checkbox_Value), Icon_Type.OK, Common.GetHomeBaseUrl("default.aspx"));
        }

        protected static string GetRecordPageByCate(int deviceId)
        {
            
            DeviceEntity de = BusinessFacadeShanliTech_HLD_Business.DeviceDisp(deviceId);
            string cate = de.DeviceCategoryCode.ToUpper();
            string _r = string.Empty;
            if ("DEVICE_CATE_P".Equals(cate) || "DEVICE_CATE_AP".Equals(cate))
            {
                _r = "P_DetectResult.aspx";
            }
            else if ("DEVICE_CATE_E".Equals(cate))
            {
                _r = "E_DetectResult.aspx";
            }
            return _r;
        }

        protected static string GetOperateUrl(int detecteId, int VerifierID, int VerifyFlag,int ReportType,int ApproverID,int ApproveFlag,string ReportPath)
        {
            string _r = string.Empty;
           
            //出具证书或提交核验
            if (ReportType <= 0)
                _r = string.Format("<a href=\"Doc_Online.aspx?DeviceDetectID={0}\" >出具证书</a>", detecteId);
            else if (VerifierID == 0)
            {
                _r = string.Format("<a href=\"Doc_Online.aspx?DeviceDetectID={0}&CMD=Update&DetectRecordPath={1}\">证书修改</a>", detecteId, ReportPath)
                    + string.Format("&nbsp;&nbsp;&nbsp;<a href=\"javascript:showPopWin('重新出具','../../../inc/ReCreateDoc.aspx?DetectID={0}&'+rand(100000000),400, 120, AlertMessageBox,true);\" >重新出具</a>", detecteId)
                    + string.Format("&nbsp;&nbsp;&nbsp;<a href=\"javascript:showPopWin('提交核验','../../../inc/SubmitReport.aspx?DetectID={0}&UserID={1}&CMD=SubmitToCheck&rand'+rand(100000000),400, 150, AlertMessageBox,true);\" >提交核验</a>", detecteId, UserData.GetUserDate.UserID);
            }
            else if (VerifierID > 0)
            {

                if (VerifyFlag == 0)
                    _r = "等待核验";
                else if (VerifyFlag == 2)
                    _r = string.Format("<a href = \"javascript:showPopWin('核验未通过原因','../../../inc/NoPass.aspx?CMD=List&Role=R_Check&DetectID={0}&UserID={1}&rand'+rand(100000000),400, 150, AlertMessageBox,true);\">核验未通过原因</a>", detecteId, UserData.GetUserDate.UserID)
                        + string.Format("&nbsp;&nbsp;&nbsp;&nbsp;<a href=\"Doc_Online.aspx?DeviceDetectID={0}\" >重新出具证书</a>", detecteId);
                else if (VerifyFlag == 1)
                {
                    if (ApproveFlag == 0)
                        _r = "核验已通过，等待批准";
                    else if (ApproveFlag == 1)
                        _r = "批准通过";
                    else
                        _r = string.Format("<a href = \"javascript:showPopWin('批准未通过原因','../../../inc/NoPass.aspx?CMD=List&Role=R_Approve&DetectID={0}&UserID={1}&rand'+rand(100000000),400, 150, AlertMessageBox,true);\">批准未通过原因</a>", detecteId, UserData.GetUserDate.UserID);
                }
            }
            return _r;
        }

        protected static string GetDetectRecord(int detectid, int detectflag, string DetectRecordPath)
        {
            //if (string.IsNullOrEmpty(DetectRecordPath))
            //{
            //    DeviceDetectEntity dde = BusinessFacadeShanliTech_HLD_Business.DeviceDetectDisp(detectid);
            //    DeviceEntity de = BusinessFacadeShanliTech_HLD_Business.DeviceDisp(dde.WillTestDeviceID);
            //    if ("DEVICE_CATE_P".Equals(de.DeviceCategoryCode))
            //    {
            //        //return string.Format("<a href=\"javascript:showPopWin('选择记录文档类型','../../../inc/NormalPresure_RecordSelect.aspx?DetectID={0}&rand'+rand(100000000),400, 350, createRecordDoc,true);\">生成记录文档</a>",detectid);
            //        if (ToolMethods.IsRegulateType(dde.DeptDeviceID))
            //            return string.Format("<a href=\"?CMD=Regulate&DetectID={0}\">生成校准记录文档</a>", detectid);
            //    }
            //    return string.Format("<a href=\"?CMD=Record&DetectID={0}\">生成检定记录文档</a>", detectid);
            //}
            //else
            //{
            //    string url = string.Empty;
            //    url += string.Format("<a href=\"Doc_Online.aspx?CMD=ViewRecord&DeviceDetectID={0}&DetectRecordPath={1}\">查看记录文档</a>", detectid, DetectRecordPath);
            //    if(
            //    return url;
            //    //return string.Format("<a href=\"Doc_Online.aspx?CMD=ViewRecord&DeviceDetectID={0}&DetectRecordPath={1}\">查看记录文档</a>&nbsp;&nbsp;<a href=\"javascript:showPopWin('记录文档提交核验','../../../inc/SubmitDetectRecorde.aspx?file={2}&DetectID={3}&rand'+rand(100000000),400, 150, AlertMessageBox,true);\">提交记录文档</a>", detectid, DetectRecordPath, DetectRecordPath, detectid);
            //}
            string _r = "<span style=\"margin:0px 3px 0px 3px;padding:0px 3px 0px 3px;border:1px solid #3C3C3C;\">";
            string hrefText = string.Empty;
            DeviceDetectEntity dde = BusinessFacadeShanliTech_HLD_Business.DeviceDetectDisp(detectid);
            DeviceEntity de = BusinessFacadeShanliTech_HLD_Business.DeviceDisp(dde.WillTestDeviceID);
            if ("DEVICE_CATE_P".Equals(de.DeviceCategoryCode))
            {
                //return string.Format("<a href=\"javascript:showPopWin('选择记录文档类型','../../../inc/NormalPresure_RecordSelect.aspx?DetectID={0}&rand'+rand(100000000),400, 350, createRecordDoc,true);\">生成记录文档</a>",detectid);
                if (ToolMethods.IsRegulateType(dde.DeptDeviceID))
                    hrefText += "<a href=\"?CMD=Regulate&DetectID={0}\">{1}校准记录文档</a>";
            }
            hrefText += "<a href=\"?CMD=Record&DetectID={0}\">{1}检定记录文档</a>";

            //生成
            if (string.IsNullOrEmpty(DetectRecordPath))
            {
                _r += string.Format(hrefText, detectid, "生成");
            }
            else
            {
                //重新生成 + 驳回原因说明
                if (detectflag == 3)
                {
                    _r += string.Format(hrefText, detectid, "重新生成");
                }
                //核验通过
                else if (detectflag == 2)
                {
                    _r += "核验已通过";
                }
                //等待核验
                else if (detectflag == 1)
                {
                    _r += "等待核验";
                }
                //提交核验
                else if (detectflag == 0)
                {
                    _r += string.Format("<a href=\"javascript:showPopWin('记录文档提交核验','../../../inc/SubmitDetectRecorde.aspx?file={0}&DetectID={1}&rand'+rand(100000000),400, 210, AlertMessageBox,true);\">提交记录文档</a>", DetectRecordPath, detectid);
                }
                _r += string.Format("&nbsp;&nbsp;<a href=\"Doc_Online.aspx?CMD=ViewRecord&DeviceDetectID={0}&DetectRecordPath={1}\">查看记录文档</a>", detectid, DetectRecordPath);
            }

            return _r + "</span>";
        }

        protected static string GetDocView(int detectid,string reportPath)
        {
            string _r = string.Empty;
            if (!string.IsNullOrEmpty(reportPath))
            {
                _r = string.Format("&nbsp;<a href=\"Doc_Online.aspx?CMD=ViewDoc&DetectRecordPath={0}&DeviceDetectID={1}\">查看证书</a>", reportPath, detectid);
            }
            return _r;
        }

        protected static string GetValiateDateStr(string value,string detectdate,int updateid)
        {
            string urlStr = "<a href=\"javascript:showPopWin('有效期修改','Update_GridView_ValideDate.aspx?Validate={0}&IDX={1}&Detectdate={2}&rand'+rand(100000000),350, 280, AlertMessageBox,true)\">";
            if (string.IsNullOrEmpty(value))
                urlStr += "添加";
            else
            {
                DateTime dt = DateTime.Now;
                if (DateTime.TryParse(value, out dt))
                    urlStr += dt.ToString("yyyy年MM月dd日");
                else
                    urlStr += value;
            }
            urlStr += "</a>";
            return string.Format(urlStr, (string.IsNullOrEmpty(value) ? "" : System.Web.HttpUtility.UrlEncode(value)), updateid, (string.IsNullOrEmpty(detectdate) ? "" : System.Web.HttpUtility.UrlEncode(detectdate)));
        }
    }
}
