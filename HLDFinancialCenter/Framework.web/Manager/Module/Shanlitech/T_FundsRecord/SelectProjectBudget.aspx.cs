/********************************************************************************
     File:																
            Default.aspx.cs                         
     Description:
            经费使用申请单列表
     Author:									
            DDBuildTools
            http://FrameWork.supesoft.com
     Finish DateTime:
            2014-6-27 18:28:22
     History:
*********************************************************************************/
using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;

using Shanlitech_Location;
using Shanlitech_Location.Components;
using FrameWork;
using FrameWork.Components;

namespace Shanlitech_Location.Web.Module.Shanlitech_Location.T_FundsRecord
{
    public partial class SelectProjectBudget : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Innit();
                BindDataList();
            }
        }

        /// <summary>
        /// 初始化Grid
        /// </summary>
        public string InnitList(int p)
        {
            switch (p)
            {
                case 0:
                    return "正常";
                case 9:
                    return "删除";
                default:
                    return "正常";
            }
        }

        /// <summary>
        /// 初始化
        /// </summary>
        private void Innit()
        {
            ListItem nullItems = new ListItem();
            nullItems.Value = "";
            nullItems.Text = "请选择";

            //初始化所属经费类别
            ClassNO_Input.Items.Add(nullItems);
            List<T_ClassDicEntity> classlist = BusinessFacadeShanlitech_Location.GetClassList();
            foreach (T_ClassDicEntity r in classlist)
            {
                ListItem item = new ListItem();
                item.Text = r.ClassName;
                item.Value = r.ID.ToString();
                ClassNO_Input.Items.Add(item);
            }

            //初始化所属科目
            SubjectNO_Input.Items.Add(nullItems);
            List<T_SubjectDicEntity> subjectlist = BusinessFacadeShanlitech_Location.GetSubjectList();
            foreach (T_SubjectDicEntity r in subjectlist)
            {
                ListItem item = new ListItem();
                item.Text = r.SubjectName;
                item.Value = r.ID.ToString();
                SubjectNO_Input.Items.Add(item);
            }

            //初始化项目编号
            ProjectNO_Input.Items.Add(nullItems);
            List<T_ProjectDicEntity> projectlist = BusinessFacadeShanlitech_Location.GetProjectList();
            foreach (T_ProjectDicEntity r in projectlist)
            {
                ListItem item = new ListItem();
                item.Text = r.ProjectName;
                item.Value = r.ID.ToString();
                ProjectNO_Input.Items.Add(item);
            }

            //初始化项目组长
            Leader_Input.Items.Add(nullItems);
            ArrayList userlist = BusinessFacadeShanlitech_Location.GetUserList();
            foreach (sys_UserTable r in userlist)
            {
                ListItem item = new ListItem();
                item.Value = r.UserID.ToString();
                item.Text = r.U_LoginName;
                if (!r.U_LoginName.Equals(""))
                {
                    Leader_Input.Items.Add(item);
                }
            }

            //初始化指定承办人
            Undertaker_Input.Items.Add(nullItems);
            foreach (sys_UserTable r in userlist)
            {
                ListItem item = new ListItem();
                item.Value = r.UserID.ToString();
                item.Text = r.U_LoginName;
                if (!r.U_LoginName.Equals(""))
                {
                    Undertaker_Input.Items.Add(item);
                }
            }
        }


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
            List<T_ProjectBudgetEntity> lst = BusinessFacadeShanlitech_Location.T_ProjectBudgetList(qp, out RecordCount);
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
                    ViewState["SearchTerms"] = string.Format("where state={0}", (int)Status.Normal);
                return (string)ViewState["SearchTerms"];
            }
            set { ViewState["SearchTerms"] = value; }
        }

        /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {
            string ProjectNO_Value = (string)Common.sink(ProjectNO_Input.UniqueID, MethodType.Post, 50, 0, DataType.Str);
            string SubjectNO_Value = (string)Common.sink(SubjectNO_Input.UniqueID, MethodType.Post, 50, 0, DataType.Str);
            string ClassNO_Value = (string)Common.sink(ClassNO_Input.UniqueID, MethodType.Post, 50, 0, DataType.Str);
            string AnnualNO_Value = (string)Common.sink(AnnualNO_Input.UniqueID, MethodType.Post, 50, 0, DataType.Str);

            string Leader_Value = (string)Common.sink(Leader_Input.UniqueID, MethodType.Post, 10, 0, DataType.Str);
            string Undertaker_Value = (string)Common.sink(Undertaker_Input.UniqueID, MethodType.Post, 10, 0, DataType.Str);

            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(" Where state={0} ", (int)Status.Normal);

            if (ProjectNO_Value != string.Empty)
            {
                sb.AppendFormat(" AND ProjectNO ={0} ", Convert.ToInt32(ProjectNO_Value));
            }

            if (SubjectNO_Value != string.Empty)
            {
                sb.AppendFormat(" AND SubjectNO ={0} ", Convert.ToInt32(SubjectNO_Value));
            }

            if (ClassNO_Value != string.Empty)
            {
                sb.AppendFormat(" AND ClassNO ={0} ", Convert.ToInt32(ClassNO_Value));
            }

            if (AnnualNO_Value != string.Empty)
            {
                sb.AppendFormat(" AND AnnualNO like '%{0}%' ", Common.inSQL(AnnualNO_Value));
            }

            if (Leader_Value != string.Empty)
            {
                sb.AppendFormat(" AND Leader = {0} ", Convert.ToInt32(Leader_Value));
            }

            if (Undertaker_Value != string.Empty)
            {
                sb.AppendFormat(" AND Undertaker = {0} ", Convert.ToInt32(Undertaker_Value));
            }

            ViewState["SearchTerms"] = sb.ToString();
            BindDataList();
            TabOptionWebControls1.SelectIndex = 0;
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
        /// <summary>
        /// 排序事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
        {
            Int32 DataIDX = 0;
            if (e.Row.RowType == DataControlRowType.Header)
            {
                if (FrameWorkPermission.CheckButtonPermission(PopedomType.Delete))
                {
                    Button2.Visible = true;
                    //增加check列头全选
                    TableCell cell = new TableCell();
                    cell.Width = Unit.Pixel(5);
                    cell.Text = "";
                    //cell.Text = " <input id='CheckboxAll' value='0' type='checkbox' onclick='SelectAll()'/>";
                    e.Row.Cells.AddAt(0, cell);
                }

                foreach (TableCell var in e.Row.Cells)
                {
                    if (var.Controls.Count > 0 && var.Controls[0] is LinkButton)
                    {
                        string Colume = ((LinkButton)var.Controls[0]).CommandArgument;
                        if (Colume == Orderfld)
                        {

                            LinkButton l = (LinkButton)var.Controls[0];
                            l.Text += string.Format("<img src='{0}' border='0'>", (OrderType == 0) ? Page.ResolveUrl("~/Manager/images/sort_asc.gif") : Page.ResolveUrl("~/Manager/images/sort_desc.gif"));
                            //Image Img = new Image();
                            //SortDirection a = GridView1.SortDirection;
                            //Img.ImageUrl = (a == SortDirection.Ascending) ? "i_p_sort_asc.gif" : "i_p_sort_desc.gif";
                            //var.Controls.Add(Img);
                        }
                    }
                }
            }
            else
            {
                if (FrameWorkPermission.CheckButtonPermission(PopedomType.Delete))
                {
                    //增加行选项
                    DataIDX = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "ID"));
                    TableCell cell = new TableCell();
                    cell.Width = Unit.Pixel(5);
                    cell.Text = string.Format(" <input name='radio' id='radio' value='{0}' type='radio' />", DataIDX);
                    e.Row.Cells.AddAt(0, cell);
                }
            }
        }
        #endregion

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button2_Click(object sender, EventArgs e)
        {
            string radio_Value = (string)Common.sink("radio", MethodType.Post, 2000, 0, DataType.Str);
            int IDX;
            if (Int32.TryParse(radio_Value, out IDX))
            {
                T_ProjectBudgetEntity entity = BusinessFacadeShanlitech_Location.T_ProjectBudgetDisp(IDX);
                string script = "<script>parent.hidePopWin(false);parent.ReloadPage(" + IDX + ",'" + BusinessFacadeShanlitech_Location.GetProjectBudgetFormat(entity)
                    + "','"+entity.BalanceAmount.ToString()+"');</script>";
                ClientScript.RegisterStartupScript(this.Page.GetType(), "alert", script);
            }
            else
            {

            }
        }
    }
}
