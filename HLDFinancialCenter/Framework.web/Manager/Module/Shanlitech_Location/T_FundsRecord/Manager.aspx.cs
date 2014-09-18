/********************************************************************************
     File:																
            Manager.aspx.cs                         
     Description:
            经费使用申请单管理
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

namespace Shanlitech_Location.Web.Module.Shanlitech_Location.T_FundsRecord
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
            T_FundsRecordEntity ut = BusinessFacadeShanlitech_Location.T_FundsRecordDisp(IDX);
            OnStartData(ut);
            switch (CMD)
            { 
                case "New":
                    TabOptionItem1.Tab_Name = HeadMenuWebControls1.HeadOPTxt = "增加经费使用申请单";
                    Hidden_Disp();
                    break;
                case "List":
                    TabOptionItem1.Tab_Name = HeadMenuWebControls1.HeadOPTxt = "查看经费使用申请单";
                    Hidden_Input();
                    ButtonOption.Visible = false;
                    AddEditButton();
                    break;
                case "Edit":
                    TabOptionItem1.Tab_Name = HeadMenuWebControls1.HeadOPTxt = "修改经费使用申请单";
                    Hidden_Disp();
                    AddDeleteButton();
                    break;
                case "Delete":
                    ut.DataTable_Action_ = DataTable_Action.Delete;
                    if (BusinessFacadeShanlitech_Location.T_FundsRecordInsertUpdateDelete(ut) > 0)
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
            bi.ButtonName = "经费使用申请单";
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
            bi.ButtonName = "经费使用申请单";
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
        private void OnStartData(T_FundsRecordEntity ut)
        {
        ProjID_Input.Text = ProjID_Disp.Text = ut.ProjID.ToString();
                BalanceAmount_Input.Text = BalanceAmount_Disp.Text = ut.BalanceAmount.ToString();
                UseRemark_Input.Text = UseRemark_Disp.Text = ut.UseRemark.ToString();
                AdvanceAmount_Input.Text = AdvanceAmount_Disp.Text = ut.AdvanceAmount.ToString();
                Applicant_Input.Text = Applicant_Disp.Text = ut.Applicant.ToString();
                Checker_Input.Text = Checker_Disp.Text = ut.Checker.ToString();
                Approver_Input.Text = Approver_Disp.Text = ut.Approver.ToString();
                TransferState_Input.Text = TransferState_Disp.Text = ut.TransferState.ToString();
                State_Input.Text = State_Disp.Text = ut.State.ToString();
                AppricationTime_Input.Text = AppricationTime_Disp.Text = ut.AppricationTime.ToString();
                CheckTime_Input.Text = CheckTime_Disp.Text = ut.CheckTime.ToString();
                ApprovalTime_Input.Text = ApprovalTime_Disp.Text = ut.ApprovalTime.ToString();
                IntegrityCheckCode_Input.Text = IntegrityCheckCode_Disp.Text = ut.IntegrityCheckCode.ToString();
                
        }

        /// <summary>
        /// 隐藏输入框
        /// </summary>
        private void Hidden_Input()
        {
        ProjID_Input.Visible = false;
        BalanceAmount_Input.Visible = false;
        UseRemark_Input.Visible = false;
        AdvanceAmount_Input.Visible = false;
        Applicant_Input.Visible = false;
        Checker_Input.Visible = false;
        Approver_Input.Visible = false;
        TransferState_Input.Visible = false;
        State_Input.Visible = false;
        AppricationTime_Input.Visible = false;
        CheckTime_Input.Visible = false;
        ApprovalTime_Input.Visible = false;
        IntegrityCheckCode_Input.Visible = false;
        
        }

        /// <summary>
        /// 隐藏显示框
        /// </summary>
        private void Hidden_Disp()
        {
        ProjID_Disp.Visible = false;
        BalanceAmount_Disp.Visible = false;
        UseRemark_Disp.Visible = false;
        AdvanceAmount_Disp.Visible = false;
        Applicant_Disp.Visible = false;
        Checker_Disp.Visible = false;
        Approver_Disp.Visible = false;
        TransferState_Disp.Visible = false;
        State_Disp.Visible = false;
        AppricationTime_Disp.Visible = false;
        CheckTime_Disp.Visible = false;
        ApprovalTime_Disp.Visible = false;
        IntegrityCheckCode_Disp.Visible = false;
        
        }

        /// <summary>
        /// 增加/修改事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {
        
            int ProjID_Value = (int)Common.sink(ProjID_Input.UniqueID, MethodType.Post, 10, 0, DataType.Int);
            double BalanceAmount_Value = (double)Common.sink(BalanceAmount_Input.UniqueID, MethodType.Post, 53, 0, DataType.Double);
            string UseRemark_Value = (string)Common.sink(UseRemark_Input.UniqueID, MethodType.Post, 50, 0, DataType.Str);
            double AdvanceAmount_Value = (double)Common.sink(AdvanceAmount_Input.UniqueID, MethodType.Post, 53, 0, DataType.Double);
            int Applicant_Value = (int)Common.sink(Applicant_Input.UniqueID, MethodType.Post, 10, 0, DataType.Int);
            int Checker_Value = (int)Common.sink(Checker_Input.UniqueID, MethodType.Post, 10, 0, DataType.Int);
            int Approver_Value = (int)Common.sink(Approver_Input.UniqueID, MethodType.Post, 10, 0, DataType.Int);
            int TransferState_Value = (int)Common.sink(TransferState_Input.UniqueID, MethodType.Post, 10, 0, DataType.Int);
            int State_Value = (int)Common.sink(State_Input.UniqueID, MethodType.Post, 10, 0, DataType.Int);
            
                    DateTime? AppricationTime_Value = (DateTime?)Common.sink(AppricationTime_Input.UniqueID, MethodType.Post, 50, 0, DataType.Dat);
                
            
                    DateTime? CheckTime_Value = (DateTime?)Common.sink(CheckTime_Input.UniqueID, MethodType.Post, 50, 0, DataType.Dat);
                
            
                    DateTime? ApprovalTime_Value = (DateTime?)Common.sink(ApprovalTime_Input.UniqueID, MethodType.Post, 50, 0, DataType.Dat);
                
            string IntegrityCheckCode_Value = (string)Common.sink(IntegrityCheckCode_Input.UniqueID, MethodType.Post, 50, 0, DataType.Str);
            T_FundsRecordEntity ut = BusinessFacadeShanlitech_Location.T_FundsRecordDisp(IDX);
            
            ut.ProjID = ProjID_Value;
            ut.BalanceAmount = BalanceAmount_Value;
            ut.UseRemark = UseRemark_Value;
            ut.AdvanceAmount = AdvanceAmount_Value;
            ut.Applicant = Applicant_Value;
            ut.Checker = Checker_Value;
            ut.Approver = Approver_Value;
            ut.TransferState = TransferState_Value;
            ut.State = State_Value;
            ut.AppricationTime = AppricationTime_Value;
            ut.CheckTime = CheckTime_Value;
            ut.ApprovalTime = ApprovalTime_Value;
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
            Int32 rInt = BusinessFacadeShanlitech_Location.T_FundsRecordInsertUpdateDelete(ut);
            if ( rInt> 0)
            {
                string OpTxt = string.Format("增加经费使用申请单成功!(ID:{0})", rInt);
                if (ut.DataTable_Action_ == DataTable_Action.Update)
                    OpTxt = string.Format("修改经费使用申请单成功!(ID:{0})",IDX);
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
