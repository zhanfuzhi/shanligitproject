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
    public partial class Waitting : System.Web.UI.Page
    {
        protected string Title = (string)Common.sink("Title", MethodType.Get, 10, 0, DataType.Str);
        protected int Interval =(int)Common.sink("Interval", MethodType.Get, 10, 0, DataType.Int);
        protected void Page_Load(object sender, EventArgs e)
        {
            Title = System.Web.HttpUtility.UrlDecode(Title);
        }
    }
}
