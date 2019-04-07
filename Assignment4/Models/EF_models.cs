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
            
            public virtual Financials Financials { get; set; }

        }

        public class ShortInterestList
        {
            [Key]
            public DateTime nameSettlementDate { get; set; }           
            public string SecurityName { get; set; }
            public int CurrentShortInterest { get; set; }
            public int PreviousShortInterest { get; set; }
            public double PercentChange { get; set; }
            public int AverageDailyVolume { get; set; }
            public double DaystoCover { get; set; }
        }

        public class Financials
        {
            [Key]
            public string name { get; set; }
            [DataType(DataType.Date)]
            [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
            public string reportDate { get; set; }
            public int grossProfit { get; set; }
            public int costOfRevenue { get; set; }
            public int operatingRevenue { get; set; }
            public int totalRevenue { get; set; }

        }
    }
}
