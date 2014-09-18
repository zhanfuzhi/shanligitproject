using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using FrameWork.Components;
using System.Collections.Generic;
namespace FrameWork.web
{
    public partial class right : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                sys_FrameWorkInfoTable si = FrameSystemInfo.GetSystemInfoTable.S_FrameWorkInfo;                
                SystemName.Text = string.Format("{0} {1}", FrameSystemInfo.GetSystemInfoTable.S_Name, FrameSystemInfo.GetSystemInfoTable.S_Version);
            }
        }

    }
}
