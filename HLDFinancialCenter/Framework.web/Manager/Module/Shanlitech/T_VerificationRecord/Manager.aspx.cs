/********************************************************************************
     File:																
            Manager.aspx.cs                         
     Description:
            核销申请单管理
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
using System.IO;
using System.Collections.Generic;

namespace Shanlitech_Location.Web.Module.Shanlitech_Location.T_VerificationRecord
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
                BindDataList();
            }
        }
        
        /// <summary>
        /// 开始操作
        /// </summary>
        private void OnStart()
        {
            T_VerificationRecordEntity ut = BusinessFacadeShanlitech_Location.T_VerificationRecordDisp(IDX);
            OnStartData(ut);
            switch (CMD)
            { 
                case "New":
                    TabOptionItem1.Tab_Name = HeadMenuWebControls1.HeadOPTxt = "增加核销申请单";
                    Hidden_Disp();
                    break;
                case "List":
                    TabOptionItem1.Tab_Name = HeadMenuWebControls1.HeadOPTxt = "查看核销申请单";
                    Hidden_Input();
                    ButtonOption.Visible = false;
                    if (ut.TransferState <= 0)
                    {
                        AddEditButton();
                    }
                    break;
                case "Edit":
                    TabOptionItem1.Tab_Name = HeadMenuWebControls1.HeadOPTxt = "修改核销申请单";
                    Hidden_Disp();
                    if (ut.TransferState <= 0)
                    {
                        AddDeleteButton();
                    }
                    break;
                case "Delete":
                    ut.DataTable_Action_ = DataTable_Action.Update;
                    ut.State = (int)Status.Delete;
                    if (BusinessFacadeShanlitech_Location.T_VerificationRecordInsertUpdateDelete(ut) > 0)
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
            bi.ButtonName = "核销申请单";
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
                bi.ButtonName = "核销申请单";
                bi.ButtonUrlType = UrlType.JavaScript;
                bi.ButtonUrl = string.Format("DelData('?CMD=Delete&IDX={0}')", IDX);
                HeadMenuWebControls1.ButtonList.Add(bi);
        

            //HeadMenuButtonItem bi1 = new HeadMenuButtonItem();
            //bi1.ButtonPopedom = PopedomType.List;
            //bi1.ButtonIcon = "back.gif";
            //bi1.ButtonName = "返回";
            //bi1.ButtonUrl = string.Format("?CMD=List&IDX={0}", IDX);
            //HeadMenuWebControls1.ButtonList.Add(bi1);
        }

        /// <summary>
        /// 初始化数据
        /// </summary>
        /// <param name="ut"></param>
        private void OnStartData(T_VerificationRecordEntity ut)
        {
            ProjID_Hidden.Value = ut.FundID.ToString();
            Protype_Hidden.Value = ut.ProjID.ToString();
            if (!ut.ProjID.Equals(0))
            {
                ProjID_Disp.Text = BusinessFacadeShanlitech_Location.GetProjectBudgetFormat(BusinessFacadeShanlitech_Location.T_ProjectBudgetDisp(ut.ProjID));
            }

        
            ShenHeNote_Disp.Text = ut.ShenHeNote;
         
            CunDangNote_Disp.Text = ut.CunDangNote;
       
                
        }

        /// <summary>
        /// 隐藏输入框
        /// </summary>
        private void Hidden_Input()
        {
            SelectCase.Visible = false;
          

        }

        /// <summary>
        /// 隐藏显示框
        /// </summary>
        private void Hidden_Disp()
        {
          
        //tr_ShenHeNote.Visible = false;
        //tr_PiZhunNote.Visible = false;
        //tr_CunDangNote.Visible = false;
        }

        /// <summary>
        /// 增加/修改事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {
            T_VerificationRecordEntity ut = BusinessFacadeShanlitech_Location.T_VerificationRecordDisp(IDX);

            int FundID_Value = Convert.ToInt32(ProjID_Hidden.Value);
            int ProjID_Value = Convert.ToInt32(Protype_Hidden.Value);

            int Undertaker_Value = (int)UserData.GetUserDate.UserID;
            int TransferState_Value = (int)TransferState.ShenQing;
            int State_Value = (int)Status.Normal;

            DateTime? CreateTime_Value = (DateTime?)DateTime.Now;
                
            ut.FundID = FundID_Value;
            ut.ProjID = ProjID_Value;
           
            ut.Undertaker = Undertaker_Value;
            ut.TransferState = TransferState_Value;
            ut.State = State_Value;
            ut.CreateTime = CreateTime_Value;
            
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
            Int32 rInt = BusinessFacadeShanlitech_Location.T_VerificationRecordInsertUpdateDelete(ut);
            if ( rInt> 0)
            {
                string OpTxt = string.Format("增加核销申请单成功!(ID:{0})", rInt);
                if (ut.DataTable_Action_ == DataTable_Action.Update)
                {
                    OpTxt = string.Format("修改核销申请单成功!(ID:{0})", IDX);
                    rInt = IDX;
                }
                //EventMessage.MessageBox(1, "操作成功", OpTxt, Icon_Type.OK, ommon.GetHomeBaseUrl("Manager.aspx"));
               
                //Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('保存成功');</script>");
                Response.Redirect(string.Format("InStockManager.aspx?CMD=New&VerID={0}", rInt));
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button2_Click(object sender, EventArgs e)
        {

        }


        #region 资产库列表
        /// <summary>
        /// 绑定数据
        /// </summary>
        private void BindDataList()
        {
            QueryParam qp = new QueryParam();
            qp.Where = SearchTerms;
            qp.PageIndex = AspNetPager1.CurrentPageIndex;
            qp.PageSize = AspNetPager1.PageSize;
            qp.Orderfld = Orderfld;
            qp.OrderType = OrderType;
            int RecordCount = 0;
            List<T_StorageRecordEntity> lst = BusinessFacadeShanlitech_Location.T_StorageRecordList(qp, out RecordCount);
            GridView1.DataSource = lst;
            GridView1.DataBind();
            this.AspNetPager1.RecordCount = RecordCount;
        }

        /// <summary>
        /// 点击分页事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindDataList();
        }

        /// <summary>
        /// 查询条件
        /// </summary>
        private string SearchTerms
        {
            get
            {
                if (ViewState["SearchTerms"] == null)
                    ViewState["SearchTerms"] = string.Format(" Where VeriID={0}",IDX);
                return (string)ViewState["SearchTerms"];
            }
            set { ViewState["SearchTerms"] = value; }
        }

        #region "排序"
        protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
        {
            if (Orderfld == e.SortExpression)
            {
                if (OrderType == 0)
                {
                    OrderType = 1;
                }
                else
                {
                    OrderType = 0;
                }
            }
            Orderfld = e.SortExpression;
            BindDataList();
        }

        /// <summary>
        /// 排序字段
        /// </summary>
        public string Orderfld
        {
            get
            {
                if (ViewState["sortOrderfld"] == null)

                    ViewState["sortOrderfld"] = "ID";

                return (string)ViewState["sortOrderfld"];
            }
            set
            {
                ViewState["sortOrderfld"] = value;
            }
        }

        /// <summary>
        /// 排序类型 1:降序 0:升序
        /// </summary>
        public int OrderType
        {

            get
            {

                if (ViewState["sortOrderType"] == null)
                    ViewState["sortOrderType"] = 1;

                return (int)ViewState["sortOrderType"];


            }

            set { ViewState["sortOrderType"] = value; }

        }
        #endregion

        #endregion
    }
}
