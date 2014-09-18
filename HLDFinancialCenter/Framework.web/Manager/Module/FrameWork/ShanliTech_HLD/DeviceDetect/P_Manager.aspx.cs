/********************************************************************************
     File:																
            Manager.aspx.cs                         
     Description:
            压力设备检定记录管理
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

namespace ShanliTech_HLD_Business.Web.Module.ShanliTech_HLD_Business.DeviceDetect
{
    public partial class P_Manager : System.Web.UI.Page
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
            P_DetectResultEntity ut = BusinessFacadeShanliTech_HLD_Business.P_DetectResultDisp(IDX);
            OnStartData(ut);
            switch (CMD)
            { 
                //case "New":
                //    TabOptionItem1.Tab_Name = HeadMenuWebControls1.HeadOPTxt = "增加压力设备检定记录";
                //    Hidden_Disp();
                //    break;
                case "List":
                    TabOptionItem1.Tab_Name = HeadMenuWebControls1.HeadOPTxt = "查看压力设备检定记录";
                    Hidden_Input();
                    ButtonOption.Visible = false;
                    //AddEditButton();
                    break;
                //case "Edit":
                //    TabOptionItem1.Tab_Name = HeadMenuWebControls1.HeadOPTxt = "修改压力设备检定记录";
                //    Hidden_Disp();
                //    AddDeleteButton();
                //    break;
                case "Delete":
                    ut.DataTable_Action_ = DataTable_Action.Delete;
                    if (BusinessFacadeShanliTech_HLD_Business.P_DetectResultInsertUpdateDelete(ut) > 0)
                    {
                        EventMessage.MessageBox(1, "删除成功", string.Format("删除ID:{0}成功!", IDX), Icon_Type.OK, Common.GetHomeBaseUrl("P_DetectResult.aspx"));
                    }
                    else {
                        EventMessage.MessageBox(1, "删除失败", string.Format("删除ID:{0}失败!", IDX), Icon_Type.Error, Common.GetHomeBaseUrl("P_DetectResult.aspx"));
                    }
                    break;
                default :
                    EventMessage.MessageBox(2, "不存在操作字符串!", "不存在操作字符串!", Icon_Type.Error, Common.GetHomeBaseUrl("P_DetectResult.aspx"));
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
            bi.ButtonName = "压力设备检定记录";
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
            bi.ButtonName = "压力设备检定记录";
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
        private void OnStartData(P_DetectResultEntity ut)
        {
        DeviceDetectID_Input.Text = DeviceDetectID_Disp.Text = ut.DeviceDetectID.ToString();
                DeviceFunctionID_Input.Text = DeviceFunctionID_Disp.Text = ut.DeviceFunctionID.ToString();
                Unit_Input.Text = Unit_Disp.Text = ut.Unit.ToString();
                StandardValue_Input.Text = StandardValue_Disp.Text = ut.StandardValue.ToString();
                UpValue_Input.Text = UpValue_Disp.Text = ut.UpValue.ToString();
                DownValue_Input.Text = DownValue_Disp.Text = ut.DownValue.ToString();
                ValuePerMissibleError_Input.Text = ValuePerMissibleError_Disp.Text = ut.ValuePerMissibleError.ToString();
                ValueResult_Input.Text = ValueResult_Disp.Text = ut.ValueResult.ToString();
                UpChange_Input.Text = UpChange_Disp.Text = ut.UpChange.ToString();
                DownChange_Input.Text = DownChange_Disp.Text = ut.DownChange.ToString();
                ChangePerMissibleError_Input.Text = ChangePerMissibleError_Disp.Text = ut.ChangePerMissibleError.ToString();
                HysteresisErrorValue_Input.Text = HysteresisErrorValue_Disp.Text = ut.HysteresisErrorValue.ToString();
                H_PerMissibleError_Input.Text = H_PerMissibleError_Disp.Text = ut.H_PerMissibleError.ToString();
                H_Result_Input.Text = H_Result_Disp.Text = ut.H_Result.ToString();
                
        }

        /// <summary>
        /// 隐藏输入框
        /// </summary>
        private void Hidden_Input()
        {
        DeviceDetectID_Input.Visible = false;
        DeviceFunctionID_Input.Visible = false;
        Unit_Input.Visible = false;
        StandardValue_Input.Visible = false;
        UpValue_Input.Visible = false;
        DownValue_Input.Visible = false;
        ValuePerMissibleError_Input.Visible = false;
        ValueResult_Input.Visible = false;
        UpChange_Input.Visible = false;
        DownChange_Input.Visible = false;
        ChangePerMissibleError_Input.Visible = false;
        HysteresisErrorValue_Input.Visible = false;
        H_PerMissibleError_Input.Visible = false;
        H_Result_Input.Visible = false;
        
        }

        /// <summary>
        /// 隐藏显示框
        /// </summary>
        private void Hidden_Disp()
        {
        DeviceDetectID_Disp.Visible = false;
        DeviceFunctionID_Disp.Visible = false;
        Unit_Disp.Visible = false;
        StandardValue_Disp.Visible = false;
        UpValue_Disp.Visible = false;
        DownValue_Disp.Visible = false;
        ValuePerMissibleError_Disp.Visible = false;
        ValueResult_Disp.Visible = false;
        UpChange_Disp.Visible = false;
        DownChange_Disp.Visible = false;
        ChangePerMissibleError_Disp.Visible = false;
        HysteresisErrorValue_Disp.Visible = false;
        H_PerMissibleError_Disp.Visible = false;
        H_Result_Disp.Visible = false;
        
        }

        /// <summary>
        /// 增加/修改事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {
        
            int DeviceDetectID_Value = (int)Common.sink(DeviceDetectID_Input.UniqueID, MethodType.Post, 10, 0, DataType.Int);
            int DeviceFunctionID_Value = (int)Common.sink(DeviceFunctionID_Input.UniqueID, MethodType.Post, 10, 0, DataType.Int);
            string Unit_Value = (string)Common.sink(Unit_Input.UniqueID, MethodType.Post, 50, 0, DataType.Str);
            double StandardValue_Value = (double)Common.sink(StandardValue_Input.UniqueID, MethodType.Post, 53, 0, DataType.Double);
            double UpValue_Value = (double)Common.sink(UpValue_Input.UniqueID, MethodType.Post, 53, 0, DataType.Double);
            double DownValue_Value = (double)Common.sink(DownValue_Input.UniqueID, MethodType.Post, 53, 0, DataType.Double);
            double ValuePerMissibleError_Value = (double)Common.sink(ValuePerMissibleError_Input.UniqueID, MethodType.Post, 53, 0, DataType.Double);
            string ValueResult_Value = (string)Common.sink(ValueResult_Input.UniqueID, MethodType.Post, 50, 0, DataType.Str);
            double UpChange_Value = (double)Common.sink(UpChange_Input.UniqueID, MethodType.Post, 53, 0, DataType.Double);
            double DownChange_Value = (double)Common.sink(DownChange_Input.UniqueID, MethodType.Post, 53, 0, DataType.Double);
            double ChangePerMissibleError_Value = (double)Common.sink(ChangePerMissibleError_Input.UniqueID, MethodType.Post, 53, 0, DataType.Double);
            double HysteresisErrorValue_Value = (double)Common.sink(HysteresisErrorValue_Input.UniqueID, MethodType.Post, 53, 0, DataType.Double);
            double H_PerMissibleError_Value = (double)Common.sink(H_PerMissibleError_Input.UniqueID, MethodType.Post, 53, 0, DataType.Double);
            string H_Result_Value = (string)Common.sink(H_Result_Input.UniqueID, MethodType.Post, 50, 0, DataType.Str);
            P_DetectResultEntity ut = BusinessFacadeShanliTech_HLD_Business.P_DetectResultDisp(IDX);
            
            ut.DeviceDetectID = DeviceDetectID_Value;
            ut.DeviceFunctionID = DeviceFunctionID_Value;
            ut.Unit = Unit_Value;
            ut.StandardValue = StandardValue_Value;
            ut.UpValue = UpValue_Value;
            ut.DownValue = DownValue_Value;
            ut.ValuePerMissibleError = ValuePerMissibleError_Value;
            ut.ValueResult = ValueResult_Value;
            ut.UpChange = UpChange_Value;
            ut.DownChange = DownChange_Value;
            ut.ChangePerMissibleError = ChangePerMissibleError_Value;
            ut.HysteresisErrorValue = HysteresisErrorValue_Value;
            ut.H_PerMissibleError = H_PerMissibleError_Value;
            ut.H_Result = H_Result_Value;
            
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
                EventMessage.MessageBox(2, "不存在操作字符串!", "不存在操作字符串!", Icon_Type.Error, Common.GetHomeBaseUrl("P_DetectResult.aspx"));
            }
            Int32 rInt = BusinessFacadeShanliTech_HLD_Business.P_DetectResultInsertUpdateDelete(ut);
            if ( rInt> 0)
            {
                string OpTxt = string.Format("增加压力设备检定记录成功!(ID:{0})", rInt);
                if (ut.DataTable_Action_ == DataTable_Action.Update)
                    OpTxt = string.Format("修改压力设备检定记录成功!(ID:{0})",IDX);
                EventMessage.MessageBox(1, "操作成功", OpTxt, Icon_Type.OK, Common.GetHomeBaseUrl("P_DetectResult.aspx"));
            }
            else if (rInt == -2)
            {
                EventMessage.MessageBox(1, "操作失败", "操作失败,存在相同的键值(用户名/数据)!", Icon_Type.Alert, Common.GetHomeBaseUrl("P_DetectResult.aspx"));
            }
            else
            {
                EventMessage.MessageBox(1, "操作失败", string.Format("操作失败,返回值:{0}!", rInt), Icon_Type.Error, Common.GetHomeBaseUrl("P_DetectResult.aspx"));
            }
        }
    }
}
