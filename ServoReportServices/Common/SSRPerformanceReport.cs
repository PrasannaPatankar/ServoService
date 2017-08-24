using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServoReportServices.Common
{
    public class SSRPerformanceReport
    {
        public string EmployeeCode { get; set; }
        public string EmployeeName { get; set; }
        public string SaleInRs { get; set; }
        public string SaleInLtr { get; set; }
        public string Receipts { get; set; }
        public string Debit { get; set; }
        public string Credit { get; set; }
        public string Outstandings { get; set; }
    }
}