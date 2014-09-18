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
using ShanliTech_HLD_Business;
using ShanliTech_HLD_Business.Components;
using System.Collections.Generic;

namespace FrameWork.web.Manager.Module.ShanliTech_HLD.DeviceTemplate
{
    public partial class RangeSelectList : System.Web.UI.Page
    {
        Int32 FunctionID = (Int32)Common.sink("FunctionID", MethodType.Get, 10, 0, DataType.Int);

        DeviceFunctionEntity _Function = new DeviceFunctionEntity();
        DeviceEntity _Device = new DeviceEntity();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                _Function = BusinessFacadeShanliTech_HLD_Business.DeviceFunctionDisp(FunctionID);
                _Device = BusinessFacadeShanliTech_HLD_Business.DeviceDisp(_Function.DeviceID);

                BindDataList();
            }
        }
        private void BindDataList()
        {
            QueryParam qp = new QueryParam();
            qp.Where = string.Format("Where DeviceNum = '{0}' And DeviceModel = '{1}' And FunctionCode = '{2}'", _Device.DeviceNum, _Device.DeviceModel, _Function.FunctionCode);
            qp.OrderType = 1;
            int RecordCount = 0;
            List<Device_Permition_DataEntity> lst = BusinessFacadeShanliTech_HLD_Business.Device_Permition_DataList(qp, out RecordCount);
            GridView1.DataSource = lst;
            GridView1.DataBind();
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
                #region 多选框

                cell = new TableCell();
                cell.Width = Unit.Pixel(5);
                cell.Text = " ";
                e.Row.Cells.AddAt(0, cell);

                #endregion

                foreach (TableCell var in e.Row.Cells)
                {
                    if (var.Controls.Count > 0 && var.Controls[0] is LinkButton)
                    {
                        string Colume = ((LinkButton)var.Controls[0]).CommandArgument;
                        //if (Colume == Orderfld)
                        //{

                        //    LinkButton l = (LinkButton)var.Controls[0];
                        //    l.Text += string.Format("<img src='{0}' border='0'>", (OrderType == 0) ? Page.ResolveUrl("~/Manager/images/sort_asc.gif") : Page.ResolveUrl("~/Manager/images/sort_desc.gif"));
                        //}
                    }
                }

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
        #endregion

        protected void Button1_Click(object sender, EventArgs e)
        {
            string RadioValue = (string)Common.sink("RadioButton", MethodType.Post, 200, 0, DataType.Str);
            string returnVal = string.Empty;
            if (!string.IsNullOrEmpty(RadioValue))
            {
                int idx = 0;
                Int32.TryParse(RadioValue, out idx);
                Device_Permition_DataEntity dpd = BusinessFacadeShanliTech_HLD_Business.Device_Permition_DataDisp(idx);
                returnVal = dpd.RangeEndOriginal.ToString() + "|" + dpd.RangeUnitOriginal + "|" + dpd.RangeCode;
            }
            Page.ClientScript.RegisterStartupScript(typeof(string), "TabJs", "<script language='javascript'>window.parent.RangeValueAndUnit='" + returnVal + "';window.parent.hidePopWin(true);</script>");
        }
    }
}
