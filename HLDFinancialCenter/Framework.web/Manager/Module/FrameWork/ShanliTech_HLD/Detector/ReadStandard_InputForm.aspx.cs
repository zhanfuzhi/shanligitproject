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
    public partial class ReadStandard_InputForm :PopPage
    {
        DetectManager _myDetectManager = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            //Button1.Attributes.Add("onClick", " window.returnValue = 'Detector.aspx';window.close();");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Session["DetectManager"] != null)
            {
                _myDetectManager = (DetectManager)Session["DetectManager"];
            }
            if (_myDetectManager != null)
            {
                //_myDetectManager.DeviceDetectResult.EnvironmentNote = TextBox3.Text;
                //if (string.IsNullOrEmpty(TextBox2.Text))
                //{
                //    _myDetectManager.DeviceDetectResult.Humidity = 0;
                //}
                //else
                //{
                //    _myDetectManager.DeviceDetectResult.Humidity = Convert.ToDouble(TextBox2.Text);
                //}
                //_myDetectManager.DeviceDetectResult.HumidityUnit = "RH";
                //if (string.IsNullOrEmpty(TextBox1.Text))
                //{ _myDetectManager.DeviceDetectResult.Temperature = 0; }
                //else
                //{
                //    _myDetectManager.DeviceDetectResult.Temperature = Convert.ToDouble(TextBox1.Text);
                //}
                //_myDetectManager.DeviceDetectResult.TemperatureUnit = "°C";
                //_myDetectManager.DeviceDetectResult.DetectLocation = DropDownList1.SelectedItem.Text;
                //_myDetectManager.DeviceDetectResult.DetectNote = TextBox4.Text;
            }
            Page.ClientScript.RegisterStartupScript(this.GetType(), "input_form", "<script>window.returnValue = 'Detector.aspx';window.close();</script>");
            
        }
    }
}
