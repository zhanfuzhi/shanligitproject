/********************************************************************************
     File:																
            Default.aspx.cs                         
     Description:
            预算明细列表
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

namespace Shanlitech_Location.Web.Module.Shanlitech_Location.T_BudgetDetail
{
    public partial class Default : System.Web.UI.Page
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
        /// 初始化
        /// </summary>
        private void Innit()
        {
            ListItem nullItems = new ListItem();
            nullItems.Value = "";
            nullItems.Text = "请选择";

            //初始化所属经费类别
            ProjID_Input.Items.Add(nullItems);
            List<T_ProjectBudgetEntity> classlist = BusinessFacadeShanlitech_Location.GetProjectBudList();
            foreach (T_ProjectBudgetEntity r in classlist)
            {
                ListItem item = new ListItem();
                item.Text = r.AnnualNO;//年度编号作为项目名称
                item.Value = r.ID.ToString();
                ProjID_Input.Items.Add(item);
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
            List<T_BudgetDetailEntity> lst = BusinessFacadeShanlitech_Location.T_BudgetDetailList(qp, out RecordCount);
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
                {
                    ViewState["SearchTerms"] = "where 1=1";
                }
                if (!string.IsNullOrEmpty(Request.QueryString["proid"]))
                {
                    ViewState["SearchTerms"] += string.Format(" and  projid={0}", Request.QueryString["proid"].ToString());
                }
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
            string ProjID_Value = (string)Common.sink(ProjID_Input.UniqueID, MethodType.Post, 10, 0, DataType.Str);
            string EquipmentName_Value = (string)Common.sink(EquipmentName_Input.UniqueID, MethodType.Post, 50, 0, DataType.Str);
            string Supplier_Value = (string)Common.sink(Supplier_Input.UniqueID, MethodType.Post, 50, 0, DataType.Str);
            string Remark_Value = (string)Common.sink(Remark_Input.UniqueID, MethodType.Post, 50, 0, DataType.Str);
            StringBuilder sb = new StringBuilder();
            sb.Append(" Where 1=1 ");

            if (ProjID_Value != string.Empty)
            {
                sb.AppendFormat(" AND ProjID = {0} ", Convert.ToInt32(ProjID_Value));
            }

            if (EquipmentName_Value != string.Empty)
            {
                sb.AppendFormat(" AND EquipmentName like '%{0}%' ", Common.inSQL(EquipmentName_Value.Trim()));
            }

            if (Supplier_Value != string.Empty)
            {
                sb.AppendFormat(" AND Supplier like '%{0}%' ", Common.inSQL(Supplier_Value.Trim()));
            }

            if (Remark_Value != string.Empty)
            {
                sb.AppendFormat(" AND Remark like '%{0}%' ", Common.inSQL(Remark_Value.Trim()));
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
                    cell.Text = " <input id='CheckboxAll' value='0' type='checkbox' onclick='SelectAll()'/>";
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
                    cell.Text = string.Format(" <input name='Checkbox' id='Checkbox' value='{0}' type='checkbox' />", DataIDX);
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
        [PopedomTypeAttaible(PopedomType.Delete)]
        [System.Security.Permissions.PrincipalPermission(System.Security.Permissions.SecurityAction.Demand, Role = "OR")]
        protected void Button2_Click(object sender, EventArgs e)
        {
            string Checkbox_Value = (string)Common.sink("Checkbox", MethodType.Post, 2000, 1, DataType.Str);
            string[] Checkbox_Value_Array = Checkbox_Value.Split(',');
            Int32 IDX = 0;
            for (int i = 0; i < Checkbox_Value_Array.Length; i++)
            {
                if (Int32.TryParse(Checkbox_Value_Array[i], out IDX))
                {
                    T_BudgetDetailEntity et = new T_BudgetDetailEntity();
                    et.DataTable_Action_ = DataTable_Action.Delete;
                    et.ID = IDX;
                    BusinessFacadeShanlitech_Location.T_BudgetDetailInsertUpdateDelete(et);
                }
            }

            EventMessage.MessageBox(1, "批量删除成功", string.Format("批量删除({0})成功!", Checkbox_Value), Icon_Type.OK, Common.GetHomeBaseUrl("default.aspx"));
        }

        /// <summary>
        /// 批量导入预算明细
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnImportYSMX_Click(object sender, EventArgs e)
        {
            #region 检查上传文件格式是否正确
            sys_UserTable curruser = UserData.GetUserDate;
            if (curruser.U_LoginName != null)
            {
                try
                {
                    string creatPath = System.Web.HttpContext.Current.Server.MapPath("/FJ/YSMX").ToString();
                    if (!System.IO.Directory.Exists(creatPath))
                    {
                        System.IO.Directory.CreateDirectory(creatPath);
                    }
                }
                catch
                {
                    throw;
                }
            }


            string strBaseLocation = Server.MapPath("/FJ/YSMX/");
            string LocalFile = string.Empty;//本地文件名
            string newfilename = DateTime.Now.ToString("yyyyMMddHHmmss");

            string clientFilename = System.IO.Path.GetFileName(Filename.PostedFile.FileName);

            string serverFilename = "";
            if (clientFilename == "")
            {
                EventMessage.Show(this.Page, "您上传的文件名不能为空！");
                return;
            }
            if (clientFilename.ToLower().IndexOf(".xlsx") > 0)
            {
                serverFilename = ".xlsx";
            }
            else
            {
                if (clientFilename.ToLower().IndexOf(".xls") > 0 && clientFilename.EndsWith("xls"))
                {
                    serverFilename = ".xls";
                }
                else
                {
                    EventMessage.Show(this.Page, "您上传的文件必须为Excel文件！");

                    return;
                }
            }
            //设置文件名    
            LocalFile = strBaseLocation + newfilename + serverFilename;
            //保存文件
            Filename.PostedFile.SaveAs(LocalFile);

            #endregion

            #region 数据导入库中
            StringBuilder msg = new StringBuilder();
            DataTable dt = new DataTable();

            if (this.Filename.HasFile)
            {
                try
                {
                    //读取Excel资料流并转换成DataTable 
                    dt = ExcelHelper.RenderDataTableFromExcel(this.Filename.FileContent, 0, 4);

                    int success = 0; //成功的个数
                    int unsucess = 0;//失败的个数
                    int t_proID=0;
                    bool IsInsertTPro = true;
                    foreach (DataRow dr in dt.Rows)
                    {
                        try
                        {
                            #region 给个字段赋值
                            string lbmc = "";
                            string kmmc = "";
                            string xmmc = "";
                            //判断此项目是否已添加到项目预算表中
                            if (!dr[2].ToString().Trim().Equals(""))
                            {
                                lbmc = BusinessFacadeShanlitech_Location.GetIDByClassName(dr[0].ToString().Trim()).ToString(); //类别ID
                                kmmc = BusinessFacadeShanlitech_Location.GetIDBySubjectName(dr[1].ToString().Trim()).ToString();//科目名称
                                xmmc = BusinessFacadeShanlitech_Location.GetIDByProjectName(dr[2].ToString().Trim()).ToString();//项目名称
                                IsInsertTPro = true;
                            }
                            else
                            {
                                IsInsertTPro = false;
                            }
                            float xmje;
                            if (dr[3].ToString().Trim().Length > 0)
                            {
                                xmje = float.Parse(dr[3].ToString().Trim());//项目金额
                            }
                            else
                            {
                                xmje = 0f;//项目金额
                            }
                            string qcmc = dr[4].ToString().Trim();//器材名称
                            float yssr;
                            if (dr[5].ToString().Trim().Length > 0)
                            {
                                yssr = float.Parse(dr[5].ToString().Trim());//预算收入
                            }
                            else
                            {
                                yssr = 0f;//预算收入
                            }
                            string jldw = dr[6].ToString().Trim();//计量单位
                            float dj;
                            if (dr[7].ToString().Trim().Length > 0)
                            {
                                dj = float.Parse(dr[7].ToString().Trim());//单价
                            }
                            else
                            {
                                dj = 0f;//单价
                            }
                            int sl;
                            if (dr[8].ToString().Trim().Length > 0)
                            {
                                sl = Convert.ToInt32(dr[8].ToString().Trim());//数量
                            }
                            else
                            {
                                sl = 0;//数量
                            }
                            float je;
                            if (dr[9].ToString().Trim().Length > 0)
                            {
                                je = float.Parse(dr[9].ToString().Trim());//金额
                            }
                            else
                            {
                                je = 0f;//金额
                            }
                            string ghdw = dr[10].ToString().Trim();//供货单位
                            float ysye;
                            if (dr[11].ToString().Trim().Length > 0)
                            {
                                ysye = float.Parse(dr[11].ToString().Trim());//预算余额
                            }
                            else
                            {
                                ysye = 0f;//预算余额
                            }

                            string bz = dr[12].ToString().Trim();//备注
                            #endregion

                            #region 项目预算表插入数据
                            if (IsInsertTPro)
                            {
                                T_ProjectBudgetEntity t_proEntity = new T_ProjectBudgetEntity();
                                t_proEntity.DataTable_Action_ = DataTable_Action.Insert;
                                t_proEntity.ClassNO = lbmc;
                                t_proEntity.SubjectNO = kmmc;
                                t_proEntity.ProjectNO = xmmc;
                                t_proEntity.BudgetExpenditure = xmje;
                                t_proID = BusinessFacadeShanlitech_Location.T_ProjectBudgetInsertUpdateDelete(t_proEntity);
                            }
                            #endregion

                            #region 预算明细表插入数据
                            if (t_proID > 0)
                            {
                                T_BudgetDetailEntity t_budEntity = new T_BudgetDetailEntity();
                                t_budEntity.DataTable_Action_ = DataTable_Action.Insert;
                                t_budEntity.ProjID = t_proID;
                                t_budEntity.EquipmentName = qcmc;
                                t_budEntity.BudgetRevenue = yssr;
                                t_budEntity.Measurement = jldw;
                                t_budEntity.BudgetPrice = dj;
                                t_budEntity.BudgetNumber = sl;
                                t_budEntity.BudgetExpenditure = je;
                                t_budEntity.Supplier = ghdw;
                                t_budEntity.BalanceAmount = ysye;
                                t_budEntity.Remark = bz;
                                int t_budID = BusinessFacadeShanlitech_Location.T_BudgetDetailInsertUpdateDelete(t_budEntity);
                                if (t_budID > 0)
                                {
                                    success += 1;
                                }
                            }
                            #endregion
                        }
                        catch (Exception)
                        {
                            unsucess += 1;
                            continue;
                        }
                    }

                    msg.Append("添加成功个数：" + success + "!\\n");
                    msg.Append("添加失败个数：" + unsucess + "!\\n");
                    EventMessage.Show(this.Page, "操作结果：\\n" + msg.ToString(), "Default.aspx");
                    this.TabOptionWebControls1.SelectIndex = 1;
                }
                catch (Exception ex)
                {
                    EventMessage.MessageBox(1, "操作无效", "上传文件导入数据失败!", Icon_Type.Error, Common.GetHomeBaseUrl("Default.aspx"));
                }
            }
            else
            {
                EventMessage.Show(this.Page, "此文件为空！");
            }

            #endregion

        }
    }
}
