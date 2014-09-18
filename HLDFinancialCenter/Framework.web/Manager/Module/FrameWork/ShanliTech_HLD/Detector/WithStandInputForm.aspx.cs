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
    public partial class WithStandInputForm : PopPage
    {
        protected string Title = (string)Common.sink("Title", MethodType.Get, 10, 0, DataType.Str);
        protected int Interval = (int)Common.sink("Interval", MethodType.Get, 10, 0, DataType.Int);
        DetectManager _myDetectManager = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            Title = System.Web.HttpUtility.UrlDecode(Title);
            Button1.Attributes.Add("onClick", " window.returnValue = 'Detector.aspx';window.close();");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Session["DetectManager"] != null)
            {
                _myDetectManager = (DetectManager)Session["DetectManager"];
            }
            if (_myDetectManager != null)
            {
                int _flagInt=0;
                string _flagTxt="不合格";
                if (RadioButton1.Checked == true)
                {
                    _flagInt = 1;// "合格";
                    _flagTxt="合格";
                }
                else
                {
                    _flagInt = 0;// "不合格"; 
                    _flagTxt="不合格";
                }
                _myDetectManager.DeviceDetectResult.WithstandCheck = _flagTxt;
                _myDetectManager.DeviceDetectResult.WithstandCheckFlag = _flagInt;
                
                try
                {
                    _myDetectManager.DeviceDetectAdapter.SaveDeviceDetectResult();
                }
                catch
                {
                    ClientScript.RegisterStartupScript(ClientScript.GetType(), "Error", "<script>保存耐压3分钟检查结果时发生了异常！</script>");
                }
            }

        }
    }
}
