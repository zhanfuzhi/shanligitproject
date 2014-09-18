using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace FrameWork.web.Manager.Module.ShanliTech_HLD
{
    public class PopPage:System.Web.UI.Page
    {
        private string _FrameName = FrameSystemInfo.GetSystemInfoTable.S_Name;

        public string FrameName
        {
            get { return _FrameName; }
            set { _FrameName = value; }
        }
        private string _FrameNameVer = FrameSystemInfo.GetSystemInfoTable.S_Version;

        public string FrameNameVer
        {
            get { return _FrameNameVer; }
            set { _FrameNameVer = value; }
        }
    }
}
