/********************************************************************************
     File:																
            Manager.aspx.cs                         
     Description:
            出库表单管理
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
using System.Collections.Generic;

namespace Shanlitech_Location.Web.Module.Shanlitech_Location.T_OutboundRecordFinish
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
                Innit();
                OnStart();
            }
        }

        /// <summary>
        /// 初始化
        /// </summary>
        private void Innit()
        {
            ListItem nullItems = new ListItem();
            nullItems.Value = "";
            nullItems.Text = "请选择";


            //初始化项目编号
            ProjectNO_Input.Items.Add(nullItems);
            List<T_ProjectDicEntity> projectlist = BusinessFacadeShanlitech_Location.GetProjectList();
            foreach (T_ProjectDicEntity r in projectlist)
            {
                ListItem item = new ListItem();
                item.Text = r.ProjectName;
                item.Value = r.ID.ToString();
                ProjectNO_Input.Items.Add(item);
            }

            //初始化申请人
            Applicant_Input.Items.Add(nullItems);
            ArrayList userlist = BusinessFacadeShanlitech_Location.GetUserList();
            foreach (sys_UserTable r in userlist)
            {
                ListItem item = new ListItem();
                item.Value = r.UserID.ToString();
                item.Text = r.U_LoginName;
                if (!r.U_LoginName.Equals(""))
                {
                    Applicant_Input.Items.Add(item);
                }
            }

         
        }


        
        /// <summary>
        /// 开始操作
        /// </summary>
        private void OnStart()
        {
            T_OutboundRecordEntity ut = BusinessFacadeShanlitech_Location.T_OutboundRecordDisp(IDX);
            OnStartData(ut);
            switch (CMD)
            { 
                case "New":
                    TabOptionItem1.Tab_Name = HeadMenuWebControls1.HeadOPTxt = "增加出库表单";
                    Hidden_Disp();
                    break;
                case "List":
                    TabOptionItem1.Tab_Name = HeadMenuWebControls1.HeadOPTxt = "查看出库表单";
                    Hidden_Input();
                    ButtonOption.Visible = false;
                    AddEditButton();
                    break;
                case "Edit":
                    TabOptionItem1.Tab_Name = HeadMenuWebControls1.HeadOPTxt = "修改出库表单";
                    Hidden_Disp();
                    AddDeleteButton();
                    break;
                case "Delete":
                    ut.DataTable_Action_ = DataTable_Action.Delete;
                    if (BusinessFacadeShanlitech_Location.T_OutboundRecordInsertUpdateDelete(ut) > 0)
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
            //bi.ButtonName = "出库表单";
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
            //bi.ButtonName = "出库表单";
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
        private void OnStartData(T_OutboundRecordEntity ut)
        {
            StockID_Hidden.Value = ut.CodeNO.ToString();
            StockName_Disp.Text = "器材名称:" + ut.EquipmentName + "; 型号:" + ut.Model + ";库存编码:" + BusinessFacadeShanlitech_Location.GetCodeByStockid(ut.CodeNO);
            EquipmentName_Hidden.Value = ut.EquipmentName;
            Model_Hidden.Value = ut.Model;
            CodeNO_Hidden.Value = ut.CodeNO;
            //项目类别
            if (!string.IsNullOrEmpty(ut.ProjectNO))
            {
                ListItem projectitem = ProjectNO_Input.Items.FindByValue(ut.ProjectNO.ToString());
                ProjectNO_Input.ClearSelection();
                if (projectitem != null)
                    projectitem.Selected = true;
                ProjectNO_Disp.Text = BusinessFacadeShanlitech_Location.GetProjectNameByID(Convert.ToInt32(ut.ProjectNO.ToString()));
            }

            //EquipmentName_Input.Text = 
                EquipmentName_Disp.Text = ut.EquipmentName.ToString();
                //Model_Input.Text = 
                    Model_Disp.Text = ut.Model.ToString();
                OutboundNumber_Input.Text = OutboundNumber_Disp.Text = ut.OutboundNumber.ToString();
                BalanceNumber_Input.Text = BalanceNumber_Disp.Text = ut.BalanceNumber.ToString();
                OutboundTime_Disp.Text = ut.OutboundTime.ToString();
                if (string.IsNullOrEmpty(ut.OutboundTime.ToString()))
                {
                    OutboundTime_Disp.Text = DateTime.Now.ToString();
                }
                //申请人
                ListItem Applicantitem = Applicant_Input.Items.FindByValue(ut.Applicant.ToString());
                Applicant_Input.ClearSelection();
                if (Applicantitem != null)
                    Applicantitem.Selected = true;
                Applicant_Disp.Text = BusinessFacadeShanlitech_Location.GetUserNameByID(Convert.ToInt32(ut.Applicant.ToString()));

                //批准人
                
                Approver_Disp.Text = BusinessFacadeShanlitech_Location.GetUserNameByID(Convert.ToInt32(ut.Approver.ToString()));

                Remark_Input.Text = Remark_Disp.Text = ut.Remark.ToString();
                CodeNO_Input.Text = CodeNO_Disp.Text = ut.CodeNO.ToString();
                
        }

        /// <summary>
        /// 隐藏输入框
        /// </summary>
        private void Hidden_Input()
        {
        ProjectNO_Input.Visible = false;
      
        OutboundNumber_Input.Visible = false;
        BalanceNumber_Input.Visible = false;
        Applicant_Input.Visible = false;
      
        Remark_Input.Visible = false;
        CodeNO_Input.Visible = false;
        
        }

        /// <summary>
        /// 隐藏显示框
        /// </summary>
        private void Hidden_Disp()
        {
        ProjectNO_Disp.Visible = false;
        EquipmentName_Disp.Visible = false;
        Model_Disp.Visible = false;
        OutboundNumber_Disp.Visible = false;
       
        Applicant_Disp.Visible = false;
        Approver_Disp.Visible = false;
        Remark_Disp.Visible = false;
        CodeNO_Disp.Visible = false;
        
        }

        /// <summary>
        /// 增加/修改事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {
        
        }
    }
}
