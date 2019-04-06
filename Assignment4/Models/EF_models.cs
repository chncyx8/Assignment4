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
            public string date { get; set; }
            /*public string symbol { get; set; }
            public string companyName { get; set; }
            public string exchange { get; set; }
            public string industry { get; set; }
            public string website { get; set; }
            public int operatingIncome { get; set; }
            public int netIncome { get; set; }
            public int researchAndDevelopment { get; set; }
            public int operatingExpense { get; set; }
            public int currentAssets { get; set; }
            public int totalAssets { get; set; }
            public int totalLiabilities { get; set; }
            public int currentCash { get; set; }
            public int currentDebt { get; set; }
            public int totalCash { get; set; }
            public int totalDebt { get; set; }
            public int shareholderEquity { get; set; }
            public int cashChange { get; set; }
            public int cashFlow { get; set; }
            public string operatingGainsLosses { get; set; } */

        }
    }
}
