using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Diagnostics;
//using log4net;
//using log4net.Config;
//using log4net.Core;
//using log4net.Repository.Hierarchy;
//using log4net.Appender;

namespace intertrak_webapi.Helpers
{
    public class LoggerHelper
    {
        //private readonly log4net.ILog logNet = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public LoggerHelper()
        {
           // log4net.Config.XmlConfigurator.Configure();
        }

        public void Logger(string logMessage)
        {
            string deviceID = System.Web.HttpContext.Current.Request.Headers["cn-device-id"];

            string message = string.Format("{0} - {1}", deviceID, logMessage);

            if (message.Length > 4000)
            {
                message = message.Substring(0, 4000);
            }

            System.Diagnostics.Debug.Print(string.Format("Message = {0}", logMessage));

            try
            {
             //   logNet.Debug(message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.ToString());
                System.Diagnostics.Debug.Print("Error: " + ex.ToString());
            }
        }

        public void LoggerError(string logMessage)
        {
            string deviceID = System.Web.HttpContext.Current.Request.Headers["cn-device-id"];
            string apiKey = System.Web.HttpContext.Current.Request.Headers["cn-api-key"];

            string message = string.Format("#### {0} - {1} - {2}", deviceID, apiKey, logMessage);

            if (message.Length > 4000)
            {
                message = message.Substring(0, 4000);
            }

            System.Diagnostics.Debug.Print(string.Format("Message = {0}", logMessage));

            try
            {
               // logNet.Error(message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.ToString());
                System.Diagnostics.Debug.Print("Error: " + ex.ToString());
            }
        }

        public void LogException(Exception ex)
        {
           

            string message = "";
            string outputMsg = "";

            if (ex.InnerException != null)
            {
                message = ex.InnerException.Message;
            }
            else
            {
                message = ex.Message;
            }

            string deviceID = System.Web.HttpContext.Current.Request.Headers["cn-device-id"];
            string apiKey = System.Web.HttpContext.Current.Request.Headers["cn-api-key"];

            outputMsg = string.Format("{0} - {1} - #### ERROR: {2}", deviceID, apiKey, message);

            if (outputMsg.Length > 4000)
            {
                outputMsg = outputMsg.Substring(0, 4000);
            }

            try
            {
                //logNet.Error(outputMsg, ex);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.ToString());
                System.Diagnostics.Debug.Print("Error: " + e.ToString());
            }
        }
    }
}