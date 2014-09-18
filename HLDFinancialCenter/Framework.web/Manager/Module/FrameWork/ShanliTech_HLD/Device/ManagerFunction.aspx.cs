/********************************************************************************
     File:																
            Manager.aspx.cs                         
     Description:
            DeviceFunction管理
     Author:									
            DDBuildTools
            http://DDBuildTools.supesoft.com
     Finish DateTime:
            2012/12/26 11:58:00
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

using ShanliTech_HLD_Business;
using ShanliTech_HLD_Business.Components;
using FrameWork;
using FrameWork.Components;
using FrameWork.WebControls;
using System.Collections.Generic;

namespace ShanliTech_HLD_Business.Web.Module.ShanliTech_HLD_Business.Device
{
    public partial class ManagerFunction : System.Web.UI.Page
    {
        Int32 DeviceID = (Int32)Common.sink("DeviceID", MethodType.Get, 10, 0, DataType.Int);
        Int32 IDX = (Int32)Common.sink("IDX", MethodType.Get, 10, 0, DataType.Int);
        string CMD = (string)Common.sink("CMD", MethodType.Get, 10, 1, DataType.Str);
        protected void Page_Load(object sender, EventArgs e)
        {
           
            FrameWorkPermission.CheckPagePermission(CMD);
            AddListButton();
            if (!Page.IsPostBack)
            {
                //ToolMethods.InitDropDownFunction(FunctionTemplates_DropDown);
                //ToolMethods.InitDropDownDevice(DeviceID_DropDown);
                OnStart();
            }
        }
       
        /// <summary>
        /// 开始操作
        /// </summary>
        private void OnStart()
        {
            DeviceFunctionEntity ut = BusinessFacadeShanliTech_HLD_Business.DeviceFunctionDisp(IDX);
            OnStartData(ut);
            switch (CMD)
            { 
                case "New":
                    TabOptionItem1.Tab_Name = HeadMenuWebControls1.HeadOPTxt = "增加设备功能";
                    Hidden_Disp();
                    break;
                case "List":
                    TabOptionItem1.Tab_Name = HeadMenuWebControls1.HeadOPTxt = "查看设备功能";
                    Hidden_Input();
                    ButtonOption.Visible = false;
                    AddEditButton();
                    break;
                case "Edit":
                    TabOptionItem1.Tab_Name = HeadMenuWebControls1.HeadOPTxt = "修改设备功能";
                    Hidden_Disp();
                    AddDeleteButton();
                    break;
                case "Delete":
                    ToolMethods.PointDeleteByFunctionID(IDX);   //级联删除功能相关测试点

                    ut.DataTable_Action_ = DataTable_Action.Update;
                    ut.DelFlag = true;
                    if (BusinessFacadeShanliTech_HLD_Business.DeviceFunctionInsertUpdateDelete(ut) > 0)
                    {
                        EventMessage.MessageBox(1, "删除成功", string.Format("删除ID:{0}成功!", IDX), Icon_Type.OK, Common.GetHomeBaseUrl("DefaultFunction.aspx?DeviceID="+DeviceID));
                    }
                    else {
                        EventMessage.MessageBox(1, "删除失败", string.Format("删除ID:{0}失败!", IDX), Icon_Type.Error, Common.GetHomeBaseUrl("DefaultFunction.aspx?DeviceID=" + DeviceID));
                    }
                    break;
                default :
                    EventMessage.MessageBox(2, "不存在操作字符串!", "不存在操作字符串!", Icon_Type.Error, Common.GetHomeBaseUrl("DefaultFunction.aspx?DeviceID=" + DeviceID));
                    break;
            }
        }

        /// <summary>
        /// 列表按钮
        /// </summary>
        private void AddListButton()
        {
            HeadMenuButtonItem bi = new HeadMenuButtonItem();
            bi.ButtonPopedom = PopedomType.List;
            bi.ButtonName = "设备功能";
            bi.ButtonUrl = string.Format("DefaultFunction.aspx?CMD=List&DeviceID={0}", DeviceID);
            HeadMenuWebControls1.ButtonList.Add(bi);
        }
        /// <summary>
        /// 增加修改按钮
        /// </summary>
        private void AddEditButton()
        {
            HeadMenuButtonItem bi = new HeadMenuButtonItem();
            bi.ButtonPopedom = PopedomType.Edit;
            bi.ButtonName = "设备功能";
            bi.ButtonUrl = string.Format("?CMD=Edit&IDX={0}&DeviceID={1}" , IDX,DeviceID);
            HeadMenuWebControls1.ButtonList.Add(bi);
        }


        /// <summary>
        /// 增加删除按钮
        /// </summary>
        private void AddDeleteButton()
        {
            HeadMenuButtonItem bi = new HeadMenuButtonItem();
            bi.ButtonPopedom = PopedomType.Delete;
            bi.ButtonName = "设备功能";
            bi.ButtonUrlType = UrlType.JavaScript;
            bi.ButtonUrl = string.Format("DelData('?CMD=Delete&IDX={0}&DeviceID={1}')", IDX,DeviceID);
            HeadMenuWebControls1.ButtonList.Add(bi);

            HeadMenuButtonItem bi1 = new HeadMenuButtonItem();
            bi1.ButtonPopedom = PopedomType.List;
            bi1.ButtonIcon = "back.gif";
            bi1.ButtonName = "返回";
            bi1.ButtonUrl = string.Format("?CMD=List&IDX={0}&DeviceID={1}", IDX,DeviceID);
            HeadMenuWebControls1.ButtonList.Add(bi1);
        }

        /// <summary>
        /// 初始化数据
        /// </summary>
        /// <param name="ut"></param>
        private void OnStartData(DeviceFunctionEntity ut)
        {
        AccuracyLevel_Input.Text = AccuracyLevel_Disp.Text = ut.AccuracyLevel.ToString();
                DetectBasisCode_Input.Text = DetectBasisCode_Disp.Text = ut.DetectBasisCode.ToString();
                DetectBasisName_Input.Text = DetectBasisName_Disp.Text = ut.DetectBasisName.ToString();
                //DeviceID_Input.Text = DeviceID_Disp.Text = DeviceID.ToString();
                //DeviceID_DropDown.SelectedValue = ut.DeviceID.ToString();
                //DeviceID_Disp.Text = DeviceID_DropDown.SelectedItem.Text;

                FunctionCode_Input.Text = FunctionCode_Disp.Text = ut.FunctionCode.ToString();
                FunctionName_Input.Text = FunctionName_Disp.Text = ut.FunctionName.ToString();
                TestRange_Input.Text = TestRange_Disp.Text = ut.TestRange.ToString();
                SourceValidDate_Input.Text = SourceValidDate_Disp.Text = ut.SourceValidDate.ToString();
                
                DeviceID_Disp.Text = BusinessFacadeShanliTech_HLD_Business.DeviceDisp(DeviceID).DeviceNum;
                //OrderID_Input.Text = OrderID_Disp.Text = ut.OrderID.ToString();
                
        }

        /// <summary>
        /// 隐藏输入框
        /// </summary>
        private void Hidden_Input()
        {
        AccuracyLevel_Input.Visible = false;
        DetectBasisCode_Input.Visible = false;
        DetectBasisName_Input.Visible = false;
        //DeviceID_Input.Visible = false;
        //DeviceID_DropDown.Visible = false;
        FunctionCode_Input.Visible = false;
        FunctionName_Input.Visible = false;
        TestRange_Input.Visible = false;
        SourceValidDate_Input.Visible = false;
        
        //OrderID_Input.Visible = false;
        
        }

        /// <summary>
        /// 隐藏显示框
        /// </summary>
        private void Hidden_Disp()
        {
        AccuracyLevel_Disp.Visible = false;
        DetectBasisCode_Disp.Visible = false;
        DetectBasisName_Disp.Visible = false;
        //DeviceID_Disp.Visible = false;
        FunctionCode_Disp.Visible = false;
        FunctionName_Disp.Visible = false;
        TestRange_Disp.Visible = false;
        SourceValidDate_Disp.Visible = false;
        
        //OrderID_Disp.Visible = false;
        }

        /// <summary>
        /// 增加/修改事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {
        
            string AccuracyLevel_Value = ((string)Common.sink(AccuracyLevel_Input.UniqueID, MethodType.Post, 50, 0, DataType.Str)).Trim();
            string DetectBasisCode_Value = ((string)Common.sink(DetectBasisCode_Input.UniqueID, MethodType.Post, 50, 0, DataType.Str)).Trim();
            string DetectBasisName_Value = ((string)Common.sink(DetectBasisName_Input.UniqueID, MethodType.Post, 50, 0, DataType.Str)).Trim();
            //int DeviceID_Value = (int)Common.sink(DeviceID_Input.UniqueID, MethodType.Post, 10, 0, DataType.Int);
            string FunctionCode_Value = ((string)Common.sink(FunctionCode_Input.UniqueID, MethodType.Post, 50, 0, DataType.Str)).Trim();
            string FunctionName_Value = ((string)Common.sink(FunctionName_Input.UniqueID, MethodType.Post, 50, 0, DataType.Str)).Trim();
            string TestRange_Value = ((string)Common.sink(TestRange_Input.UniqueID, MethodType.Post, 50, 0, DataType.Str)).Trim();
            string SourceValidDate_Value = ((string)Common.sink(SourceValidDate_Input.UniqueID, MethodType.Post, 50, 0, DataType.Str)).Trim();
            //int OrderID_Value = (int)Common.sink(OrderID_Input.UniqueID, MethodType.Post, 10, 0, DataType.Int);

            int DeviceID_Value = DeviceID;// Convert.ToInt32(DeviceID_DropDown.SelectedValue);

            //对应设备
            if (DeviceID_Value <= 0)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "alert1", "<script>alert('请选择对应设备编号');</script>");
                return;
            }
           

            DeviceFunctionEntity ut = BusinessFacadeShanliTech_HLD_Business.DeviceFunctionDisp(IDX);
            
            ut.AccuracyLevel = AccuracyLevel_Value;
            ut.DetectBasisCode = DetectBasisCode_Value;
            ut.DetectBasisName = DetectBasisName_Value;
            ut.DeviceID = DeviceID_Value;
            ut.FunctionCode = FunctionCode_Value;
            ut.FunctionName = FunctionName_Value;
            ut.TestRange = TestRange_Value;
            ut.SourceValidDate = SourceValidDate_Value;
            ut.DelFlag = false;
            ut.Inputter = UserData.GetUserDate.UserID;
            ut.InputTime = DateTime.Now;
            ut.State = 0;
            //ut.OrderID = OrderID_Value;
            
            if (CMD == "New")
            {
                ut.DataTable_Action_ = DataTable_Action.Insert;
                ut.OrderID = ToolMethods.GetMaxOrderIdFunc(DeviceID) + 1;
            }
            else if (CMD == "Edit")
            {
                ut.DataTable_Action_ = DataTable_Action.Update;
            }
            else
            {
                EventMessage.MessageBox(2, "不存在操作字符串!", "不存在操作字符串!", Icon_Type.Error, Common.GetHomeBaseUrl("DefaultFunction.aspx?DeviceID=" + DeviceID));
            }
            Int32 rInt = BusinessFacadeShanliTech_HLD_Business.DeviceFunctionInsertUpdateDelete(ut);
            if ( rInt> 0)
            {
                string OpTxt = string.Format("增加设备功能成功!(ID:{0})", rInt);
                if (ut.DataTable_Action_ == DataTable_Action.Update)
                    OpTxt = string.Format("修改设备功能成功!(ID:{0})", IDX);
                EventMessage.MessageBox(1, "操作成功", OpTxt, Icon_Type.OK, Common.GetHomeBaseUrl("DefaultFunction.aspx?DeviceID=" + DeviceID));
            }
            else if (rInt == -2)
            {
                EventMessage.MessageBox(1, "操作失败", "操作失败,存在相同的键值(用户名/数据)!", Icon_Type.Alert, Common.GetHomeBaseUrl("DefaultFunction.aspx?DeviceID=" + DeviceID));
            }
            else
            {
                EventMessage.MessageBox(1, "操作失败", string.Format("操作失败,返回值:{0}!", rInt), Icon_Type.Error, Common.GetHomeBaseUrl("DefaultFunction.aspx?DeviceID=" + DeviceID));
            }
        }

    }
}
