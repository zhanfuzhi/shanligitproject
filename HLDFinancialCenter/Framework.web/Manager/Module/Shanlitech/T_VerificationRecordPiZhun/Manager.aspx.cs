/********************************************************************************
     File:																
            Manager.aspx.cs                         
     Description:
            核销申请单管理
     Author:									
            DDBuildTools
            http://DDBuildTools.supesoft.com
     Finish DateTime:
            2014-6-27 18:28:22
     History:
*********************************************************************************/
using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using Shanlitech_Location;
using Shanlitech_Location.Components;
using FrameWork;
using FrameWork.Components;
using FrameWork.WebControls;
using System.IO;
using System.Collections.Generic;

namespace Shanlitech_Location.Web.Module.Shanlitech_Location.T_VerificationRecordPiZhun
{
    public partial class Manager : System.Web.UI.Page
    {
        Int32 IDX = (Int32)Common.sink("IDX", MethodType.Get, 10, 0, DataType.Int);
        string CMD = (string)Common.sink("CMD", MethodType.Get, 10, 1, DataType.Str);
        protected void Page_Load(object sender, EventArgs e)
        {
            FrameWorkPermission.CheckPagePermission(CMD);
            if (!Page.IsPostBack)
            {
                OnStart();
                BindDataList();
            }
        }
        
        /// <summary>
        /// 开始操作
        /// </summary>
        private void OnStart()
        {
            T_VerificationRecordEntity ut = BusinessFacadeShanlitech_Location.T_VerificationRecordDisp(IDX);
            OnStartData(ut);
            switch (CMD)
            { 
                case "New":
                    TabOptionItem1.Tab_Name = HeadMenuWebControls1.HeadOPTxt = "增加核销申请待批准单";
                    Hidden_Disp();
                    break;
                case "List":
                    TabOptionItem1.Tab_Name = HeadMenuWebControls1.HeadOPTxt = "查看核销申请待批准单";
                    Hidden_Input();
                    ButtonOption.Visible = false;
                    AddEditButton();
                    break;
                case "Edit":
                    TabOptionItem1.Tab_Name = HeadMenuWebControls1.HeadOPTxt = "修改核销申请待批准单";
                    Hidden_Disp();
                    AddDeleteButton();
                    break;
                case "Delete":
                    ut.DataTable_Action_ = DataTable_Action.Delete;
                    if (BusinessFacadeShanlitech_Location.T_VerificationRecordInsertUpdateDelete(ut) > 0)
                    {
                        EventMessage.MessageBox(1, "删除成功", string.Format("删除ID:{0}成功!", IDX), Icon_Type.OK, Common.GetHomeBaseUrl("Default.aspx"));
                    }
                    else {
                        EventMessage.MessageBox(1, "删除失败", string.Format("删除ID:{0}失败!", IDX), Icon_Type.Error, Common.GetHomeBaseUrl("Default.aspx"));
                    }
                    break;
                default :
                    EventMessage.MessageBox(2, "不存在操作字符串!", "不存在操作字符串!", Icon_Type.Error, Common.GetHomeBaseUrl("Default.aspx"));
                    break;
            }
        }

        /// <summary>
        /// 增加修改按钮
        /// </summary>
        private void AddEditButton()
        {
            HeadMenuButtonItem bi = new HeadMenuButtonItem();
            bi.ButtonPopedom = PopedomType.Edit;
            bi.ButtonName = "核销申请单";
            bi.ButtonUrl = string.Format("?CMD=Edit&IDX={0}", IDX);
            HeadMenuWebControls1.ButtonList.Add(bi);
        }


        /// <summary>
        /// 增加删除按钮
        /// </summary>
        private void AddDeleteButton()
        {
            //HeadMenuButtonItem bi = new HeadMenuButtonItem();
            //bi.ButtonPopedom = PopedomType.Delete;
            //bi.ButtonName = "核销申请待批准单";
            //bi.ButtonUrlType = UrlType.JavaScript;
            //bi.ButtonUrl = string.Format("DelData('?CMD=Delete&IDX={0}')", IDX);
            //HeadMenuWebControls1.ButtonList.Add(bi);

            //HeadMenuButtonItem bi1 = new HeadMenuButtonItem();
            //bi1.ButtonPopedom = PopedomType.List;
            //bi1.ButtonIcon = "back.gif";
            //bi1.ButtonName = "返回";
            //bi1.ButtonUrl = string.Format("?CMD=List&IDX={0}", IDX);
            //HeadMenuWebControls1.ButtonList.Add(bi1);
        }

        /// <summary>
        /// 初始化数据
        /// </summary>
        /// <param name="ut"></param>
        private void OnStartData(T_VerificationRecordEntity ut)
        {
            ProjID_Hidden.Value = ut.FundID.ToString();
            Protype_Hidden.Value = ut.ProjID.ToString();
            if (!ut.ProjID.Equals(0))
            {
                ProjID_Disp.Text = BusinessFacadeShanlitech_Location.GetProjectBudgetFormat(BusinessFacadeShanlitech_Location.T_ProjectBudgetDisp(ut.ProjID));
            }

            //imag_Fapiao.ImageUrl = ut.InvoiceFolder;
            //ContractFolder_Image.ImageUrl = ut.ContractFolder;
            ////PayAmount_Input.Text = 
            //    PayAmount_Disp.Text = ut.PayAmount.ToString();
            Undertaker_Disp.Text = BusinessFacade.sys_UserDisp(ut.Undertaker).U_LoginName;
            if (!string.IsNullOrEmpty(ut.CreateTime.ToString()))
            {
                CreateTime_Disp.Text = ut.CreateTime.ToString();
            }
            else
            {
                CreateTime_Disp.Text = DateTime.Now.ToString();
            }

            Check_Disp.Text = BusinessFacade.sys_UserDisp(ut.Checker).U_LoginName;
            if (!string.IsNullOrEmpty(ut.CheckTime.ToString()))
            {
                CheckTime_Disp.Text = ut.CheckTime.ToString();
            }
            else
            {
                CheckTime_Disp.Text = DateTime.Now.ToString();
            }
            PiZhunState_Disp.Text = ut.PiZhunNote;
            CheckState_Disp.Text = InnitList(ut.TransferState);
        }

        /// <summary>
        /// 初始化Grid
        /// </summary>
        public string InnitList(int p)
        {
            switch (p)
            {
                case (int)TransferState.PiZhun:
                    return "批准中";
                default:
                    return "批准未通过";
            }
        }

        /// <summary>
        /// 隐藏输入框
        /// </summary>
        private void Hidden_Input()
        {
            PiZhunState_Input.Visible = false;
            CheckState_Input.Visible = false;
        
        }

        /// <summary>
        /// 隐藏显示框
        /// </summary>
        private void Hidden_Disp()
        {
        PiZhunState_Disp.Visible = false;
        CheckState_Disp.Visible = false;
        }

        /// <summary>
        /// 增加/修改事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {
            T_VerificationRecordEntity ut = BusinessFacadeShanlitech_Location.T_VerificationRecordDisp(IDX);

            int TransferState_Value = (int)Common.sink(CheckState_Input.UniqueID, MethodType.Post, 10, 0, DataType.Int);
            if (TransferState_Value.Equals(1))
            {
                TransferState_Value = (int)TransferState.CunDang;
            }
            else
            {
                TransferState_Value = (int)TransferState.NoPiZhun;
            }

            string PiZhunState = (string)Common.sink(PiZhunState_Input.UniqueID, MethodType.Post, 500, 0, DataType.Str);

            int Approver_Value = (int)UserData.GetUserDate.UserID;
            DateTime? ApprovalTime_Value = (DateTime?)DateTime.Now;
                                
            ut.TransferState = TransferState_Value;

            ut.Approver = Approver_Value;
            ut.ApprovalTime = ApprovalTime_Value;
            ut.PiZhunNote = PiZhunState;
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
                EventMessage.MessageBox(2, "不存在操作字符串!", "不存在操作字符串!", Icon_Type.Error, Common.GetHomeBaseUrl("Default.aspx"));
            }
            Int32 rInt = BusinessFacadeShanlitech_Location.T_VerificationRecordInsertUpdateDelete(ut);
            if ( rInt> 0)
            {
                string OpTxt = string.Format("增加核销申请批准单成功!(ID:{0})", rInt);
                if (ut.DataTable_Action_ == DataTable_Action.Update)
                    OpTxt = string.Format("修改核销申请批准单成功!(ID:{0})",IDX);
                EventMessage.MessageBox(1, "操作成功", OpTxt, Icon_Type.OK, Common.GetHomeBaseUrl("Default.aspx"));
            }
            else if (rInt == -2)
            {
                EventMessage.MessageBox(1, "操作失败", "操作失败,存在相同的键值(用户名/数据)!", Icon_Type.Alert, Common.GetHomeBaseUrl("Default.aspx"));
            }
            else
            {
                EventMessage.MessageBox(1, "操作失败", string.Format("操作失败,返回值:{0}!", rInt), Icon_Type.Error, Common.GetHomeBaseUrl("Default.aspx"));
            }
        }

        #region 资产库列表
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
            List<T_StorageRecordEntity> lst = BusinessFacadeShanlitech_Location.T_StorageRecordList(qp, out RecordCount);
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
                    ViewState["SearchTerms"] = string.Format(" Where VeriID={0}", IDX);
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
        #endregion

        #endregion
    }
}
