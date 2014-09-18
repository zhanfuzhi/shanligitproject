using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using FrameWork.Components;
using ShanliTech_HLD_Business.Components;
using System.Collections.Generic;
using ShanliTech_HLD_Business;
using System.Text;

namespace FrameWork.web.Manager.Module.ShanliTech_HLD.DeviceTemplate
{
    public partial class AssembleCmdSelectList : System.Web.UI.Page
    {
        protected string DeviceModel = (string)Common.sink("DeviceModel", MethodType.Get, 50, 0, DataType.Str);
        protected string CmdIdentity = (string)Common.sink("CmdIdentity", MethodType.Get, 50, 0, DataType.Str);
        Int32 DeviceID = (Int32)Common.sink("DeviceID", MethodType.Get, 10, 0, DataType.Int);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindDataList();
            }
            
        }
        
        private void BindDataList()
        {
            QueryParam qp = new QueryParam();
            qp.Where = SearchTerms;
            qp.PageIndex = AspNetPager1.CurrentPageIndex;
            qp.PageSize = AspNetPager1.PageSize;
            qp.Orderfld = Orderfld;
            qp.OrderType = OrderType;
            int RecordCount = 0;
            List<CommandAssembleEntity> lst = BusinessFacadeShanliTech_HLD_Business.CommandAssembleList(qp, out RecordCount);
            GridView1.DataSource = lst;
            GridView1.DataBind();
            this.AspNetPager1.RecordCount = RecordCount;
        }

        #region "排序"

        /// <summary>
        /// 排序事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
        {
            Int32 DataIDX = 0;
            TableCell cell = null;
            if (e.Row.RowType == DataControlRowType.Header)
            {
                #region 单选框

                cell = new TableCell();
                cell.Width = Unit.Pixel(5);
                cell.Text = " ";
                e.Row.Cells.AddAt(0, cell);

                #endregion

            }
            else
            {
                //增加行选项
                DataIDX = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "ID"));
                cell = new TableCell();
                cell.Width = Unit.Pixel(5);
                cell.Text = string.Format(" <input name='RadioButton' id='RadioButton' value='{0}' type='radio' />", DataIDX);
                e.Row.Cells.AddAt(0, cell);
            }
        }
        /// <summary>
        /// 查询条件
        /// </summary>
        private string SearchTerms
        {
            get
            {
                if (ViewState["SearchTerms"] == null)
                    ViewState["SearchTerms"] = string.Format(" Where DeviceModel = '{0}' And CommandIdentity = '{1}'", DeviceModel, CmdIdentity);
                return (string)ViewState["SearchTerms"];
            }
            set { ViewState["SearchTerms"] = value; }
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

        protected void Button1_Click(object sender, EventArgs e)
        {
            string RadioValue = (string)Common.sink("RadioButton", MethodType.Post, 200, 0, DataType.Str);
            string returnVal = string.Empty;
            if (!string.IsNullOrEmpty(RadioValue))
            {
                int idx = 0;
                Int32.TryParse(RadioValue, out idx);
                CommandAssembleEntity dpd = BusinessFacadeShanliTech_HLD_Business.CommandAssembleDisp(idx);
                
                int underIndex = CmdIdentity.IndexOf("_");
                string _Identity = CmdIdentity;
                if (underIndex != -1)
                {
                    _Identity = CmdIdentity.Substring(underIndex + 1);
                }

                returnVal = "{\"" + _Identity + "\":\"" + dpd.CommandCode + "\"}";
            }
            Page.ClientScript.RegisterStartupScript(typeof(string), "TabJs", "<script language='javascript'>window.parent.CmdJson='" + returnVal + "';window.parent.hidePopWin(true);</script>");
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("AssembleCmd_SaveUpdate.aspx?DeviceModel=" + DeviceModel + "&CmdIdentity=" + CmdIdentity + "&BackUrl=AssembleCmdSelectList.aspx&DeviceID=" + DeviceID);
        }

        protected void ShowAll_CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            string sqlWhere="Where 1=1 ";
            if (ShowAll_CheckBox.Checked)
            {
                sqlWhere = string.Format(" Where DeviceModel = '{0}' And CommandIdentity = '{1}'", DeviceModel, CmdIdentity);
            }
            ViewState["SearchTerms"] = sqlWhere;
            BindDataList();
        }
    }
}
