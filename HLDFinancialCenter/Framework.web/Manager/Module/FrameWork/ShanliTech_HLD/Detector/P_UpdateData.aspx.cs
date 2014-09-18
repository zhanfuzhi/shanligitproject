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
using ShanliTech_HLD_Business.Components;
using ShanliTech_HLD_Business;

namespace FrameWork.web.Manager.Module.ShanliTech_HLD.Detector
{
    public partial class P_UpdateData :PopPage
    {
        DetectManager _myDetectManager = null;
        Int32 IDX = (Int32)Common.sink("IDX", MethodType.Get, 10, 0, DataType.Int);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                P_DetectResultEntity pre=BusinessFacadeShanliTech_HLD_Business.P_DetectResultDisp(IDX);
                Standard_Disp.Text = pre.StandardValue.ToString() + pre.Unit;
                UpValue_Input.Text = pre.UpValue.ToString();
                DownValue_Input.Text = pre.DownValue.ToString();
                UpChange_Input.Text = pre.UpChange.ToString();
                DownChange_Input.Text = pre.DownChange.ToString();
            }
        }

        protected void Btn_Submit_Click(object sender, EventArgs e)
        {
            if (IDX == 0)
            {
                Page.ClientScript.RegisterStartupScript(typeof(string), "PopWin", "<script language='javascript'>window.returnVal='参数错误，可能由于数据还未被持久化。';window.parent.hidePopWin(false);</script>");
                return;
            }
            P_DetectResultEntity pre = BusinessFacadeShanliTech_HLD_Business.P_DetectResultDisp(IDX);
            DetectResultDataItem preSession = null;
            if (_myDetectManager == null)
            {
                _myDetectManager = (DetectManager)Session["DetectManager"];
                preSession = _myDetectManager.DeviceDetectAdapter.DetectDetectDateItemList.Find(x => { return x.ID == IDX; });
            }

            
            double upValue = (string.IsNullOrEmpty(UpValue_Input.Text) ? 0f : Convert.ToDouble(UpValue_Input.Text));
            double downValue = (string.IsNullOrEmpty(DownValue_Input.Text) ? 0f : Convert.ToDouble(DownValue_Input.Text));
            double upChange = (string.IsNullOrEmpty(UpChange_Input.Text) ? 0f : Convert.ToDouble(UpChange_Input.Text));
            double downChange = (string.IsNullOrEmpty(DownChange_Input.Text) ? 0f : Convert.ToDouble(DownChange_Input.Text));

            if (upValue >= 0 && upValue != pre.UpValue)
                preSession.UpValue = pre.UpValue = upValue;
            if (downValue >= 0 && downValue != pre.DownValue)
                preSession.DownValue = pre.DownValue = downValue;
            if (upChange >= 0 && upChange != pre.UpChange)
                preSession.UpChange = pre.UpChange = upChange;
            if (downChange >= 0 && downChange != pre.DownChange)
                preSession.DownChange = pre.DownChange = downChange;

            SetDetectResult(pre, preSession);
            pre.DataTable_Action_ = DataTable_Action.Update;
            int rInt = BusinessFacadeShanliTech_HLD_Business.P_DetectResultInsertUpdateDelete(pre);
            string msg = string.Empty;
            if (rInt > 0)
                msg = "修改成功！";
            else
                msg = "修改失败！";
            Page.ClientScript.RegisterStartupScript(typeof(string), "PopWin", string.Format("<script language='javascript'>window.returnVal='{0}';window.parent.hidePopWin(true);</script>",msg));
        }
        private void SetDetectResult(P_DetectResultEntity p, DetectResultDataItem preSession)
        {
            if (Math.Abs(p.StandardValue - p.UpValue) < p.ValuePerMissibleError && Math.Abs(p.StandardValue - p.DownValue) < p.ValuePerMissibleError)
                p.ValueResult = "合格";
            else
                p.ValueResult = "不合格";

            if (p.UpChange < p.ChangePerMissibleError && p.DownChange < p.ChangePerMissibleError)
                p.ChangeResult = "合格";
            else
                p.ChangeResult = "不合格";

            p.HysteresisErrorValue = Math.Round((p.DownValue - p.UpValue), 5);
            if (p.HysteresisErrorValue < p.H_PerMissibleError)
                p.H_Result = "合格";
            else
                p.H_Result = "不合格";

            preSession.ValueResult = p.ValueResult;
            preSession.ChangeResult = p.ChangeResult;
            preSession.HysteresisErrorValue = p.HysteresisErrorValue;
            preSession.H_Result = p.H_Result;
        }
    }
}
