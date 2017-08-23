using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServoReportServices.Common
{
    public class SSRIncentiveReport
    {
        public string ColumnDesc { get; set; }
        public string TotalVal { get; set; }
        public string EmpCode { get; set; }
        public string EmpName { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public List<SSRIncentiveGroup> GroupList { get; set; }
    }

}