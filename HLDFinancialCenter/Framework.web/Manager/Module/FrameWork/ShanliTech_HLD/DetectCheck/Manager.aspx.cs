/********************************************************************************
     File:																
            Manager.aspx.cs                         
     Description:
            设备检测管理
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

namespace ShanliTech_HLD_Business.Web.Module.ShanliTech_HLD_Business.DetectCheck
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
            DeviceDetectEntity ut = BusinessFacadeShanliTech_HLD_Business.DeviceDetectDisp(IDX);
            OnStartData(ut);
            switch (CMD)
            { 
                //case "New":
                //    TabOptionItem1.Tab_Name = HeadMenuWebControls1.HeadOPTxt = "增加设备检测";
                //    Hidden_Disp();
                //    break;
                case "List":
                    TabOptionItem1.Tab_Name = HeadMenuWebControls1.HeadOPTxt = "查看设备检测";
                    Hidden_Input();
                    ButtonOption.Visible = false;
                    //AddEditButton();
                    break;
                //case "Edit":
                //    TabOptionItem1.Tab_Name = HeadMenuWebControls1.HeadOPTxt = "修改设备检测";
                //    Hidden_Disp();
                //    AddDeleteButton();
                //    break;
                case "Delete":
                    ut.DataTable_Action_ = DataTable_Action.Delete;
                    if (BusinessFacadeShanliTech_HLD_Business.DeviceDetectInsertUpdateDelete(ut) > 0)
                    {
                        EventMessage.MessageBox(1, "删除成功", string.Format("删除ID:{0}成功!", IDX), Icon_Type.OK, Common.GetHomeBaseUrl("DefaultCheck.aspx"));
                    }
                    else {
                        EventMessage.MessageBox(1, "删除失败", string.Format("删除ID:{0}失败!", IDX), Icon_Type.Error, Common.GetHomeBaseUrl("DefaultCheck.aspx"));
                    }
                    break;
                default :
                    EventMessage.MessageBox(2, "不存在操作字符串!", "不存在操作字符串!", Icon_Type.Error, Common.GetHomeBaseUrl("DefaultCheck.aspx"));
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
            bi.ButtonName = "设备检测";
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
            bi.ButtonName = "设备检测";
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
        private void OnStartData(DeviceDetectEntity ut)
        {

            //StandardDeviceID_Input.Text = StandardDeviceID_Disp.Text = ut.StandardDeviceID.ToString();
            //WillTestDeviceID_Input.Text = WillTestDeviceID_Disp.Text = ut.WillTestDeviceID.ToString();
            CertificateNum_Input.Text = CertificateNum_Disp.Text = ut.CertificateNum.ToString();
            //CertificateType_Input.Text = CertificateType_Disp.Text = ut.CertificateType.ToString();
            DetectLocation_Input.Text = DetectLocation_Disp.Text = ut.DetectLocation.ToString();
            DetectResult_Input.Text = DetectResult_Disp.Text = ut.DetectResult.ToString();
            EnvironmentNote_Input.Text = EnvironmentNote_Disp.Text = ut.EnvironmentNote.ToString();

            string defStr = "/";
            if (ut.Humidity != 0)
                defStr = ut.Humidity.ToString() + ut.HumidityUnit;
            Humidity_Input.Text = Humidity_Disp.Text = defStr;
            //HumidityUnit_Input.Text = HumidityUnit_Disp.Text = ut.HumidityUnit.ToString();
            if (ut.Temperature != 0)
                defStr = ut.Temperature.ToString() + ut.TemperatureUnit;
            Temperature_Input.Text = Temperature_Disp.Text = defStr;
            //TemperatureUnit_Input.Text = TemperatureUnit_Disp.Text = ut.TemperatureUnit.ToString();
            ValidDate_Input.Text = ValidDate_Disp.Text = ut.ValidDate.ToString();
            DetectNote_Input.Text = DetectNote_Disp.Text = ut.DetectNote.ToString();
            //ReportType_Input.Text = ReportType_Disp.Text = ut.ReportType.ToString();
            //ReportPath_Input.Text = ReportPath_Disp.Text = ut.ReportPath.ToString();
            DetectUserName_Input.Text = DetectUserName_Disp.Text = ut.DetectUserName.ToString();
            //DetectUserID_Input.Text = DetectUserID_Disp.Text = ut.DetectUserID.ToString();
            DetectDate_Input.Text = DetectDate_Disp.Text = ut.DetectDate.ToString();
            Verifier_Input.Text = Verifier_Disp.Text = ut.Verifier.ToString();
            //VerifierID_Input.Text = VerifierID_Disp.Text = ut.VerifierID.ToString();
            VerifyFlag_Input.Text = VerifyFlag_Disp.Text = ToolMethods.GetVerifyStringByFlag(ut.VerifyFlag);
            VerifyTime_Input.Text = VerifyTime_Disp.Text = ut.VerifyTime.ToString();
            Approver_Input.Text = Approver_Disp.Text = ut.Approver.ToString();
            //ApproverID_Input.Text = ApproverID_Disp.Text = ut.ApproverID.ToString();
            ApproveFlag_Input.Text = ApproveFlag_Disp.Text = ToolMethods.GetApproveStringByFlag(ut.ApproveFlag);
            ApproveTime_Input.Text = ApproveTime_Disp.Text = ut.ApproveTime.ToString();
            SurfaceCheck_Input.Text = SurfaceCheck_Disp.Text = (ut.OutwardCheckFlag > 0 ? "合格" : "不合格");

            DeviceEntity device = BusinessFacadeShanliTech_HLD_Business.DeviceDisp(ut.WillTestDeviceID);
            if ("DEVICE_CATE_P".Equals(device.DeviceCategoryCode))
            {
                ZeroPointCheck_Input.Text = ZeroPointCheck_Disp.Text = ut.ZeroPointCheck.ToString();
                WithstandCheck_Input.Text = WithstandCheck_Disp.Text = ut.WithstandCheck.ToString();
                PointerSmoothCheck_Input.Text = PointerSmoothCheck_Disp.Text = ut.PointerSmoothCheck.ToString();
            }
            else if ("DEVICE_CATE_AP".Equals(device.DeviceCategoryCode))
            {
                ZeroCheck_TR.Visible = false;
                WithstandCheck_Input.Text = WithstandCheck_Disp.Text = ut.WithstandCheck.ToString();
                PointerSmoothCheck_Input.Text = PointerSmoothCheck_Disp.Text = ut.PointerSmoothCheck.ToString();
            }
            else if ("DEVICE_CATE_E".Equals(device.DeviceCategoryCode))
                P_Properties.Visible = false;

            
            StandardDeviceName_Input.Text = StandardDeviceName_Disp.Text = ut.StandardDeviceName.ToString();
            WillTestDeviceName_Input.Text = WillTestDeviceName_Disp.Text = ut.WillTestDeviceName.ToString();


            ReportType_Disp.Text = ToolMethods.GetDictionaryNameByID(ut.ReportType.ToString());
            //ReportType
        }

        /// <summary>
        /// 隐藏输入框
        /// </summary>
        private void Hidden_Input()
        {
            //StandardDeviceID_Input.Visible = false;
            //WillTestDeviceID_Input.Visible = false;
            CertificateNum_Input.Visible = false;
            //CertificateType_Input.Visible = false;
            DetectLocation_Input.Visible = false;
            DetectResult_Input.Visible = false;
            EnvironmentNote_Input.Visible = false;
            Humidity_Input.Visible = false;
            //HumidityUnit_Input.Visible = false;
            Temperature_Input.Visible = false;
            //TemperatureUnit_Input.Visible = false;
            ValidDate_Input.Visible = false;
            DetectNote_Input.Visible = false;
            ReportType_Input.Visible = false;
            //ReportPath_Input.Visible = false;
            DetectUserName_Input.Visible = false;
            //DetectUserID_Input.Visible = false;
            DetectDate_Input.Visible = false;
            Verifier_Input.Visible = false;
            //VerifierID_Input.Visible = false;
            VerifyFlag_Input.Visible = false;
            VerifyTime_Input.Visible = false;
            Approver_Input.Visible = false;
            //ApproverID_Input.Visible = false;
            ApproveFlag_Input.Visible = false;
            ApproveTime_Input.Visible = false;
            SurfaceCheck_Input.Visible = false;
            ZeroPointCheck_Input.Visible = false;
            WithstandCheck_Input.Visible = false;
            PointerSmoothCheck_Input.Visible = false;
            StandardDeviceName_Input.Visible = false;
            WillTestDeviceName_Input.Visible = false;
        
        }

        /// <summary>
        /// 隐藏显示框
        /// </summary>
        private void Hidden_Disp()
        {
            //StandardDeviceID_Disp.Visible = false;
            //WillTestDeviceID_Disp.Visible = false;
            CertificateNum_Disp.Visible = false;
            //CertificateType_Disp.Visible = false;
            DetectLocation_Disp.Visible = false;
            DetectResult_Disp.Visible = false;
            EnvironmentNote_Disp.Visible = false;
            Humidity_Disp.Visible = false;
            //HumidityUnit_Disp.Visible = false;
            Temperature_Disp.Visible = false;
            //TemperatureUnit_Disp.Visible = false;
            ValidDate_Disp.Visible = false;
            DetectNote_Disp.Visible = false;
            ReportType_Disp.Visible = false;
            //ReportPath_Disp.Visible = false;
            DetectUserName_Disp.Visible = false;
            //DetectUserID_Disp.Visible = false;
            DetectDate_Disp.Visible = false;
            Verifier_Disp.Visible = false;
            //VerifierID_Disp.Visible = false;
            VerifyFlag_Disp.Visible = false;
            VerifyTime_Disp.Visible = false;
            Approver_Disp.Visible = false;
            //ApproverID_Disp.Visible = false;
            ApproveFlag_Disp.Visible = false;
            ApproveTime_Disp.Visible = false;
            SurfaceCheck_Disp.Visible = false;
            ZeroPointCheck_Disp.Visible = false;
            WithstandCheck_Disp.Visible = false;
            PointerSmoothCheck_Disp.Visible = false;
            StandardDeviceName_Disp.Visible = false;
            WillTestDeviceName_Disp.Visible = false;
        
        }

        /// <summary>
        /// 增加/修改事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {

            //int StandardDeviceID_Value = (int)Common.sink(StandardDeviceID_Input.UniqueID, MethodType.Post, 10, 0, DataType.Int);
            //int WillTestDeviceID_Value = (int)Common.sink(WillTestDeviceID_Input.UniqueID, MethodType.Post, 10, 0, DataType.Int);
            string CertificateNum_Value = ((string)Common.sink(CertificateNum_Input.UniqueID, MethodType.Post, 50, 0, DataType.Str)).Trim();
            //int CertificateType_Value = (int)Common.sink(CertificateType_Input.UniqueID, MethodType.Post, 10, 0, DataType.Int);
            string DetectLocation_Value = ((string)Common.sink(DetectLocation_Input.UniqueID, MethodType.Post, 50, 0, DataType.Str)).Trim();
            string DetectResult_Value = ((string)Common.sink(DetectResult_Input.UniqueID, MethodType.Post, 50, 0, DataType.Str)).Trim();
            string EnvironmentNote_Value = ((string)Common.sink(EnvironmentNote_Input.UniqueID, MethodType.Post, 50, 0, DataType.Str)).Trim();
            double Humidity_Value = (double)Common.sink(Humidity_Input.UniqueID, MethodType.Post, 53, 0, DataType.Double);
            //string HumidityUnit_Value = (string)Common.sink(HumidityUnit_Input.UniqueID, MethodType.Post, 50, 0, DataType.Str);
            double Temperature_Value = (double)Common.sink(Temperature_Input.UniqueID, MethodType.Post, 53, 0, DataType.Double);
            //string TemperatureUnit_Value = (string)Common.sink(TemperatureUnit_Input.UniqueID, MethodType.Post, 50, 0, DataType.Str);

            DateTime? ValidDate_Value = (DateTime?)Common.sink(ValidDate_Input.UniqueID, MethodType.Post, 50, 0, DataType.Dat);

            string DetectNote_Value = ((string)Common.sink(DetectNote_Input.UniqueID, MethodType.Post, 300, 0, DataType.Str)).Trim();
            //int ReportType_Value = (int)Common.sink(ReportType_Input.UniqueID, MethodType.Post, 10, 0, DataType.Int);
            //string ReportPath_Value = (string)Common.sink(ReportPath_Input.UniqueID, MethodType.Post, 200, 0, DataType.Str);
            string DetectUserName_Value = ((string)Common.sink(DetectUserName_Input.UniqueID, MethodType.Post, 50, 0, DataType.Str)).Trim();
            //int DetectUserID_Value = (int)Common.sink(DetectUserID_Input.UniqueID, MethodType.Post, 10, 0, DataType.Int);

            DateTime? DetectDate_Value = (DateTime?)Common.sink(DetectDate_Input.UniqueID, MethodType.Post, 50, 0, DataType.Dat);

            string Verifier_Value = ((string)Common.sink(Verifier_Input.UniqueID, MethodType.Post, 50, 0, DataType.Str)).Trim();
            //int VerifierID_Value = (int)Common.sink(VerifierID_Input.UniqueID, MethodType.Post, 10, 0, DataType.Int);
            int VerifyFlag_Value = (int)Common.sink(VerifyFlag_Input.UniqueID, MethodType.Post, 10, 0, DataType.Int);

            DateTime? VerifyTime_Value = (DateTime?)Common.sink(VerifyTime_Input.UniqueID, MethodType.Post, 50, 0, DataType.Dat);

            string Approver_Value = ((string)Common.sink(Approver_Input.UniqueID, MethodType.Post, 50, 0, DataType.Str)).Trim();
            //int ApproverID_Value = (int)Common.sink(ApproverID_Input.UniqueID, MethodType.Post, 10, 0, DataType.Int);
            int ApproveFlag_Value = (int)Common.sink(ApproveFlag_Input.UniqueID, MethodType.Post, 10, 0, DataType.Int);

            DateTime? ApproveTime_Value = (DateTime?)Common.sink(ApproveTime_Input.UniqueID, MethodType.Post, 50, 0, DataType.Dat);

            string SurfaceCheck_Value = ((string)Common.sink(SurfaceCheck_Input.UniqueID, MethodType.Post, 200, 0, DataType.Str)).Trim();
            string ZeroPointCheck_Value = ((string)Common.sink(ZeroPointCheck_Input.UniqueID, MethodType.Post, 200, 0, DataType.Str)).Trim();
            string WithstandCheck_Value = ((string)Common.sink(WithstandCheck_Input.UniqueID, MethodType.Post, 200, 0, DataType.Str)).Trim();
            string PointerSmoothCheck_Value = ((string)Common.sink(PointerSmoothCheck_Input.UniqueID, MethodType.Post, 200, 0, DataType.Str)).Trim();
            string StandardDeviceName_Value = ((string)Common.sink(StandardDeviceName_Input.UniqueID, MethodType.Post, 50, 0, DataType.Str)).Trim();
            string WillTestDeviceName_Value = ((string)Common.sink(WillTestDeviceName_Input.UniqueID, MethodType.Post, 50, 0, DataType.Str)).Trim();
            DeviceDetectEntity ut = BusinessFacadeShanliTech_HLD_Business.DeviceDetectDisp(IDX);

            //ut.StandardDeviceID = StandardDeviceID_Value;
            //ut.WillTestDeviceID = WillTestDeviceID_Value;
            ut.CertificateNum = CertificateNum_Value;
            //ut.CertificateType = CertificateType_Value;
            ut.DetectLocation = DetectLocation_Value;
            ut.DetectResult = DetectResult_Value;
            ut.EnvironmentNote = EnvironmentNote_Value;
            ut.Humidity = Humidity_Value;
            //ut.HumidityUnit = HumidityUnit_Value;
            ut.Temperature = Temperature_Value;
            //ut.TemperatureUnit = TemperatureUnit_Value;
            ut.ValidDate = ValidDate_Value;
            ut.DetectNote = DetectNote_Value;
            //ut.ReportType = ReportType_Value;
            //ut.ReportPath = ReportPath_Value;
            ut.DetectUserName = DetectUserName_Value;
            //ut.DetectUserID = DetectUserID_Value;
            ut.DetectDate = DetectDate_Value;
            ut.Verifier = Verifier_Value;
            //ut.VerifierID = VerifierID_Value;
            ut.VerifyFlag = VerifyFlag_Value;
            ut.VerifyTime = VerifyTime_Value;
            ut.Approver = Approver_Value;
            //ut.ApproverID = ApproverID_Value;
            ut.ApproveFlag = ApproveFlag_Value;
            ut.ApproveTime = ApproveTime_Value;
            ut.OutwardCheckNote = SurfaceCheck_Value;
            ut.ZeroPointCheck = ZeroPointCheck_Value;
            ut.WithstandCheck = WithstandCheck_Value;
            ut.PointerSmoothCheck = PointerSmoothCheck_Value;
            ut.StandardDeviceName = StandardDeviceName_Value;
            ut.WillTestDeviceName = WillTestDeviceName_Value;

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
                EventMessage.MessageBox(2, "不存在操作字符串!", "不存在操作字符串!", Icon_Type.Error, Common.GetHomeBaseUrl("DefaultCheck.aspx"));
            }
            Int32 rInt = BusinessFacadeShanliTech_HLD_Business.DeviceDetectInsertUpdateDelete(ut);
            if (rInt > 0)
            {
                string OpTxt = string.Format("增加设备检定记录成功!(ID:{0})", rInt);
                if (ut.DataTable_Action_ == DataTable_Action.Update)
                    OpTxt = string.Format("修改设备检定记录成功!(ID:{0})", IDX);
                EventMessage.MessageBox(1, "操作成功", OpTxt, Icon_Type.OK, Common.GetHomeBaseUrl("DefaultCheck.aspx"));
            }
            else if (rInt == -2)
            {
                EventMessage.MessageBox(1, "操作失败", "操作失败,存在相同的键值(用户名/数据)!", Icon_Type.Alert, Common.GetHomeBaseUrl("DefaultCheck.aspx"));
            }
            else
            {
                EventMessage.MessageBox(1, "操作失败", string.Format("操作失败,返回值:{0}!", rInt), Icon_Type.Error, Common.GetHomeBaseUrl("DefaultCheck.aspx"));
            }
        }
    }
}
