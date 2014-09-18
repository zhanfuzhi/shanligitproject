/********************************************************************************
     File:																
            Manager.aspx.cs                         
     Description:
            Device管理
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
    public partial class Manager : System.Web.UI.Page
    {
        protected Int32 IDX = (Int32)Common.sink("IDX", MethodType.Get, 10, 0, DataType.Int);
        string CMD = (string)Common.sink("CMD", MethodType.Get, 10, 1, DataType.Str);
        protected void Page_Load(object sender, EventArgs e)
        {
           FrameWorkPermission.CheckPagePermission(CMD);
            if (!Page.IsPostBack)
            {
                //ToolMethods.InitDropDownCurrentGroup(Group_DropDown);
                ToolMethods.InitDropDownInterfaceType(ConnectType_DropDown);
                //ToolMethods.InitDropDownDeviceTemplate(DeviceTemplate_DropDown);
                ToolMethods.InitDropDownDeviceCate(DeviceCategory_DropDown);
                ToolMethods.InitDropDownDetectType(DetectType_DropDown);
           
                OnStart();
            }
        }
        
        /// <summary>
        /// 开始操作
        /// </summary>
        private void OnStart()
        {
            DeviceEntity ut = BusinessFacadeShanliTech_HLD_Business.DeviceDisp(IDX);
            OnStartData(ut);
            switch (CMD)
            { 
                case "New":
                    TabOptionItem1.Tab_Name = HeadMenuWebControls1.HeadOPTxt = "增加设备";
                    Hidden_Disp();
                    HiddenByDetectType(string.Empty);
                    HiddenByDeviceCategory(string.Empty);
                    HiddenByConnectType(string.Empty);
                    break;
                case "List":
                    TabOptionItem1.Tab_Name = HeadMenuWebControls1.HeadOPTxt = "查看设备";
                    Hidden_Input();
                    ButtonOption.Visible = false;
                    AddEditButton();
                    HiddenByDetectType(ut.DetectTypeCode);
                    HiddenByDeviceCategory(ut.DeviceCategoryCode);
                    HiddenByConnectType(ut.ConnectTypeCode);
                    break;
                case "Edit":
                    TabOptionItem1.Tab_Name = HeadMenuWebControls1.HeadOPTxt = "修改设备";
                    Hidden_Disp();
                    AddDeleteButton();
                    HiddenByDetectType(ut.DetectTypeCode);
                    HiddenByDeviceCategory(ut.DeviceCategoryCode);
                    HiddenByConnectType(ut.ConnectTypeCode);
                    break;
                case "Delete":
                    ToolMethods.FunctionAndPointDeleteByDeviceID(IDX);  //级联删除相关功能及功能测试点

                    ut.DataTable_Action_ = DataTable_Action.Update;
                    ut.DelFlag = true;
                    if (BusinessFacadeShanliTech_HLD_Business.DeviceInsertUpdateDelete(ut) > 0)
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

        private void HiddenByDetectType(string detectType)
        {
            if ("DETECT_TYPE_AUTO".Equals(detectType))
            {
                //CmdClose_TR.Visible = true;
                //CmdClear_TR.Visible = true;
                //CmdOpen_TR.Visible = true;
                CmdReset_TR.Visible = true;
                CmdZero_TR.Visible = true;
                CmdRead_TR.Visible = true;
                CmdSTBY_TR.Visible = true;
                SetCmdPerfix_TR.Visible = true;
                SetCmdSuffix_TR.Visible = true;
            }
            else
            {
                //CmdClose_TR.Visible = false;
                //CmdClear_TR.Visible = false;
                //CmdOpen_TR.Visible = false;
                CmdReset_TR.Visible = false;
                CmdZero_TR.Visible = false;
                CmdRead_TR.Visible = false;
                CmdSTBY_TR.Visible = false;
                SetCmdPerfix_TR.Visible = false;
                SetCmdSuffix_TR.Visible = false;
            }

        }
        private void HiddenByDeviceCategory(string deviceCategory)
        {
            if ("DEVICE_CATE_E".Equals(deviceCategory))
            {
                ScaleUnit_TR.Visible = false;
                ScaleValue_TR.Visible = false;
                DetectMedium_TR.Visible = false;
                Sleep_TR.Visible = true;
                E_PermitType_TR.Visible = true;
                RoundLen_TR.Visible = true;
                if(!"List".Equals(CMD))
                    DeviceModel_A.Visible = true;
            }
            else if ("DEVICE_CATE_P".Equals(deviceCategory) || "DEVICE_CATE_AP".Equals(deviceCategory))
            {
                Sleep_TR.Visible = false;
                ScaleUnit_TR.Visible = true;
                ScaleValue_TR.Visible = true;
                DetectMedium_TR.Visible = true;
                E_PermitType_TR.Visible = false;
                RoundLen_TR.Visible = false;
                DeviceModel_A.Visible = false;
            }
            else
            {
                ScaleUnit_TR.Visible = false;
                ScaleValue_TR.Visible = false;
                DetectMedium_TR.Visible = false;
                Sleep_TR.Visible = false;
                E_PermitType_TR.Visible = false;
                RoundLen_TR.Visible = false;
                DeviceModel_A.Visible = false;
            }
        }
        private void HiddenByConnectType(string connectType)
        {
            if ("INTERFACE_TYPE_IEEE".Equals(connectType))
            {
                RS232_Conn_TR.Visible = false;
                PrimaryAddress_TR.Visible = true;
                SecondaryAddress_TR.Visible = true;
                BoardNumber_TR.Visible = true;
            }
            else if ("INTERFACE_TYPE_RS232".Equals(connectType))
            {
                PrimaryAddress_TR.Visible = false;
                SecondaryAddress_TR.Visible = false;
                BoardNumber_TR.Visible = false;
                RS232_Conn_TR.Visible = true;
            }
            else
            {
                PrimaryAddress_TR.Visible = false;
                SecondaryAddress_TR.Visible = false;
                BoardNumber_TR.Visible = false;
                RS232_Conn_TR.Visible = false;
            }
        }

        /// <summary>
        /// 增加修改按钮
        /// </summary>
        private void AddEditButton()
        {
            HeadMenuButtonItem bi = new HeadMenuButtonItem();
            bi.ButtonPopedom = PopedomType.Edit;
            bi.ButtonName = "设备";
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
            bi.ButtonName = "设备";
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
        private void OnStartData(DeviceEntity ut)
        {
            CertifcateNumPart_Input.Text = CertifcateNumPart_Disp.Text = ut.CertifcateNumPart.ToString();
            //CmdClose_Input.Text = CmdClose_Disp.Text = ut.CmdClose.ToString();
            //CmdClear_Input.Text = CmdClear_Disp.Text = ut.CmdClear.ToString();
            //CmdOpen_Input.Text = CmdOpen_Disp.Text = ut.CmdOpen.ToString();
            CmdReset_Input.Text = CmdReset_Disp.Text = ut.CmdReset.ToString();
            CmdZero_Input.Text = CmdZero_Disp.Text = ut.CmdZero.ToString();
            CmdRead_Input.Text = CmdRead_Disp.Text = ut.CmdRead.ToString();
            CmdSTBY_Input.Text = CmdSTBY_Disp.Text = ut.CmdSTBY.ToString();
            SetCmdPerfix_Input.Text = SetCmdPerfix_Disp.Text = ut.SetCmdPerfix.ToString();
            SetCmdSuffix_Input.Text = SetCmdSuffix_Disp.Text = ut.SetCmdSuffix.ToString();

            DetectType_DropDown.SelectedValue = ut.DetectType.ToString();
            DetectType_Disp.Text = DetectType_DropDown.SelectedItem.Text;

            DeviceFactory_Input.Text = DeviceFactory_Disp.Text = ut.DeviceFactory.ToString();
            DeviceModel_Input.Text = DeviceModel_Disp.Text = ut.DeviceModel.ToString();
            DeviceName_Input.Text = DeviceName_Disp.Text = ut.DeviceName.ToString();
            DeviceNum_Input.Text = DeviceNum_Disp.Text = ut.DeviceNum.ToString();
            DeviceCategory_DropDown.SelectedValue = ut.DeviceCategoryID.ToString();
            DeviceCategoryID_Disp.Text = DeviceCategory_DropDown.SelectedItem.Text;

            Sleep_Input.Text = Sleep_Disp.Text = ut.Sleep.ToString();
            RS232_Conn_Input.Text = RS232_Conn_Disp.Text = ut.RS232_ConnStr.ToString();

            BoardNumber_Input.Text = BoardNumber_Disp.Text = ut.BoardNumber.ToString();
            PrimaryAddress_Input.Text = PrimaryAddress_Disp.Text = ut.PrimaryAddress.ToString();
            SecondaryAddress_Input.Text = SecondaryAddress_Disp.Text = ut.SecondaryAddress.ToString();
            ConnectType_DropDown.SelectedValue = ut.ConnectType.ToString();
            ConnectType_Disp.Text = ConnectType_DropDown.SelectedItem.Text;

            kvalue_Input.Text = kvalue_Disp.Text = ut.kvalue.ToString();
            kname_Input.Text = kname_Disp.Text = ut.kname.ToString();
            AccuracyLevel_Input.Text = AccuracyLevel_Disp.Text = ut.AccuracyLevel.ToString();
            ScaleUnit_Disp.Text = ScaleUnit_Input.Text = ut.ScaleUnit;
            ScaleValue_Disp.Text = ScaleValue_Input.Text = ut.ScaleValue.ToString();
            RangeUnit_Disp.Text = RangeUnit_Input.Text = ut.RangeUnit;
            RangeValue_Disp.Text = RangeValue_Input.Text = ut.RangeValue.ToString();
            DetectMedium_Input.Text = DetectMedium_Disp.Text = ut.DetectMedium;
            RoundLen_Input.Text = RoundLen_Disp.Text = ut.RoundLen.ToString();

            switch (ut.PermitType)
            {
                case 1:
                    Permit_Default.Checked = true;
                    E_PermitType_Disp.Text = Permit_Default.Text;
                    break;
                case 2:
                    Permit_Range.Checked = true;
                    E_PermitType_Disp.Text = Permit_Range.Text;
                    break;
                case 3:
                    Permit_Precision.Checked = true;
                    E_PermitType_Disp.Text = Permit_Precision.Text;
                    break;
            }
        }

        /// <summary>
        /// 隐藏输入框
        /// </summary>
        private void Hidden_Input()
        {
            CertifcateNumPart_Input.Visible = false;
            //CmdClose_Input.Visible = false;
            //CmdClear_Input.Visible = false;
            //CmdOpen_Input.Visible = false;
            CmdReset_Input.Visible = false;
            CmdZero_Input.Visible = false;
            CmdRead_Input.Visible = false;
            CmdSTBY_Input.Visible = false;
            SetCmdPerfix_Input.Visible = false;
            SetCmdSuffix_Input.Visible = false;
            //DetectType_Input.Visible = false;
            DetectType_DropDown.Visible = false;
            DeviceFactory_Input.Visible = false;
            DeviceModel_Input.Visible = false;
            DeviceName_Input.Visible = false;
            DeviceNum_Input.Visible = false;
            //DeviceCategoryID_Input.Visible = false;
            DeviceCategory_DropDown.Visible = false;
            Sleep_Input.Visible = false;
            //DeviceDepartmentID_Input.Visible = false;
            //Group_DropDown.Visible = false;
            RS232_Conn_Input.Visible = false;
            BoardNumber_Input.Visible = false;
            PrimaryAddress_Input.Visible = false;
            SecondaryAddress_Input.Visible = false;
            //ConnectType_Input.Visible = false;
            ConnectType_DropDown.Visible = false;
            kvalue_Input.Visible = false;
            kname_Input.Visible = false;
            AccuracyLevel_Input.Visible = false;
            ScaleUnit_Input.Visible = false;
            ScaleValue_Input.Visible = false;
            RangeUnit_Input.Visible = false;
            RangeValue_Input.Visible = false;
            DetectMedium_Input.Visible = false;
            RoundLen_Input.Visible = false;

            Permit_Default.Visible = false;
            Permit_Precision.Visible = false;
            Permit_Range.Visible = false;

            DeviceModel_A.Visible = false;
        }

        /// <summary>
        /// 隐藏显示框
        /// </summary>
        private void Hidden_Disp()
        {
            CertifcateNumPart_Disp.Visible = false;
            //CmdClose_Disp.Visible = false;
            //CmdClear_Disp.Visible = false;
            //CmdOpen_Disp.Visible = false;
            CmdReset_Disp.Visible = false;
            CmdZero_Disp.Visible = false;
            CmdRead_Disp.Visible = false;
            CmdSTBY_Disp.Visible = false;
            SetCmdPerfix_Disp.Visible = false;
            SetCmdSuffix_Disp.Visible = false;
            DetectType_Disp.Visible = false;
            DeviceFactory_Disp.Visible = false;
            DeviceModel_Disp.Visible = false;
            DeviceName_Disp.Visible = false;
            DeviceNum_Disp.Visible = false;
            DeviceCategoryID_Disp.Visible = false;
            Sleep_Disp.Visible = false;
            //DeviceDepartmentID_Disp.Visible = false;
            RS232_Conn_Disp.Visible = false;
            BoardNumber_Disp.Visible = false;
            PrimaryAddress_Disp.Visible = false;
            SecondaryAddress_Disp.Visible = false;
            ConnectType_Disp.Visible = false;
            kvalue_Disp.Visible = false;
            kname_Disp.Visible = false;
            AccuracyLevel_Disp.Visible = false;
            ScaleUnit_Disp.Visible = false;
            ScaleValue_Disp.Visible = false;
            RangeUnit_Disp.Visible = false;
            RangeValue_Disp.Visible = false;
            DetectMedium_Disp.Visible = false;
            RoundLen_Disp.Visible = false;

            E_PermitType_Disp.Visible = false;

            
        }

        protected void ConnectType_DropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            int connTypeID = Convert.ToInt32(ConnectType_DropDown.SelectedValue);
            HiddenByConnectType(ToolMethods.GetDictionaryCodeByID(connTypeID));
        }
        protected void DetectType_DropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            int detectType = Convert.ToInt32(DetectType_DropDown.SelectedValue);
            HiddenByDetectType(ToolMethods.GetDictionaryCodeByID(detectType));
        }
        protected void DeviceCategory_DropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            int deviceCategory = Convert.ToInt32(DeviceCategory_DropDown.SelectedValue);
            HiddenByDeviceCategory(ToolMethods.GetDictionaryCodeByID(deviceCategory));
        }
        /// <summary>
        /// 增加/修改事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {
        
            string CertifcateNumPart_Value = ((string)Common.sink(CertifcateNumPart_Input.UniqueID, MethodType.Post, 50, 0, DataType.Str)).Trim();
            string CmdClose_Value = string.Empty;// ((string)Common.sink(CmdClose_Input.UniqueID, MethodType.Post, 50, 0, DataType.Str)).Trim();
            string CmdClear_Value = string.Empty;//((string)Common.sink(CmdClear_Input.UniqueID, MethodType.Post, 50, 0, DataType.Str)).Trim();
            string CmdOpen_Value = string.Empty;//((string)Common.sink(CmdOpen_Input.UniqueID, MethodType.Post, 50, 0, DataType.Str)).Trim();
            string CmdReset_Value = ((string)Common.sink(CmdReset_Input.UniqueID, MethodType.Post, 50, 0, DataType.Str)).Trim();
            string CmdZero_Value = ((string)Common.sink(CmdZero_Input.UniqueID, MethodType.Post, 50, 0, DataType.Str)).Trim();
            string CmdRead_Value = ((string)Common.sink(CmdRead_Input.UniqueID, MethodType.Post, 50, 0, DataType.Str)).Trim();
            string CmdSTBY_Value = ((string)Common.sink(CmdSTBY_Input.UniqueID, MethodType.Post, 50, 0, DataType.Str)).Trim();
            string SetCmdPerfix_Value = ((string)Common.sink(SetCmdPerfix_Input.UniqueID, MethodType.Post, 50, 0, DataType.Str)).Trim();
            string SetCmdSuffix_Value = ((string)Common.sink(SetCmdSuffix_Input.UniqueID, MethodType.Post, 50, 0, DataType.Str)).Trim();
            
            string DeviceFactory_Value = ((string)Common.sink(DeviceFactory_Input.UniqueID, MethodType.Post, 50, 0, DataType.Str)).Trim();
            string DeviceModel_Value = ((string)Common.sink(DeviceModel_Input.UniqueID, MethodType.Post, 50, 0, DataType.Str)).Trim();
            string DeviceName_Value = ((string)Common.sink(DeviceName_Input.UniqueID, MethodType.Post, 50, 0, DataType.Str)).Trim();
            string DeviceNum_Value = ((string)Common.sink(DeviceNum_Input.UniqueID, MethodType.Post, 50, 0, DataType.Str)).Trim();
            
            int Sleep_Value = (int)Common.sink(Sleep_Input.UniqueID, MethodType.Post, 10, 0, DataType.Int);
            //int DeviceDepartmentID_Value = (int)Common.sink(DeviceDepartmentID_Input.UniqueID, MethodType.Post, 10, 0, DataType.Int);
            int BoardNumber_Value = (int)Common.sink(BoardNumber_Input.UniqueID, MethodType.Post, 10, 0, DataType.Int);
            string PrimaryAddress_Value = ((string)Common.sink(PrimaryAddress_Input.UniqueID, MethodType.Post, 10, 0, DataType.Str)).Trim();
            string SecondaryAddress_Value = ((string)Common.sink(SecondaryAddress_Input.UniqueID, MethodType.Post, 10, 0, DataType.Str)).Trim();

            string RS232_Conn_Value = ((string)Common.sink(RS232_Conn_Input.UniqueID, MethodType.Post, 50, 0, DataType.Str)).Trim();

            double kvalue_Value = Convert.ToDouble(Common.sink(kvalue_Input.UniqueID, MethodType.Post, 53, 0, DataType.Double));
            string kname_Value = ((string)Common.sink(kname_Input.UniqueID, MethodType.Post, 50, 0, DataType.Str)).Trim();
            double AccuracyLevel_Value = Convert.ToDouble(Common.sink(AccuracyLevel_Input.UniqueID, MethodType.Post, 53, 0, DataType.Double));
            double ScaleValue_Value = Convert.ToDouble(Common.sink(ScaleValue_Input.UniqueID, MethodType.Post, 53, 0, DataType.Double));
            string ScaleUnit_Value = ((string)Common.sink(ScaleUnit_Input.UniqueID, MethodType.Post, 50, 0, DataType.Str)).Trim();
            double RangeValue_Value = Convert.ToDouble(Common.sink(RangeValue_Input.UniqueID, MethodType.Post, 53, 0, DataType.Double));
            string RangeUnit_Value = ((string)Common.sink(RangeUnit_Input.UniqueID, MethodType.Post, 50, 0, DataType.Str)).Trim();
            string DetectMedium_Vaue = ((string)Common.sink(DetectMedium_Input.UniqueID, MethodType.Post, 50, 0, DataType.Str)).Trim();
            int RoundLen_Value = (int)Common.sink(RoundLen_Input.UniqueID, MethodType.Post, 10, 0, DataType.Int);
            
            int PermitType = 0;
            if (Permit_Default.Checked)
                PermitType = 1;
            else if (Permit_Range.Checked)
                PermitType = 2;
            else if (Permit_Precision.Checked)
                PermitType = 3;

            int DetectType_Value = Convert.ToInt32(DetectType_DropDown.SelectedValue);
            int DeviceCategoryID_Value = Convert.ToInt32(DeviceCategory_DropDown.SelectedValue);
            int ConnectType_Value = Convert.ToInt32(ConnectType_DropDown.SelectedValue);
            
            if (DetectType_Value <= 0)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "alert1", "<script>alert('请选择设备检测方式！')</script>");
                return;
            }
            if (ConnectType_Value <= 0)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "alert1", "<script>alert('请选择设备连接接口类型！')</script>");
                return;
            }
            if (DeviceCategoryID_Value <= 0)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "alert1", "<script>alert('请选择设备类别！')</script>");
                return;
            }

            DeviceEntity ut = BusinessFacadeShanliTech_HLD_Business.DeviceDisp(IDX);
            ut.CertifcateNumPart = CertifcateNumPart_Value;
            ut.CmdClose = CmdClose_Value;
            ut.CmdClear = CmdClear_Value;
            ut.CmdOpen = CmdOpen_Value;
            ut.CmdReset = CmdReset_Value;
            ut.CmdZero = CmdZero_Value;
            ut.CmdRead = CmdRead_Value;
            ut.CmdSTBY = CmdSTBY_Value;
            ut.SetCmdPerfix = SetCmdPerfix_Value;
            ut.SetCmdSuffix = SetCmdSuffix_Value;
            ut.DetectType = DetectType_Value;
            ut.DeviceFactory = DeviceFactory_Value;
            ut.DeviceModel = DeviceModel_Value;
            ut.DeviceName = DeviceName_Value;
            ut.DeviceNum = DeviceNum_Value;
            ut.DeviceCategoryID = DeviceCategoryID_Value;
            ut.Sleep = Sleep_Value;
            //ut.DeviceDepartmentID = DeviceDepartmentID_Value; //改为当前登录用户所在部门
            ut.DeviceDepartmentID = UserData.GetUserDate.U_GroupID;
            ut.RS232_ConnStr = RS232_Conn_Value;
            ut.BoardNumber = BoardNumber_Value;
            ut.PrimaryAddress = PrimaryAddress_Value;
            ut.SecondaryAddress = SecondaryAddress_Value;
            ut.ConnectType = ConnectType_Value;
            ut.kvalue = kvalue_Value;
            ut.kname = kname_Value;
            ut.AccuracyLevel = AccuracyLevel_Value;
            ut.DelFlag = false;
            ut.Inputter = UserData.GetUserDate.UserID;
            ut.InputTime = DateTime.Now;
            ut.State = 0;
            ut.ScaleValue = ScaleValue_Value;
            ut.ScaleUnit = ScaleUnit_Value;
            ut.RangeValue = RangeValue_Value;
            ut.RangeUnit = RangeUnit_Value;
            ut.DetectMedium = DetectMedium_Vaue;
            ut.RoundLen = RoundLen_Value;
            ut.PermitType = PermitType;
            
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
            Int32 rInt = BusinessFacadeShanliTech_HLD_Business.DeviceInsertUpdateDelete(ut);
            if ( rInt> 0)
            {
                string OpTxt = string.Format("增加设备成功!(ID:{0})", rInt);
                if (ut.DataTable_Action_ == DataTable_Action.Update)
                    OpTxt = string.Format("修改设备成功!(ID:{0})", IDX);
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

        #region 郭博浩

        //protected void DeviceTemplate_Button_Click(object sender, EventArgs e)
        //{
        //    int DevicTemplateID = Convert.ToInt32(DeviceTemplate_DropDown.SelectedValue);
        //    if (DevicTemplateID <= 0)
        //    {
        //        //未选择
        //        UseTemplate.Text = "0";
        //    }
        //    else
        //    {
        //        DeviceTemplateEntity dt = BusinessFacadeShanliTech_HLD_Business.DeviceTemplateDisp(DevicTemplateID);
        //        CopyWithTemplate(dt);
        //        UseTemplate.Text = dt.ID.ToString();
        //    }
        //}
        //private void CopyWithTemplate(DeviceTemplateEntity dt)
        //{
        //    CertifcateNumPart_Input.Text = dt.CertifcateNumPart.ToString();
        //    CmdClose_Input.Text = dt.CmdClose.ToString();
        //    CmdClear_Input.Text = dt.CmdClear.ToString();
        //    CmdOpen_Input.Text = dt.CmdOpen;
        //    CmdReset_Input.Text = dt.CmdReset;
        //    CmdZero_Input.Text = dt.CmdZero;
            
        //    DeviceFactory_Input.Text = dt.DeviceFactory;
        //    DeviceModel_Input.Text = dt.DeviceModel;
        //    DeviceName_Input.Text = dt.DeviceName;
        //    DeviceNum_Input.Text = dt.DeviceNum;
            
        //    Sleep_Input.Text = dt.Sleep.ToString();

        //    //DeviceDepartmentID_Input.Text = dt.DeviceDepartmentID.ToString();
        //    //Group_DropDown.SelectedValue = dt.DeviceDepartmentID.ToString();

        //    BoardNumber_Input.Text = dt.BoardNumber.ToString();
        //    PrimaryAddress_Input.Text = dt.PrimaryAddress;
        //    SecondaryAddress_Input.Text = dt.SecondaryAddress;
            
        //    kvalue_Input.Text = dt.kvalue.ToString();
        //    kname_Input.Text = dt.kname.ToString();
        //    AccuracyLevel_Input.Text = dt.AccuracyLevel.ToString();

        //    DetectType_Disp.Text = dt.DetectType.ToString();
        //    DeviceCategoryID_Disp.Text = dt.DeviceCategoryID.ToString();
        //    ConnectType_Disp.Text = dt.ConnectType.ToString();
        //    DeviceCategory_DropDown.SelectedValue = dt.DeviceCategoryID.ToString();
        //    ConnectType_DropDown.SelectedValue = dt.ConnectType.ToString();
        //    DetectType_DropDown.SelectedValue = dt.DetectType.ToString();
        //}
        #endregion
    }
}
