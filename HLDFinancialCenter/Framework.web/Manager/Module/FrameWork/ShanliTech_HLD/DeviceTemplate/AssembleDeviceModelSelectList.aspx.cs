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
    public partial class AssembleDeviceModelSelectList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindDataList();
        }
        private void BindDataList()
        {
            QueryParam qp = new QueryParam();
            int RecordCount = 0;
            List<CommandAssembleEntity> lst = BusinessFacadeShanliTech_HLD_Business.CommandAssembleList(qp, out RecordCount);
            List<CommandAssembleEntity> distList = new List<CommandAssembleEntity>();
            if (RecordCount > 0)
            {
                CommandAssembleEntity cae = null;
                foreach (CommandAssembleEntity item in lst)
                {
                    cae = distList.Find(x => { return item.DeviceModel.Equals(x.DeviceModel); });
                    if (cae == null || cae.ID <= 0)
                    {
                        distList.Add(item);
                    }
                    else
                    {
                        continue;
                    }
                }
            }
            GridView1.DataSource = distList;
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
                string _DeviceModel = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DeviceModel"));
                cell = new TableCell();
                cell.Width = Unit.Pixel(5);
                cell.Text = string.Format(" <input name='RadioButton' id='RadioButton' value='{0}' type='radio' />", _DeviceModel);
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
                QueryParam qp = new QueryParam();
                qp.Where = string.Format("Where DeviceModel = '{0}'",RadioValue);
                int _Count = 0;
                List<CommandAssembleEntity> lst = BusinessFacadeShanliTech_HLD_Business.CommandAssembleList(qp,out _Count);
                if (_Count > 0)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append("{");
                    sb.AppendFormat("\"DeviceModel\":\"{0}\"",RadioValue);
                    foreach (CommandAssembleEntity item in lst)
                    {
                        if ("CmdReset".ToUpper().Equals(item.CommandIdentity.ToUpper()))
                        {
                            sb.AppendFormat(",\"CmdReset\":\"{0}\"", item.CommandCode);
                        }
                        else if ("CmdZero".ToUpper().Equals(item.CommandIdentity.ToUpper()))
                        {
                            sb.AppendFormat(",\"CmdZero\":\"{0}\"", item.CommandCode);
                        }
                        else if ("CmdRead".ToUpper().Equals(item.CommandIdentity.ToUpper()))
                        {
                            sb.AppendFormat(",\"CmdRead\":\"{0}\"", item.CommandCode);
                        }
                        else if ("CmdSTBY".ToUpper().Equals(item.CommandIdentity.ToUpper()))
                        {
                            sb.AppendFormat(",\"CmdSTBY\":\"{0}\"", item.CommandCode);
                        }
                        else if ("SetCmdPerfix".ToUpper().Equals(item.CommandIdentity.ToUpper()))
                        {
                            sb.AppendFormat(",\"SetCmdPerfix\":\"{0}\"", item.CommandCode);
                        }
                        else if ("SetCmdSuffix".ToUpper().Equals(item.CommandIdentity.ToUpper()))
                        {
                            sb.AppendFormat(",\"SetCmdSuffix\":\"{0}\"", item.CommandCode);
                        }
                    }
                    sb.Append("}");
                    returnVal = sb.ToString();
                }
            }
            Page.ClientScript.RegisterStartupScript(typeof(string), "TabJs", "<script language='javascript'>window.parent.CmdJson='" + returnVal + "';window.parent.hidePopWin(true);</script>");
        }
    }
}
