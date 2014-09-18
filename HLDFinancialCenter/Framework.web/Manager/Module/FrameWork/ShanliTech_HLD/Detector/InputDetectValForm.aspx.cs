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
    public partial class InputDetectValForm : PopPage
    {
        DetectManager _myDetectManager = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            //Button1.Attributes.Add("onClick", " window.returnValue = 'Detector.aspx';window.close();");
            if (Session["DetectManager"] != null)
            {
                _myDetectManager = (DetectManager)Session["DetectManager"];
            }
            if (_myDetectManager != null)
            {
                Label3.Text = _myDetectManager.StandardDevice.DeviceName + _myDetectManager.StandardDevice.DeviceModel;
                Label4.Text = _myDetectManager.DetectDevice.DeviceName + _myDetectManager.DetectDevice.DeviceModel;
                Label5.Text = _myDetectManager.CurrentDetectFunction.FunctionName + _myDetectManager.CurrentDetectFunction.FunctionCode;
                Label6.Text = _myDetectManager.CurrentDetectPoint.TestRange.ToString() + _myDetectManager.CurrentDetectPoint.Unit;
                Label7.Text = _myDetectManager.CurrentDetectPoint.StandardValue.ToString() + _myDetectManager.CurrentDetectPoint.Unit;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            double val = 0;
            try
            {
                val = Convert.ToDouble(TextBox1.Text.Trim());

            }
            catch 
            {
                //to alert 无效数值.
            }
          
            if (_myDetectManager != null)
            {
                _myDetectManager.DeviceDetectAdapter.ReadDate(val);
            }
            Page.ClientScript.RegisterStartupScript(this.GetType(), "input_form", "<script>window.returnValue = 'Detector.aspx';window.close();</script>");
            
        }
    }
}
