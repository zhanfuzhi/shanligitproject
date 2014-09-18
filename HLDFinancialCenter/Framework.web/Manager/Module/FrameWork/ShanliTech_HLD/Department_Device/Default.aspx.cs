/********************************************************************************
     File:																
            Default.aspx.cs                         
     Description:
            部门与设备关系列表
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

namespace ShanliTech_HLD_Business.Web.Module.ShanliTech_HLD_Business.Department_Device
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //ToolMethods.InitDropDownDevice(DeviceID_DropDown);
                //ToolMethods.InitDropDownAllGroup(Group_DropDown);
                ToolMethods.InitDropDownDeviceType(DeviceType_DropDown);
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
            qp.Orderfld = "DeviceType,IntputTime";
            qp.OrderType = 0;
            int RecordCount = 0;
            List<Department_DeviceEntity> lst = BusinessFacadeShanliTech_HLD_Business.Department_DeviceList(qp, out RecordCount);
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
                    //ViewState["SearchTerms"] = "Where 1=1 And State = 0";   //默认显示待检测列表，郭博浩 2013-01-04
                    ViewState["SearchTerms"] = string.Format(" Where State <> 1 And DepartmentID = {0}", UserData.GetUserDate.U_GroupID);
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
            //string DepartmentID_Value = (string)Common.sink(DepartmentID_Input.UniqueID, MethodType.Post, 10, 0, DataType.Str);
            //string DeviceType_Value = (string)Common.sink(DeviceType_Input.UniqueID, MethodType.Post, 10, 0, DataType.Str);
            //string DeviceID_Value = (string)Common.sink(DeviceID_Input.UniqueID, MethodType.Post, 10, 0, DataType.Str);
            //string Laboratory_Value = ((string)Common.sink(Laboratory_Input.UniqueID, MethodType.Post, 50, 0, DataType.Str)).Trim();

            string DeviceType_Value = DeviceType_DropDown.SelectedValue;
            //string DepartmentID_Value = Group_DropDown.SelectedValue;
            string DeviceName_Value = ((string)Common.sink(DeviceName_Input.UniqueID, MethodType.Post, 50, 0, DataType.Str)).Trim();
            int DetectState_Value=Convert.ToInt32(DetectState_DropDown.SelectedValue);

            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(" Where DepartmentID in (select GroupID from getAllChild({0}))", UserData.GetUserDate.U_GroupID);

            //if (DepartmentID_Value != string.Empty && !DepartmentID_Value.Equals("0"))
            //{
            //    sb.AppendFormat(" AND DepartmentID = {0} ", Convert.ToInt32(DepartmentID_Value));
            //}
            ////else
            //{
            //    //当前部门下
            //    sb.AppendFormat(" AND DepartmentID in (select GroupID from getAllChild({0}))",UserData.GetUserDate.U_GroupID);
            //}

            //if (Laboratory_Value != string.Empty)
            //{
            //    sb.AppendFormat(" AND Laboratory like '%{0}%' ", Common.inSQL(Laboratory_Value));
            //}
if (DeviceType_Value != string.Empty&& !DeviceType_Value.Equals("0"))
{
    sb.AppendFormat(" AND DeviceType = {0} ", Convert.ToInt32(DeviceType_Value));
}

if (DeviceName_Value != string.Empty)
{
    sb.AppendFormat(" AND DeviceName like '%{0}%' ", Common.inSQL(DeviceName_Value));
}

if (DetectState_Value != -1)
{
    sb.AppendFormat(" AND State = {0}", DetectState_Value);
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
                    Department_DeviceEntity et = BusinessFacadeShanliTech_HLD_Business.Department_DeviceDisp(IDX);
                    et.DataTable_Action_ = DataTable_Action.Delete;
                    BusinessFacadeShanliTech_HLD_Business.Department_DeviceInsertUpdateDelete(et);
                }
            }

            EventMessage.MessageBox(1, "批量删除成功", string.Format("批量删除({0})成功!", Checkbox_Value), Icon_Type.OK, Common.GetHomeBaseUrl("default.aspx"));
        }
    }
}
