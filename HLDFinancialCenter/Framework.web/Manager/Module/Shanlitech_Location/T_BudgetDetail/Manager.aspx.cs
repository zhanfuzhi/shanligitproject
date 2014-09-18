/********************************************************************************
     File:																
            Manager.aspx.cs                         
     Description:
            预算明细管理
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

namespace Shanlitech_Location.Web.Module.Shanlitech_Location.T_BudgetDetail
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
            T_BudgetDetailEntity ut = BusinessFacadeShanlitech_Location.T_BudgetDetailDisp(IDX);
            OnStartData(ut);
            switch (CMD)
            { 
                case "New":
                    TabOptionItem1.Tab_Name = HeadMenuWebControls1.HeadOPTxt = "增加预算明细";
                    Hidden_Disp();
                    break;
                case "List":
                    TabOptionItem1.Tab_Name = HeadMenuWebControls1.HeadOPTxt = "查看预算明细";
                    Hidden_Input();
                    ButtonOption.Visible = false;
                    AddEditButton();
                    break;
                case "Edit":
                    TabOptionItem1.Tab_Name = HeadMenuWebControls1.HeadOPTxt = "修改预算明细";
                    Hidden_Disp();
                    AddDeleteButton();
                    break;
                case "Delete":
                    ut.DataTable_Action_ = DataTable_Action.Delete;
                    if (BusinessFacadeShanlitech_Location.T_BudgetDetailInsertUpdateDelete(ut) > 0)
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
            bi.ButtonName = "预算明细";
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
            bi.ButtonName = "预算明细";
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
        private void OnStartData(T_BudgetDetailEntity ut)
        {
        ProjID_Input.Text = ProjID_Disp.Text = ut.ProjID.ToString();
                EquipmentName_Input.Text = EquipmentName_Disp.Text = ut.EquipmentName.ToString();
                BudgetRevenue_Input.Text = BudgetRevenue_Disp.Text = ut.BudgetRevenue.ToString();
                Measurement_Input.Text = Measurement_Disp.Text = ut.Measurement.ToString();
                BudgetPrice_Input.Text = BudgetPrice_Disp.Text = ut.BudgetPrice.ToString();
                BudgetNumber_Input.Text = BudgetNumber_Disp.Text = ut.BudgetNumber.ToString();
                BudgetExpenditure_Input.Text = BudgetExpenditure_Disp.Text = ut.BudgetExpenditure.ToString();
                BalanceAmount_Input.Text = BalanceAmount_Disp.Text = ut.BalanceAmount.ToString();
                Supplier_Input.Text = Supplier_Disp.Text = ut.Supplier.ToString();
                Remark_Input.Text = Remark_Disp.Text = ut.Remark.ToString();
                Sort_Input.Text = Sort_Disp.Text = ut.Sort.ToString();
                
        }

        /// <summary>
        /// 隐藏输入框
        /// </summary>
        private void Hidden_Input()
        {
        ProjID_Input.Visible = false;
        EquipmentName_Input.Visible = false;
        BudgetRevenue_Input.Visible = false;
        Measurement_Input.Visible = false;
        BudgetPrice_Input.Visible = false;
        BudgetNumber_Input.Visible = false;
        BudgetExpenditure_Input.Visible = false;
        BalanceAmount_Input.Visible = false;
        Supplier_Input.Visible = false;
        Remark_Input.Visible = false;
        Sort_Input.Visible = false;
        
        }

        /// <summary>
        /// 隐藏显示框
        /// </summary>
        private void Hidden_Disp()
        {
        ProjID_Disp.Visible = false;
        EquipmentName_Disp.Visible = false;
        BudgetRevenue_Disp.Visible = false;
        Measurement_Disp.Visible = false;
        BudgetPrice_Disp.Visible = false;
        BudgetNumber_Disp.Visible = false;
        BudgetExpenditure_Disp.Visible = false;
        BalanceAmount_Disp.Visible = false;
        Supplier_Disp.Visible = false;
        Remark_Disp.Visible = false;
        Sort_Disp.Visible = false;
        
        }

        /// <summary>
        /// 增加/修改事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {
        
            int ProjID_Value = (int)Common.sink(ProjID_Input.UniqueID, MethodType.Post, 10, 0, DataType.Int);
            string EquipmentName_Value = (string)Common.sink(EquipmentName_Input.UniqueID, MethodType.Post, 50, 0, DataType.Str);
            double BudgetRevenue_Value = (double)Common.sink(BudgetRevenue_Input.UniqueID, MethodType.Post, 53, 0, DataType.Double);
            string Measurement_Value = (string)Common.sink(Measurement_Input.UniqueID, MethodType.Post, 50, 0, DataType.Str);
            double BudgetPrice_Value = (double)Common.sink(BudgetPrice_Input.UniqueID, MethodType.Post, 53, 0, DataType.Double);
            int BudgetNumber_Value = (int)Common.sink(BudgetNumber_Input.UniqueID, MethodType.Post, 10, 0, DataType.Int);
            double BudgetExpenditure_Value = (double)Common.sink(BudgetExpenditure_Input.UniqueID, MethodType.Post, 53, 0, DataType.Double);
            double BalanceAmount_Value = (double)Common.sink(BalanceAmount_Input.UniqueID, MethodType.Post, 53, 0, DataType.Double);
            string Supplier_Value = (string)Common.sink(Supplier_Input.UniqueID, MethodType.Post, 50, 0, DataType.Str);
            string Remark_Value = (string)Common.sink(Remark_Input.UniqueID, MethodType.Post, 50, 0, DataType.Str);
            int Sort_Value = (int)Common.sink(Sort_Input.UniqueID, MethodType.Post, 10, 0, DataType.Int);
            T_BudgetDetailEntity ut = BusinessFacadeShanlitech_Location.T_BudgetDetailDisp(IDX);
            
            ut.ProjID = ProjID_Value;
            ut.EquipmentName = EquipmentName_Value;
            ut.BudgetRevenue = BudgetRevenue_Value;
            ut.Measurement = Measurement_Value;
            ut.BudgetPrice = BudgetPrice_Value;
            ut.BudgetNumber = BudgetNumber_Value;
            ut.BudgetExpenditure = BudgetExpenditure_Value;
            ut.BalanceAmount = BalanceAmount_Value;
            ut.Supplier = Supplier_Value;
            ut.Remark = Remark_Value;
            ut.Sort = Sort_Value;
            
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
            Int32 rInt = BusinessFacadeShanlitech_Location.T_BudgetDetailInsertUpdateDelete(ut);
            if ( rInt> 0)
            {
                string OpTxt = string.Format("增加预算明细成功!(ID:{0})", rInt);
                if (ut.DataTable_Action_ == DataTable_Action.Update)
                    OpTxt = string.Format("修改预算明细成功!(ID:{0})",IDX);
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
