/********************************************************************************
     File:																
            Manager.aspx.cs                         
     Description:
            移动运营商基站数据管理
     Author:									
            DDBuildTools
            http://DDBuildTools.supesoft.com
     Finish DateTime:
            2013/9/12 11:04:12
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

namespace Shanlitech_Location.Web.Module.Shanlitech_Location.MobileBaseStation
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
            MobileBaseStationEntity ut = BusinessFacadeShanlitech_Location.MobileBaseStationDisp(IDX);
            OnStartData(ut);
            switch (CMD)
            { 
                case "New":
                    TabOptionItem1.Tab_Name = HeadMenuWebControls1.HeadOPTxt = "增加移动运营商基站数据";
                    Hidden_Disp();
                    break;
                case "List":
                    TabOptionItem1.Tab_Name = HeadMenuWebControls1.HeadOPTxt = "查看移动运营商基站数据";
                    Hidden_Input();
                    ButtonOption.Visible = false;
                    AddEditButton();
                    break;
                case "Edit":
                    TabOptionItem1.Tab_Name = HeadMenuWebControls1.HeadOPTxt = "修改移动运营商基站数据";
                    Hidden_Disp();
                    AddDeleteButton();
                    break;
                case "Delete":
                    ut.DataTable_Action_ = DataTable_Action.Delete;
                    if (BusinessFacadeShanlitech_Location.MobileBaseStationInsertUpdateDelete(ut) > 0)
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
            bi.ButtonName = "移动运营商基站数据";
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
            bi.ButtonName = "移动运营商基站数据";
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
        private void OnStartData(MobileBaseStationEntity ut)
        {
        lac_Input.Text = lac_Disp.Text = ut.lac.ToString();
                cid_Input.Text = cid_Disp.Text = ut.cid.ToString();
                mcc_Input.Text = mcc_Disp.Text = ut.mcc.ToString();
                mnc_Input.Text = mnc_Disp.Text = ut.mnc.ToString();
                signalStrength_Input.Text = signalStrength_Disp.Text = ut.signalStrength.ToString();
                locationDataID_Input.Text = locationDataID_Disp.Text = ut.locationDataID.ToString();
                
        }

        /// <summary>
        /// 隐藏输入框
        /// </summary>
        private void Hidden_Input()
        {
        lac_Input.Visible = false;
        cid_Input.Visible = false;
        mcc_Input.Visible = false;
        mnc_Input.Visible = false;
        signalStrength_Input.Visible = false;
        locationDataID_Input.Visible = false;
        
        }

        /// <summary>
        /// 隐藏显示框
        /// </summary>
        private void Hidden_Disp()
        {
        lac_Disp.Visible = false;
        cid_Disp.Visible = false;
        mcc_Disp.Visible = false;
        mnc_Disp.Visible = false;
        signalStrength_Disp.Visible = false;
        locationDataID_Disp.Visible = false;
        
        }

        /// <summary>
        /// 增加/修改事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {
        
            string lac_Value = (string)Common.sink(lac_Input.UniqueID, MethodType.Post, 50, 0, DataType.Str);
            string cid_Value = (string)Common.sink(cid_Input.UniqueID, MethodType.Post, 50, 0, DataType.Str);
            string mcc_Value = (string)Common.sink(mcc_Input.UniqueID, MethodType.Post, 50, 0, DataType.Str);
            string mnc_Value = (string)Common.sink(mnc_Input.UniqueID, MethodType.Post, 50, 0, DataType.Str);
            int signalStrength_Value = (int)Common.sink(signalStrength_Input.UniqueID, MethodType.Post, 10, 0, DataType.Int);
            int locationDataID_Value = (int)Common.sink(locationDataID_Input.UniqueID, MethodType.Post, 10, 0, DataType.Int);
            MobileBaseStationEntity ut = BusinessFacadeShanlitech_Location.MobileBaseStationDisp(IDX);
            
            ut.lac = lac_Value;
            ut.cid = cid_Value;
            ut.mcc = mcc_Value;
            ut.mnc = mnc_Value;
            ut.signalStrength = signalStrength_Value;
            ut.locationDataID = locationDataID_Value;
            
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
            Int32 rInt = BusinessFacadeShanlitech_Location.MobileBaseStationInsertUpdateDelete(ut);
            if ( rInt> 0)
            {
                string OpTxt = string.Format("增加移动运营商基站数据成功!(ID:{0})", rInt);
                if (ut.DataTable_Action_ == DataTable_Action.Update)
                    OpTxt = string.Format("修改移动运营商基站数据成功!(ID:{0})",IDX);
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
