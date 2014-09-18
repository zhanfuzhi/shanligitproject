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
    public partial class ReadDataHandle :PopPage
    {
        string CMD = (string)Common.sink("CMD", MethodType.Get, 10, 0, DataType.Str);
        string VAL = (string)Common.sink("VAL", MethodType.Get, 300, 0, DataType.Str);
        DetectManager _myDetectManager = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if ("VAL".Equals(CMD) && !string.IsNullOrEmpty(VAL))
                {
                    try
                    {
                        if (Session["DetectManager"] != null)
                        {
                            _myDetectManager = (DetectManager)Session["DetectManager"];
                        }
                        //todo 处理解析返回值并更新检定结果数据，将下一个检定点更新为当前检定点。
                        if (_myDetectManager != null)
                        {
                            _myDetectManager.DeviceDetectAdapter.ReadData(VAL);
                        }
                    }
                    catch (Exception ex)
                    {
                        AppLogger.Instance.Log.Info("ReadDataHandle 读取数据出现异常", ex);
                    }
                    //Page.ClientScript.RegisterStartupScript(this.GetType(), "readdata", "<script>window.location.href=\"Detector.aspx\";window.close();</script>");
                    
                }
            }
            Response.Redirect("Detector.aspx");
        }
    }
}
