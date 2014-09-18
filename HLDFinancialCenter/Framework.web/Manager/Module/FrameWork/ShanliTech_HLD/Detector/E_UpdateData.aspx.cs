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
    public partial class E_UpdateData : PopPage
    {
        DetectManager _myDetectManager = null;
        Int32 IDX = (Int32)Common.sink("IDX", MethodType.Get, 10, 0, DataType.Int);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                E_DetectResultEntity ere = BusinessFacadeShanliTech_HLD_Business.E_DetectResultDisp(IDX);
                string unit = ere.Unit;
                Standard_Disp.Text = ere.StandardValue.ToString() + unit;
                ValueStandard_Disp.Text = ere.TestStandardValue.ToString() + unit;
                PreValue_Disp.Text = ere.TestedValue.ToString() + unit;
            }
        }

        protected void Btn_Submit_Click(object sender, EventArgs e)
        {
            if (IDX == 0)
            {
                Page.ClientScript.RegisterStartupScript(typeof(string), "PopWin", "<script language='javascript'>window.returnVal='参数错误，可能由于数据还未被持久化。';window.parent.hidePopWin(false);</script>");
                return;
            }
            E_DetectResultEntity ere = BusinessFacadeShanliTech_HLD_Business.E_DetectResultDisp(IDX);
            DetectResultDataItem preSession = null;
            if (_myDetectManager == null)
            {
                _myDetectManager = (DetectManager)Session["DetectManager"];
                preSession = _myDetectManager.DeviceDetectAdapter.DetectDetectDateItemList.Find(x => { return x.ID == IDX; });
            }

            string newStr = NewValue_Input.Text;
            if (!string.IsNullOrEmpty(newStr))
            {
                preSession.TestedValue = ere.TestedValue = Convert.ToDouble(newStr);
                SetDetectResult(ere,preSession);
            }
            ere.DataTable_Action_ = DataTable_Action.Update;
            int rInt = BusinessFacadeShanliTech_HLD_Business.E_DetectResultInsertUpdateDelete(ere);
            string msg = string.Empty;
            if (rInt > 0)
                msg = "修改成功！";
            else
                msg = "修改失败！";
            Page.ClientScript.RegisterStartupScript(typeof(string), "PopWin", string.Format("<script language='javascript'>window.returnVal='{0}';window.parent.hidePopWin(true);</script>", msg));
        
        }

        //计算检定结果是否合格
        private void SetDetectResult(E_DetectResultEntity ere, DetectResultDataItem preSession)
        {
            ere.TestedPerissibleError = Math.Round((ere.TestedValue - ere.TestStandardValue), 5);
            if (Math.Abs(ere.TestedPerissibleError) <= Math.Abs(ere.MaxPerMissibleError))
            {
                ere.Result = "合格";
            }
            else
            {
                ere.Result = "不合格";
            }

            preSession.TestedPerissibleError = ere.TestedPerissibleError;
            preSession.ValueResult = ere.Result;
        }

    }
}
