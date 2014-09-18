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
    public partial class RangeChangeMessage : PopPage
    {
        //Int32 FID = (Int32)Common.sink("FID", MethodType.Get, 10, 0, DataType.Int);
        protected void Page_Load(object sender, EventArgs e)
        {

            Button1.Attributes.Add("onClick", " window.returnValue = 'Detector.aspx';window.close();");


            DetectManager _myDetectManager = null;
            if (Session["DetectManager"] != null)
            {
                _myDetectManager = (DetectManager)Session["DetectManager"];
            }
            if (_myDetectManager != null)
            {
                //DetectResultDataItem nextDetectResultDateItem = _myDetectManager.DeviceDetectAdapter.GetNextDetectResultDataItem();
                if (_myDetectManager.CurrentDetectPoint != null)
                {
                    Func_Disp.Text = "接下来将对设备的" + _myDetectManager.CurrentDetectPoint.TestRange.ToString() + _myDetectManager.CurrentDetectPoint.Unit + "量程进行检定";
                }
                else 
                {
                    Func_Disp.Text = "无效量程信息，请检查检定点的量程设置！";
                }
            }
        }
    }
}
