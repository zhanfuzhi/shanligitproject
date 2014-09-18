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

namespace FrameWork.web.Manager.Module.ShanliTech_HLD.Detector
{
    public partial class ConfirmDetectEnd : PopPage
    {
        DetectManager _myDetectManager = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            Button1.Attributes.Add("onClick", " window.returnValue = 'Detector.aspx';window.close();");
            Button2.Attributes.Add("onClick", " window.returnValue = 'Detector.aspx';window.close();");
        }

        /// <summary>
        /// 继续检定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Session["DetectManager"] != null)
            {
                _myDetectManager = (DetectManager)Session["DetectManager"];
            }
            if (_myDetectManager != null)
            {
                _myDetectManager.Pause();
                _myDetectManager.DeviceDetectAdapter._StateAdapter.Reset();
                _myDetectManager.DeviceDetectAdapter._DetectState = _myDetectManager.DeviceDetectAdapter._StateAdapter.GetState();
            }
        }

        /// <summary>
        /// 结束检定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button2_Click(object sender, EventArgs e)
        {
            if (Session["DetectManager"] != null)
            {
                _myDetectManager = (DetectManager)Session["DetectManager"];
            }
            if (_myDetectManager != null)
            {
                _myDetectManager.DeviceDetectAdapter.UpdateDetectStatusOver();
                _myDetectManager.Stop();
            }

        }
    }
}
