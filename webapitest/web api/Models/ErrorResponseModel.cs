using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CN_webapi.Models.Version0_01
{
    public class ErrorResponseModel
    {
        public string error { get; set; }
        public string displayException { get; set; }
    }
}