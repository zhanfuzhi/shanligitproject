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

namespace Shanlitech_Location.Web.Module.Shanlitech_Location.T_VerificationRecordFinish
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
                    TabOptionItem1.Tab_Name = HeadMenuWebControls1.HeadOPTxt = "增加核销存档单";
                    Hidden_Disp();
                    break;
                case "List":
                    TabOptionItem1.Tab_Name = HeadMenuWebControls1.HeadOPTxt = "查看核销存档单";
                    Hidden_Input();
                    ButtonOption.Visible = false;
                    AddEditButton();
                    break;
                case "Edit":
                    TabOptionItem1.Tab_Name = HeadMenuWebControls1.HeadOPTxt = "修改核销存档单";
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
            //HeadMenuButtonItem bi = new HeadMenuButtonItem();
            //bi.ButtonPopedom = PopedomType.Edit;
            //bi.ButtonName = "核销申请单";
            //bi.ButtonUrl = string.Format("?CMD=Edit&IDX={0}", IDX);
            //HeadMenuWebControls1.ButtonList.Add(bi);
        }


        /// <summary>
        /// 增加删除按钮
        /// </summary>
        private void AddDeleteButton()
        {
            HeadMenuButtonItem bi = new HeadMenuButtonItem();
            bi.ButtonPopedom = PopedomType.Delete;
            bi.ButtonName = "核销存档单";
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
            ProjID_Hidden.Value = ut.FundID.ToString();
            Protype_Hidden.Value = ut.ProjID.ToString();
            if (!ut.ProjID.Equals(0))
            {
                ProjID_Disp.Text = BusinessFacadeShanlitech_Location.GetProjectBudgetFormat(BusinessFacadeShanlitech_Location.T_ProjectBudgetDisp(ut.ProjID));
            }

            imag_Fapiao.ImageUrl = ut.InvoiceFolder;
            ContractFolder_Image.ImageUrl = ut.ContractFolder;
            PayAmount_Input.Text = PayAmount_Disp.Text = ut.PayAmount.ToString();

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

            Approver_Disp.Text = BusinessFacade.sys_UserDisp(Convert.ToInt32(ut.Approver)).U_LoginName;
            if (!string.IsNullOrEmpty(ut.ApprovalTime.ToString()))
            {
                ApproverTime_Disp.Text = ut.ApprovalTime.ToString();
            }
            else
            {
                ApproverTime_Disp.Text = DateTime.Now.ToString();
            }

            ShenHeNote_Disp.Text = ut.ShenHeNote;
            PiZhunNote_Disp.Text = ut.PiZhunNote;
            CunDangNote_Disp.Text = ut.CunDangNote;
        }

        /// <summary>
        /// 隐藏输入框
        /// </summary>
        private void Hidden_Input()
        {
            SelectCase.Visible = false;
            InvoiceFolder_Upload.Visible = false;
            ContractFolder_Upload.Visible = false;
        PayAmount_Input.Visible = false;
        }

        /// <summary>
        /// 隐藏显示框
        /// </summary>
        private void Hidden_Disp()
        {
        ContractFolder_Disp.Visible = false;

        PayAmount_Disp.Visible = false;
        }

        /// <summary>
        /// 增加/修改事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {
            T_VerificationRecordEntity ut = BusinessFacadeShanlitech_Location.T_VerificationRecordDisp(IDX);

            int FundID_Value = Convert.ToInt32(ProjID_Hidden.Value);
            int ProjID_Value = Convert.ToInt32(Protype_Hidden.Value);
            #region 发票联
            string InvoiceFolder_Value = string.Empty;
            string newFile = "/Down/" + DateTime.Now.ToString("yyyyMMddHHmmss");
            string strBaseLocation = Server.MapPath(newFile);
            if (!System.IO.Directory.Exists(strBaseLocation))
            {
                System.IO.Directory.CreateDirectory(strBaseLocation);
            }
            string LocalFile = string.Empty;//本地文件名

            string clientFilename = System.IO.Path.GetFileName(InvoiceFolder_Upload.PostedFile.FileName);

            if (clientFilename != string.Empty)
            {
                //设置文件名    
                LocalFile = Path.Combine(strBaseLocation, clientFilename);

                //保存文件
                InvoiceFolder_Upload.PostedFile.SaveAs(LocalFile);
                InvoiceFolder_Value = newFile + "/" + clientFilename;
                ut.InvoiceFolder = InvoiceFolder_Value;
            }

            #endregion

            #region 协议联
            string ContractFolder_Value = string.Empty;
            string newFile1 = "/Down/" + DateTime.Now.ToString("yyyyMMddHHmmss");
            string strBaseLocation1 = Server.MapPath(newFile1);
            if (!System.IO.Directory.Exists(strBaseLocation1))
            {
                System.IO.Directory.CreateDirectory(strBaseLocation1);
            }
            string LocalFile1 = string.Empty;//本地文件名

            string clientFilename1 = System.IO.Path.GetFileName(ContractFolder_Upload.PostedFile.FileName);

            if (clientFilename1 != string.Empty)
            {
                //设置文件名    
                LocalFile1 = Path.Combine(strBaseLocation1, clientFilename1);

                //保存文件
                ContractFolder_Upload.PostedFile.SaveAs(LocalFile1);
                ContractFolder_Value = newFile1 + "/" + clientFilename1;
                ut.ContractFolder = ContractFolder_Value;
            }

            #endregion

            int Undertaker_Value = (int)UserData.GetUserDate.UserID;
            int TransferState_Value = (int)TransferState.ShenHe;
            int State_Value = (int)Status.Normal;

            DateTime? CreateTime_Value = (DateTime?)DateTime.Now;
                
            double PayAmount_Value = (double)Common.sink(PayAmount_Input.UniqueID, MethodType.Post, 53, 0, DataType.Double);

            ut.FundID = FundID_Value;
            ut.ProjID = ProjID_Value;
           
            ut.Undertaker = Undertaker_Value;
            ut.TransferState = TransferState_Value;
            ut.State = State_Value;
            ut.CreateTime = CreateTime_Value;
            ut.PayAmount = PayAmount_Value;
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
                string OpTxt = string.Format("增加核销存档单成功!(ID:{0})", rInt);
                if (ut.DataTable_Action_ == DataTable_Action.Update)
                    OpTxt = string.Format("修改核销存档单成功!(ID:{0})", IDX);
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
