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
using System.Data.SqlClient;
using System.IO;
namespace FrameWork.web.Manager.Module.ShanliTech_HLD
{
    public partial class Document_online_save : System.Web.UI.Page
    {
        readonly int enterCount = 12;
        string[] requestValues = new string[2];
        protected void Page_Load(object sender, EventArgs e)
        {

            //******************************************************************************************\\
            //code by qiupeng , you can copy code, but the author to retain information please;(2006-11-5)\\
            //**********************************************************************************************\\


            string newFile = Server.MapPath("~/") + "\\CertifyDocs\\" + Request.QueryString["file"] + "";
            FileStream newDoc = new FileStream(newFile, FileMode.Create, FileAccess.Write);
            BinaryReader br = new BinaryReader(Request.InputStream);
            BinaryWriter bw = new BinaryWriter(newDoc);
            br.BaseStream.Seek(0, SeekOrigin.Begin);
            bw.BaseStream.Seek(0, SeekOrigin.End);
            int enterNo = 0;
            int streamHeadLen = 0;

            while (br.BaseStream.Position < br.BaseStream.Length)
            {
                streamHeadLen++;
                char c = (char)br.ReadByte();
                if (enterNo < enterCount)
                {
                    if (c == '\n')
                    {
                        enterNo++;
                    }
                }
                else
                {
                    break;
                }
            }

            br.BaseStream.Seek(0, SeekOrigin.Begin);
            string strTemp = System.Text.UTF8Encoding.Default.GetString(br.ReadBytes(streamHeadLen - 1));
            while (br.BaseStream.Position < br.BaseStream.Length - 38)
            {
                bw.Write(br.ReadByte());
            }
            br.Close();
            bw.Flush();
            bw.Close();

            string[] requestStrings = { "RecordID", "UserID" };
            for (int i = 0; i < requestStrings.Length; i++)
            {
                string str = "Content-Disposition: form-data; name=\"" + requestStrings[i] + "\"\r\n\r\n";
                int index = strTemp.IndexOf(str) + str.Length;
                if (index != str.Length - 1)
                {
                    for (int j = index; j < strTemp.Length; j++)
                    {
                        if (strTemp[j] != '\r')
                            this.requestValues[i] += strTemp[j];
                        else
                            break;
                    }
                }
            }
        }
    }
}
