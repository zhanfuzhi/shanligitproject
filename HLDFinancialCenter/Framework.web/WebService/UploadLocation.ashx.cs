using System;
using System.Collections;
using System.Data;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using ShanliTech.LogLib;
using Google.ProtocolBuffers.DescriptorProtos;
using System.IO;
using Shanlitech_Location;
using FrameWork.Components;
using System.Text;
using Protobuf.Components;

namespace FrameWork.web.WebService
{
    /// <summary>
    /// $codebehindclassname$ 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class UploadLocation :  IHttpHandler,IHttpAsyncHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            
        }

        /// <summary>
        /// 表明其它的请求是否可以使用这个类的一个实例。
        /// </summary>
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        #region IHttpAsyncHandler 成员

        public IAsyncResult BeginProcessRequest(HttpContext context, AsyncCallback cb, object extraData)
        {
            //AppLogger.Instance.Log.Info("BeginProcessRequest 响应HTTP请求，开始处理 ----");
            //try
            //{
            //    //Location loc = Protobuf.Protobuf_Codec.ParseForm(context.Request.InputStream);
            //    //UploadLocationManager.Instance.AddUploadLocationInsert(loc);
            //}
            //catch (Exception e)
            //{
            //    AppLogger.Instance.Log.Error("error: " + e.StackTrace);
            //}
            //return null;

            UploadLocationManager.Instance.BeginInsertLocationData(context, cb);
            return null;
            
        }

        public void EndProcessRequest(IAsyncResult result)
        {
            AppLogger.Instance.Log.Info("EndProcessRequest 响应HTTP请求，处理结束 ----");
        }

        #endregion
    }
}
