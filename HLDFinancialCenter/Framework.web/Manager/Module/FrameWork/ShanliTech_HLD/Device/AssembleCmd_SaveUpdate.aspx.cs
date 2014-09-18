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
using System.Collections.Generic;
using ShanliTech_HLD_Business.Components;
using FrameWork.Components;
using ShanliTech_HLD_Business;

namespace FrameWork.web.Manager.Module.ShanliTech_HLD.Device
{
    public partial class AssembleCmd_SaveUpdate : System.Web.UI.Page
    {
        Int32 IDX = (Int32)Common.sink("IDX", MethodType.Get, 10, 0, DataType.Int);
        Int32 DeviceID = (Int32)Common.sink("DeviceID", MethodType.Get, 10, 0, DataType.Int);
        string CMD = (string)Common.sink("CMD", MethodType.Get, 10, 0, DataType.Str);
        protected string DeviceModel = (string)Common.sink("DeviceModel", MethodType.Get, 50, 0, DataType.Str);
        protected string CmdIdentity = (string)Common.sink("CmdIdentity", MethodType.Get, 50, 0, DataType.Str);
        protected string BackUrl = (string)Common.sink("BackUrl", MethodType.Get, 200, 0, DataType.Str);
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(CMD)) CMD = "New";

            if (!Page.IsPostBack)
            {
                InitCmdTypeDropDown();
                InitCmdIdentityDropDown();
                OnStart();
            }
            BindDataList();
        }
        /// <summary>
        /// 绑定数据
        /// </summary>
        private void BindDataList()
        {
            QueryParam qp = new QueryParam();
            qp.Where = string.Format("Where DeviceModel = '{0}'", DeviceModel);
            qp.Orderfld = Orderfld;
            qp.OrderType = OrderType;
            int RecordCount = 0;
            List<CommandAssembleEntity> lst = BusinessFacadeShanliTech_HLD_Business.CommandAssembleList(qp, out RecordCount);
            GridView1.DataSource = lst;
            GridView1.DataBind();
        }

        private void InitCmdTypeDropDown() 
        {
            CmdType_DropDown.Items.Clear();

            ListItem listItem = new ListItem();
            listItem.Text = "设备常规指令";
            listItem.Value = "0";
            CmdType_DropDown.Items.Add(listItem);

            ListItem dropItem = null;
            List<DeviceFunctionEntity> funcList = ToolMethods.GetFunctionsByDeviceID(DeviceID);
            foreach (DeviceFunctionEntity item in funcList)
            {
                dropItem = new ListItem(item.FunctionName, item.FunctionCode);
                CmdType_DropDown.Items.Add(dropItem);
            }
        }
        private void InitCmdIdentityDropDown()
        {
            CommandIdentity_DropDown.Items.Clear();

            string _CmdType = CmdType_DropDown.SelectedValue;
            ListItem item = null;

            if ("0".Equals(_CmdType))
            {
                item = new ListItem("复位", "CmdReset");
                CommandIdentity_DropDown.Items.Add(item);
                item = new ListItem("清零", "CmdZero");
                CommandIdentity_DropDown.Items.Add(item);
                item = new ListItem("读", "CmdRead");
                CommandIdentity_DropDown.Items.Add(item);
                item = new ListItem("停止输出", "CmdStby");
                CommandIdentity_DropDown.Items.Add(item);
                item = new ListItem("指令前缀", "SetCmdPerfix");
                CommandIdentity_DropDown.Items.Add(item);
                item = new ListItem("指令后缀", "SetCmdSuffix");
                CommandIdentity_DropDown.Items.Add(item);
            }
            else
            {
                item = new ListItem("切换功能", "SwitchFuncCmdCode");
                CommandIdentity_DropDown.Items.Add(item);
                item = new ListItem("切换精度", "SwitchRESCmdCode");
                CommandIdentity_DropDown.Items.Add(item);
            }
        }

        /// <summary>
        /// 开始操作
        /// </summary>
        private void OnStart()
        {
            CommandAssembleEntity ut = BusinessFacadeShanliTech_HLD_Business.CommandAssembleDisp(IDX);
            OnStartData(ut);
            switch (CMD)
            {
                case "New":
                    Hidden_Disp();
                    break;
                case "List":
                    Hidden_Input();
                    break;
                case "Edit":
                    Hidden_Disp();
                    break;
                case "Delete":
                    break;
                default:
                    EventMessage.MessageBox(2, "不存在操作字符串!", "不存在操作字符串!", Icon_Type.Error, Common.GetHomeBaseUrl("AssembleCmd_SaveUpdate.aspx?DeviceID=" + DeviceID + "&DeviceModel=" + DeviceModel + "&CmdIdentity=" + CmdIdentity + "&BackUrl=" + BackUrl));
                    break;
            }
            DeviceModel_Input.Visible = false;
            DeviceModel_Disp.Visible = true;
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
                    Button3.Visible = true;
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
                DataIDX = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "ID"));
                if (FrameWorkPermission.CheckButtonPermission(PopedomType.Delete))
                {
                    //增加行选项
                    TableCell cell = new TableCell();
                    cell.Width = Unit.Pixel(5);
                    cell.Text = string.Format(" <input name='Checkbox' id='Checkbox' value='{0}' type='checkbox' />", DataIDX);
                    e.Row.Cells.AddAt(0, cell);
                }
                //控制修改连接
                string _Identity = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "CommandIdentity"));
                if (DeviceID <= 0 && _Identity.IndexOf("_") != -1)
                {
                    e.Row.Cells[5].Text = "修改";
                }
                else
                {
                    e.Row.Cells[5].Text = string.Format("<a href=\"?CMD=Edit&IDX={0}&DeviceModel={1}&CmdIdentity={2}&BackUrl={3}&DeviceID={4}\">修改</a>", DataIDX, DeviceModel, CmdIdentity, BackUrl, DeviceID);
                
                }
            }
            
        }
        #endregion

        /// <summary>
        /// 初始化数据
        /// </summary>
        /// <param name="ut"></param>
        private void OnStartData(CommandAssembleEntity ut)
        {
            DeviceModel_Disp.Text = DeviceModel_Input.Text = DeviceModel;
            int underlineIndex = ut.CommandIdentity.IndexOf("_");
            if (underlineIndex != -1)
            {
                CmdType_DropDown.SelectedValue = ut.CommandIdentity.Substring(0, underlineIndex);
                InitCmdIdentityDropDown();
            }
            CommandIdentity_DropDown.SelectedValue = (string.IsNullOrEmpty(CmdIdentity) ? ut.CommandIdentity.Substring(underlineIndex + 1) : CmdIdentity);
            CommandIdentity_Disp.Text = (string.IsNullOrEmpty(CmdIdentity) ? ut.CommandIdentity : CmdIdentity);
            CommandName_Input.Text = CommandName_Disp.Text = ut.CommandName.ToString();
            CommandCode_Input.Text = CommandCode_Disp.Text = ut.CommandCode.ToString();

        }

        /// <summary>
        /// 隐藏输入框
        /// </summary>
        private void Hidden_Input()
        {
            CommandIdentity_DropDown.Visible = false;
            CommandName_Input.Visible = false;
            CommandCode_Input.Visible = false;

        }

        /// <summary>
        /// 隐藏显示框
        /// </summary>
        private void Hidden_Disp()
        {
            CommandIdentity_Disp.Visible = false;
            CommandName_Disp.Visible = false;
            CommandCode_Disp.Visible = false;

        }

        //新增
        protected void Button1_Click(object sender, EventArgs e)
        {
            //CommandIdentity_Input.Text = string.Empty;
            CommandName_Input.Text = string.Empty;
            CommandCode_Input.Text = string.Empty;
        }
        //保存
        protected void Button2_Click(object sender, EventArgs e)
        {
            string DeviceModel_Value = DeviceModel;// (string)Common.sink(DeviceModel_Input.UniqueID, MethodType.Post, 50, 0, DataType.Str);
            string CommandIdentity_Value = CommandIdentity_DropDown.SelectedValue;//(string)Common.sink(CommandIdentity_Input.UniqueID, MethodType.Post, 50, 0, DataType.Str);
            string IdentityPerfix_Value = CmdType_DropDown.SelectedValue;
            string CommandName_Value = (string)Common.sink(CommandName_Input.UniqueID, MethodType.Post, 50, 0, DataType.Str);
            string CommandCode_Value = (string)Common.sink(CommandCode_Input.UniqueID, MethodType.Post, 50, 0, DataType.Str);

            CommandIdentity_Value = ("0".Equals(IdentityPerfix_Value) ? "" : (IdentityPerfix_Value+"_")) + CommandIdentity_Value;

            CommandAssembleEntity ut = BusinessFacadeShanliTech_HLD_Business.CommandAssembleDisp(IDX);
            ut.DeviceModel = DeviceModel_Value;
            ut.CommandIdentity = CommandIdentity_Value;
            ut.CommandName = CommandName_Value;
            ut.CommandCode = CommandCode_Value;

            if (CMD == "New")
            {
                ut.DataTable_Action_ = DataTable_Action.Insert;
            }
            else if (CMD == "Edit")
            {
                ut.DataTable_Action_ = DataTable_Action.Update;
            }
            else
            {
                EventMessage.MessageBox(2, "不存在操作字符串!", "不存在操作字符串!", Icon_Type.Error, Common.GetHomeBaseUrl("AssembleCmd_SaveUpdate.aspx?DeviceID=" + DeviceID + "&DeviceModel=" + DeviceModel + "&CmdIdentity=" + CmdIdentity + "&BackUrl=" + BackUrl));
            }
            Int32 rInt = BusinessFacadeShanliTech_HLD_Business.CommandAssembleInsertUpdateDelete(ut);
            if (rInt > 0)
            {
                string OpTxt = string.Format("增加指令集成功!(ID:{0})", rInt);
                if (ut.DataTable_Action_ == DataTable_Action.Update)
                    OpTxt = string.Format("修改指令集成功!(ID:{0})", IDX);
                EventMessage.MessageBox(1, "操作成功", OpTxt, Icon_Type.OK, Common.GetHomeBaseUrl("AssembleCmd_SaveUpdate.aspx?DeviceID=" + DeviceID + "&DeviceModel=" + DeviceModel + "&CmdIdentity=" + CmdIdentity + "&BackUrl=" + BackUrl));
            }
            else if (rInt == -2)
            {
                EventMessage.MessageBox(1, "操作失败", "操作失败,存在相同的键值(用户名/数据)!", Icon_Type.Alert, Common.GetHomeBaseUrl("AssembleCmd_SaveUpdate.aspx?DeviceID=" + DeviceID + "&DeviceModel=" + DeviceModel + "&CmdIdentity=" + CmdIdentity + "&BackUrl=" + BackUrl));
            }
            else
            {
                EventMessage.MessageBox(1, "操作失败", string.Format("操作失败,返回值:{0}!", rInt), Icon_Type.Error, Common.GetHomeBaseUrl("AssembleCmd_SaveUpdate.aspx?DeviceID=" + DeviceID + "&DeviceModel=" + DeviceModel + "&CmdIdentity=" + CmdIdentity + "&BackUrl=" + BackUrl));
            }
        }
        protected void Button3_Click(object sender, EventArgs e)
        {
            string Checkbox_Value = (string)Common.sink("Checkbox", MethodType.Post, 2000, 1, DataType.Str);
            string[] Checkbox_Value_Array = Checkbox_Value.Split(',');
            Int32 IDX = 0;
            for (int i = 0; i < Checkbox_Value_Array.Length; i++)
            {
                if (Int32.TryParse(Checkbox_Value_Array[i], out IDX))
                {
                    CommandAssembleEntity et = new CommandAssembleEntity();
                    et.DataTable_Action_ = DataTable_Action.Delete;
                    et.ID = IDX;
                    BusinessFacadeShanliTech_HLD_Business.CommandAssembleInsertUpdateDelete(et);
                }
            }

            EventMessage.MessageBox(1, "批量删除成功", string.Format("批量删除({0})成功!", Checkbox_Value), Icon_Type.OK, Common.GetHomeBaseUrl("AssembleCmd_SaveUpdate.aspx?DeviceID=" + DeviceID + "&DeviceModel=" + DeviceModel + "&CmdIdentity=" + CmdIdentity + "&BackUrl=" + BackUrl));
        }

        //返回
        protected void Button4_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.BackUrl))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "PopWin", "<script language='javascript'>window.parent.hidePopWin(false);</script>");
            }
            else
            {
                Response.Redirect(this.BackUrl + "?DeviceID=" + DeviceID + "&DeviceModel=" + DeviceModel + "&CmdIdentity=" + CmdIdentity);
            }
        }

        protected void CmdType_DropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            InitCmdIdentityDropDown();
        }

    }
}
