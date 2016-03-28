using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace SmallCodeBoot.DataModels
{
    public class BaseViewModel
    {
        public BaseViewModel()
        {
            this.IsInsert = true;
            this.IsSuccess = true;
            this.ReturnMsg = "";
        }

        public int TotalRecords { set; get; }

        public DataTable DataSource { set; get; }

        public bool IsInsert { set; get; }

        public bool IsSuccess { set; get; }

        public string ReturnMsg { set; get; }
    }
}