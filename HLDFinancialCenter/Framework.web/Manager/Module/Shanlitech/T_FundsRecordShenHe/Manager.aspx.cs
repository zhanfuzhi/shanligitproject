/********************************************************************************
     File:																
            Manager.aspx.cs                         
     Description:
            经费使用审核单管理
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

namespace Shanlitech_Location.Web.Module.Shanlitech_Location.T_FundsRecordShenHe
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
        /// 初始化Grid
        /// </summary>
        public string InnitList(int p)
        {
            switch (p)
            {
                case (int)TransferState.ShenHe:
                    return "审核中";
                default:
                    return "审核未通过";
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
                    TabOptionItem1.Tab_Name = HeadMenuWebControls1.HeadOPTxt = "增加经费使用待审核单";
                    Hidden_Disp();
                    break;
                case "List":
                    TabOptionItem1.Tab_Name = HeadMenuWebControls1.HeadOPTxt = "查看经费使用待审核单";
                    Hidden_Input();
                    ButtonOption.Visible = false;
                    AddEditButton();
                    break;
                case "Edit":
                    TabOptionItem1.Tab_Name = HeadMenuWebControls1.HeadOPTxt = "修改经费使用待审核单";
                    Hidden_Disp();
                    AddDeleteButton();
                    break;
                case "Delete":
                    ut.DataTable_Action_ = DataTable_Action.Update;
                    ut.State = (int)Status.Delete;
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
            //HeadMenuButtonItem bi = new HeadMenuButtonItem();
            //bi.ButtonPopedom = PopedomType.Edit;
            //bi.ButtonName = "经费使用待审核单";
            //bi.ButtonUrl = string.Format("?CMD=Edit&IDX={0}", IDX);
            //HeadMenuWebControls1.ButtonList.Add(bi);
        }


        /// <summary>
        /// 增加删除按钮
        /// </summary>
        private void AddDeleteButton()
        {
            //HeadMenuButtonItem bi = new HeadMenuButtonItem();
            //bi.ButtonPopedom = PopedomType.Delete;
            //bi.ButtonName = "经费使用待审核单";
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
        private void OnStartData(T_FundsRecordEntity ut)
        {
            //Checker_Disp.Text = UserData.GetUserDate.U_LoginName;
            ProjID_Hidden.Value = ut.ProjID.ToString();
            if (!ut.ProjID.Equals(0))
            {
                ProjID_Disp.Text = BusinessFacadeShanlitech_Location.GetProjectBudgetFormat(BusinessFacadeShanlitech_Location.T_ProjectBudgetDisp(ut.ProjID));
                BalanceAmount_Disp.Text = ut.BalanceAmount.ToString();
                BalanceAmount_Hidden.Value = ut.BalanceAmount.ToString();
                Applicant_Disp.Text = BusinessFacade.sys_UserDisp(ut.Applicant).U_LoginName;
            }
            UseRemark_Disp.Text = ut.UseRemark.ToString();
            AdvanceAmount_Disp.Text = ut.AdvanceAmount.ToString();
            TransferState_Disp.Text = BusinessFacadeShanlitech_Location.GetTransferStateNameByState(ut.TransferState);
            if (!string.IsNullOrEmpty(ut.AppricationTime.ToString()))
            {
                AppricationTime_Disp.Text = ut.AppricationTime.ToString();

            }
            else
            {
                AppricationTime_Disp.Text = DateTime.Now.ToString();
            }

            CheckState_Disp.Text = InnitList(ut.TransferState);
            ShenHeState_Disp.Text = ut.ShenHeState;
        }

        /// <summary>
        /// 隐藏输入框
        /// </summary>
        private void Hidden_Input()
        {
            CheckState_Input.Visible = false;
            ShenHeState_Input.Visible = false;
        }

        /// <summary>
        /// 隐藏显示框
        /// </summary>
        private void Hidden_Disp()
        {
           CheckState_Disp.Visible = false;
           ShenHeState_Disp.Visible = false;
        }

        /// <summary>
        /// 增加/修改事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {
            int Checker_Value = UserData.GetUserDate.UserID;
            int TransferState_Value = (int)Common.sink(CheckState_Input.UniqueID, MethodType.Post, 10, 0, DataType.Int);
            if (TransferState_Value.Equals(1))
            { 
              TransferState_Value= (int)TransferState.PiZhun;
            }
            else
            {
                TransferState_Value = (int)TransferState.NoShenHe;
            }

            string ShenHeState = (string)Common.sink(ShenHeState_Input.UniqueID, MethodType.Post, 500, 0, DataType.Str);
            
            DateTime? CheckTime_Value = (DateTime?)DateTime.Now;
            T_FundsRecordEntity ut = BusinessFacadeShanlitech_Location.T_FundsRecordDisp(IDX);
            ut.Checker = Checker_Value;
            ut.TransferState = TransferState_Value;
            ut.CheckTime = CheckTime_Value;
            ut.ShenHeState = ShenHeState;
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
            if (rInt > 0)
            {
                string OpTxt = string.Format("增加经费使用审核单成功!(ID:{0})", rInt);
                if (ut.DataTable_Action_ == DataTable_Action.Update)
                    OpTxt = string.Format("修改经费使用审核单成功!(ID:{0})", IDX);
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

        /// <summary>
        /// 重填
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button2_Click(object sender, EventArgs e)
        {
            ShenHeState_Input.Text = "";
        }
    }
}
