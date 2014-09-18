using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using log4net.Config;
using log4net; 
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ShanliTech.LogLib
{

    public class AppLogger
    {
        private static readonly ILog _log = LogManager.GetLogger("Test");
        private static AppLogger _logger = null;

        /// <summary>
        /// the contruct of Logger
        /// </summary>
        private AppLogger(AppLoggerType type)
        {

            //load the configeration file ,and init the Component of log4net
            FileInfo _configFile = new FileInfo(new ConfigFileCreate().GetConfigFile());

            XmlConfigurator.ConfigureAndWatch(_configFile);


        }

        public ILog Log { get { return _log; } }

        /// <summary>
        /// Logger 's  Only  Instance
        /// </summary>
        public static AppLogger Instance
        {
            get
            {
                if (_logger == null)
                    _logger = new AppLogger(AppLoggerType.Error|AppLoggerType.Info);
                return _logger;
            }
        }
    }

    [Serializable]
    [ComVisible(true)]
    [Flags]
    public enum AppLoggerType
    {
        Error,
        Debug,
        Warn,
        Falat,
        Info

    }
}
