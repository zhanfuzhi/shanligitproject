/********************************************************************************
     File:																
            Manager.aspx.cs                         
     Description:
            部门与设备关系管理
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
using System.Drawing;

namespace ShanliTech_HLD_Business.Web.Module.ShanliTech_HLD_Business.Department_Device
{
    public partial class Manager : System.Web.UI.Page
    {
        Int32 IDX = (Int32)Common.sink("IDX", MethodType.Get, 10, 0, DataType.Int);
        string CMD = (string)Common.sink("CMD", MethodType.Get, 10, 1, DataType.Str);
        int standard = ToolMethods.GetDictionaryIDByCode("DEVICE_DETECT_STANDARD");
        sys_GroupTable currentGP = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            FrameWorkPermission.CheckPagePermission(CMD);

            currentGP = BusinessFacade.sys_GroupDisp(UserData.GetUserDate.U_GroupID);
            if (!Page.IsPostBack)
            {
                if ("Edit".Equals(CMD))
                {
                    Department_DeviceEntity ut = BusinessFacadeShanliTech_HLD_Business.Department_DeviceDisp(IDX);
                    if (ut.State == 1)
                    {
                        EventMessage.MessageBox(2, "操作提示", "该设备已检定完成，禁止再次修改！", Icon_Type.Error, Common.GetHomeBaseUrl("Manager.aspx?CMD=List&IDX=" + IDX));
                        
                    }
                }
                ToolMethods.InitDropDownDevice(DeviceID_DropDown);
                //ToolMethods.InitDropDownAllGroup(Group_DropDown);
                ToolMethods.InitDropDownDeviceType(DeviceType_DropDown);
                ToolMethods.InitDropDownVerifyType(VerifyType_DropDown);
                OnStart();
            }
        }
        
        /// <summary>
        /// 开始操作
        /// </summary>
        private void OnStart()
        {
            Department_DeviceEntity ut = BusinessFacadeShanliTech_HLD_Business.Department_DeviceDisp(IDX);
            DeviceEntity de = BusinessFacadeShanliTech_HLD_Business.DeviceDisp(ut.DeviceID);
            int preDeptId = de.DeviceDepartmentID;
            OnStartData(ut);
            switch (CMD)
            { 
                case "New":
                    TabOptionItem1.Tab_Name = HeadMenuWebControls1.HeadOPTxt = "增加检定设备";
                    Hidden_Disp();
                    break;
                case "List":
                    TabOptionItem1.Tab_Name = HeadMenuWebControls1.HeadOPTxt = "查看检定设备";
                    Hidden_Input();
                    ButtonOption.Visible = false;
                    AddEditButton();

                    if (ut.DeviceType != standard)
                    {
                        Verify_TR.Visible = true;
                        VerifyType_DropDown.Visible = false;
                    }
                        
                    if (UserData.GetUserDate.U_GroupID == preDeptId)
                    {
                        if (de.DelFlag)
                        {
                            //已被删除
                            //Common.MessBox("原设备可能已被删除，请重新选择！");
                            DeviceID_Disp.Text = "原设备已被删除";
                            DeviceID_Disp.ForeColor = Color.Red;
                        }
                        else
                        {
                            DeviceID_DropDown.SelectedValue = ut.DeviceID.ToString();
                            DeviceID_Disp.Text = DeviceID_DropDown.SelectedItem.Text;
                            DeviceID_Disp.ForeColor = Color.Black;
                        }
                    }
                    else
                    {
                        DeviceID_Disp.Text = de.DeviceName + "（设备不属于当前部门，不允许其他选择！）";
                        DeviceID_Disp.ForeColor = Color.Red;
                        DeviceID_Disp.Visible = true;
                        DeviceID_DropDown.Visible = false;
                    }

                    break;
                case "Edit":
                    TabOptionItem1.Tab_Name = HeadMenuWebControls1.HeadOPTxt = "修改检定设备";
                    Hidden_Disp();
                    AddDeleteButton();
                    if (ut.DeviceType != standard)
                    {
                        Verify_TR.Visible = true;
                        VerifyType_Disp.Visible = false;
                        VerifyType_DropDown.SelectedValue = ut.VerifyType.ToString();
                    }
                    //本部门下的设备，可以进行
                    if (UserData.GetUserDate.U_GroupID == preDeptId)
                    {
                        if (de.DelFlag)
                        {
                            //已被删除
                            //Common.MessBox("原设备可能已被删除，请重新选择！");
                            DeviceID_Disp.Text = "原设备已被删除";
                            DeviceID_Disp.ForeColor = Color.Red;
                        }
                        else
                        {
                            DeviceID_DropDown.SelectedValue = ut.DeviceID.ToString();
                            DeviceID_Disp.Text = DeviceID_DropDown.SelectedItem.Text;
                            DeviceID_Disp.ForeColor = Color.Black;
                        }
                    }
                    else
                    {
                        DeviceID_Disp.Text = de.DeviceName + "（设备不属于当前部门，不允许其他选择！）";
                        DeviceID_Disp.ForeColor = Color.Red;
                        DeviceID_Disp.Visible = true;
                        DeviceID_DropDown.Visible = false;
                    }
                   
                    break;
                case "Delete":
                    ut.DataTable_Action_ = DataTable_Action.Delete;
                    if (BusinessFacadeShanliTech_HLD_Business.Department_DeviceInsertUpdateDelete(ut) > 0)
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
            bi.ButtonName = "检定设备";
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
            bi.ButtonName = "检定设备";
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
        private void OnStartData(Department_DeviceEntity ut)
        {
            DeviceType_DropDown.SelectedValue = ut.DeviceType.ToString();
            DeviceType_Disp.Text = DeviceType_DropDown.SelectedItem.Text;
            DepartmentID_Disp.Text = currentGP.G_CName;
            Laboratory_Input.Text = Laboratory_Disp.Text = ut.Laboratory.ToString();
            VerifyType_DropDown.SelectedValue = ut.VerifyType.ToString();
            VerifyType_Disp.Text = VerifyType_DropDown.SelectedItem.Text;
                
        }

        /// <summary>
        /// 隐藏输入框
        /// </summary>
        private void Hidden_Input()
        {

            DeviceType_DropDown.Visible = false;
            DeviceID_DropDown.Visible = false;
            Laboratory_Input.Visible = false;
            Verify_TR.Visible = false;
        
        }

        /// <summary>
        /// 隐藏显示框
        /// </summary>
        private void Hidden_Disp()
        {
            DeviceType_Disp.Visible = false;
            DeviceID_Disp.Visible = false;
            Laboratory_Disp.Visible = false;
            Verify_TR.Visible = false;
        }

        /// <summary>
        /// 增加/修改事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {
        
            int DeviceID_Value = Convert.ToInt32(DeviceID_DropDown.SelectedValue);
            string Laboratory_Value = ((string)Common.sink(Laboratory_Input.UniqueID, MethodType.Post, 50, 0, DataType.Str)).Trim();
            int DepartmentID_Value = currentGP.GroupID;

            int DeviceType_Value = Convert.ToInt32(DeviceType_DropDown.SelectedValue);
            int VerifyType_Value = 0;
           
            if (DeviceID_Value <= 0)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "alert1", "<script>alert('请选择设备！')</script>");
                return;
            }
            if (DeviceType_Value <= 0)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "alert1", "<script>alert('请选择设备类型（标准设备或是被检设备）！')</script>");
                return;
            }
            else if (standard != 0 && standard != DeviceType_Value)
            {
                //被检设备
                VerifyType_Value = Convert.ToInt32(VerifyType_DropDown.SelectedValue);
                if (VerifyType_Value <= 0)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "alert1", "<script>alert('请选择设备检测类型！')</script>");
                    return;
                }
            }
            
            if (DepartmentID_Value <= 0)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "alert1", "<script>alert('请选择检定设备单位！')</script>");
                return;
            }

            Department_DeviceEntity ut = BusinessFacadeShanliTech_HLD_Business.Department_DeviceDisp(IDX);
            
            ut.DepartmentID = DepartmentID_Value;
            ut.DeviceType = DeviceType_Value;
            ut.DeviceID = DeviceID_Value;
            ut.Laboratory = Laboratory_Value;
            ut.State = (DeviceType_Value == standard ? 2 : 0); //检定状态  
            ut.Inputter = UserData.GetUserDate.UserID;
            ut.IntputTime = DateTime.Now;
            ut.DeviceName = BusinessFacadeShanliTech_HLD_Business.DeviceDisp(DeviceID_Value).DeviceName;
            ut.VerifyType = VerifyType_Value;

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
            Int32 rInt = BusinessFacadeShanliTech_HLD_Business.Department_DeviceInsertUpdateDelete(ut);
            if ( rInt> 0)
            {
                string OpTxt = string.Format("增加检定设备成功!(ID:{0})", rInt);
                if (ut.DataTable_Action_ == DataTable_Action.Update)
                    OpTxt = string.Format("修改检定设备成功!(ID:{0})", IDX);
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

        protected void DeviceType_DropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            int temp = Convert.ToInt32(DeviceType_DropDown.SelectedValue);
            if (temp == standard)
                Verify_TR.Visible = false;
            else
            {
                Verify_TR.Visible = true;
                VerifyType_Disp.Visible = false;
            }
        }
    }
}
