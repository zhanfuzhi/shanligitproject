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
using FrameWork.WebControls;
using System.Text;

namespace FrameWork.web.Manager.Module.ShanliTech_HLD.Device
{
    public partial class AddByFunctionTemplate : System.Web.UI.Page
    {
        string DeviceTemplateID = (string)Common.sink("DeviceTemplateID", MethodType.Get, 10, 0, DataType.Str);
        string DeviceID = (string)Common.sink("DeviceID", MethodType.Get, 10, 0, DataType.Str);
        string CMD = (string)Common.sink("CMD", MethodType.Get, 10, 1, DataType.Str);
        protected void Page_Load(object sender, EventArgs e)
        {
            FrameWorkPermission.CheckPagePermission(CMD);
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
            qp.PageIndex = 1; //AspNetPager1.CurrentPageIndex;
            qp.PageSize = int.MaxValue;// AspNetPager1.PageSize;
            qp.Orderfld = "DeviceID,OrderID";
            qp.OrderType = 0;
            int RecordCount = 0;
            List<DeviceFunctionTemplateEntity> lst = BusinessFacadeShanliTech_HLD_Business.DeviceFunctionTemplateList(qp, out RecordCount);
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
                {
                    int TIDX = 0;
                    if (!string.IsNullOrEmpty(DeviceTemplateID))
                    {
                        if (Int32.TryParse(DeviceTemplateID, out TIDX))
                        {
                            ViewState["SearchTerms"] = string.Format(" Where DelFlag = 0 And DeviceID = {0}", TIDX);
                            return (string)ViewState["SearchTerms"];
                        }
                    }
                    else
                    {
                        if (Int32.TryParse(DeviceID, out TIDX))
                        {
                            int cate = BusinessFacadeShanliTech_HLD_Business.DeviceDisp(TIDX).DeviceCategoryID;
                            ViewState["SearchTerms"] = string.Format(" Where DelFlag = 0 And DeviceID in (select ID from DeviceTemplate where DeviceCategoryID = {0})", cate);
                            return (string)ViewState["SearchTerms"];
                        }
                    }
                    ViewState["SearchTerms"] = " Where DelFlag = 0 ";
                }
                return (string)ViewState["SearchTerms"];
            }
            set { ViewState["SearchTerms"] = value; }
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
                   //增加check列头全选
                    TableCell cell = new TableCell();
                    cell.Width = Unit.Pixel(5);
                    cell.Text = " <input id='CheckboxAll' value='0' type='checkbox' onclick='SelectAll()'/>";
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
                    cell.Text = string.Format(" <input name='Checkbox' id='Checkbox' value='{0}' type='checkbox' />", DataIDX);
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
            string _tip = string.Empty;
            string Checkbox_Value = (string)Common.sink("Checkbox", MethodType.Post, 2000, 0, DataType.Str);

            if (string.IsNullOrEmpty(Checkbox_Value))
            {
                _tip = "请选择设备功能模板！";
                Common.MessBox(_tip);
            }else
            {
                Response.Redirect(Common.GetHomeBaseUrl(string.Format("AddByPointTemplate.aspx?CMD=New&FunctionTemplateIDs={0}&DeviceTemplateID={1}&&DeviceID={2}", Checkbox_Value, DeviceTemplateID,DeviceID)));
            }
        }
        /// <summary>
        /// 完成
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button3_Click(object sender, EventArgs e)
        {
            string _tip = string.Empty;
            string Checkbox_Value = (string)Common.sink("Checkbox", MethodType.Post, 2000, 0, DataType.Str);
            //保存设备
            int DIDX=0;
            if (string.IsNullOrEmpty(DeviceID) && string.IsNullOrEmpty(DeviceTemplateID))
            {
                Common.MessBox("给定参数有误，可以点击\"取消\"按钮重新尝试添加！");
                return;
            }
            //首选是依据模板编号添加，其次为针对设备选择功能模板添加功能
            if (!string.IsNullOrEmpty(DeviceTemplateID) && Int32.TryParse(DeviceTemplateID, out DIDX))
            {
                DeviceTemplateEntity dte = BusinessFacadeShanliTech_HLD_Business.DeviceTemplateDisp(DIDX);
                dte.DataTable_Action_ = DataTable_Action.Insert;
                dte.DeviceDepartmentID = UserData.GetUserDate.U_GroupID;
                DeviceID = ToolMethods.ReverseDeviceAndPersistance(dte).ToString();
            }

            //如果是在功能列表页面直接根据模板添加功能，则必须选择选项
            if(string.IsNullOrEmpty(DeviceTemplateID))
            {
                if (string.IsNullOrEmpty(Checkbox_Value))
                {
                    Common.MessBox("请选择设备功能模板！");
                    return;
                }
            }
            //保存功能
            if (!string.IsNullOrEmpty(Checkbox_Value) && Checkbox_Value.Length > 0)
            {
                string[] Checkbox_Value_Array = Checkbox_Value.Split(',');
                Int32 IDX = 0;
                for (int i = 0; i < Checkbox_Value_Array.Length; i++)
                {
                    if (Int32.TryParse(Checkbox_Value_Array[i], out IDX))
                    {
                        DeviceFunctionTemplateEntity dft = BusinessFacadeShanliTech_HLD_Business.DeviceFunctionTemplateDisp(IDX);
                        dft.DeviceID = Convert.ToInt32(DeviceID);
                        dft.DataTable_Action_ = DataTable_Action.Insert;
                        ToolMethods.ReverseFunctionAndPersistance(dft);
                    }
                }
            }
            string msg = string.Empty;
            if (Convert.ToInt32(DeviceID) > 0)
                msg = "操作成功！";
            else
                msg = "操作失败！";

            Page.ClientScript.RegisterStartupScript(typeof(string), "TabJs", "<script language='javascript'>window.returnVal='"+msg+"';window.parent.hidePopWin(true);</script>");
        }
        
    }
}
