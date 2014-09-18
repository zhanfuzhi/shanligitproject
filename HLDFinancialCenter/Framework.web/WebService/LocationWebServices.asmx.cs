using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using Shanlitech_Location.Components;
using System.Collections.Generic;
using Shanlitech_Location;

namespace FrameWork.web.WebService
{
    /// <summary>
    /// LocationWebServices 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://location.shanlitech.com/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    public class LocationWebServices : System.Web.Services.WebService
    {
        /// <summary>
        /// 最近一次定位数据
        /// </summary>
        /// <returns>单次定位数据</returns>
        [WebMethod]
        public LocationDataEntity LastLocationData(string userID,string appID)
        {
            if (string.IsNullOrEmpty(userID) || string.IsNullOrEmpty(appID))
                return null;
            return BusinessFacadeShanlitech_Location.GetLastLocationData(userID, appID);
        }

        /// <summary>
        /// 指定时间段定位数据
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        public List<LocationDataEntity> SomeLocationDatas(string userID,string appID,DateTime start,DateTime end)
        {
            if (string.IsNullOrEmpty(userID) || string.IsNullOrEmpty(appID))
                return null;
            return BusinessFacadeShanlitech_Location.GetLocationDatas(userID, appID, start, end);
        }

        /// <summary>
        /// 所有定位数据
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        public List<LocationDataEntity> AllLocationDatas(string userID,string appID)
        {
            if (string.IsNullOrEmpty(userID) || string.IsNullOrEmpty(appID))
                return null;
            return BusinessFacadeShanlitech_Location.GetAllLocationDatas(userID,appID);
        }
       
    }
}
