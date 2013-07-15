using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Net;
using System.Net.Http;
using CN_webapi.Models.Version0_01;
using Newtonsoft.Json;

namespace CN_webapi.Helpers
{
    public static class ResponseHelper
    {
        public static HttpResponseMessage CreateErrorResponse(HttpStatusCode errorCode, int errorNumber, string displayExceiption, HttpRequestMessage request)
        {
            ErrorResponseModel errorResponseModel = new ErrorResponseModel();
            errorResponseModel.error = ((int)errorCode).ToString();
            //errorResponseModel.error = errorNumber.ToString();
            errorResponseModel.displayException = displayExceiption;
            return request.CreateResponse<ErrorResponseModel>(errorCode, errorResponseModel);
        }

        public static HttpResponseMessage CreateExceptionResponse(Exception exception, HttpRequestMessage request)
        {
            ErrorResponseModel errorResponseModel = new ErrorResponseModel();
            errorResponseModel.error = "500";
            if (exception.InnerException != null)
            {
                errorResponseModel.displayException = exception.Message + ", " + exception.InnerException.Message;
            }
            else
            {
                errorResponseModel.displayException = exception.Message;
            }

            //Business.Business.LogException(exception);

            return request.CreateResponse<ErrorResponseModel>(HttpStatusCode.InternalServerError, errorResponseModel);
        }

        public static HttpResponseMessage CreateResponse(HttpStatusCode statusCode, object returnItem, HttpRequestMessage request)
        {
            string json = JsonConvert.SerializeObject(returnItem);
            //Business.Business.LogMessage(string.Format("Returning ({0}/{1}): {2}", statusCode, (int)statusCode, json));
            return request.CreateResponse<object>(statusCode, returnItem);
        }

        public static HttpResponseMessage CreateResponse(HttpStatusCode statusCode, HttpRequestMessage request)
        {
            //Business.Business.LogMessage(string.Format("Returning ({0}/{1})", statusCode, (int)statusCode));
            return request.CreateResponse(statusCode);
        }
    }
}