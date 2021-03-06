﻿/********************************************************************************
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

namespace ShanliTech_HLD_Business.Web.Module.ShanliTech_HLD_Business.DeviceDetect
{
    public partial class DefaultApprove : System.Web.UI.Page
    {
        static int DEVICE_CATE_E = 0;
        static int DEVICE_CATE_P = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindDataList();
            }
            DEVICE_CATE_P = ToolMethods.GetDictionaryIDByCode("DEVICE_CATE_P");
            DEVICE_CATE_E = ToolMethods.GetDictionaryIDByCode("DEVICE_CATE_E");

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
                    string sql = "Where ApproverID = {0}";
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
            string DetectResult_Value = ((string)Common.sink(DetectResult_Input.UniqueID, MethodType.Post, 50, 0, DataType.Str)).Trim();
            //string DetectUser_Value = (string)Common.sink(DetectUser_Input.UniqueID, MethodType.Post, 50, 0, DataType.Str);

            string DetectDate_Start_Value = (string)Common.sink(DetectDate_Start_Input.UniqueID, MethodType.Post, 50, 0, DataType.Str);
            string DetectDate_End_Value = (string)Common.sink(DetectDate_End_Input.UniqueID, MethodType.Post, 50, 0, DataType.Str);

            StringBuilder sb = new StringBuilder();
            UserRole ur = ToolMethods.GetCurrentUserRole();

            //限定于当前用户所拥有角色
            sb.AppendFormat("Where ApproverID = {0} ", UserData.GetUserDate.UserID);

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
                sb.AppendFormat(" And DetectDate between '{0}' and '{1}'", DetectDate_Start_Value, DetectDate_End_Value);
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
                sb.AppendFormat(" AND DetectResult like '%{0}%' ", Common.inSQL(DetectResult_Value));
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

            EventMessage.MessageBox(1, "批量删除成功", string.Format("批量删除({0})成功!", Checkbox_Value), Icon_Type.OK, Common.GetHomeBaseUrl("DefaultApprove.aspx"));
        }

        protected static string GetRecordPageByCate(int deviceId)
        {

            DeviceEntity de = BusinessFacadeShanliTech_HLD_Business.DeviceDisp(deviceId);
            int cate = de.DeviceCategoryID;
            string _r = string.Empty;
            if (cate == DEVICE_CATE_P)
            {
                _r = "P_DetectResult.aspx";
            }
            else if (cate == DEVICE_CATE_E)
            {
                _r = "E_DetectResult.aspx";
            }
            return _r;
        }


        protected static string GetOperateUrl(int detecteId, int Approver, int ApproveFlag, string ReportPath)
        {
            string _r = string.Empty;
            
            if (ApproveFlag == 0)
            {
                _r = string.Format("<a href=\"Doc_Online_Approve.aspx?DetectID={0}&CheckerID={1}&ReportPath={2}\">进行批准</a>", detecteId, Approver, ReportPath);
            }
            //核验通过
            else if (ApproveFlag == 1)
            {
                _r = "批准已通过";
            }
            //核验未通过
            else if (ApproveFlag == 2)
            {
                _r = string.Format("<a href = \"javascript:showPopWin('批准未通过原因','NoPass.aspx?CMD=List&Role=R_Approve&DetectID={0}&UserID={1}&rand'+rand(100000000),400, 350, AlertMessageBox,true);\">批准未通过原因</a>", detecteId, UserData.GetUserDate.UserID);
            }

            return _r;
        }
    }
}
