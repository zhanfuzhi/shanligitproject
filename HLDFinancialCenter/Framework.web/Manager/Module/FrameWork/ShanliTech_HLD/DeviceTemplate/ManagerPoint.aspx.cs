/********************************************************************************
     File:																
            Manager.aspx.cs                         
     Description:
            测试点管理
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
using ShanliTech_HLD_Business.PermitErrorCalculate;

namespace ShanliTech_HLD_Business.Web.Module.ShanliTech_HLD_Business.DeviceTemplate
{
    public partial class ManagerPoint : System.Web.UI.Page
    {
        public Int32 FunctionID = (Int32)Common.sink("FunctionID", MethodType.Get, 10, 0, DataType.Int);
        protected Int32 DeviceID = 0;
        Int32 IDX = (Int32)Common.sink("IDX", MethodType.Get, 10, 0, DataType.Int);
        string CMD = (string)Common.sink("CMD", MethodType.Get, 10, 1, DataType.Str);
        protected string DeviceModel = string.Empty;
        protected string FunctionCode = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            FunctionCode = BusinessFacadeShanliTech_HLD_Business.DeviceFunctionDisp(FunctionID).FunctionCode;
            DeviceID = ToolMethods.GetDeviceIDByFunction(FunctionID);
            DeviceModel = BusinessFacadeShanliTech_HLD_Business.DeviceDisp(DeviceID).DeviceModel;
            FrameWorkPermission.CheckPagePermission(CMD);
            AddListButton();
            FrameWorkPermission.CheckPagePermission(CMD);
            if (!Page.IsPostBack)
            {
                OnStart();
            }
        }
        /// <summary>
        /// 增加列表按钮
        /// </summary>
        private void AddListButton()
        {
            HeadMenuButtonItem bi = new HeadMenuButtonItem();
            bi.ButtonPopedom = PopedomType.List;
            bi.ButtonName = "功能检定点模板";
            bi.ButtonUrl = string.Format("DefaultPoint.aspx?CMD=List&FunctionID={0}&DeviceID={1}", FunctionID, DeviceID);
            HeadMenuWebControls1.ButtonList.Add(bi);
        }
        
        /// <summary>
        /// 开始操作
        /// </summary>
        private void OnStart()
        {
            DetectPointTemplateEntity ut = BusinessFacadeShanliTech_HLD_Business.DetectPointTemplateDisp(IDX);
            OnStartData(ut);
            switch (CMD)
            { 
                case "New":
                    TabOptionItem1.Tab_Name = HeadMenuWebControls1.HeadOPTxt = "增加测试点模板";
                    Hidden_Disp();
                    break;
                case "List":
                    TabOptionItem1.Tab_Name = HeadMenuWebControls1.HeadOPTxt = "查看测试点模板";
                    Hidden_Input();
                    ButtonOption.Visible = false;
                    AddEditButton();
                    break;
                case "Edit":
                    TabOptionItem1.Tab_Name = HeadMenuWebControls1.HeadOPTxt = "修改测试点模板";
                    Hidden_Disp();
                    AddDeleteButton();
                    break;
                case "Delete":
                    ut.DataTable_Action_ = DataTable_Action.Update;
                    ut.DelFlag = true;
                    if (BusinessFacadeShanliTech_HLD_Business.DetectPointTemplateInsertUpdateDelete(ut) > 0)
                    {
                        EventMessage.MessageBox(1, "删除成功", string.Format("删除ID:{0}成功!", IDX), Icon_Type.OK, Common.GetHomeBaseUrl("DefaultPoint.aspx"));
                    }
                    else {
                        EventMessage.MessageBox(1, "删除失败", string.Format("删除ID:{0}失败!", IDX), Icon_Type.Error, Common.GetHomeBaseUrl("DefaultPoint.aspx"));
                    }
                    break;
                default :
                    EventMessage.MessageBox(2, "不存在操作字符串!", "不存在操作字符串!", Icon_Type.Error, Common.GetHomeBaseUrl("DefaultPoint.aspx"));
                    break;
            }
            HiddenChangeValue();
        }

        private void HiddenChangeValue()
        {
            bool pre = ToolMethods.IsPresureDevice(DeviceID, false);
            if (pre)
            {
                FreqUnit_TR.Visible = false;
                FreqValue_TR.Visible = false;
                ChangePerMissibleError_TR.Visible = true;
                H_PerMissibleError_TR.Visible = true;
            }
            else
            {
                DeviceFunctionEntity _Function = BusinessFacadeShanliTech_HLD_Business.DeviceFunctionDisp(FunctionID);
                if (_Function.IsAC==1)
                {
                    FreqUnit_TR.Visible = true;
                    FreqValue_TR.Visible = true;
                }
                else
                {
                    FreqValue_TR.Visible = false;
                    FreqUnit_TR.Visible = false;
                }

                ChangePerMissibleError_TR.Visible = false;
                H_PerMissibleError_TR.Visible = false;
            }
        }

        /// <summary>
        /// 增加修改按钮
        /// </summary>
        private void AddEditButton()
        {
            HeadMenuButtonItem bi = new HeadMenuButtonItem();
            bi.ButtonPopedom = PopedomType.Edit;
            bi.ButtonName = "功能检定点模板";
            bi.ButtonUrl = string.Format("?CMD=Edit&IDX={0}&FunctionID={1}&DeviceID={2}", IDX, FunctionID, DeviceID);
            HeadMenuWebControls1.ButtonList.Add(bi);
        }


        /// <summary>
        /// 增加删除按钮
        /// </summary>
        private void AddDeleteButton()
        {
            HeadMenuButtonItem bi = new HeadMenuButtonItem();
            bi.ButtonPopedom = PopedomType.Delete;
            bi.ButtonName = "功能检定点模板";
            bi.ButtonUrlType = UrlType.JavaScript;
            bi.ButtonUrl = string.Format("DelData('?CMD=Delete&IDX={0}&FunctionID={1}&DeviceID={2}')", IDX, FunctionID, DeviceID);
            HeadMenuWebControls1.ButtonList.Add(bi);

            HeadMenuButtonItem bi1 = new HeadMenuButtonItem();
            bi1.ButtonPopedom = PopedomType.List;
            bi1.ButtonIcon = "back.gif";
            bi1.ButtonName = "返回";
            bi1.ButtonUrl = string.Format("?CMD=List&IDX={0}&FunctionID={1}&DeviceID={2}')", IDX, FunctionID, DeviceID);
            HeadMenuWebControls1.ButtonList.Add(bi1);
        }

        /// <summary>
        /// 初始化数据
        /// </summary>
        /// <param name="ut"></param>
        private void OnStartData(DetectPointTemplateEntity ut)
        {
            DeviceEntity _Device = BusinessFacadeShanliTech_HLD_Business.DeviceDisp(DeviceID);
            MissibleErrorSymbol_DropDown.SelectedValue = ut.MissibleErrorSymbol;

            ValuePerMissibleErrorName_Input.Text = ToolMethods.GetRadix(ut.ValuePerMissibleErrorName);
            ValuePerMissibleErrorName_Fraction_Input.Text = ToolMethods.GetExponent(ut.ValuePerMissibleErrorName);

            ValuePerMissibleErrorName_Disp.Text = ut.MissibleErrorSymbol + ut.ValuePerMissibleErrorName.ToString();
            StandardValue_Input.Text = StandardValue_Disp.Text = ut.StandardValue.ToString();
            ChangePerMissibleError_Input.Text = ChangePerMissibleError_Disp.Text = ut.ChangePerMissibleError.ToString();
            H_PerMissibleError_Input.Text = H_PerMissibleError_Disp.Text = ut.H_PerMissibleError.ToString();
            SwichRangeCmdCode_Input.Text = SwichRangeCmdCode_Disp.Text = ut.SwichRangeCmdCode.ToString();
            SwichFuncCmdCode_Disp.Text = SwichFuncCmdCode_Input.Text = ut.SwitchFuncCmdCode.ToString();
            SwichRESCmdCode_Disp.Text = SwichRESCmdCode_Input.Text = ut.SwitchRESCmdCode.ToString();
            TestRange_Input.Text = TestRange_Disp.Text = ut.TestRange.ToString();
            Unit_Input.Text = Unit_Disp.Text = ut.Unit.ToString();
            FunctionID_Disp.Text = BusinessFacadeShanliTech_HLD_Business.DeviceFunctionTemplateDisp(FunctionID).FunctionName;
            Frequency_Disp.Text = Frequency_Input.Text = ut.Frequency.ToString();
            FrequencyUnit_Disp.Text = FrequencyUnit_Input.Text = ut.FrequencyUnit.ToString();

            string _perfix = (string.IsNullOrEmpty(ut.SetCmdPerfix) ? _Device.SetCmdPerfix : ut.SetCmdPerfix);
            SetCmdPerfix_Input.Text = _perfix;
            SetCmdPerfix_Disp.Text = ut.SetCmdPerfix.ToString();
            string _suffix = (string.IsNullOrEmpty(ut.SetCmdSuffix) ? _Device.SetCmdSuffix : ut.SetCmdSuffix);
            SetCmdSuffix_Input.Text = _suffix;
            SetCmdSuffix_Disp.Text = ut.SetCmdSuffix.ToString();
        }

        /// <summary>
        /// 隐藏输入框
        /// </summary>
        private void Hidden_Input()
        {

            ValuePerMissible_Div.Visible = false;
            StandardValue_Input.Visible = false;
            ChangePerMissibleError_Input.Visible = false;
            H_PerMissibleError_Input.Visible = false;
            SwichRangeCmdCode_Input.Visible = false;
            SwichFuncCmdCode_Input.Visible = false;
            SwichRESCmdCode_Input.Visible = false;
            TestRange_Input.Visible = false;
            Unit_Input.Visible = false;
            FrequencyUnit_Input.Visible = false;
            Frequency_Input.Visible = false;
            SetCmdPerfix_Input.Visible = false;
            SetCmdSuffix_Input.Visible = false;
            RangeSelectList_Pop.Visible = false;

            SwitchFuncCmdCode_A.Visible = false;
            SwitchRESCmdCode_A.Visible = false;
        }

        /// <summary>
        /// 隐藏显示框
        /// </summary>
        private void Hidden_Disp()
        {
            //CommandCode_Disp.Visible = false;
            //FunctionCode_Disp.Visible = false;
            ValuePerMissibleErrorName_Disp.Visible = false;
            StandardValue_Disp.Visible = false;
            ChangePerMissibleError_Disp.Visible = false;
            H_PerMissibleError_Disp.Visible = false;
            SwichRangeCmdCode_Disp.Visible = false;
            SwichFuncCmdCode_Disp.Visible = false;
            SwichRESCmdCode_Disp.Visible = false;
            TestRange_Disp.Visible = false;
            Unit_Disp.Visible = false;
            Frequency_Disp.Visible = false;
            FrequencyUnit_Disp.Visible = false;
            SetCmdPerfix_Disp.Visible = false;
            SetCmdSuffix_Disp.Visible = false;

        }

        /// <summary>
        /// 增加/修改事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {
            string symbol_Value = MissibleErrorSymbol_DropDown.SelectedValue;
            double StandardValue_Value = Convert.ToDouble(Common.sink(StandardValue_Input.UniqueID, MethodType.Post, 53, 0, DataType.Double));
            double ChangePerMissibleError_Value = Convert.ToDouble(Common.sink(ChangePerMissibleError_Input.UniqueID, MethodType.Post, 53, 0, DataType.Double));
            double H_PerMissibleError_Value = Convert.ToDouble(Common.sink(H_PerMissibleError_Input.UniqueID, MethodType.Post, 53, 0, DataType.Double));
            string SwichRangeCmdCode_Value = ((string)Common.sink(SwichRangeCmdCode_Input.UniqueID, MethodType.Post, 50, 0, DataType.Str)).Trim();
            string SwichFuncCmdCode_Value = ((string)Common.sink(SwichFuncCmdCode_Input.UniqueID, MethodType.Post, 50, 0, DataType.Str)).Trim();
            string SwichRESCmdCode_Value = ((string)Common.sink(SwichRESCmdCode_Input.UniqueID, MethodType.Post, 50, 0, DataType.Str)).Trim();
            double TestRange_Value = Convert.ToDouble(Common.sink(TestRange_Input.UniqueID, MethodType.Post, 53, 0, DataType.Double));
            string FrequencyUnit_Value = ((string)Common.sink(FrequencyUnit_Input.UniqueID, MethodType.Post, 50, 0, DataType.Str)).Trim();
            double Frequency_Value = Convert.ToDouble(Common.sink(Frequency_Input.UniqueID, MethodType.Post, 53, 0, DataType.Double));
            string SetCmdPerfix_Value = ((string)Common.sink(SetCmdPerfix_Input.UniqueID, MethodType.Post, 50, 0, DataType.Str)).Trim();
            string SetCmdSuffix_Value = ((string)Common.sink(SetCmdSuffix_Input.UniqueID, MethodType.Post, 50, 0, DataType.Str)).Trim();
            string Unit_Value = ((string)Common.sink(Unit_Input.UniqueID, MethodType.Post, 50, 0, DataType.Str)).Trim();
            int RoundLen_Value = 0;// (int)Common.sink(RoundLen_Input.UniqueID, MethodType.Post, 10, 0, DataType.Int);
            //
            double ValuePerMissibleErrorName_Value = Math.Abs(Convert.ToDouble(Common.sink(ValuePerMissibleErrorName_Input.UniqueID, MethodType.Post, 53, 0, DataType.Double)));
            int ValuePerMissible_Fraction_Value = Convert.ToInt32(Common.sink(ValuePerMissibleErrorName_Fraction_Input.UniqueID, MethodType.Post, 53, 0, DataType.Int));

            DeviceTemplateEntity device = BusinessFacadeShanliTech_HLD_Business.DeviceTemplateDisp(DeviceID);
            
            //单位微伏等由u替换µ
            Unit_Value = Unit_Value.Replace("u", "µ");
           
            int FunctionID_Value = FunctionID;// Convert.ToInt32(FunctionID_DropDown.SelectedValue);
            string FunctionCode_Value = string.Empty;
            string CommandCode_Value = string.Empty;
            if (FunctionID_Value > 0)
            {
                FunctionCode_Value = BusinessFacadeShanliTech_HLD_Business.DeviceFunctionTemplateDisp(FunctionID_Value).FunctionCode;
                CommandCode_Value = CommonUtils.GetCommandStr(StandardValue_Value, Unit_Value, Frequency_Value, FrequencyUnit_Value, FunctionCode_Value);
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "alert1", "<script>alert('请选择对应设备功能模板');</script>");
                return;
            }

            //RoundLen_Value==0则取所属设备的属性RoundLen值
            RoundLen_Value = device.RoundLen;

            if (ValuePerMissibleErrorName_Value.ToString().ToUpper().IndexOf("E") >= 0)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "alert1", string.Format("<script>alert('请正确填写最大允许误差底数！不应包含指数形式：{0}');</script>", ValuePerMissibleErrorName_Value.ToString()));
                return;
            }
            double per = 0;
            Double.TryParse(NumberFormatUtils.ToSicenOneFractionStr(Convert.ToDouble(ValuePerMissibleErrorName_Value.ToString() + "E" + ValuePerMissible_Fraction_Value.ToString())), out per);

            DetectPointTemplateEntity ut = BusinessFacadeShanliTech_HLD_Business.DetectPointTemplateDisp(IDX);
            
            ut.CommandCode = CommandCode_Value;
            ut.FunctionCode = FunctionCode_Value;
            ut.StandardValue = StandardValue_Value;
            ut.ChangePerMissibleError = ChangePerMissibleError_Value;
            ut.H_PerMissibleError = H_PerMissibleError_Value;
            ut.TestRange = TestRange_Value;
            ut.Unit = Unit_Value;
            ut.FunctionID = FunctionID_Value;
            ut.DelFlag = false;
            ut.Inputter = UserData.GetUserDate.UserID;
            ut.InputTime = DateTime.Now;
            ut.FrequencyUnit = FrequencyUnit_Value;
            ut.Frequency = Frequency_Value;
            ut.MissibleErrorSymbol = symbol_Value;
            ut.SetCmdPerfix = SetCmdPerfix_Value;
            ut.SetCmdSuffix = SetCmdSuffix_Value;
            ut.RoundLen = RoundLen_Value;

            ut.SwichRangeCmdCode = SwichRangeCmdCode_Value;
            ut.SwitchFuncCmdCode = SwichFuncCmdCode_Value;
            ut.SwitchRESCmdCode = SwichRESCmdCode_Value;
            
            if (per == 0)
            {
                PermitErrorCalculator calculator = new PermitErrorCalculator();
                ut.ValuePerMissibleErrorName = calculator.GetPermitError(device, ut);
            }
            else
            {
                ut.ValuePerMissibleErrorName = per;
            }

            if (CMD == "New")
            {
                ut.DataTable_Action_ = DataTable_Action.Insert;
                ut.OrderID = ToolMethods.GetMaxOrderIdPointTemplate(FunctionID_Value) + 1;
            }
            else if (CMD == "Edit")
            {
                ut.DataTable_Action_ = DataTable_Action.Update;
            }
            else
            {
                EventMessage.MessageBox(2, "不存在操作字符串!", "不存在操作字符串!", Icon_Type.Error, Common.GetHomeBaseUrl("DefaultPoint.aspx?FunctionID=" + FunctionID + "&DeviceID=" + DeviceID));
            }
            Int32 rInt = BusinessFacadeShanliTech_HLD_Business.DetectPointTemplateInsertUpdateDelete(ut);
            if ( rInt> 0)
            {
                string OpTxt = string.Format("增加功能检定点模板成功!(ID:{0})", rInt);
                if (ut.DataTable_Action_ == DataTable_Action.Update)
                    OpTxt = string.Format("修改功能检定点模板成功!(ID:{0})", IDX);
                EventMessage.MessageBox(1, "操作成功", OpTxt, Icon_Type.OK, Common.GetHomeBaseUrl("DefaultPoint.aspx?FunctionID=" + FunctionID + "&DeviceID=" + DeviceID));
            }
            else if (rInt == -2)
            {
                EventMessage.MessageBox(1, "操作失败", "操作失败,存在相同的键值(用户名/数据)!", Icon_Type.Alert, Common.GetHomeBaseUrl("DefaultPoint.aspx?FunctionID=" + FunctionID + "&DeviceID=" + DeviceID));
            }
            else
            {
                EventMessage.MessageBox(1, "操作失败", string.Format("操作失败,返回值:{0}!", rInt), Icon_Type.Error, Common.GetHomeBaseUrl("DefaultPoint.aspx?FunctionID=" + FunctionID + "&DeviceID=" + DeviceID));
            }
        }
    }
}
