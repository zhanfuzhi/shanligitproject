/********************************************************************************
     File:																
            Default.aspx.cs                         
     Description:
            DeviceTemplate列表
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

namespace ShanliTech_HLD_Business.Web.Module.ShanliTech_HLD_Business.DeviceTemplate
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ToolMethods.InitDropDownCurrentGroup(Group_DropDown);
                ToolMethods.InitDropDownDeviceCate(DeviceCategory_DropDown);
                ToolMethods.InitDropDownInterfaceType(ConnectType_DropDown);
                ToolMethods.InitDropDownDetectType(DetectType_DropDown);
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
            List<DeviceTemplateEntity> lst = BusinessFacadeShanliTech_HLD_Business.DeviceTemplateList(qp, out RecordCount);
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
                    ViewState["SearchTerms"] = string.Format(" Where DelFlag = 0 And DeviceDepartmentID in (select GroupID from getAllChild({0}))", UserData.GetUserDate.U_GroupID);
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
            //string CertifcateNumPart_Value = (string)Common.sink(CertifcateNumPart_Input.UniqueID, MethodType.Post, 50, 0, DataType.Str);
           
            string DeviceFactory_Value = ((string)Common.sink(DeviceFactory_Input.UniqueID, MethodType.Post, 50, 0, DataType.Str)).Trim();
            string DeviceModel_Value = ((string)Common.sink(DeviceModel_Input.UniqueID, MethodType.Post, 50, 0, DataType.Str)).Trim();
            string DeviceName_Value = ((string)Common.sink(DeviceName_Input.UniqueID, MethodType.Post, 50, 0, DataType.Str)).Trim();
            //string DeviceNum_Value = (string)Common.sink(DeviceNum_Input.UniqueID, MethodType.Post, 50, 0, DataType.Str);
            
          
            string DetectType_Value = DetectType_DropDown.SelectedValue;
            string DeviceCategoryID_Value = DeviceCategory_DropDown.SelectedValue;
            string ConnectType_Value = ConnectType_DropDown.SelectedValue;
            string DeviceDepartmentID_Value = Group_DropDown.SelectedValue;
            string AccuracyLevel_Value = ((string)Common.sink(AccuracyLevel_Input.UniqueID, MethodType.Post, 50, 0, DataType.Str)).Trim();
            

            StringBuilder sb = new StringBuilder();
            sb.Append(" Where DelFlag = 0 ");
                    
//if (CertifcateNumPart_Value != string.Empty)
//{
//    sb.AppendFormat(" AND CertifcateNumPart like '%{0}%' ", Common.inSQL(CertifcateNumPart_Value));
//}
                    
                    
if (DetectType_Value != string.Empty && !DetectType_Value.Equals("0"))
{
    sb.AppendFormat(" AND DetectType = {0} ", Convert.ToInt32(DetectType_Value));
}
                    
if (DeviceFactory_Value != string.Empty)
{
    sb.AppendFormat(" AND DeviceFactory like '%{0}%' ", Common.inSQL(DeviceFactory_Value));
}
                    
if (DeviceModel_Value != string.Empty)
{
    sb.AppendFormat(" AND DeviceModel like '%{0}%' ", Common.inSQL(DeviceModel_Value));
}
                    
if (DeviceName_Value != string.Empty)
{
    sb.AppendFormat(" AND DeviceName like '%{0}%' ", Common.inSQL(DeviceName_Value));
}
                    
//if (DeviceNum_Value != string.Empty)
//{
//    sb.AppendFormat(" AND DeviceNum like '%{0}%' ", Common.inSQL(DeviceNum_Value));
//}
                    
if (DeviceCategoryID_Value != string.Empty && !DeviceCategoryID_Value.Equals("0"))
{
    sb.AppendFormat(" AND DeviceCategoryID = {0} ", Convert.ToInt32(DeviceCategoryID_Value));
}
           

if (DeviceDepartmentID_Value != string.Empty && !DeviceDepartmentID_Value.Equals("0"))
{
    sb.AppendFormat(" AND DeviceDepartmentID in (select GroupID from getAllChild({0}))", UserData.GetUserDate.U_GroupID);
}
        
                    
if (ConnectType_Value != string.Empty && !ConnectType_Value.Equals("0"))
{
    sb.AppendFormat(" AND ConnectType = {0} ", Convert.ToInt32(ConnectType_Value));
}

if (AccuracyLevel_Value != string.Empty)
{
    sb.AppendFormat(" AND AccuracyLevel = {0} ", Convert.ToDouble(AccuracyLevel_Value));
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
                    ToolMethods.TemplateFunctionAndPointDeleteByDeviceID(IDX);//级联删除相关功能模板及功能测试点模板

                    DeviceTemplateEntity et = BusinessFacadeShanliTech_HLD_Business.DeviceTemplateDisp(IDX);
                    et.DataTable_Action_ = DataTable_Action.Update;
                    et.DelFlag = true;
                    BusinessFacadeShanliTech_HLD_Business.DeviceTemplateInsertUpdateDelete(et);
                }
            }

            EventMessage.MessageBox(1, "批量删除成功", string.Format("批量删除({0})成功!", Checkbox_Value), Icon_Type.OK, Common.GetHomeBaseUrl("default.aspx"));
        }

        //设备指令数据
        protected string AssembleCmdLinkString(object ID, object DeviceModel)
        {
            int _ID = 0;
            if (Int32.TryParse(ID.ToString(), out _ID))
            {
                bool _IsElectrict = ToolMethods.IsElectrictTemplate(_ID);
                if (_IsElectrict)
                    return string.Format("<a href=\"javascript:AssembleCmdPop({0},'{1}');\">设备指令数据</a>", _ID, Convert.ToString(DeviceModel));
            }
            return string.Empty;
        }
        protected string CreatePointLinkString(object ID)
        {
            int _ID = 0;
            if (Int32.TryParse(ID.ToString(), out _ID))
            {
                bool _IsElectrict = ToolMethods.IsElectrictTemplate(_ID);
                if (_IsElectrict)
                    return string.Format("<a href=\"javascript:showPopWin('速成检定点','CreateDetectPoint.aspx?IDX={0}&rand'+rand(100000000),920, 480, AlertMessageBox,true)\">速成检定点</a>", _ID);
            }
            return string.Empty;
        }
    }
}
