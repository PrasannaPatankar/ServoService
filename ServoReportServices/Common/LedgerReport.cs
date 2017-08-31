using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServoReportServices.Common
{
    public class LedgerReport
    {
        public string Month { get; set; }
        public string EntryDate { get; set; }
        public string DebitAmount { get; set; }
        public string CreditAmount { get; set; }
        public string Year { get; set; }
    }
}