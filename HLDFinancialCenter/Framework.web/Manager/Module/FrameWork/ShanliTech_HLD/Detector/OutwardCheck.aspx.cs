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
    public partial class OutwardCheck : PopPage
    {
        DetectManager _myDetectManager = null;
        string DeviceType = (string)Common.sink("DeviceType", MethodType.Get, 10, 0, DataType.Str);
        protected void Page_Load(object sender, EventArgs e)
        {
            //Button1.Attributes.Add("onClick", " window.returnValue = 'Detector.aspx';window.close();");

            if (string.IsNullOrEmpty(DeviceType) || !"Device_P".Equals(DeviceType))
                Zero_TR.Visible = false;

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int _flag = 0;
            bool _Pass = true;
            if (Session["DetectManager"] != null)
            {
                _myDetectManager = (DetectManager)Session["DetectManager"];
            }
            if (_myDetectManager != null)
            {
                if (RadioButton1.Checked == true) 
                {
                    _flag =1;// "合格";
                } 
                else 
                {
                    _flag =0;// "不合格"; 
                    _Pass = false;
                }
                _myDetectManager.DeviceDetectResult.OutwardCheckFlag =_flag;
                _myDetectManager.DeviceDetectResult.OutwardCheckNote = TextBox4.Text;

                //零位检测
                if (!string.IsNullOrEmpty(DeviceType) && "Device_P".Equals(DeviceType))
                {
                    if (Radio_Zero_OK.Checked == true)
                    {
                        _myDetectManager.DeviceDetectResult.ZeroPointCheck = "合格";
                        _myDetectManager.DeviceDetectResult.ZeroPointCheckFalg = 1;
                    }
                    else
                    {
                        _myDetectManager.DeviceDetectResult.ZeroPointCheck = "不合格";
                        _myDetectManager.DeviceDetectResult.ZeroPointCheckFalg = 0;
                        _Pass = false;
                    }
                }

                try
                {
                    if (!_Pass)
                        _myDetectManager.DeviceDetectAdapter.FreezeState();
                    _myDetectManager.DeviceDetectAdapter.SaveDeviceDetectResult();
                }
                catch
                {
                    ClientScript.RegisterStartupScript(ClientScript.GetType(), "Error", "<script>保存外观检查结果时发生了异常！</script>");
                }
            }
            Page.ClientScript.RegisterStartupScript(this.GetType(), "input_form", "<script>window.returnValue = 'Detector.aspx';window.close();</script>");
            
        }
    }
}
