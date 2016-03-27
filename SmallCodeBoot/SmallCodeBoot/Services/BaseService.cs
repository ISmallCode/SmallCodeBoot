using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace SmallCodeBoot.Services
{
    public class BaseService
    {
        public BaseService()
        {
            this.IsSuccess = true;
            this.ReturnMsg = "";
        }

        public DataTable PageTable { set; get; }

        public DataSet PageSet { set; get; }

        public int TotalRecords { set; get; }

        public int PageSize { set; get; }

        public int PageIndex { set; get; }

        public bool IsNew { set; get; }// = true;

        public bool IsSuccess { set; get; }// = true;

        public string ReturnMsg { set; get; } //= "";
    }
}