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
    public partial class SessionTest : PopPage
    {
        ManagerTest mt = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["TEST"] == null)
            {
                mt = new ManagerTest();
            }
            else 
            {
                mt = (ManagerTest)Session["TEST"];
            }
            
        }

       

        protected void Button1_Click(object sender, EventArgs e)
        {
            mt.count = mt.count + 1;
            Session["TEST"] = mt;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "alert1", string.Format("<script>alert('mt count: {0} | value: {1}');</script>",mt.count,mt.value));
        }
    }

    [Serializable]
    public class ManagerTest
    {
        public int count = 0;
        public string value = string.Empty;
    }
}
