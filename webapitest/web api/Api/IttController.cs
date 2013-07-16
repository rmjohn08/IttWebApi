using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using intertrak_api.Models;

namespace intertrak_api.Api
{
    public class IttController : ApiController
    {
        //public HttpResponseMessage getAppStatus(string os, string version)
        public HttpResponseMessage getAppStatus()
        {
            HttpResponseMessage response = null;
            //response = ResponseHelper.CreateResponse(HttpStatusCode.OK, sm, Request);

            StatusMessageModel mm = new StatusMessageModel();
            mm.status = "Ok";
            mm.message = "Good Call"; 
            //string mm = "message model string";
            string json = JsonConvert.SerializeObject(mm);
            //Business.Business.LogMessage(string.Format("Returning ({0}/{1}): {2}", statusCode, (int)statusCode, json));
            response = Request.CreateResponse<object>(HttpStatusCode.OK, mm);

            return response;
        }

        
    }
}
