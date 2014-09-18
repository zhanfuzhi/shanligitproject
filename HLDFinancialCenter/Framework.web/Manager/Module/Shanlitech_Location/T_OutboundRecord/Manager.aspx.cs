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

namespace Shanlitech_Location.Web.Module.Shanlitech_Location.T_OutboundRecord
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
            HeadMenuButtonItem bi = new HeadMenuButtonItem();
            bi.ButtonPopedom = PopedomType.Edit;
            bi.ButtonName = "出库表单";
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
            bi.ButtonName = "出库表单";
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
        private void OnStartData(T_OutboundRecordEntity ut)
        {
        ProjectNO_Input.Text = ProjectNO_Disp.Text = ut.ProjectNO.ToString();
                EquipmentName_Input.Text = EquipmentName_Disp.Text = ut.EquipmentName.ToString();
                Model_Input.Text = Model_Disp.Text = ut.Model.ToString();
                OutboundNumber_Input.Text = OutboundNumber_Disp.Text = ut.OutboundNumber.ToString();
                BalanceNumber_Input.Text = BalanceNumber_Disp.Text = ut.BalanceNumber.ToString();
                OutboundTime_Input.Text = OutboundTime_Disp.Text = ut.OutboundTime.ToString();
                Applicant_Input.Text = Applicant_Disp.Text = ut.Applicant.ToString();
                Approver_Input.Text = Approver_Disp.Text = ut.Approver.ToString();
                IntegrityCheckCode_Input.Text = IntegrityCheckCode_Disp.Text = ut.IntegrityCheckCode.ToString();
                Remark_Input.Text = Remark_Disp.Text = ut.Remark.ToString();
                CodeNO_Input.Text = CodeNO_Disp.Text = ut.CodeNO.ToString();
                
        }

        /// <summary>
        /// 隐藏输入框
        /// </summary>
        private void Hidden_Input()
        {
        ProjectNO_Input.Visible = false;
        EquipmentName_Input.Visible = false;
        Model_Input.Visible = false;
        OutboundNumber_Input.Visible = false;
        BalanceNumber_Input.Visible = false;
        OutboundTime_Input.Visible = false;
        Applicant_Input.Visible = false;
        Approver_Input.Visible = false;
        IntegrityCheckCode_Input.Visible = false;
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
        BalanceNumber_Disp.Visible = false;
        OutboundTime_Disp.Visible = false;
        Applicant_Disp.Visible = false;
        Approver_Disp.Visible = false;
        IntegrityCheckCode_Disp.Visible = false;
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
        
            string ProjectNO_Value = (string)Common.sink(ProjectNO_Input.UniqueID, MethodType.Post, 50, 0, DataType.Str);
            string EquipmentName_Value = (string)Common.sink(EquipmentName_Input.UniqueID, MethodType.Post, 50, 0, DataType.Str);
            string Model_Value = (string)Common.sink(Model_Input.UniqueID, MethodType.Post, 50, 0, DataType.Str);
            int OutboundNumber_Value = (int)Common.sink(OutboundNumber_Input.UniqueID, MethodType.Post, 10, 0, DataType.Int);
            int BalanceNumber_Value = (int)Common.sink(BalanceNumber_Input.UniqueID, MethodType.Post, 10, 0, DataType.Int);
            
                    DateTime? OutboundTime_Value = (DateTime?)Common.sink(OutboundTime_Input.UniqueID, MethodType.Post, 50, 0, DataType.Dat);
                
            int Applicant_Value = (int)Common.sink(Applicant_Input.UniqueID, MethodType.Post, 10, 0, DataType.Int);
            int Approver_Value = (int)Common.sink(Approver_Input.UniqueID, MethodType.Post, 10, 0, DataType.Int);
            string IntegrityCheckCode_Value = (string)Common.sink(IntegrityCheckCode_Input.UniqueID, MethodType.Post, 50, 0, DataType.Str);
            string Remark_Value = (string)Common.sink(Remark_Input.UniqueID, MethodType.Post, 50, 0, DataType.Str);
            string CodeNO_Value = (string)Common.sink(CodeNO_Input.UniqueID, MethodType.Post, 50, 0, DataType.Str);
            T_OutboundRecordEntity ut = BusinessFacadeShanlitech_Location.T_OutboundRecordDisp(IDX);
            
            ut.ProjectNO = ProjectNO_Value;
            ut.EquipmentName = EquipmentName_Value;
            ut.Model = Model_Value;
            ut.OutboundNumber = OutboundNumber_Value;
            ut.BalanceNumber = BalanceNumber_Value;
            ut.OutboundTime = OutboundTime_Value;
            ut.Applicant = Applicant_Value;
            ut.Approver = Approver_Value;
            ut.IntegrityCheckCode = IntegrityCheckCode_Value;
            ut.Remark = Remark_Value;
            ut.CodeNO = CodeNO_Value;
            
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
            Int32 rInt = BusinessFacadeShanlitech_Location.T_OutboundRecordInsertUpdateDelete(ut);
            if ( rInt> 0)
            {
                string OpTxt = string.Format("增加出库表单成功!(ID:{0})", rInt);
                if (ut.DataTable_Action_ == DataTable_Action.Update)
                    OpTxt = string.Format("修改出库表单成功!(ID:{0})",IDX);
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
