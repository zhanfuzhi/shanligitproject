/********************************************************************************
     File:																
            Manager.aspx.cs                         
     Description:
            定位数据表管理
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

namespace Shanlitech_Location.Web.Module.Shanlitech_Location.LocationData
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
            LocationDataEntity ut = BusinessFacadeShanlitech_Location.LocationDataDisp(IDX);
            OnStartData(ut);
            switch (CMD)
            { 
                case "New":
                    TabOptionItem1.Tab_Name = HeadMenuWebControls1.HeadOPTxt = "增加定位数据表";
                    Hidden_Disp();
                    break;
                case "List":
                    TabOptionItem1.Tab_Name = HeadMenuWebControls1.HeadOPTxt = "查看定位数据表";
                    Hidden_Input();
                    ButtonOption.Visible = false;
                    AddEditButton();
                    break;
                case "Edit":
                    TabOptionItem1.Tab_Name = HeadMenuWebControls1.HeadOPTxt = "修改定位数据表";
                    Hidden_Disp();
                    AddDeleteButton();
                    break;
                case "Delete":
                    ut.DataTable_Action_ = DataTable_Action.Delete;
                    if (BusinessFacadeShanlitech_Location.LocationDataInsertUpdateDelete(ut) > 0)
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
            bi.ButtonName = "定位数据表";
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
            bi.ButtonName = "定位数据表";
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
        private void OnStartData(LocationDataEntity ut)
        {
        appID_Input.Text = appID_Disp.Text = ut.appID.ToString();
                userID_Input.Text = userID_Disp.Text = ut.userID.ToString();
                type_Input.Text = type_Disp.Text = ut.type.ToString();
                operator_mobile_Input.Text = operator_mobile_Disp.Text = ut.operator_mobile.ToString();
                coordination_Input.Text = coordination_Disp.Text = ut.coordination.ToString();
                lat_Input.Text = lat_Disp.Text = ut.lat.ToString();
                lng_Input.Text = lng_Disp.Text = ut.lng.ToString();
                address_Input.Text = address_Disp.Text = ut.address.ToString();
                locate_time_Input.Text = locate_time_Disp.Text = ut.locate_time.ToString();
                error_code_Input.Text = error_code_Disp.Text = ut.error_code.ToString();
                code_description_Input.Text = code_description_Disp.Text = ut.code_description.ToString();
                create_time_Input.Text = create_time_Disp.Text = ut.create_time.ToString();
                
        }

        /// <summary>
        /// 隐藏输入框
        /// </summary>
        private void Hidden_Input()
        {
        appID_Input.Visible = false;
        userID_Input.Visible = false;
        type_Input.Visible = false;
        operator_mobile_Input.Visible = false;
        coordination_Input.Visible = false;
        lat_Input.Visible = false;
        lng_Input.Visible = false;
        address_Input.Visible = false;
        locate_time_Input.Visible = false;
        error_code_Input.Visible = false;
        code_description_Input.Visible = false;
        create_time_Input.Visible = false;
        
        }

        /// <summary>
        /// 隐藏显示框
        /// </summary>
        private void Hidden_Disp()
        {
        appID_Disp.Visible = false;
        userID_Disp.Visible = false;
        type_Disp.Visible = false;
        operator_mobile_Disp.Visible = false;
        coordination_Disp.Visible = false;
        lat_Disp.Visible = false;
        lng_Disp.Visible = false;
        address_Disp.Visible = false;
        locate_time_Disp.Visible = false;
        error_code_Disp.Visible = false;
        code_description_Disp.Visible = false;
        create_time_Disp.Visible = false;
        
        }

        /// <summary>
        /// 增加/修改事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {
        
            string appID_Value = (string)Common.sink(appID_Input.UniqueID, MethodType.Post, 50, 0, DataType.Str);
            string userID_Value = (string)Common.sink(userID_Input.UniqueID, MethodType.Post, 50, 0, DataType.Str);
            int type_Value = (int)Common.sink(type_Input.UniqueID, MethodType.Post, 10, 0, DataType.Int);
            int operator_mobile_Value = (int)Common.sink(operator_mobile_Input.UniqueID, MethodType.Post, 10, 0, DataType.Int);
            string coordination_Value = (string)Common.sink(coordination_Input.UniqueID, MethodType.Post, 50, 0, DataType.Str);
            string lat_Value = (string)Common.sink(lat_Input.UniqueID, MethodType.Post, 50, 0, DataType.Str);
            string lng_Value = (string)Common.sink(lng_Input.UniqueID, MethodType.Post, 50, 0, DataType.Str);
            string address_Value = (string)Common.sink(address_Input.UniqueID, MethodType.Post, 100, 0, DataType.Str);
            
                    DateTime? locate_time_Value = (DateTime?)Common.sink(locate_time_Input.UniqueID, MethodType.Post, 50, 0, DataType.Dat);
                
            int error_code_Value = (int)Common.sink(error_code_Input.UniqueID, MethodType.Post, 10, 0, DataType.Int);
            string code_description_Value = (string)Common.sink(code_description_Input.UniqueID, MethodType.Post, 50, 0, DataType.Str);
            
                    DateTime? create_time_Value = (DateTime?)Common.sink(create_time_Input.UniqueID, MethodType.Post, 50, 0, DataType.Dat);
                
            LocationDataEntity ut = BusinessFacadeShanlitech_Location.LocationDataDisp(IDX);
            
            ut.appID = appID_Value;
            ut.userID = userID_Value;
            ut.type = type_Value;
            ut.operator_mobile = operator_mobile_Value;
            ut.coordination = coordination_Value;
            ut.lat = lat_Value;
            ut.lng = lng_Value;
            ut.address = address_Value;
            ut.locate_time = locate_time_Value;
            ut.error_code = error_code_Value;
            ut.code_description = code_description_Value;
            ut.create_time = create_time_Value;
            
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
            Int32 rInt = BusinessFacadeShanlitech_Location.LocationDataInsertUpdateDelete(ut);
            if ( rInt> 0)
            {
                string OpTxt = string.Format("增加定位数据表成功!(ID:{0})", rInt);
                if (ut.DataTable_Action_ == DataTable_Action.Update)
                    OpTxt = string.Format("修改定位数据表成功!(ID:{0})",IDX);
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
