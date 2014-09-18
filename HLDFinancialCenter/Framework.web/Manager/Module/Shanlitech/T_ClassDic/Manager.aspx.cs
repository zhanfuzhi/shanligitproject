/********************************************************************************
     File:																
            Manager.aspx.cs                         
     Description:
            T_ClassDic管理
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

namespace Shanlitech_Location.Web.Module.Shanlitech_Location.T_ClassDic
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
            T_ClassDicEntity ut = BusinessFacadeShanlitech_Location.T_ClassDicDisp(IDX);
            OnStartData(ut);
            switch (CMD)
            {
                case "New":
                    TabOptionItem1.Tab_Name = HeadMenuWebControls1.HeadOPTxt = "增加经费类别";
                    Hidden_Disp();
                    break;
                case "List":
                    TabOptionItem1.Tab_Name = HeadMenuWebControls1.HeadOPTxt = "查看经费类别";
                    Hidden_Input();
                    ButtonOption.Visible = false;
                    AddEditButton();
                    break;
                case "Edit":
                    TabOptionItem1.Tab_Name = HeadMenuWebControls1.HeadOPTxt = "修改经费类别";
                    Hidden_Disp();
                    AddDeleteButton();
                    break;
                case "Delete":
                    ut.DataTable_Action_ = DataTable_Action.Update;
                    ut.State = (int)Status.Delete;//删除状态
                    if (BusinessFacadeShanlitech_Location.T_ClassDicInsertUpdateDelete(ut) > 0)
                    {
                        EventMessage.MessageBox(1, "删除成功", string.Format("删除ID:{0}成功!", IDX), Icon_Type.OK, Common.GetHomeBaseUrl("Default.aspx"));
                    }
                    else
                    {
                        EventMessage.MessageBox(1, "删除失败", string.Format("删除ID:{0}失败!", IDX), Icon_Type.Error, Common.GetHomeBaseUrl("Default.aspx"));
                    }
                    break;
                default:
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
            bi.ButtonName = "经费类别";
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
            bi.ButtonName = "经费类别";
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
        private void OnStartData(T_ClassDicEntity ut)
        {
            ClassNO_Input.Text = ClassNO_Disp.Text = ut.ClassNO.ToString();
            ClassName_Input.Text = ClassName_Disp.Text = ut.ClassName.ToString();
        }

        /// <summary>
        /// 隐藏输入框
        /// </summary>
        private void Hidden_Input()
        {
            ClassNO_Input.Visible = false;
            ClassName_Input.Visible = false;
        }

        /// <summary>
        /// 隐藏显示框
        /// </summary>
        private void Hidden_Disp()
        {
            ClassNO_Disp.Visible = false;
            ClassName_Disp.Visible = false;
        }

        /// <summary>
        /// 增加/修改事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {

            string ClassNO_Value = (string)Common.sink(ClassNO_Input.UniqueID, MethodType.Post, 50, 1, DataType.Str);
            string ClassName_Value = (string)Common.sink(ClassName_Input.UniqueID, MethodType.Post, 50, 0, DataType.Str);
            DateTime? CreateTime_Value = DateTime.Now;


            DateTime? UpdateTime_Value = DateTime.Now;

            T_ClassDicEntity ut = BusinessFacadeShanlitech_Location.T_ClassDicDisp(IDX);

            ut.ClassNO = ClassNO_Value;
            ut.ClassName = ClassName_Value;
            ut.State = (int)Status.Normal;//正常状态

            if (CMD == "New")
            {
                ut.CreateTime = CreateTime_Value;
                ut.UpdateTime = UpdateTime_Value;
                ut.DataTable_Action_ = DataTable_Action.Insert;
            }
            else if (CMD == "Edit")
            {
                ut.UpdateTime = UpdateTime_Value;
                ut.DataTable_Action_ = DataTable_Action.Update;
            }
            else
            {
                EventMessage.MessageBox(2, "不存在操作字符串!", "不存在操作字符串!", Icon_Type.Error, Common.GetHomeBaseUrl("Default.aspx"));
            }
            Int32 rInt = BusinessFacadeShanlitech_Location.T_ClassDicInsertUpdateDelete(ut);
            if (rInt > 0)
            {
                string OpTxt = string.Format("增加经费类别成功!(ID:{0})", rInt);
                if (ut.DataTable_Action_ == DataTable_Action.Update)
                    OpTxt = string.Format("修改经费类别成功!(ID:{0})", IDX);
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
