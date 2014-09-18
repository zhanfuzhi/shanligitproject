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

namespace FrameWork.web.Manager.Module.ShanliTech_HLD.Detector
{
    public partial class P_StandardOutput : PopPage
    {
        string StandardValueAndUnit=(string)(Common.sink("StandardValueAndUnit",MethodType.Get,20,0,DataType.Str));
        protected void Page_Load(object sender, EventArgs e)
        {
            Button1.Attributes.Add("onClick", " window.returnValue = 'Detector.aspx';window.close();");
            Label2.Text = StandardValueAndUnit;
        }
    }
}
