/********************************************************************************
     File:																
            Default.aspx.cs                         
     Description:
            DeviceFunction列表
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
using System.Drawing;

namespace ShanliTech_HLD_Business.Web.Module.ShanliTech_HLD_Business.Device
{
    public partial class DefaultFunction : System.Web.UI.Page
    {
        public Int32 DeviceID = (Int32)Common.sink("DeviceID", MethodType.Get, 10, 0, DataType.Int);
        string CMD = (string)Common.sink("CMD", MethodType.Get, 10, 0, DataType.Str);
        protected void Page_Load(object sender, EventArgs e)
        {
            AddNewButton();
            AddBackButton();
            if (!Page.IsPostBack)
            {
                if (!string.IsNullOrEmpty(CMD))
                {
                    string funcIDStr = Request.Params["FunctionID"];
                    int funcID = 0;
                    if (Int32.TryParse(funcIDStr, out funcID))
                    {
                        DeviceFunctionEntity func = BusinessFacadeShanliTech_HLD_Business.DeviceFunctionDisp(funcID);
                        switch (CMD)
                        {
                            case "Up":
                                ToolMethods.MoverUpFunction(func);
                                break;
                            case "Down":
                                ToolMethods.MoverDownFunction(func);
                                break;
                        }
                    }
                }
                //ToolMethods.InitDropDownDevice(DeviceID_DropDown);
                BindDataList();
            }
        }
        private void AddBackButton()
        {
            HeadMenuButtonItem bi = new HeadMenuButtonItem();
            bi.ButtonPopedom = PopedomType.List;
            bi.ButtonName = "设备";
            bi.ButtonUrl = "Default.aspx";
            HeadMenuWebControls1.ButtonList.Add(bi);
        }
        /// <summary>
        /// 增加增加按钮
        /// </summary>
        private void AddNewButton()
        {
            HeadMenuButtonItem bi = new HeadMenuButtonItem();
            bi.ButtonPopedom = PopedomType.New;
            bi.ButtonName = "设备功能";
            bi.ButtonUrl = string.Format("ManagerFunction.aspx?CMD=New&DeviceID={0}", DeviceID);
            HeadMenuWebControls1.ButtonList.Add(bi);

            bi = new HeadMenuButtonItem();
            bi.ButtonPopedom = PopedomType.New;
            bi.ButtonUrlType = UrlType.JavaScript;
            bi.ButtonName = "通过模板创建";
            bi.ButtonUrl = "javascript:showPopWin('选择模板创建设备功能','AddByFunctionTemplate.aspx?CMD=New&DeviceID=" + DeviceID + "&rand'+rand(100000000),700, 420, AlertMessageBox,true)";
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
            List<DeviceFunctionEntity> lst = BusinessFacadeShanliTech_HLD_Business.DeviceFunctionList(qp, out RecordCount);
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
                    ViewState["SearchTerms"] = string.Format(" Where DelFlag = 0 And DeviceID = {0}", DeviceID);
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
            //string AccuracyLevel_Value = (string)Common.sink(AccuracyLevel_Input.UniqueID, MethodType.Post, 50, 0, DataType.Str);
            string DetectBasisCode_Value = ((string)Common.sink(DetectBasisCode_Input.UniqueID, MethodType.Post, 50, 0, DataType.Str)).Trim();
            string DetectBasisName_Value = ((string)Common.sink(DetectBasisName_Input.UniqueID, MethodType.Post, 50, 0, DataType.Str)).Trim();
            
            string FunctionCode_Value = ((string)Common.sink(FunctionCode_Input.UniqueID, MethodType.Post, 50, 0, DataType.Str)).Trim();
            string FunctionName_Value = ((string)Common.sink(FunctionName_Input.UniqueID, MethodType.Post, 50, 0, DataType.Str)).Trim();
            //string TestRange_Value = (string)Common.sink(TestRange_Input.UniqueID, MethodType.Post, 50, 0, DataType.Str);
            
            //string SetCmdPerfix_Value = (string)Common.sink(SetCmdPerfix_Input.UniqueID, MethodType.Post, 50, 0, DataType.Str);
            //string SetCmdSuffix_Value = (string)Common.sink(SetCmdSuffix_Input.UniqueID, MethodType.Post, 50, 0, DataType.Str);
            //string ReadCmd_Value = (string)Common.sink(ReadCmd_Input.UniqueID, MethodType.Post, 100, 0, DataType.Str);

            //溯源有效期范围
            //string SourceValidDate_Start_Value = (string)Common.sink(SourceValidDate_Start_Input.UniqueID, MethodType.Post, 50, 0, DataType.Str);
            //string SourceValidDate_End_Value = (string)Common.sink(SourceValidDate_End_Input.UniqueID, MethodType.Post, 50, 0, DataType.Str);

            //string DeviceID_Value = DeviceID_DropDown.SelectedValue;
            string SourceValidDate = ((string)Common.sink(SourceValidDate_Input.UniqueID, MethodType.Post, 50, 0, DataType.Str)).Trim();


            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(" Where DelFlag = 0 And DeviceID = {0}",DeviceID);
                    
//if (AccuracyLevel_Value != string.Empty)
//{
//    sb.AppendFormat(" AND AccuracyLevel like '%{0}%' ", Common.inSQL(AccuracyLevel_Value));
//}
                    
if (DetectBasisCode_Value != string.Empty)
{
    sb.AppendFormat(" AND DetectBasisCode like '%{0}%' ", Common.inSQL(DetectBasisCode_Value));
}
                    
if (DetectBasisName_Value != string.Empty)
{
    sb.AppendFormat(" AND DetectBasisName like '%{0}%' ", Common.inSQL(DetectBasisName_Value));
}

//if (DeviceID_Value != string.Empty && !DeviceID_Value.Equals("0"))
//{
//    sb.AppendFormat(" AND DeviceID = {0} ", Convert.ToInt32(DeviceID_Value));
//}
                    
if (FunctionCode_Value != string.Empty)
{
    sb.AppendFormat(" AND FunctionCode like '%{0}%' ", Common.inSQL(FunctionCode_Value));
}
                    
if (FunctionName_Value != string.Empty)
{
    sb.AppendFormat(" AND FunctionName like '%{0}%' ", Common.inSQL(FunctionName_Value));
}
                    
//if (TestRange_Value != string.Empty)
//{
//    sb.AppendFormat(" AND TestRange like '%{0}%' ", Common.inSQL(TestRange_Value));
//}
//溯源有效期
if (!string.IsNullOrEmpty(SourceValidDate))
{
    sb.AppendFormat(" AND SourceValidDate like '%{0}%' ", Common.inSQL(SourceValidDate));
}
//if (SourceValidDate_Start_Value != string.Empty && SourceValidDate_End_Value == string.Empty)
//{
//    sb.AppendFormat(" AND SourceValidDate > '{0}' ", Common.inSQL(SourceValidDate_Start_Value));
//}
//else if (SourceValidDate_End_Value != string.Empty && SourceValidDate_Start_Value == string.Empty)
//{
//    sb.AppendFormat(" AND SourceValidDate < '{0}' ", Common.inSQL(SourceValidDate_End_Value));
//}
//else if (SourceValidDate_Start_Value != string.Empty && SourceValidDate_End_Value != string.Empty)
//{
//    sb.AppendFormat(" AND SourceValidDate between '{0}' and '{1}' ", Common.inSQL(SourceValidDate_Start_Value), Common.inSQL(SourceValidDate_End_Value));
//}
//
   
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
                bool IsAdd = false;
                if (FrameWorkPermission.CheckButtonPermission(PopedomType.Delete))
                {
                    IsAdd = true;
                    //增加行选项
                    DataIDX = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "ID"));
                    TableCell cell = new TableCell();
                    cell.Width = Unit.Pixel(5);
                    cell.Text = string.Format(" <input name='Checkbox' id='Checkbox' value='{0}' type='checkbox' />", DataIDX);
                    e.Row.Cells.AddAt(0, cell);
                }
                if (Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "State")) > 0)
                {
                    TableCell SerialCell = null;
                    if (IsAdd)
                        SerialCell = e.Row.Cells[1];
                    else
                        SerialCell = e.Row.Cells[0];
                    SerialCell.BackColor = Color.Chocolate;
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
                    ToolMethods.PointDeleteByFunctionID(IDX);   //级联删除功能相关测试点

                    DeviceFunctionEntity et = BusinessFacadeShanliTech_HLD_Business.DeviceFunctionDisp(IDX);
                    et.DataTable_Action_ = DataTable_Action.Update;
                    et.DelFlag = true;
                    BusinessFacadeShanliTech_HLD_Business.DeviceFunctionInsertUpdateDelete(et);
                }
            }

            EventMessage.MessageBox(1, "批量删除成功", string.Format("批量删除({0})成功!", Checkbox_Value), Icon_Type.OK, Common.GetHomeBaseUrl("DefaultFunction.aspx?DeviceID="+DeviceID));
        }

        protected string PermitErrorLinkString(object FuncID,object DeviceID)
        {
            int _ID = 0;
            if (Int32.TryParse(DeviceID.ToString(), out _ID))
            {
                bool _IsElectrict = ToolMethods.IsElectrict(_ID);
                if (_IsElectrict)
                    return string.Format("<a href=\"javascript:AlertPermitErrorWindow({0})\">量程误差数据</a>", Convert.ToInt32(FuncID));
            }
            return string.Empty;
        }
        
    }
}
