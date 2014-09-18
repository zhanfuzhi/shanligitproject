/********************************************************************************
     File:																
            Manager.aspx.cs                         
     Description:
            数据字典管理
     Author:									
            DDBuildTools
            http://DDBuildTools.supesoft.com
     Finish DateTime:
            2010-6-1 18:01:11
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

using FrameWork;

using FrameWork.WebControls; 
using System.Collections.Generic;
using ShanliTech_HLD_Business.Components;
using FrameWork.Components;

namespace ShanliTech_HLD_Business.Web.Module.ShanliTech_HLD_Business.T_DataDictionary
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
            T_DataDictionaryEntity ut = BusinessFacadeShanliTech_HLD_Business.T_DataDictionaryDisp(IDX);
            OnStartData(ut);
            switch (CMD)
            {
                case "New":
                    TabOptionItem1.Tab_Name = HeadMenuWebControls1.HeadOPTxt = "增加数据字典";
                    Hidden_Disp();
                    ButtonNew();
                    break;
                case "List":
                    TabOptionItem1.Tab_Name = HeadMenuWebControls1.HeadOPTxt = "查看数据字典";
                    Hidden_Input();
                    ButtonOption.Visible = false;
                    AddEditButton();
                    break;
                case "Edit":
                    TabOptionItem1.Tab_Name = HeadMenuWebControls1.HeadOPTxt = "修改数据字典";
                    Hidden_Disp();
                    AddDeleteButton();
                    break;
                case "Delete":
                    switch (IsDataDictionaryValid(ut))
                    {
                        case 0:
                            ut.DataTable_Action_ = DataTable_Action.Delete;
                            if (BusinessFacadeShanliTech_HLD_Business.T_DataDictionaryInsertUpdateDelete(ut) > 0)
                            {
                                EventMessage.MessageBox(1, "删除成功", string.Format("删除ID:{0}成功!", IDX), Icon_Type.OK, Common.GetHomeBaseUrl("Default.aspx"), Common.BuildJs);
                            }
                            else
                            {
                                EventMessage.MessageBox(1, "删除失败", string.Format("删除ID:{0}失败!", IDX), Icon_Type.Error, Common.GetHomeBaseUrl(string.Format("Default.aspx?ID={0}", IDX)), Common.BuildJs);
                            }
                            break;
                        case 1:
                            EventMessage.MessageBox(1, "删除失败", string.Format("删除ID:{0}失败,有子结点!", IDX), Icon_Type.Error, Common.GetHomeBaseUrl(string.Format("Default.aspx?ID={0}", IDX)), Common.BuildJs);
                            break;
                        case 2:
                            EventMessage.MessageBox(1, "删除失败", string.Format("删除ID:{0}失败,在设备中存在该设备品牌的设备!", IDX), Icon_Type.Error, Common.GetHomeBaseUrl(string.Format("Default.aspx?ID={0}", IDX)), Common.BuildJs);
                            break;
                        case 3:
                            EventMessage.MessageBox(1, "删除失败", string.Format("删除ID:{0}失败,在设备中存在该设备型号的设备!", IDX), Icon_Type.Error, Common.GetHomeBaseUrl(string.Format("Default.aspx?ID={0}", IDX)), Common.BuildJs);
                            break;
                        case 4:
                            EventMessage.MessageBox(1, "删除失败", string.Format("删除ID:{0}失败,在车辆中存在该车辆类型的车辆!", IDX), Icon_Type.Error, Common.GetHomeBaseUrl(string.Format("Default.aspx?ID={0}", IDX)), Common.BuildJs);
                            break;
                        case 5:
                            EventMessage.MessageBox(1, "删除失败", string.Format("删除ID:{0}失败,在设备中存在该设备类型的设备!", IDX), Icon_Type.Error, Common.GetHomeBaseUrl(string.Format("Default.aspx?ID={0}", IDX)), Common.BuildJs);
                            break;

                    }
                    break;
                default:
                    EventMessage.MessageBox(2, "不存在操作字符串!", "不存在操作字符串!", Icon_Type.Error, Common.GetHomeBaseUrl(string.Format("Default.aspx?ID={0}", IDX)), Common.BuildJs);
                    break;
            }
        }

        private int IsDataDictionaryValid(T_DataDictionaryEntity ut)
        {
            int Record = 0;
            QueryParam qp = null;

            qp = new QueryParam();;
            qp.Where = "where parent=" + ut.ID;
            List<T_DataDictionaryEntity> isChiledrenNode = BusinessFacadeShanliTech_HLD_Business.T_DataDictionaryList(qp, out Record);//验证是否有子结点
            if (Record > 0)
            {
                return 1;
            }
            
            return 0;
        }

        private void ButtonNew()
        {
            HeadMenuButtonItem bi1 = new HeadMenuButtonItem();
            bi1.ButtonPopedom = PopedomType.List;
            bi1.ButtonIcon = "back.gif";
            bi1.ButtonName = "返回";
            bi1.ButtonUrl = string.Format("Default.aspx?ID={0}", IDX);
            HeadMenuWebControls1.ButtonList.Add(bi1);
        }

        /// <summary>
        /// 增加修改按钮
        /// </summary>
        private void AddEditButton()
        {
            HeadMenuButtonItem bi = new HeadMenuButtonItem();
            bi.ButtonPopedom = PopedomType.Edit;
            bi.ButtonName = "数据字典";
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
            bi.ButtonName = "数据字典";
            bi.ButtonUrlType = UrlType.JavaScript;
            bi.ButtonUrl = string.Format("DelData('?CMD=Delete&IDX={0}')", IDX);
            HeadMenuWebControls1.ButtonList.Add(bi);

            HeadMenuButtonItem bi1 = new HeadMenuButtonItem();
            bi1.ButtonPopedom = PopedomType.List;
            bi1.ButtonIcon = "back.gif";
            bi1.ButtonName = "返回";
            bi1.ButtonUrl = string.Format("Default.aspx?ID={0}", IDX);
            HeadMenuWebControls1.ButtonList.Add(bi1);
        }

        /// <summary>
        /// 初始化数据
        /// </summary>
        /// <param name="ut"></param>
        private void OnStartData(T_DataDictionaryEntity ut)
        {

            if (ut.ID != 0)
            {

                parent_Disp.Text = BusinessFacadeShanliTech_HLD_Business.T_DataDictionaryDisp(ut.ID).Name;
                
            }
            else
            {
                parent_Disp.Text = "数据字典";
            }

            if (CMD == "Edit" || CMD == "List")
            {
                Name_Input.Text = Name_Disp.Text = ut.Name.ToString();
                Code_Input.Text = Code_Disp.Text = ut.Code.ToString();
                if (ut.parent != 0)
                {
                    if (ut.ID != 0)
                    {
                        parent_Disp.Text = BusinessFacadeShanliTech_HLD_Business.T_DataDictionaryDisp(ut.parent).Name;
                    }

                }
                else
                {
                    parent_Disp.Text = "数据字典";
                }
            }
            else if (CMD == "New")
            {
                Code_Input.Text = Code_Disp.Text = BusinessFacadeShanliTech_HLD_Business.T_DataDictionaryDisp(ut.ID).Code;
            }

        }

        /// <summary>
        /// 隐藏输入框
        /// </summary>
        private void Hidden_Input()
        {
            Name_Input.Visible = false;
            Code_Input.Visible = false;
            //--
            lblName.Visible = false;

        }

        /// <summary>
        /// 隐藏显示框
        /// </summary>
        private void Hidden_Disp()
        {
            Name_Disp.Visible = false;
            Code_Disp.Visible = false;
            //--

        }

        /// <summary>
        /// 增加/修改事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {
            int parent_Value = 0;
            string Name_Value = (string)Common.sink(Name_Input.UniqueID, MethodType.Post, 50, 0, DataType.Str);
            string Code_Value = (string)Common.sink(Code_Input.UniqueID, MethodType.Post, 50, 0, DataType.Str);

            T_DataDictionaryEntity ut = BusinessFacadeShanliTech_HLD_Business.T_DataDictionaryDisp(IDX);
            if (CMD == "New")
            {
                parent_Value = ut.ID;
            }
            if (CMD == "Edit")
            {
                parent_Value = ut.parent;
            }
            ut.Name = Name_Value;
            ut.Code = Code_Value;
            ut.Type = parent_Disp.Text;
            ut.parent = parent_Value;
            if (ut.ID == 0)
            {
                ut.Type = "数据字典";
            }

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
                EventMessage.MessageBox(2, "不存在操作字符串!", "不存在操作字符串!", Icon_Type.Error, Common.GetHomeBaseUrl(string.Format("Default.aspx?ID={0}", IDX)), Common.BuildJs);
            }
            Int32 rInt = BusinessFacadeShanliTech_HLD_Business.T_DataDictionaryInsertUpdateDelete(ut);
            if (rInt > 0)
            {
                string OpTxt = string.Format("增加数据字典成功!(ID:{0})", rInt);
                if (ut.DataTable_Action_ == DataTable_Action.Update)
                    OpTxt = string.Format("修改数据字典成功!(ID:{0})", IDX);
                EventMessage.MessageBox(1, "操作成功", OpTxt, Icon_Type.OK, Common.GetHomeBaseUrl(string.Format("Default.aspx?ID={0}", IDX)), Common.BuildJs);
            }
            else if (rInt == -2)
            {
                EventMessage.MessageBox(1, "操作失败", "操作失败,存在相同的键值(用户名/数据)!", Icon_Type.Alert, Common.GetHomeBaseUrl(string.Format("Default.aspx?ID={0}", IDX)), Common.BuildJs);
            }
            else
            {
                EventMessage.MessageBox(1, "操作失败", string.Format("操作失败,返回值:{0}!", rInt), Icon_Type.Error, Common.GetHomeBaseUrl(string.Format("Default.aspx?ID={0}", IDX)), Common.BuildJs);
            }
        }
    }
}
