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
using ShanliTech.LogLib;

namespace FrameWork.web.Manager.Module.ShanliTech_HLD.Detector
{
    public partial class ReadDetect_InputForm : PopPage
    {
        DetectManager _myDetectManager = null;
        string UpOrDown = (string)Common.sink("UpOrDown", MethodType.Get, 10, 1, DataType.Str);
        string standard = (string)Common.sink("Standard", MethodType.Get, 10, 1, DataType.Str);
        protected void Page_Load(object sender, EventArgs e)
        {
            //Button1.Attributes.Add("onClick", " window.returnValue = 'Detector.aspx';window.close();");
            Standard_Disp.Text = standard;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Session["DetectManager"] != null)
            {
                _myDetectManager = (DetectManager)Session["DetectManager"];
            }
            if (_myDetectManager != null)
            {
                if ("up".Equals(UpOrDown.ToLower()))
                {
                    if (string.IsNullOrEmpty(Value_Input.Text))
                        _myDetectManager.CurrentDetectPoint.UpValue = 0.0f;
                    else
                        _myDetectManager.CurrentDetectPoint.UpValue = Convert.ToDouble(Value_Input.Text);

                    if (string.IsNullOrEmpty(Change_Input.Text))
                        _myDetectManager.CurrentDetectPoint.UpChange = 0.0f;
                    else
                        _myDetectManager.CurrentDetectPoint.UpChange = Convert.ToDouble(Change_Input.Text);
                }
                else if ("down".Equals(UpOrDown.ToLower()))
                {
                    if (string.IsNullOrEmpty(Value_Input.Text))
                        _myDetectManager.CurrentDetectPoint.DownValue = 0.0f;
                    else    
                        _myDetectManager.CurrentDetectPoint.DownValue = Convert.ToDouble(Value_Input.Text);
                    if (string.IsNullOrEmpty(Change_Input.Text))
                        _myDetectManager.CurrentDetectPoint.DownChange = 0.0f;
                    else
                        _myDetectManager.CurrentDetectPoint.DownChange = Convert.ToDouble(Change_Input.Text);
                }
                //
            }
            Page.ClientScript.RegisterStartupScript(this.GetType(), "input_form", "<script>window.returnValue = 'Detector.aspx';window.close();</script>");
            
        }
    }
}
