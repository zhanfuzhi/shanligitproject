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

namespace Shanlitech_Location.Web.Module.Shanlitech_Location.T_VerificationRecord
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
                    TabOptionItem1.Tab_Name = HeadMenuWebControls1.HeadOPTxt = "增加核销申请单";
                    Hidden_Disp();
                    break;
                case "List":
                    TabOptionItem1.Tab_Name = HeadMenuWebControls1.HeadOPTxt = "查看核销申请单";
                    Hidden_Input();
                    ButtonOption.Visible = false;
                    AddEditButton();
                    break;
                case "Edit":
                    TabOptionItem1.Tab_Name = HeadMenuWebControls1.HeadOPTxt = "修改核销申请单";
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
            HeadMenuButtonItem bi = new HeadMenuButtonItem();
            bi.ButtonPopedom = PopedomType.Delete;
            bi.ButtonName = "核销申请单";
            bi.ButtonUrlType = UrlType.JavaScript;
            bi.ButtonUrl = string.Format("DelData('?CMD=Delete&IDX={0}')", IDX);
            HeadMenuWebControls1.ButtonList.Add(bi);

            HeadMenuButtonItem bi1 = new HeadMenuButtonItem();
            bi1.ButtonPopedom = PopedomType.List;
            bi1.ButtonIcon = "back.gif";
            bi1.ButtonName = "返回";
            bi1.ButtonUrl = string.Format("?CMD=List&IDX={0}", IDX);
            HeadMenuWebControls1.ButtonList.Add(bi1);
        }

        /// <summary>
        /// 初始化数据
        /// </summary>
        /// <param name="ut"></param>
        private void OnStartData(T_VerificationRecordEntity ut)
        {
        FundID_Input.Text = FundID_Disp.Text = ut.FundID.ToString();
                ProjID_Input.Text = ProjID_Disp.Text = ut.ProjID.ToString();
                InvoiceFolder_Input.Text = InvoiceFolder_Disp.Text = ut.InvoiceFolder.ToString();
                ContractFolder_Input.Text = ContractFolder_Disp.Text = ut.ContractFolder.ToString();
                Undertaker_Input.Text = Undertaker_Disp.Text = ut.Undertaker.ToString();
                Checker_Input.Text = Checker_Disp.Text = ut.Checker.ToString();
                Approver_Input.Text = Approver_Disp.Text = ut.Approver.ToString();
                TransferState_Input.Text = TransferState_Disp.Text = ut.TransferState.ToString();
                State_Input.Text = State_Disp.Text = ut.State.ToString();
                CreateTime_Input.Text = CreateTime_Disp.Text = ut.CreateTime.ToString();
                CheckTime_Input.Text = CheckTime_Disp.Text = ut.CheckTime.ToString();
                ApprovalTime_Input.Text = ApprovalTime_Disp.Text = ut.ApprovalTime.ToString();
                PayAmount_Input.Text = PayAmount_Disp.Text = ut.PayAmount.ToString();
                IntegrityCheckCode_Input.Text = IntegrityCheckCode_Disp.Text = ut.IntegrityCheckCode.ToString();
                
        }

        /// <summary>
        /// 隐藏输入框
        /// </summary>
        private void Hidden_Input()
        {
        FundID_Input.Visible = false;
        ProjID_Input.Visible = false;
        InvoiceFolder_Input.Visible = false;
        ContractFolder_Input.Visible = false;
        Undertaker_Input.Visible = false;
        Checker_Input.Visible = false;
        Approver_Input.Visible = false;
        TransferState_Input.Visible = false;
        State_Input.Visible = false;
        CreateTime_Input.Visible = false;
        CheckTime_Input.Visible = false;
        ApprovalTime_Input.Visible = false;
        PayAmount_Input.Visible = false;
        IntegrityCheckCode_Input.Visible = false;
        
        }

        /// <summary>
        /// 隐藏显示框
        /// </summary>
        private void Hidden_Disp()
        {
        FundID_Disp.Visible = false;
        ProjID_Disp.Visible = false;
        InvoiceFolder_Disp.Visible = false;
        ContractFolder_Disp.Visible = false;
        Undertaker_Disp.Visible = false;
        Checker_Disp.Visible = false;
        Approver_Disp.Visible = false;
        TransferState_Disp.Visible = false;
        State_Disp.Visible = false;
        CreateTime_Disp.Visible = false;
        CheckTime_Disp.Visible = false;
        ApprovalTime_Disp.Visible = false;
        PayAmount_Disp.Visible = false;
        IntegrityCheckCode_Disp.Visible = false;
        
        }

        /// <summary>
        /// 增加/修改事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {
        
            int FundID_Value = (int)Common.sink(FundID_Input.UniqueID, MethodType.Post, 10, 0, DataType.Int);
            int ProjID_Value = (int)Common.sink(ProjID_Input.UniqueID, MethodType.Post, 10, 0, DataType.Int);
            string InvoiceFolder_Value = (string)Common.sink(InvoiceFolder_Input.UniqueID, MethodType.Post, 50, 0, DataType.Str);
            string ContractFolder_Value = (string)Common.sink(ContractFolder_Input.UniqueID, MethodType.Post, 50, 0, DataType.Str);
            int Undertaker_Value = (int)Common.sink(Undertaker_Input.UniqueID, MethodType.Post, 10, 0, DataType.Int);
            int Checker_Value = (int)Common.sink(Checker_Input.UniqueID, MethodType.Post, 10, 0, DataType.Int);
            Int64 Approver_Value = (Int64)Common.sink(Approver_Input.UniqueID, MethodType.Post, 19, 0, DataType.Long);
            int TransferState_Value = (int)Common.sink(TransferState_Input.UniqueID, MethodType.Post, 10, 0, DataType.Int);
            int State_Value = (int)Common.sink(State_Input.UniqueID, MethodType.Post, 10, 0, DataType.Int);
            
                    DateTime? CreateTime_Value = (DateTime?)Common.sink(CreateTime_Input.UniqueID, MethodType.Post, 50, 0, DataType.Dat);
                
            
                    DateTime? CheckTime_Value = (DateTime?)Common.sink(CheckTime_Input.UniqueID, MethodType.Post, 50, 0, DataType.Dat);
                
            
                    DateTime? ApprovalTime_Value = (DateTime?)Common.sink(ApprovalTime_Input.UniqueID, MethodType.Post, 50, 0, DataType.Dat);
                
            double PayAmount_Value = (double)Common.sink(PayAmount_Input.UniqueID, MethodType.Post, 53, 0, DataType.Double);
            string IntegrityCheckCode_Value = (string)Common.sink(IntegrityCheckCode_Input.UniqueID, MethodType.Post, 50, 0, DataType.Str);
            T_VerificationRecordEntity ut = BusinessFacadeShanlitech_Location.T_VerificationRecordDisp(IDX);
            
            ut.FundID = FundID_Value;
            ut.ProjID = ProjID_Value;
            ut.InvoiceFolder = InvoiceFolder_Value;
            ut.ContractFolder = ContractFolder_Value;
            ut.Undertaker = Undertaker_Value;
            ut.Checker = Checker_Value;
            ut.Approver = Approver_Value;
            ut.TransferState = TransferState_Value;
            ut.State = State_Value;
            ut.CreateTime = CreateTime_Value;
            ut.CheckTime = CheckTime_Value;
            ut.ApprovalTime = ApprovalTime_Value;
            ut.PayAmount = PayAmount_Value;
            ut.IntegrityCheckCode = IntegrityCheckCode_Value;
            
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
                string OpTxt = string.Format("增加核销申请单成功!(ID:{0})", rInt);
                if (ut.DataTable_Action_ == DataTable_Action.Update)
                    OpTxt = string.Format("修改核销申请单成功!(ID:{0})",IDX);
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
    }
}
