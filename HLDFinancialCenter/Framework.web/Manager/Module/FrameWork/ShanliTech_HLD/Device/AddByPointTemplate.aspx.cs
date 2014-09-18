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
using ShanliTech_HLD_Business.PermitErrorCalculate;

namespace FrameWork.web.Manager.Module.ShanliTech_HLD.Device
{
    public partial class AddByPointTemplate : System.Web.UI.Page
    {
        string FunctionTemplateIDs = (string)Common.sink("FunctionTemplateIDs", MethodType.Get, 1000, 0, DataType.Str);
        string DeviceTemplateID = (string)Common.sink("DeviceTemplateID", MethodType.Get, 10, 0, DataType.Str);
        string DeviceID = (string)Common.sink("DeviceID", MethodType.Get, 10, 0, DataType.Str);
        string FunctionID = (string)Common.sink("FunctionID", MethodType.Get, 10, 0, DataType.Str);
        string CMD = (string)Common.sink("CMD", MethodType.Get, 10, 1, DataType.Str);
        bool Is_P_Cate = true;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(FunctionTemplateIDs))
            {
                int id=0;
                if (!string.IsNullOrEmpty(DeviceTemplateID))
                    id = Convert.ToInt32(DeviceTemplateID);
                else
                    id = Convert.ToInt32(FunctionTemplateIDs.Split(',')[0]);
                Is_P_Cate = ToolMethods.IsPresureDevice(id, true);
            }
            else
            {
                int did = ToolMethods.GetDeviceIDByFunction(Convert.ToInt32(FunctionID));
                Is_P_Cate = ToolMethods.IsPresureDevice(Convert.ToInt32(did), false);
            }
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
            qp.PageIndex = 1;// AspNetPager1.CurrentPageIndex;
            qp.PageSize = int.MaxValue;// AspNetPager1.PageSize;
            qp.Orderfld = "OrderID";
            qp.OrderType = 0;
            int RecordCount = 0;
            List<DetectPointTemplateEntity> lst = BusinessFacadeShanliTech_HLD_Business.DetectPointTemplateList(qp, out RecordCount);
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
                    if (!ValidateParamsError())
                    {
                        //如果从选择功能模板进入
                        if (!string.IsNullOrEmpty(FunctionTemplateIDs) && FunctionTemplateIDs.Length > 0)
                            ViewState["SearchTerms"] = string.Format(" Where DelFlag = 0 And FunctionID in ({0})", FunctionTemplateIDs);
                        //直接进入测试点模板选择
                        else
                        {

                            string fCode = BusinessFacadeShanliTech_HLD_Business.DeviceFunctionDisp(Convert.ToInt32(FunctionID)).FunctionCode;
                            ViewState["SearchTerms"] = string.Format(" Where DelFlag = 0 And FunctionCode = '{0}'", fCode);
                        }
                    }
                    else
                    {
                        ViewState["SearchTerms"] = " Where DelFlag = 0 ";
                    }
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
            //
            if (!Is_P_Cate)
            {
                int len = e.Row.Cells.Count;
                e.Row.Cells.RemoveAt(len - 1);
                e.Row.Cells.RemoveAt(len - 2);
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
        /// 完成
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button2_Click(object sender, EventArgs e)
        {
            string Checkbox_Value = (string)Common.sink("Checkbox", MethodType.Post, 2000, 0, DataType.Str);
            Dictionary<int, int> _tmp = new Dictionary<int, int>();
            //保存设备
            //功能模板编号有值，但是设备模板为空，则存在参数错误进行提醒；
            if (ValidateParamsError())
            {
                Common.MessBox("给定参数有误，可以点击\"取消\"按钮重新尝试添加！");

            }
            else
            {
                
                //首选从功能模板添加，其次为直接进行测试点模板选择添加
                if (!string.IsNullOrEmpty(FunctionTemplateIDs))
                {
                    int DID = 0;
                    if (!string.IsNullOrEmpty(DeviceTemplateID) && DeviceTemplateID.Length > 0)
                    {

                        if (Int32.TryParse(DeviceTemplateID, out DID))
                        {
                            DeviceTemplateEntity dte = BusinessFacadeShanliTech_HLD_Business.DeviceTemplateDisp(DID);
                            dte.DataTable_Action_ = DataTable_Action.Insert;
                            dte.DeviceDepartmentID = UserData.GetUserDate.U_GroupID;
                            DeviceID = ToolMethods.ReverseDeviceAndPersistance(dte).ToString();    //保存
                        }
                    }

                    //保存功能
                    DID = Convert.ToInt32(DeviceID);
                    if (DID > 0)
                    {
                        string[] FunctionTemplateIDs_Array = FunctionTemplateIDs.Split(',');
                        Int32 IDX = 0;
                        for (int i = 0; i < FunctionTemplateIDs_Array.Length; i++)
                        {
                            if (Int32.TryParse(FunctionTemplateIDs_Array[i], out IDX))
                            {
                                DeviceFunctionTemplateEntity dft = BusinessFacadeShanliTech_HLD_Business.DeviceFunctionTemplateDisp(IDX);
                                dft.DeviceID = DID;
                                dft.DataTable_Action_ = DataTable_Action.Insert;
                                int rInt = ToolMethods.ReverseFunctionAndPersistance(dft);  //保存
                                _tmp.Add(IDX, rInt);
                            }
                        }
                    }
                }

                //如果直接通过检测点列表页添加检测点，如果不选择任何，则提示！
                if(string.IsNullOrEmpty(FunctionTemplateIDs))
                {
                    if (string.IsNullOrEmpty(Checkbox_Value))
                    {
                        Common.MessBox("请选择功能检测点模板！");
                        return;
                    }
                }

                //保存检测点
                
                if (!string.IsNullOrEmpty(Checkbox_Value))
                {
                    string[] Checkbox_Value_Array = Checkbox_Value.Split(',');
                    int IDX = 0;
                    int tmpNew = 0;
                    DeviceEntity device = BusinessFacadeShanliTech_HLD_Business.DeviceDisp(ToolMethods.GetDeviceIDByFunction(Convert.ToInt32(FunctionID)));
                    PermitErrorCalculator calculator = new PermitErrorCalculator();
                    
                    for (int i = 0; i < Checkbox_Value_Array.Length; i++)
                    {
                        if (Int32.TryParse(Checkbox_Value_Array[i], out IDX))
                        {
                            DetectPointTemplateEntity dpt = BusinessFacadeShanliTech_HLD_Business.DetectPointTemplateDisp(IDX);

                            //替换Function编号
                            if (_tmp.Count > 0 && _tmp.TryGetValue(dpt.FunctionID, out tmpNew))
                            {
                                dpt.FunctionID = tmpNew;
                            }
                            else
                                dpt.FunctionID = Convert.ToInt32(FunctionID);
                            dpt.ValuePerMissibleErrorName = calculator.GetPermitError(device, dpt);
                            dpt.RoundLen = device.RoundLen; //小数位
                            ToolMethods.ReversePointAndPersistance(dpt);    //保存
                        }
                    }
                }
                Page.ClientScript.RegisterStartupScript(typeof(string), "TabJs", "<script language='javascript'>window.returnVal='操作成功！';window.parent.hidePopWin(true);</script>");
            }
        }

        /// <summary>
        /// 检测参数是否正确
        /// </summary>
        /// <returns></returns>
        private bool ValidateParamsError()
        {
            //return (string.IsNullOrEmpty(DeviceTemplateID) && !string.IsNullOrEmpty(FunctionTemplateIDs)) || (string.IsNullOrEmpty(FunctionTemplateIDs) && string.IsNullOrEmpty(FunctionID));
            return (string.IsNullOrEmpty(FunctionTemplateIDs) && string.IsNullOrEmpty(FunctionID)) || (string.IsNullOrEmpty(DeviceTemplateID) && string.IsNullOrEmpty(DeviceID)&&!string.IsNullOrEmpty(FunctionTemplateIDs));
        }
    }
}
