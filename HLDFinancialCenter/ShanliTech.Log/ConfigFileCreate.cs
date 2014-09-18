using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace ShanliTech.LogLib
{
    internal class ConfigFileCreate
    {

        public const string Log4Config = "log.xml";

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        internal string GetConfigFile()
        {
            string _AssemblyCatalogue = GetAssemblyCatalogue();
            FileInfo _fileinfo = new FileInfo(_AssemblyCatalogue + @"/" + Log4Config);
            //find  where the file is contained
            if (!_fileinfo.Exists)
            {
                CreateXMLConfig(_fileinfo);
            }
            return _fileinfo.FullName;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private string GetAssemblyCatalogue()
        {
            return AppDomain.CurrentDomain.BaseDirectory;
        }


        private void CreateXMLConfig(FileInfo fileInfo)
        {
            using (StreamWriter sw = File.CreateText(fileInfo.FullName))
            {
                sw.WriteLine("<?xml version=\"1.0\" encoding=\"utf-8\" ?>");
                sw.WriteLine("<configuration>");
                sw.WriteLine("<log4net>");
                sw.WriteLine("<appender name=\"InfoLog\" type=\"log4net.Appender.RollingFileAppender,log4net\">");
                sw.WriteLine("<param name=\"File\" value=\"log\\\"/>");
                sw.WriteLine("<param name=\"AppendToFile\" value=\"true\"/>");
                sw.WriteLine("<param name=\"MaxSizeRollBackups\" value=\"10\"/>");
                sw.WriteLine("<param name=\"MaximumFileSize\" value=\"10240KB\"/>");
                sw.WriteLine("<param name=\"RollingStyle\" value=\"Date\"/>");
                sw.WriteLine("<param name=\"StaticLogFileName\" value=\"false\"/>");
                sw.WriteLine("<param name=\"DatePattern\" value=\"yyyy-MM/dd_&quot;info.log&quot;\"  />");
                sw.WriteLine("<param name=\"Threshold\" value=\"INFO\"/>");
                sw.WriteLine("<layout type=\"log4net.Layout.PatternLayout,log4net\">");
                sw.WriteLine("<param name=\"ConversionPattern\" value=\"记录时间：%date  %n 消息：%message%newline%n%n\" />");
                sw.WriteLine("</layout>");
                sw.WriteLine("<filter type=\"log4net.Filter.LevelRangeFilter\">");
                sw.WriteLine("<levelMin value=\"INFO\"/>");
                sw.WriteLine("<levelMax value=\"INFO\"/>");
                sw.WriteLine("</filter>");
                sw.WriteLine("<filter class=\"log4net.Filter.DenyAllFilter\"/>");
                sw.WriteLine("</appender>");
                sw.WriteLine("<appender name=\"ErrorLog\" type=\"log4net.Appender.RollingFileAppender,log4net\">");
                sw.WriteLine("<param name=\"File\" value=\"log\\\"/>");
                sw.WriteLine("<param name=\"AppendToFile\" value=\"true\"/>");
                sw.WriteLine("<param name=\"MaxSizeRollBackups\" value=\"10\"/>");
                sw.WriteLine("<param name=\"MaximumFileSize\" value=\"10240KB\"/>");
                sw.WriteLine("<param name=\"RollingStyle\" value=\"Date\"/>");
                sw.WriteLine("<param name=\"StaticLogFileName\" value=\"false\"/>");
                sw.WriteLine("<param name=\"DatePattern\" value=\"yyyy-MM/dd_&quot;error.log&quot;\"  />");
                sw.WriteLine("<param name=\"Threshold\" value=\"ERROR\"/>");
                sw.WriteLine("<layout type=\"log4net.Layout.PatternLayout,log4net\">");
                sw.WriteLine("<param name=\"ConversionPattern\" value=\"记录时间：%date  日志级别：%-5level %n     记录位置：%location%n   异常：%exception%n 消息：%message%newline%n%n\" />");
                sw.WriteLine("</layout>");
                sw.WriteLine("<filter type=\"log4net.Filter.LevelRangeFilter\">");
                sw.WriteLine("<levelMin value=\"ERROR\"/>");
                sw.WriteLine("<levelMax value=\"ERROR\"/>");
                sw.WriteLine("</filter>");
                sw.WriteLine("</appender>");
                //sw.WriteLine("<appender name=\"WarnLog\" type=\"log4net.Appender.RollingFileAppender,log4net\">");
                //sw.WriteLine("<param name=\"File\" value=\"log\\\"/>");
                //sw.WriteLine("<param name=\"AppendToFile\" value=\"true\"/>");
                //sw.WriteLine("<param name=\"MaxSizeRollBackups\" value=\"10\"/>");
                //sw.WriteLine("<param name=\"MaximumFileSize\" value=\"10240KB\"/>");
                //sw.WriteLine("<param name=\"RollingStyle\" value=\"Date\"/>");
                //sw.WriteLine("<param name=\"StaticLogFileName\" value=\"false\"/>");
                //sw.WriteLine("<param name=\"DatePattern\" value=\"yyyy-MM/dd_&quot;warn.log&quot;\"  />");
                //sw.WriteLine("<param name=\"Threshold\" value=\"WARN\"/>");
                //sw.WriteLine("<layout type=\"log4net.Layout.PatternLayout,log4net\">");
                //sw.WriteLine("<param name=\"ConversionPattern\" value=\"记录时间：%date  日志级别：%-5level %n     记录位置：%location%n   异常：%exception%n 消息：%message%newline%n%n\" />");
                //sw.WriteLine("</layout>");
                //sw.WriteLine("<filter type=\"log4net.Filter.LevelRangeFilter\">");
                //sw.WriteLine("<levelMin value=\"WARN\"/>");
                //sw.WriteLine("<levelMax value=\"WARN\"/>");
                //sw.WriteLine("</filter>");
                //sw.WriteLine("</appender>");
                //sw.WriteLine("<appender name=\"FatalLog\" type=\"log4net.Appender.RollingFileAppender,log4net\">");
                //sw.WriteLine("<param name=\"File\" value=\"log\\\"/>");
                //sw.WriteLine("<param name=\"AppendToFile\" value=\"true\"/>");
                //sw.WriteLine("<param name=\"MaxSizeRollBackups\" value=\"10\"/>");
                //sw.WriteLine("<param name=\"MaximumFileSize\" value=\"10240KB\"/>");
                //sw.WriteLine("<param name=\"RollingStyle\" value=\"Date\"/>");
                //sw.WriteLine("<param name=\"StaticLogFileName\" value=\"false\"/>");
                //sw.WriteLine("<param name=\"DatePattern\" value=\"yyyy-MM/dd_&quot;fatal.log&quot;\"  />");
                //sw.WriteLine("<param name=\"Threshold\" value=\"FATAL\"/>");
                //sw.WriteLine("<layout type=\"log4net.Layout.PatternLayout,log4net\">");
                //sw.WriteLine("<param name=\"ConversionPattern\" value=\"记录时间：%date  日志级别：%-5level %n     记录位置：%location%n   异常：%exception%n 消息：%message%newline%n%n\" />");
                //sw.WriteLine("</layout>");
                //sw.WriteLine("<filter type=\"log4net.Filter.LevelRangeFilter\">");
                //sw.WriteLine("<levelMin value=\"FATAL\"/>");
                //sw.WriteLine("<levelMax value=\"FATAL\"/>");
                //sw.WriteLine("</filter>");
                //sw.WriteLine("</appender>");
                //sw.WriteLine("<appender name=\"DebugLog\" type=\"log4net.Appender.RollingFileAppender,log4net\">");
                //sw.WriteLine("<param name=\"File\" value=\"log\\\"/>");
                //sw.WriteLine("<param name=\"AppendToFile\" value=\"true\"/>");
                //sw.WriteLine("<param name=\"MaxSizeRollBackups\" value=\"10\"/>");
                //sw.WriteLine("<param name=\"MaximumFileSize\" value=\"10240KB\"/>");
                //sw.WriteLine("<param name=\"RollingStyle\" value=\"Date\"/>");
                //sw.WriteLine("<param name=\"StaticLogFileName\" value=\"false\"/>");
                //sw.WriteLine("<param name=\"DatePattern\" value=\"yyyy-MM/dd_&quot;debug.log&quot;\"  />");
                //sw.WriteLine("<param name=\"Threshold\" value=\"DEBUG\"/>");
                //sw.WriteLine("<layout type=\"log4net.Layout.PatternLayout,log4net\">");
                //sw.WriteLine("<param name=\"ConversionPattern\" value=\"记录时间：%date  日志级别：%-5level %n     记录位置：%location%n   异常：%exception%n 消息：%message%newline%n%n\" />");
                //sw.WriteLine("</layout>");
                //sw.WriteLine("<filter type=\"log4net.Filter.LevelRangeFilter\">");
                //sw.WriteLine("<levelMin value=\"DEBUG\"/>");
                //sw.WriteLine("<levelMax value=\"DEBUG\"/>");
                //sw.WriteLine("</filter>");
                //sw.WriteLine("</appender>");
                sw.WriteLine("<root>");
                sw.WriteLine("<level value=\"debug\"/>");
                sw.WriteLine("<appender-ref ref=\"InfoLog\"/>");
                sw.WriteLine("<appender-ref ref=\"ErrorLog\"/>");
                //sw.WriteLine("<appender-ref ref=\"WarnLog\"/>");
                //sw.WriteLine("<appender-ref ref=\"FatalLog\"/>");
                //sw.WriteLine("<appender-ref ref=\"DebugLog\"/>");
                sw.WriteLine("</root>");
                sw.WriteLine("</log4net>");
                sw.WriteLine("</configuration>");
                sw.Close();
            }

        }

    }
}
