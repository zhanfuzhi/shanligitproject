/********************************************************************************
     File:																
            Default.aspx.cs                         
     Description:
            定位数据表列表
     Author:									
            DDBuildTools
            http://FrameWork.supesoft.com
     Finish DateTime:
            2013/9/12 11:04:12
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

namespace Shanlitech_Location.Web.Module.Shanlitech_Location.LocationData
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
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
            List<LocationDataEntity> lst = BusinessFacadeShanlitech_Location.LocationDataList(qp, out RecordCount);
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
                    ViewState["SearchTerms"] = " Where 1=1 ";
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
            string appID_Value = (string)Common.sink(appID_Input.UniqueID, MethodType.Post, 50, 0, DataType.Str);
            string userID_Value = (string)Common.sink(userID_Input.UniqueID, MethodType.Post, 50, 0, DataType.Str);
            string type_Value = (string)Common.sink(type_Input.UniqueID, MethodType.Post, 10, 0, DataType.Str);
            string operator_mobile_Value = (string)Common.sink(operator_mobile_Input.UniqueID, MethodType.Post, 10, 0, DataType.Str);
            string coordination_Value = (string)Common.sink(coordination_Input.UniqueID, MethodType.Post, 50, 0, DataType.Str);
            string lat_Value = (string)Common.sink(lat_Input.UniqueID, MethodType.Post, 50, 0, DataType.Str);
            string lng_Value = (string)Common.sink(lng_Input.UniqueID, MethodType.Post, 50, 0, DataType.Str);
            string address_Value = (string)Common.sink(address_Input.UniqueID, MethodType.Post, 100, 0, DataType.Str);
            
            string error_code_Value = (string)Common.sink(error_code_Input.UniqueID, MethodType.Post, 10, 0, DataType.Str);
            string code_description_Value = (string)Common.sink(code_description_Input.UniqueID, MethodType.Post, 50, 0, DataType.Str);
                        
            StringBuilder sb = new StringBuilder();
            sb.Append(" Where 1=1 ");
                    
if (appID_Value != string.Empty)
{
    sb.AppendFormat(" AND appID like '%{0}%' ", Common.inSQL(appID_Value));
}
                    
if (userID_Value != string.Empty)
{
    sb.AppendFormat(" AND userID like '%{0}%' ", Common.inSQL(userID_Value));
}
                    
if (type_Value != string.Empty)
{
    sb.AppendFormat(" AND type = {0} ", Convert.ToInt32(type_Value));
}
                    
if (operator_mobile_Value != string.Empty)
{
    sb.AppendFormat(" AND operator_mobile = {0} ", Convert.ToInt32(operator_mobile_Value));
}
                    
if (coordination_Value != string.Empty)
{
    sb.AppendFormat(" AND coordination like '%{0}%' ", Common.inSQL(coordination_Value));
}
                    
if (lat_Value != string.Empty)
{
    sb.AppendFormat(" AND lat like '%{0}%' ", Common.inSQL(lat_Value));
}
                    
if (lng_Value != string.Empty)
{
    sb.AppendFormat(" AND lng like '%{0}%' ", Common.inSQL(lng_Value));
}
                    
if (address_Value != string.Empty)
{
    sb.AppendFormat(" AND address like '%{0}%' ", Common.inSQL(address_Value));
}
                    
                    
if (error_code_Value != string.Empty)
{
    sb.AppendFormat(" AND error_code = {0} ", Convert.ToInt32(error_code_Value));
}
                    
if (code_description_Value != string.Empty)
{
    sb.AppendFormat(" AND code_description like '%{0}%' ", Common.inSQL(code_description_Value));
}
                    
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
                    LocationDataEntity et = new LocationDataEntity();
                    et.DataTable_Action_ = DataTable_Action.Delete;
                    et.ID = IDX;
                    BusinessFacadeShanlitech_Location.LocationDataInsertUpdateDelete(et);
                }
            }

            EventMessage.MessageBox(1, "批量删除成功", string.Format("批量删除({0})成功!", Checkbox_Value), Icon_Type.OK, Common.GetHomeBaseUrl("default.aspx"));
        }
    }
}
