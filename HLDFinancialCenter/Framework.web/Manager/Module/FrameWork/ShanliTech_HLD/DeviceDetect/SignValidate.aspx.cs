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

namespace FrameWork.web.Manager.Module.ShanliTech_HLD.DeviceDetect
{
    public partial class SignValidate : System.Web.UI.Page
    {
        public string SignPicture = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            SignPicture = UserData.GetUserDate.SignPicture;
            if(!string.IsNullOrEmpty(SignPicture))
                SignPicture_Image.ImageUrl = Common.BuildDownFileUrl("SignPictures/" + SignPicture);
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string pwd=Password.Text;
            if (string.IsNullOrEmpty(pwd))
            {
                this.Response.Write("<script>alert('请输入密码！');</script>");
                return;
            }
            string hashPassword = Common.md5(pwd,32);
            if (UserData.GetUserDate.SignPassword.Equals(hashPassword))
            {
                this.Response.Write("<script language=javascript>window.opener.OpenSealToWeb('" + UserData.GetUserDate.SignPicture + "');window.close();</script>");
            }
            else
            {
                this.Response.Write("<script>alert('签名密码输入错误！');</script>");
            }
        }
    }
}
