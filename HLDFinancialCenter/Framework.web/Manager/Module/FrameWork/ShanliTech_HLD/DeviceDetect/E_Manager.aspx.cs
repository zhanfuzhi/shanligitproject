/********************************************************************************
     File:																
            Manager.aspx.cs                         
     Description:
            电气设备检定记录管理
     Author:									
            DDBuildTools
            http://DDBuildTools.supesoft.com
     Finish DateTime:
            2013/1/7 15:09:47
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

namespace ShanliTech_HLD_Business.Web.Module.ShanliTech_HLD_Business.DeviceDetect
{
    public partial class E_Manager : System.Web.UI.Page
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
            E_DetectResultEntity ut = BusinessFacadeShanliTech_HLD_Business.E_DetectResultDisp(IDX);
            OnStartData(ut);
            switch (CMD)
            { 
                case "New":
                    TabOptionItem1.Tab_Name = HeadMenuWebControls1.HeadOPTxt = "增加电气设备检定记录";
                    Hidden_Disp();
                    break;
                case "List":
                    TabOptionItem1.Tab_Name = HeadMenuWebControls1.HeadOPTxt = "查看电气设备检定记录";
                    Hidden_Input();
                    ButtonOption.Visible = false;
                    AddEditButton();
                    break;
                case "Edit":
                    TabOptionItem1.Tab_Name = HeadMenuWebControls1.HeadOPTxt = "修改电气设备检定记录";
                    Hidden_Disp();
                    AddDeleteButton();
                    break;
                case "Delete":
                    ut.DataTable_Action_ = DataTable_Action.Delete;
                    if (BusinessFacadeShanliTech_HLD_Business.E_DetectResultInsertUpdateDelete(ut) > 0)
                    {
                        EventMessage.MessageBox(1, "删除成功", string.Format("删除ID:{0}成功!", IDX), Icon_Type.OK, Common.GetHomeBaseUrl("E_DetectResult.aspx"));
                    }
                    else {
                        EventMessage.MessageBox(1, "删除失败", string.Format("删除ID:{0}失败!", IDX), Icon_Type.Error, Common.GetHomeBaseUrl("E_DetectResult.aspx"));
                    }
                    break;
                default :
                    EventMessage.MessageBox(2, "不存在操作字符串!", "不存在操作字符串!", Icon_Type.Error, Common.GetHomeBaseUrl("E_DetectResult.aspx"));
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
            bi.ButtonName = "电气设备检定记录";
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
            bi.ButtonName = "电气设备检定记录";
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
        private void OnStartData(E_DetectResultEntity ut)
        {
        //DeviceDetectID_Input.Text = DeviceDetectID_Disp.Text = ut.DeviceDetectID.ToString();
            DeviceFunctionID_Input.Text = DeviceFunctionID_Disp.Text = ut.DeviceFunctionID.ToString();
                MaxPerMissibleError_Input.Text = MaxPerMissibleError_Disp.Text = ut.MaxPerMissibleError.ToString();
                Result_Input.Text = Result_Disp.Text = ut.Result.ToString();
                StandardValue_Input.Text = StandardValue_Disp.Text = ut.StandardValue.ToString();
                TestedPerissibleError_Input.Text = TestedPerissibleError_Disp.Text = ut.TestedPerissibleError.ToString();
                TestedValue_Input.Text = TestedValue_Disp.Text = ut.TestedValue.ToString();
                TestRange_Input.Text = TestRange_Disp.Text = ut.TestRange.ToString();
                Unit_Input.Text = Unit_Disp.Text = ut.Unit.ToString();
                FunctionCode_Input.Text = FunctionCode_Disp.Text = ut.FunctionCode.ToString();
                Frequency_Input.Text = Frequency_Disp.Text = ut.Frequency.ToString();
                FrequencyUnit_Input.Text = FrequencyUnit_Disp.Text = ut.FrequencyUnit.ToString();
                
        }

        /// <summary>
        /// 隐藏输入框
        /// </summary>
        private void Hidden_Input()
        {
        //DeviceDetectID_Input.Visible = false;
        DeviceFunctionID_Input.Visible = false;
        MaxPerMissibleError_Input.Visible = false;
        Result_Input.Visible = false;
        StandardValue_Input.Visible = false;
        TestedPerissibleError_Input.Visible = false;
        TestedValue_Input.Visible = false;
        TestRange_Input.Visible = false;
        Unit_Input.Visible = false;
        FunctionCode_Input.Visible = false;
        Frequency_Input.Visible = false;
        FrequencyUnit_Input.Visible = false;
        
        }

        /// <summary>
        /// 隐藏显示框
        /// </summary>
        private void Hidden_Disp()
        {
        //DeviceDetectID_Disp.Visible = false;
        DeviceFunctionID_Disp.Visible = false;
        MaxPerMissibleError_Disp.Visible = false;
        Result_Disp.Visible = false;
        StandardValue_Disp.Visible = false;
        TestedPerissibleError_Disp.Visible = false;
        TestedValue_Disp.Visible = false;
        TestRange_Disp.Visible = false;
        Unit_Disp.Visible = false;
        FunctionCode_Disp.Visible = false;
        Frequency_Disp.Visible = false;
        FrequencyUnit_Disp.Visible = false;
        
        }

        /// <summary>
        /// 增加/修改事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {
        
            //int DeviceDetectID_Value = (int)Common.sink(DeviceDetectID_Input.UniqueID, MethodType.Post, 10, 0, DataType.Int);
            //int DeviceFunctionID_Value = (int)Common.sink(DeviceFunctionID_Input.UniqueID, MethodType.Post, 10, 0, DataType.Int);
            double MaxPerMissibleError_Value = (double)Common.sink(MaxPerMissibleError_Input.UniqueID, MethodType.Post, 53, 0, DataType.Double);
            string Result_Value = (string)Common.sink(Result_Input.UniqueID, MethodType.Post, 50, 0, DataType.Str);
            double StandardValue_Value = (double)Common.sink(StandardValue_Input.UniqueID, MethodType.Post, 53, 0, DataType.Double);
            double TestedPerissibleError_Value = (double)Common.sink(TestedPerissibleError_Input.UniqueID, MethodType.Post, 53, 0, DataType.Double);
            double TestedValue_Value = (double)Common.sink(TestedValue_Input.UniqueID, MethodType.Post, 53, 0, DataType.Double);
            double TestRange_Value = (double)Common.sink(TestRange_Input.UniqueID, MethodType.Post, 53, 0, DataType.Double);
            string Unit_Value = (string)Common.sink(Unit_Input.UniqueID, MethodType.Post, 50, 0, DataType.Str);
            string FunctionCode_Value = (string)Common.sink(FunctionCode_Input.UniqueID, MethodType.Post, 50, 0, DataType.Str);
            double Frequency_Value = (double)Common.sink(Frequency_Input.UniqueID, MethodType.Post, 53, 0, DataType.Double);
            string FrequencyUnit_Value = (string)Common.sink(FrequencyUnit_Input.UniqueID, MethodType.Post, 50, 0, DataType.Str);
            E_DetectResultEntity ut = BusinessFacadeShanliTech_HLD_Business.E_DetectResultDisp(IDX);
            
            //ut.DeviceDetectID = DeviceDetectID_Value;
            //ut.DeviceFunctionID = DeviceFunctionID_Value;
            ut.MaxPerMissibleError = MaxPerMissibleError_Value;
            ut.Result = Result_Value;
            ut.StandardValue = StandardValue_Value;
            ut.TestedPerissibleError = TestedPerissibleError_Value;
            ut.TestedValue = TestedValue_Value;
            ut.TestRange = TestRange_Value;
            ut.Unit = Unit_Value;
            ut.FunctionCode = FunctionCode_Value;
            ut.Frequency = Frequency_Value;
            ut.FrequencyUnit = FrequencyUnit_Value;
            
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
                EventMessage.MessageBox(2, "不存在操作字符串!", "不存在操作字符串!", Icon_Type.Error, Common.GetHomeBaseUrl("E_DetectResult.aspx"));
            }
            Int32 rInt = BusinessFacadeShanliTech_HLD_Business.E_DetectResultInsertUpdateDelete(ut);
            if ( rInt> 0)
            {
                string OpTxt = string.Format("增加电气设备检定记录成功!(ID:{0})", rInt);
                if (ut.DataTable_Action_ == DataTable_Action.Update)
                    OpTxt = string.Format("修改电气设备检定记录成功!(ID:{0})",IDX);
                EventMessage.MessageBox(1, "操作成功", OpTxt, Icon_Type.OK, Common.GetHomeBaseUrl("E_DetectResult.aspx"));
            }
            else if (rInt == -2)
            {
                EventMessage.MessageBox(1, "操作失败", "操作失败,存在相同的键值(用户名/数据)!", Icon_Type.Alert, Common.GetHomeBaseUrl("E_DetectResult.aspx"));
            }
            else
            {
                EventMessage.MessageBox(1, "操作失败", string.Format("操作失败,返回值:{0}!", rInt), Icon_Type.Error, Common.GetHomeBaseUrl("E_DetectResult.aspx"));
            }
        }
    }
}
