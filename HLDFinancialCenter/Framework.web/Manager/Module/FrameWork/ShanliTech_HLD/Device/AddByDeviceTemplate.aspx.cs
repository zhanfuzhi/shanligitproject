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
using FrameWork.Components;
using ShanliTech_HLD_Business.Components;
using System.Collections.Generic;
using ShanliTech_HLD_Business;

namespace FrameWork.web.Manager.Module.ShanliTech_HLD.Device
{
    public partial class AddByDeviceTemplate : System.Web.UI.Page
    {
        string CMD = (string)Common.sink("CMD", MethodType.Get, 10, 1, DataType.Str);
        protected void Page_Load(object sender, EventArgs e)
        {
            FrameWorkPermission.CheckPagePermission(CMD);
            //if (!Page.IsPostBack)
            //{
                BindDataList();
            //}
        }
        /// <summary>
        /// 绑定数据
        /// </summary>
        private void BindDataList()
        {
            QueryParam qp = new QueryParam();
            qp.Where = SearchTerms;
            qp.PageSize = int.MaxValue;
            qp.PageIndex = 1;
            //qp.PageIndex = AspNetPager1.CurrentPageIndex;
            //qp.PageSize = AspNetPager1.PageSize;
            qp.Orderfld = Orderfld;
            qp.OrderType = OrderType;
            int RecordCount = 0;
            List<DeviceTemplateEntity> lst = BusinessFacadeShanliTech_HLD_Business.DeviceTemplateList(qp, out RecordCount);
            GridView1.DataSource = lst;
            GridView1.DataBind();
            //this.AspNetPager1.RecordCount = RecordCount;
        }

        /// <summary>
        /// 点击分页事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        //{
        //    BindDataList();
        //}

        /// <summary>
        /// 查询条件
        /// </summary>
        private string SearchTerms
        {
            get
            {
                if (ViewState["SearchTerms"] == null)
                    ViewState["SearchTerms"] = " Where DelFlag = 0 ";
                return (string)ViewState["SearchTerms"];
            }
            set { ViewState["SearchTerms"] = value; }
        }

        #region 暂时无用
        ///// <summary>
        ///// 查询数据
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //protected void Button1_Click(object sender, EventArgs e)
        //{
        //    string CertifcateNumPart_Value = (string)Common.sink(CertifcateNumPart_Input.UniqueID, MethodType.Post, 50, 0, DataType.Str);

        //    string DeviceFactory_Value = (string)Common.sink(DeviceFactory_Input.UniqueID, MethodType.Post, 50, 0, DataType.Str);
        //    string DeviceModel_Value = (string)Common.sink(DeviceModel_Input.UniqueID, MethodType.Post, 50, 0, DataType.Str);
        //    string DeviceName_Value = (string)Common.sink(DeviceName_Input.UniqueID, MethodType.Post, 50, 0, DataType.Str);
        //    string DeviceNum_Value = (string)Common.sink(DeviceNum_Input.UniqueID, MethodType.Post, 50, 0, DataType.Str);


        //    string DetectType_Value = DetectType_DropDown.SelectedValue;
        //    string DeviceCategoryID_Value = DeviceCategory_DropDown.SelectedValue;
        //    string ConnectType_Value = ConnectType_DropDown.SelectedValue;
        //    string DeviceDepartmentID_Value = Group_DropDown.SelectedValue;

        //    StringBuilder sb = new StringBuilder();
        //    sb.Append(" Where DelFlag = 0 ");

        //    if (CertifcateNumPart_Value != string.Empty)
        //    {
        //        sb.AppendFormat(" AND CertifcateNumPart like '%{0}%' ", Common.inSQL(CertifcateNumPart_Value));
        //    }


        //    if (DetectType_Value != string.Empty && !DetectType_Value.Equals("0"))
        //    {
        //        sb.AppendFormat(" AND DetectType = {0} ", Convert.ToInt32(DetectType_Value));
        //    }

        //    if (DeviceFactory_Value != string.Empty)
        //    {
        //        sb.AppendFormat(" AND DeviceFactory like '%{0}%' ", Common.inSQL(DeviceFactory_Value));
        //    }

        //    if (DeviceModel_Value != string.Empty)
        //    {
        //        sb.AppendFormat(" AND DeviceModel like '%{0}%' ", Common.inSQL(DeviceModel_Value));
        //    }

        //    if (DeviceName_Value != string.Empty)
        //    {
        //        sb.AppendFormat(" AND DeviceName like '%{0}%' ", Common.inSQL(DeviceName_Value));
        //    }

        //    if (DeviceNum_Value != string.Empty)
        //    {
        //        sb.AppendFormat(" AND DeviceNum like '%{0}%' ", Common.inSQL(DeviceNum_Value));
        //    }

        //    if (DeviceCategoryID_Value != string.Empty && !DeviceCategoryID_Value.Equals("0"))
        //    {
        //        sb.AppendFormat(" AND DeviceCategoryID = {0} ", Convert.ToInt32(DeviceCategoryID_Value));
        //    }


        //    if (DeviceDepartmentID_Value != string.Empty && !DeviceDepartmentID_Value.Equals("0"))
        //    {
        //        sb.AppendFormat(" AND DeviceDepartmentID = {0} ", Convert.ToInt32(DeviceDepartmentID_Value));
        //    }
        //    else
        //    {
        //        sb.AppendFormat(" AND DeviceDepartmentID in (select GroupID from getAllChild({0}))", UserData.GetUserDate.U_GroupID);
        //    }


        //    if (ConnectType_Value != string.Empty && !ConnectType_Value.Equals("0"))
        //    {
        //        sb.AppendFormat(" AND ConnectType = {0} ", Convert.ToInt32(ConnectType_Value));
        //    }


        //    ViewState["SearchTerms"] = sb.ToString();
        //    BindDataList();
        //    TabOptionWebControls1.SelectIndex = 0;
        //}
        #endregion 

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
                //增加check列头全选
                    TableCell cell = new TableCell();
                    cell.Width = Unit.Pixel(5);
                    cell.Text = " ";
                    e.Row.Cells.AddAt(0, cell);
                
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
                  //增加行选项
                    DataIDX = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "ID"));
                    TableCell cell = new TableCell();
                    cell.Width = Unit.Pixel(5);
                    cell.Text = string.Format(" <input name='RadioButton' id='RadioButton' value='{0}' type='radio' />", DataIDX);
                    e.Row.Cells.AddAt(0, cell);
                
            }
        }
        #endregion

        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {
            Page.ClientScript.RegisterStartupScript(typeof(string), "TabJs", "<script language='javascript'>window.parent.hidePopWin(false);</script>");
        }
        /// <summary>
        /// 下一步
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button2_Click(object sender, EventArgs e)
        {
            AddDeviceEvent(true);
        }
        /// <summary>
        /// 完成
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button3_Click(object sender, EventArgs e)
        {

            int rInt = AddDeviceEvent(false);
            //回到原窗体，并刷新页面
            string msg = string.Empty;
            if (rInt > 0)
                msg = "设备添加成功！（ID：" + rInt + "）";
            else
                msg = "设备添加失败！";
                            
            Page.ClientScript.RegisterStartupScript(typeof(string), "TabJs", "<script language='javascript'>window.returnVal='"+msg+"';window.parent.hidePopWin(true);</script>");
        }

        private int AddDeviceEvent(bool IsNext)
        {
            //Common.MessBox(Request.Params["RadioButton"]);
            string Radio_Value = (string)Common.sink("RadioButton", MethodType.Post, 2000, 0, DataType.Str);
            if (string.IsNullOrEmpty(Radio_Value) || "0".Equals(Radio_Value))
            {
                Common.MessBox("请先选择设备模板！");
            }
            else
            {

                if (IsNext)
                {
                    //跳转下一页，选择模板功能页
                    Response.Redirect(Common.GetHomeBaseUrl(string.Format("AddByFunctionTemplate.aspx?CMD=New&DeviceTemplateID={0}", Radio_Value)));
                }
                else
                {
                    int IDX = 0;
                    if (Int32.TryParse(Radio_Value, out IDX))
                    {
                        DeviceTemplateEntity dte = BusinessFacadeShanliTech_HLD_Business.DeviceTemplateDisp(IDX);
                        dte.DataTable_Action_ = DataTable_Action.Insert;
                        dte.DeviceDepartmentID = UserData.GetUserDate.U_GroupID;
                        return ToolMethods.ReverseDeviceAndPersistance(dte);
                    }
                }
            }
            return 0;
        }
    }
}
