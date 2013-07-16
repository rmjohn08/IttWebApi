using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using System.Net.Mail;
using System.Net.Mime;
using System.Configuration;
using System.IO;
using System.Xml;
using intertrak_api.Models;
using Newtonsoft.Json;
using intertrak_webapi.Helpers;

namespace intertrak_webapi.Api.Version0_01
{
    /// <summary>
    /// purpose of this class is to test the Web Api framework.  Api versioning is made following the work done in Complete Nutrition with WebAPi.  
    /// </summary>
    public class IttStatusController : ApiController
    {
        /// <summary>
        /// Get method that provides a simple string returning a string
        /// </summary>
        /// <returns>An HttpResponseMessage object</returns>
        [HttpGet]
        public HttpResponseMessage apiStatus()
        {
            HttpResponseMessage response = null;
            //response = ResponseHelper.CreateResponse(HttpStatusCode.OK, sm, Request);

            StatusMessageModel mm = new StatusMessageModel();
            mm.status = "Ok";
            mm.message = "Good Call";
            //string mm = "message model string";
            //string json = JsonConvert.SerializeObject(mm);
            //Business.Business.LogMessage(string.Format("Returning ({0}/{1}): {2}", statusCode, (int)statusCode, json));
            response = Request.CreateResponse<object>(HttpStatusCode.OK, mm);

            return response;
        }

        /// <summary>
        /// simple method showing how to pass a string parameter in the post request. 
        /// </summary>
        /// <param name="user"></param>
        /// <returns>HttpResponseMessage</returns>
        [HttpPost]
        public HttpResponseMessage registerUser(string user)
        {
            StatusMessageModel mm = new StatusMessageModel();

            if (user == null)
            {
                mm.message = "User is null";
                mm.status = "Bad User";
            }
            else if (user.IndexOf("admin") >= 0)
            {
                mm.status = "Admin user registered";
                mm.message = user + " is Registered";
            }
            else
            {
                mm.status = "User Registered";
                mm.message = user + " is Registered";

            }

            HttpResponseMessage response = null;
            response = ResponseHelper.CreateResponse(HttpStatusCode.Accepted, mm, Request);

            return response;

        }

        /// <summary>
        /// simple method showing how to send Object in post request. The framework takes a Json string and converts it to the StatusMessageModel
        /// </summary>
        /// <param name="mm">a StatusMessageModel object </param>
        /// <returns>HttpResponseMessage</returns>
        [HttpPost]
        public HttpResponseMessage postMessage(StatusMessageModel mm)
        {
            StatusMessageModel newMessage = new StatusMessageModel();

            newMessage.message = "Received (" + mm.status + " " + mm.message + ")";
            newMessage.status = "OK";
            
            HttpResponseMessage response = null;
            response = ResponseHelper.CreateResponse(HttpStatusCode.Accepted, newMessage, Request);

            return response;

        }

        [HttpPost]
        public HttpResponseMessage registerCompany(Company company)
        {

            StatusMessageModel message = new StatusMessageModel();
            message.message = "Company registered";
            message.status = "OK";
            HttpResponseMessage response = ResponseHelper.CreateResponse(HttpStatusCode.Accepted, message, Request);

            return response;
        }
        
    }
}
