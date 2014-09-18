/********************************************************************************
     File:																
            Manager.aspx.cs                         
     Description:
            入库表单管理
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

namespace Shanlitech_Location.Web.Module.Shanlitech_Location.T_StorageRecord
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
            T_StorageRecordEntity ut = BusinessFacadeShanlitech_Location.T_StorageRecordDisp(IDX);
            OnStartData(ut);
            switch (CMD)
            { 
                case "New":
                    TabOptionItem1.Tab_Name = HeadMenuWebControls1.HeadOPTxt = "增加入库表单";
                    Hidden_Disp();
                    break;
                case "List":
                    TabOptionItem1.Tab_Name = HeadMenuWebControls1.HeadOPTxt = "查看入库表单";
                    Hidden_Input();
                    ButtonOption.Visible = false;
                    AddEditButton();
                    break;
                case "Edit":
                    TabOptionItem1.Tab_Name = HeadMenuWebControls1.HeadOPTxt = "修改入库表单";
                    Hidden_Disp();
                    AddDeleteButton();
                    break;
                case "Delete":
                    ut.DataTable_Action_ = DataTable_Action.Delete;
                    if (BusinessFacadeShanlitech_Location.T_StorageRecordInsertUpdateDelete(ut) > 0)
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
            bi.ButtonName = "入库表单";
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
            bi.ButtonName = "入库表单";
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
        private void OnStartData(T_StorageRecordEntity ut)
        {
        VeriID_Input.Text = VeriID_Disp.Text = ut.VeriID.ToString();
                ProjectNO_Input.Text = ProjectNO_Disp.Text = ut.ProjectNO.ToString();
                EquipmentName_Input.Text = EquipmentName_Disp.Text = ut.EquipmentName.ToString();
                Model_Input.Text = Model_Disp.Text = ut.Model.ToString();
                StorageNumber_Input.Text = StorageNumber_Disp.Text = ut.StorageNumber.ToString();
                UnitPrice_Input.Text = UnitPrice_Disp.Text = ut.UnitPrice.ToString();
                StorageTime_Input.Text = StorageTime_Disp.Text = ut.StorageTime.ToString();
                Applicant_Input.Text = Applicant_Disp.Text = ut.Applicant.ToString();
                Approver_Input.Text = Approver_Disp.Text = ut.Approver.ToString();
                PayAmount_Input.Text = PayAmount_Disp.Text = ut.PayAmount.ToString();
                IntegrityCheckCode_Input.Text = IntegrityCheckCode_Disp.Text = ut.IntegrityCheckCode.ToString();
                Remark_Input.Text = Remark_Disp.Text = ut.Remark.ToString();
                CodeNO_Input.Text = CodeNO_Disp.Text = ut.CodeNO.ToString();
                
        }

        /// <summary>
        /// 隐藏输入框
        /// </summary>
        private void Hidden_Input()
        {
        VeriID_Input.Visible = false;
        ProjectNO_Input.Visible = false;
        EquipmentName_Input.Visible = false;
        Model_Input.Visible = false;
        StorageNumber_Input.Visible = false;
        UnitPrice_Input.Visible = false;
        StorageTime_Input.Visible = false;
        Applicant_Input.Visible = false;
        Approver_Input.Visible = false;
        PayAmount_Input.Visible = false;
        IntegrityCheckCode_Input.Visible = false;
        Remark_Input.Visible = false;
        CodeNO_Input.Visible = false;
        
        }

        /// <summary>
        /// 隐藏显示框
        /// </summary>
        private void Hidden_Disp()
        {
        VeriID_Disp.Visible = false;
        ProjectNO_Disp.Visible = false;
        EquipmentName_Disp.Visible = false;
        Model_Disp.Visible = false;
        StorageNumber_Disp.Visible = false;
        UnitPrice_Disp.Visible = false;
        StorageTime_Disp.Visible = false;
        Applicant_Disp.Visible = false;
        Approver_Disp.Visible = false;
        PayAmount_Disp.Visible = false;
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
        
            int VeriID_Value = (int)Common.sink(VeriID_Input.UniqueID, MethodType.Post, 10, 0, DataType.Int);
            string ProjectNO_Value = (string)Common.sink(ProjectNO_Input.UniqueID, MethodType.Post, 50, 0, DataType.Str);
            string EquipmentName_Value = (string)Common.sink(EquipmentName_Input.UniqueID, MethodType.Post, 50, 0, DataType.Str);
            string Model_Value = (string)Common.sink(Model_Input.UniqueID, MethodType.Post, 50, 0, DataType.Str);
            int StorageNumber_Value = (int)Common.sink(StorageNumber_Input.UniqueID, MethodType.Post, 10, 0, DataType.Int);
            double UnitPrice_Value = (double)Common.sink(UnitPrice_Input.UniqueID, MethodType.Post, 53, 0, DataType.Double);
            
                    DateTime? StorageTime_Value = (DateTime?)Common.sink(StorageTime_Input.UniqueID, MethodType.Post, 50, 0, DataType.Dat);
                
            int Applicant_Value = (int)Common.sink(Applicant_Input.UniqueID, MethodType.Post, 10, 0, DataType.Int);
            int Approver_Value = (int)Common.sink(Approver_Input.UniqueID, MethodType.Post, 10, 0, DataType.Int);
            double PayAmount_Value = (double)Common.sink(PayAmount_Input.UniqueID, MethodType.Post, 53, 0, DataType.Double);
            string IntegrityCheckCode_Value = (string)Common.sink(IntegrityCheckCode_Input.UniqueID, MethodType.Post, 50, 0, DataType.Str);
            string Remark_Value = (string)Common.sink(Remark_Input.UniqueID, MethodType.Post, 50, 0, DataType.Str);
            string CodeNO_Value = (string)Common.sink(CodeNO_Input.UniqueID, MethodType.Post, 50, 0, DataType.Str);
            T_StorageRecordEntity ut = BusinessFacadeShanlitech_Location.T_StorageRecordDisp(IDX);
            
            ut.VeriID = VeriID_Value;
            ut.ProjectNO = ProjectNO_Value;
            ut.EquipmentName = EquipmentName_Value;
            ut.Model = Model_Value;
            ut.StorageNumber = StorageNumber_Value;
            ut.UnitPrice = UnitPrice_Value;
            ut.StorageTime = StorageTime_Value;
            ut.Applicant = Applicant_Value;
            ut.Approver = Approver_Value;
            ut.PayAmount = PayAmount_Value;
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
            Int32 rInt = BusinessFacadeShanlitech_Location.T_StorageRecordInsertUpdateDelete(ut);
            if ( rInt> 0)
            {
                string OpTxt = string.Format("增加入库表单成功!(ID:{0})", rInt);
                if (ut.DataTable_Action_ == DataTable_Action.Update)
                    OpTxt = string.Format("修改入库表单成功!(ID:{0})",IDX);
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
