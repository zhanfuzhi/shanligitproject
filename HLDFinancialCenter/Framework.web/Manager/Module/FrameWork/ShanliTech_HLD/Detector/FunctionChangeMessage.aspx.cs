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
    public partial class FunctionChangeMessage : PopPage
    {
        Int32 FID = (Int32)Common.sink("FID", MethodType.Get, 10, 0, DataType.Int);
        protected void Page_Load(object sender, EventArgs e)
        {

            DeviceFunctionEntity tmpfun = null;

            Button1.Attributes.Add("onClick", " window.returnValue = 'Detector.aspx';window.close();");

            if (FID > 0) 
            {

                tmpfun = BusinessFacadeShanliTech_HLD_Business.DeviceFunctionDisp(FID);
                if (tmpfun == null) 
                {
                    Label1.Visible = false;
                    //Label1.Text = "无效功能代码，请与系统管理员联系！";
                }
                else
                {
                    Label2.Visible = false;
                    Func_Disp.Text = "["+tmpfun.FunctionName+"]";
                }
            }
        }
    }
}
