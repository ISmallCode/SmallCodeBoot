using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmallCodeBoot.DataModels
{
    public class AjaxReturnModel
    {
        public string Status { set; get; }

        public string Message { set; get; }

        public string ReturnUrl { set; get; }
    }
}