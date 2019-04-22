using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Assignment4.Models
{
    public class EF_model
    {
        public class Company
        {
            [Key]
            public string symbol { get; set; }
            public string name { get; set; }
            public DateTime date { get; set; }
            public string isEnabled { get; set; }
            public string type { get; set; }
            public double iexID { get; set; }
        }

        public class ShortInterestList
        {
            [Key]
            public DateTime SettlementDate { get; set; }           
            public string SecurityName { get; set; }
            public int CurrentShortInterest { get; set; }
            public int PreviousShortInterest { get; set; }
            public double PercentChange { get; set; }
            public int AverageDailyVolume { get; set; }
            public double DaystoCover { get; set; }
            public string StockAdjustmentFlag { get; set; }
            public string RevisionFlag { get; set; }
            public string SymbolinINETSymbology { get; set; }
            public string SymbolinCQSSymbology { get; set; }
            public string SymbolinCMSSymbology { get; set; }
            public string NewIssueFlag { get; set; }
            public string CompanyName { get; set; }
        }

        public class Book
        {
            [Key]
            public float quote { get; set; }
            public float bids { get; set; }
            public float asks { get; set; }
            public float trades { get; set; }
            public float systemEvent { get; set; }

        }

        public class Dividend
        {
            [Key]
            public DateTime Exdate { get; set; }
            public DateTime Payment_date { get; set; }
            public DateTime Record_date { get; set; }
            public float? Amount { get; set; }
            public string type { get; set; }
            public string qualified { get; set; }
        }

        public class Price
        {
            [Key]
            public double Amount { get; set; }
            public string Symbol { get; set; }
        }
    }
}
