/********************************************************************************
     File:																
            Manager.aspx.cs                         
     Description:
            项目预算管理
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

namespace Shanlitech_Location.Web.Module.Shanlitech_Location.T_ProjectBudget
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

            //初始化所属经费类别
            ClassNO_Input.Items.Add(nullItems);
            List<T_ClassDicEntity> classlist = BusinessFacadeShanlitech_Location.GetClassList();
            foreach (T_ClassDicEntity r in classlist)
            {
                ListItem item = new ListItem();
                item.Text = r.ClassName;
                item.Value = r.ID.ToString();
                ClassNO_Input.Items.Add(item);
            }

            //初始化所属科目
            SubjectNO_Input.Items.Add(nullItems);
            List<T_SubjectDicEntity> subjectlist = BusinessFacadeShanlitech_Location.GetSubjectList();
            foreach (T_SubjectDicEntity r in subjectlist)
            {
                ListItem item = new ListItem();
                item.Text = r.SubjectName;
                item.Value = r.ID.ToString();
                SubjectNO_Input.Items.Add(item);
            }

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

            //初始化项目组长  项目预算中的项目组长  -----有项目组长角色的人员
            Leader_Input.Items.Add(nullItems);
            ArrayList userlist = BusinessFacadeShanlitech_Location.GetUserListByRole((int)RoleName.XMZZJS);
            //ArrayList userlist = BusinessFacadeShanlitech_Location.GetUserList();
            foreach (sys_UserTable r in userlist)
            {
                ListItem item = new ListItem();
                item.Value = r.UserID.ToString();
                item.Text = r.U_LoginName;
                if (!r.U_LoginName.Equals(""))
                {
                    Leader_Input.Items.Add(item);
                }
            }

            //初始化指定承办人
            Undertaker_Input.Items.Add(nullItems);
            ArrayList userlist1 = BusinessFacadeShanlitech_Location.GetUserListByRole((int)RoleName.CBRJS);
            foreach (sys_UserTable r in userlist1)
            {
                ListItem item = new ListItem();
                item.Value = r.UserID.ToString();
                item.Text = r.U_LoginName;
                if (!r.U_LoginName.Equals(""))
                {
                    Undertaker_Input.Items.Add(item);
                }
            }



        }

        /// <summary>
        /// 开始操作
        /// </summary>
        private void OnStart()
        {
            T_ProjectBudgetEntity ut = BusinessFacadeShanlitech_Location.T_ProjectBudgetDisp(IDX);
            OnStartData(ut);
            switch (CMD)
            { 
                case "New":
                    TabOptionItem1.Tab_Name = HeadMenuWebControls1.HeadOPTxt = "增加项目预算";
                    Hidden_Disp();
                    break;
                case "List":
                    TabOptionItem1.Tab_Name = HeadMenuWebControls1.HeadOPTxt = "查看项目预算";
                    Hidden_Input();
                    ButtonOption.Visible = false;
                    AddEditButton();
                    break;
                case "Edit":
                    TabOptionItem1.Tab_Name = HeadMenuWebControls1.HeadOPTxt = "修改项目预算";
                    Hidden_Disp();
                    AddDeleteButton();
                    break;
                case "Delete":
                    ut.DataTable_Action_ = DataTable_Action.Update;
                    ut.State = (int)Status.Delete;
                    if (BusinessFacadeShanlitech_Location.T_ProjectBudgetInsertUpdateDelete(ut) > 0)
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
            bi.ButtonName = "项目预算";
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
            bi.ButtonName = "项目预算";
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
        private void OnStartData(T_ProjectBudgetEntity ut)
        {
            
            //经费类别
            if (!string.IsNullOrEmpty(ut.ClassNO))
            {
                ListItem classitem = ClassNO_Input.Items.FindByValue(ut.ClassNO.ToString());
                ClassNO_Input.ClearSelection();
                if (classitem != null)
                    classitem.Selected = true;
                ClassNO_Disp.Text = BusinessFacadeShanlitech_Location.GetClassNameByID(Convert.ToInt32(ut.ClassNO.ToString()));
            }

            //项目类别
            if (!string.IsNullOrEmpty(ut.ProjectNO))
            {
                ListItem projectitem = ProjectNO_Input.Items.FindByValue(ut.ProjectNO.ToString());
                ProjectNO_Input.ClearSelection();
                if (projectitem != null)
                    projectitem.Selected = true;
                ProjectNO_Disp.Text = BusinessFacadeShanlitech_Location.GetProjectNameByID(Convert.ToInt32(ut.ProjectNO.ToString()));
            }

            //科目类别
            if (!string.IsNullOrEmpty(ut.SubjectNO))
            {
                ListItem subjectitem = SubjectNO_Input.Items.FindByValue(ut.SubjectNO.ToString());
                SubjectNO_Input.ClearSelection();
                if (subjectitem != null)
                    subjectitem.Selected = true;
                SubjectNO_Disp.Text = BusinessFacadeShanlitech_Location.GetSubjectNameByID(Convert.ToInt32(ut.SubjectNO.ToString()));
            }

            AnnualNO_Input.Text = AnnualNO_Disp.Text = ut.AnnualNO.ToString();
            BudgetRevenue_Input.Text = BudgetRevenue_Disp.Text = ut.BudgetRevenue.ToString();
            BudgetExpenditure_Input.Text = BudgetExpenditure_Disp.Text = ut.BudgetExpenditure.ToString();
            //BalanceAmount_Input.Text =
                BalanceAmount_Disp.Text = ut.BalanceAmount.ToString();

            //项目组长
            ListItem leaderitem = Leader_Input.Items.FindByValue(ut.Leader.ToString());
            Leader_Input.ClearSelection();
            if (leaderitem != null)
                leaderitem.Selected = true;
            Leader_Disp.Text = BusinessFacadeShanlitech_Location.GetUserNameByID(Convert.ToInt32(ut.Leader.ToString()));

            //项目承办人
            ListItem Undertakeritem = Undertaker_Input.Items.FindByValue(ut.Undertaker.ToString());
            Undertaker_Input.ClearSelection();
            if (Undertakeritem != null)
                Undertakeritem.Selected = true;
            Undertaker_Disp.Text = BusinessFacadeShanlitech_Location.GetUserNameByID(Convert.ToInt32(ut.Undertaker.ToString()));
        }

        /// <summary>
        /// 隐藏输入框
        /// </summary>
        private void Hidden_Input()
        {
        ProjectNO_Input.Visible = false;
        SubjectNO_Input.Visible = false;
        ClassNO_Input.Visible = false;
        AnnualNO_Input.Visible = false;
        BudgetRevenue_Input.Visible = false;
        BudgetExpenditure_Input.Visible = false;
        //BalanceAmount_Input.Visible = false;
        Leader_Input.Visible = false;
        Undertaker_Input.Visible = false;
        }

        /// <summary>
        /// 隐藏显示框
        /// </summary>
        private void Hidden_Disp()
        {
        ProjectNO_Disp.Visible = false;
        SubjectNO_Disp.Visible = false;
        ClassNO_Disp.Visible = false;
        AnnualNO_Disp.Visible = false;
        BudgetRevenue_Disp.Visible = false;
        BudgetExpenditure_Disp.Visible = false;
        tr_BalanceAmount.Visible = false;
        //BalanceAmount_Disp.Visible = false;
        Leader_Disp.Visible = false;
        Undertaker_Disp.Visible = false;
       }

        /// <summary>
        /// 增加/修改事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {
        
            string ProjectNO_Value = (string)Common.sink(ProjectNO_Input.UniqueID, MethodType.Post, 50, 0, DataType.Str);
            string SubjectNO_Value = (string)Common.sink(SubjectNO_Input.UniqueID, MethodType.Post, 50, 0, DataType.Str);
            string ClassNO_Value = (string)Common.sink(ClassNO_Input.UniqueID, MethodType.Post, 50, 0, DataType.Str);
            string AnnualNO_Value = (string)Common.sink(AnnualNO_Input.UniqueID, MethodType.Post, 50, 0, DataType.Str);
            double BudgetRevenue_Value = (double)Common.sink(BudgetRevenue_Input.UniqueID, MethodType.Post, 53, 0, DataType.Double);
            double BudgetExpenditure_Value = (double)Common.sink(BudgetExpenditure_Input.UniqueID, MethodType.Post, 53, 0, DataType.Double);
            double BalanceAmount_Value = (double)Common.sink(BudgetRevenue_Input.UniqueID, MethodType.Post, 53, 0, DataType.Double);
            int Leader_Value = (int)Common.sink(Leader_Input.UniqueID, MethodType.Post, 10, 0, DataType.Int);
            int Undertaker_Value = (int)Common.sink(Undertaker_Input.UniqueID, MethodType.Post, 10, 0, DataType.Int);
            int State_Value = (int)Status.Normal;
            
                    DateTime? CreateTime_Value = (DateTime?)DateTime.Now;
                
            
                    DateTime? UpdateTime_Value = (DateTime?)DateTime.Now;
                
            T_ProjectBudgetEntity ut = BusinessFacadeShanlitech_Location.T_ProjectBudgetDisp(IDX);
            
            ut.ProjectNO = ProjectNO_Value;
            ut.SubjectNO = SubjectNO_Value;
            ut.ClassNO = ClassNO_Value;
            ut.AnnualNO = AnnualNO_Value;
            ut.BudgetRevenue = BudgetRevenue_Value;
            ut.BudgetExpenditure = BudgetExpenditure_Value;
            ut.BalanceAmount = BalanceAmount_Value;
            ut.Leader = Leader_Value;
            ut.Undertaker = Undertaker_Value;
            ut.State = State_Value;
           
            if (CMD == "New")
            {
                ut.CreateTime = CreateTime_Value;
                ut.UpdateTime = UpdateTime_Value;
                ut.DataTable_Action_ = DataTable_Action.Insert;
            }
            else if (CMD == "Edit")
            {
                ut.UpdateTime = UpdateTime_Value;
                ut.DataTable_Action_ = DataTable_Action.Update;
            }
            else
            {
                EventMessage.MessageBox(2, "不存在操作字符串!", "不存在操作字符串!", Icon_Type.Error, Common.GetHomeBaseUrl("Default.aspx"));
            }
            Int32 rInt = BusinessFacadeShanlitech_Location.T_ProjectBudgetInsertUpdateDelete(ut);
            if ( rInt> 0)
            {
                string OpTxt = string.Format("增加项目预算成功!(ID:{0})", rInt);
                if (ut.DataTable_Action_ == DataTable_Action.Update)
                    OpTxt = string.Format("修改项目预算成功!(ID:{0})",IDX);
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
