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
using FrameWork.Components;
using System.Collections.Generic;
using ShanliTech_HLD_Business.CustomComponents;

namespace FrameWork.web.Manager.Module.ShanliTech_HLD.DeviceDetect
{
    public partial class Doc_Online_Check : System.Web.UI.Page
    {
        public string updatefilname, realname;
        public string forname, number;

        protected int DetectID = (Int32)Common.sink("DetectID", MethodType.Get, 10, 0, DataType.Int);
        protected int CheckerID = (Int32)Common.sink("CheckerID", MethodType.Get, 10, 0, DataType.Int);
        protected string ReportPath = (string)Common.sink("ReportPath", MethodType.Get, 200, 1, DataType.Str);
        protected int userid = 0,btnId;
        protected void Page_Load(object sender, EventArgs e)
        {
            userid = BusinessFacadeShanliTech_HLD_Business.DeviceDetectDisp(DetectID).VerifierID;
            //Button1.Attributes.Add("onclick", "javascript: SaveToWeb();");
            Button2.Attributes.Add("onclick", "javascript: SignValidate();");
            Button3.Attributes.Add("onclick", "javascript: SignValidate();");
            if (!Page.IsPostBack)
            {
               
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            this.Response.Write("<script language=javascript>alert('提交成功！');window.close();</script>");
        }
        /// <summary>
        /// 通过
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button2_Click(object sender, EventArgs e)
        {
            //int userid = BusinessFacadeShanliTech_HLD_Business.DeviceDetectDisp(DetectID).VerifierID;
            //this.Response.Write(string.Format("<script>javascript:showPopWin('核验通过并提交批准','SubmitReport.aspx?CMD=Check&DetectID={0}&UserID={1}&rand'+rand(100000000),700, 420, AlertMessageBox,true);</script>", DetectID, userid));
            btnId = 2;
        }
        /// <summary>
        /// 不通过
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button3_Click(object sender, EventArgs e)
        {
            btnId = 3;
            //int userid = BusinessFacadeShanliTech_HLD_Business.DeviceDetectDisp(DetectID).VerifierID;
            //this.Response.Write(string.Format("<script>javascript:showPopWin('核验不通过原因说明','NoPass.aspx?CMD=Check&DetectID={0}&UserID={1}&rand'+rand(100000000),700, 420, AlertMessageBox,true);</script>", DetectID, userid));
        }
    }
}
