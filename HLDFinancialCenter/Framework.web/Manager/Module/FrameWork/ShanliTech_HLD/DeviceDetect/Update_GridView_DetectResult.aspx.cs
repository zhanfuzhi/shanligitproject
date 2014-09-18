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
using ShanliTech_HLD_Business;
using ShanliTech_HLD_Business.Components;

namespace FrameWork.web.Manager.Module.ShanliTech_HLD.DeviceDetect
{
    public partial class Update_GridView_DetectResult : PopPage
    {
        Int32 IDX = (Int32)Common.sink("IDX", MethodType.Get, 10, 0, DataType.Int);
        string Result = (string)Common.sink("Result", MethodType.Get, 10, 1, DataType.Str);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if ("合格".Equals(Result))
                    Btn_Result_OK.Checked = true;
                else
                    Btn_Result_NO.Checked = true;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string _r = Result;
            if (Btn_Result_OK.Checked)
                _r = "合格";
            else
                _r = "不合格";

            DeviceDetectEntity dde = BusinessFacadeShanliTech_HLD_Business.DeviceDetectDisp(IDX);
            dde.DetectResult = _r;
            dde.DataTable_Action_ = DataTable_Action.Update;
            int rInt = BusinessFacadeShanliTech_HLD_Business.DeviceDetectInsertUpdateDelete(dde);
            string msg = string.Empty;
            if (rInt > 0)
                msg = "修改成功！";
            else
                msg = "修改失败！";
            Page.ClientScript.RegisterStartupScript(typeof(string), "TabJs", "<script language='javascript'>window.returnVal='" + msg + "';window.parent.hidePopWin(true);</script>");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Page.ClientScript.RegisterStartupScript(typeof(string), "TabJs", "<script language='javascript'>window.parent.hidePopWin(false);</script>");
        }
    }
}
