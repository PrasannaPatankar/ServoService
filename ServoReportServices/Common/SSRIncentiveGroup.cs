using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServoReportServices.Common
{
    public class SSRIncentiveGroup
    {
        public string EmpCode { get; set; }
        public string EmpName { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string Receipt { get; set; }
        public string Cash_Discount { get; set; }
        public string Spacial_Discount { get; set; }
        public string Credit_Note { get; set; }
        public string Cheque_Bounce { get; set; }
        public string Total_Receipts { get; set; }
        public string Total_Incentive { get; set; }
        public string Salary_Incentive { get; set; }
        public string  Basic_Salary { get; set; }
    }
}