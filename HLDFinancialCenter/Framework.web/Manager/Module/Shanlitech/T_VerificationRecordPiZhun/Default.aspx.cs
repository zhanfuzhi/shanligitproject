/********************************************************************************
     File:																
            Default.aspx.cs                         
     Description:
            核销申请单列表
     Author:									
            DDBuildTools
            http://FrameWork.supesoft.com
     Finish DateTime:
            2014-6-27 18:28:22
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

using Shanlitech_Location;
using Shanlitech_Location.Components;
using FrameWork;
using FrameWork.Components;

namespace Shanlitech_Location.Web.Module.Shanlitech_Location.T_VerificationRecordPiZhun
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Innit();
                BindDataList();
            }
        }
        public void Innit()
        {
            ListItem nullItems = new ListItem();
            nullItems.Value = "";
            nullItems.Text = "请选择";

            //初始化申请人
            Undertaker_Input.Items.Add(nullItems);
            ArrayList userlist = BusinessFacadeShanlitech_Location.GetUserList();
            foreach (sys_UserTable r in userlist)
            {
                ListItem item = new ListItem();
                item.Value = r.UserID.ToString();
                item.Text = r.U_LoginName;
                if (!r.U_LoginName.Equals(""))
                {
                    Undertaker_Input.Items.Add(item);
                }
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
            List<T_VerificationRecordEntity> lst = BusinessFacadeShanlitech_Location.T_VerificationRecordList(qp, out RecordCount);
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
                    ViewState["SearchTerms"] = string.Format(" Where state={0} and  TransferState={1}", (int)Status.Normal,(int)TransferState.PiZhun);
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
            string FundID_Value = ProjID_Hidden.Value;
            string Undertaker_Value = (string)Common.sink(Undertaker_Input.UniqueID, MethodType.Post, 10, 0, DataType.Str);
            string State_Value = (string)Common.sink(State_Input.UniqueID, MethodType.Post, 10, 0, DataType.Str);
            string PayAmount_Value = (string)Common.sink(PayAmount_Input.UniqueID, MethodType.Post, 10, 0, DataType.Str);

            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(" Where TransferState ={0} ", (int)TransferState.PiZhun);

            if (FundID_Value != string.Empty)
            {
                sb.AppendFormat(" AND FundID = {0} ", Convert.ToInt32(FundID_Value));
            }


            if (Undertaker_Value != string.Empty)
            {
                sb.AppendFormat(" AND Undertaker = {0} ", Convert.ToInt32(Undertaker_Value));
            }


            if (State_Value != string.Empty)
            {
                sb.AppendFormat(" AND State = {0} ", Convert.ToInt32(State_Value));
            }
            if (PayAmount_Value.Trim() != string.Empty)
            {
                sb.AppendFormat(" AND PayAmount = {0} ", Convert.ToDouble(PayAmount_Value.Trim()));
            }

            ViewState["SearchTerms"] = sb.ToString();
            BindDataList();
            ProjID_Hidden.Value = string.Empty;
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
            //#region MyRegion
            //Int32 DataIDX = 0;
            //if (e.Row.RowType == DataControlRowType.Header)
            //{
            //    if (FrameWorkPermission.CheckButtonPermission(PopedomType.Delete))
            //    {
            //        Button2.Visible = true;
            //        //增加check列头全选
            //        TableCell cell = new TableCell();
            //        cell.Width = Unit.Pixel(5);
            //        cell.Text = " <input id='CheckboxAll' value='0' type='checkbox' onclick='SelectAll()'/>";
            //        e.Row.Cells.AddAt(0, cell);
            //    }

            //    foreach (TableCell var in e.Row.Cells)
            //    {
            //        if (var.Controls.Count > 0 && var.Controls[0] is LinkButton)
            //        {
            //            string Colume = ((LinkButton)var.Controls[0]).CommandArgument;
            //            if (Colume == Orderfld)
            //            {

            //                LinkButton l = (LinkButton)var.Controls[0];
            //                l.Text += string.Format("<img src='{0}' border='0'>", (OrderType == 0) ? Page.ResolveUrl("~/Manager/images/sort_asc.gif") : Page.ResolveUrl("~/Manager/images/sort_desc.gif"));
            //                //Image Img = new Image();
            //                //SortDirection a = GridView1.SortDirection;
            //                //Img.ImageUrl = (a == SortDirection.Ascending) ? "i_p_sort_asc.gif" : "i_p_sort_desc.gif";
            //                //var.Controls.Add(Img);
            //            }
            //        }
            //    }
            //}
            //else
            //{
            //    if (FrameWorkPermission.CheckButtonPermission(PopedomType.Delete))
            //    {
            //        //增加行选项
            //        DataIDX = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "ID"));
            //        TableCell cell = new TableCell();
            //        cell.Width = Unit.Pixel(5);
            //        cell.Text = string.Format(" <input name='Checkbox' id='Checkbox' value='{0}' type='checkbox' />", DataIDX);
            //        e.Row.Cells.AddAt(0, cell);
            //    }
            //}
            //#endregion
           
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
                    T_VerificationRecordEntity et = BusinessFacadeShanlitech_Location.T_VerificationRecordDisp(IDX);
                    et.DataTable_Action_ = DataTable_Action.Update;
                    et.State = (int)Status.Delete;
                    BusinessFacadeShanlitech_Location.T_VerificationRecordInsertUpdateDelete(et);
                }
            }

            EventMessage.MessageBox(1, "批量删除成功", string.Format("批量删除({0})成功!", Checkbox_Value), Icon_Type.OK, Common.GetHomeBaseUrl("default.aspx"));
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //审核通过
            if (e.CommandName.Equals("Pass"))
            {
                T_VerificationRecordEntity entity = BusinessFacadeShanlitech_Location.T_VerificationRecordDisp(Convert.ToInt32(e.CommandArgument));
                if (entity != null)
                {
                    entity.DataTable_Action_ = DataTable_Action.Update;
                    entity.TransferState = (int)TransferState.PiZhun;
                    entity.Approver = UserData.GetUserDate.UserID;
                    entity.ApprovalTime = (DateTime?)DateTime.Now;
                    BusinessFacadeShanlitech_Location.T_VerificationRecordInsertUpdateDelete(entity);
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "alert1", "<script>alert('批准通过！');</script>");
                }
            }
            //撤销审核
            if (e.CommandName.Equals("NoPass"))
            {
                T_VerificationRecordEntity entity = BusinessFacadeShanlitech_Location.T_VerificationRecordDisp(Convert.ToInt32(e.CommandArgument));
                if (entity != null)
                {
                    entity.DataTable_Action_ = DataTable_Action.Update;
                    entity.TransferState = (int)TransferState.ShenQing;
                    BusinessFacadeShanlitech_Location.T_VerificationRecordInsertUpdateDelete(entity);
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "alert1", "<script>alert('撤销审核成功！');</script>");
                }
            }
            BindDataList();
        }
    }
}
