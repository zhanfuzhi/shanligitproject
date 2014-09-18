/********************************************************************************
     File:																
            Default.aspx.cs                         
     Description:
            测试点列表
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
using FrameWork.WebControls;

namespace ShanliTech_HLD_Business.Web.Module.ShanliTech_HLD_Business.DeviceTemplate
{
    public partial class DefaultPoint : System.Web.UI.Page
    {
        protected Int32 FunctionID = (Int32)Common.sink("FunctionID", MethodType.Get, 10, 0, DataType.Int);
        Int32 DeviceID = 0;
        protected bool Is_P_Cate = true;
        string CMD = (string)Common.sink("CMD", MethodType.Get, 10, 0, DataType.Str);
        protected void Page_Load(object sender, EventArgs e)
        {
            DeviceID = ToolMethods.GetTemplateDeviceIDByFunction(FunctionID);
            Is_P_Cate = ToolMethods.IsPresureDevice(DeviceID,true);
            AddNewButton();
            AddFunctionListButton();
            if (!Page.IsPostBack)
            {
                if (!string.IsNullOrEmpty(CMD))
                {
                    string PointIDStr = Request.Params["PointID"];
                    int PointID = 0;
                    if (Int32.TryParse(PointIDStr, out PointID))
                    {
                        DetectPointTemplateEntity point = BusinessFacadeShanliTech_HLD_Business.DetectPointTemplateDisp(PointID);
                        switch (CMD)
                        {
                            case "Up":
                                ToolMethods.MoverUpPoint(point);
                                break;
                            case "Down":
                                ToolMethods.MoverDownPoint(point);
                                break;
                        }
                    }
                }
                //ToolMethods.InitDropDownFunction(FunctionID_DropDown);
                BindDataList();
            }
        }
        /// <summary>
        /// 增加增加按钮
        /// </summary>
        private void AddNewButton()
        {
            HeadMenuButtonItem bi = new HeadMenuButtonItem();
            bi.ButtonPopedom = PopedomType.New;
            bi.ButtonName = "功能检定点模板";
            bi.ButtonUrl = string.Format("ManagerPoint.aspx?CMD=New&FunctionID={0}&DeviceID={1}", FunctionID, DeviceID);
            HeadMenuWebControls1.ButtonList.Add(bi);
        }

        /// <summary>
        /// 增加功能按钮
        /// </summary>
        private void AddFunctionListButton()
        {
            HeadMenuButtonItem bi = new HeadMenuButtonItem();
            bi.ButtonPopedom = PopedomType.List;
            bi.ButtonName = "设备功能模板";
            bi.ButtonUrl = string.Format("DefaultFunction.aspx?CMD=List&DeviceID={0}", DeviceID);
            HeadMenuWebControls1.ButtonList.Add(bi);
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
            qp.Orderfld = "OrderID";
            qp.OrderType = 0;
            int RecordCount = 0;
            List<DetectPointTemplateEntity> lst = BusinessFacadeShanliTech_HLD_Business.DetectPointTemplateList(qp, out RecordCount);
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
                    ViewState["SearchTerms"] = " Where DelFlag = 0 And FunctionID = " + FunctionID;
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
            //string CommandCode_Value = (string)Common.sink(CommandCode_Input.UniqueID, MethodType.Post, 50, 0, DataType.Str);
            string TestRange_Value = ((string)Common.sink(TestRange_Input.UniqueID, MethodType.Post, 50, 0, DataType.Str)).Trim();
            string StandardValue_Value = ((string)Common.sink(StandardValue_Input.UniqueID, MethodType.Post, 50, 0, DataType.Str)).Trim();

            string FunctionID_Value = FunctionID.ToString();// FunctionID_DropDown.SelectedValue;

            double trv = 0, svv = 0;
            if (!string.IsNullOrEmpty(TestRange_Value) && !Double.TryParse(TestRange_Value, out trv))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "alert1", "<script>alert('输入查询量程需为Float型！');</script>");
                return;
            }
            if (!string.IsNullOrEmpty(StandardValue_Value) && !Double.TryParse(StandardValue_Value, out svv))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "alert1", "<script>alert('输入查询标准值需为Float型！');</script>");
                return;
            }
            

            StringBuilder sb = new StringBuilder();
            sb.Append(" Where DelFlag = 0 And FunctionID = " + FunctionID_Value);

            //if (CommandCode_Value != string.Empty)
            //{
            //    sb.AppendFormat(" AND CommandCode like '%{0}%' ", Common.inSQL(CommandCode_Value));
            //}
            if (!string.IsNullOrEmpty(TestRange_Value))
            {
                sb.AppendFormat(" AND TestRange = {0} ", trv);
            }
            if (!string.IsNullOrEmpty(StandardValue_Value))
            {
                sb.AppendFormat(" AND StandardValue = {0} ", svv);
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
            if (!Is_P_Cate)
            {
                int len = e.Row.Cells.Count;
                e.Row.Cells.RemoveAt(len - 2);
                e.Row.Cells.RemoveAt(len - 3);
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
                    DetectPointTemplateEntity et = BusinessFacadeShanliTech_HLD_Business.DetectPointTemplateDisp(IDX);
                    et.DataTable_Action_ = DataTable_Action.Update;
                    et.DelFlag = true;
                    BusinessFacadeShanliTech_HLD_Business.DetectPointTemplateInsertUpdateDelete(et);
                }
            }

            EventMessage.MessageBox(1, "批量删除成功", string.Format("批量删除({0})成功!", Checkbox_Value), Icon_Type.OK, Common.GetHomeBaseUrl("DefaultPoint.aspx?FunctionID=" + FunctionID + "&DeviceID=" + DeviceID));
        }
    }
}
