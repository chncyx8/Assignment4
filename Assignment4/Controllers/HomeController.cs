using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using static Assignment4.Models.EF_model;
using Assignment4.Models;
// ADD THESE DIRECTIVES
using Assignment4.DataAccess;
using Newtonsoft.Json;
using System.Net.Http;

namespace API_Simple.Controllers
{
    public class HomeController : Controller
    {
        public ApplicationDbContext dbContext;
        string BASE_URL = "https://api.iextrading.com/1.0/";
        HttpClient httpClient;


        public HomeController(ApplicationDbContext context)
        {
            dbContext = context;
            
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new
                System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }

        /*
            Calls the IEX reference API to get the list of symbols.
            Returns a list of the companies whose information is available. 
        */
        public List<Company> GetSymbols()
        {
            string IEXTrading_API_Symbols = BASE_URL + "ref-data/symbols";
            string companyList = "";
            List<Company> companies = null;

            // Connect to the IEXTrading API and retrieve information
            httpClient.BaseAddress = new Uri(IEXTrading_API_Symbols);
            HttpResponseMessage response = httpClient.GetAsync(IEXTrading_API_Symbols).GetAwaiter().GetResult();

            // Read the Json objects in the API response
            if (response.IsSuccessStatusCode)
            {
                companyList = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            }

            // Parse the Json strings as C# objects
            if (!companyList.Equals(""))
            {
                companies = JsonConvert.DeserializeObject<List<Company>>(companyList);
                companies = companies.GetRange(0, 50);
            }

            return companies;
        }

        public IActionResult Index()
        {
            //Set ViewBag variable first
            ViewBag.dbSuccessComp = 0;
            List<Company> companies = GetSymbols();

            //Save companies in TempData, so they do not have to be retrieved again
            TempData["Companies"] = JsonConvert.SerializeObject(companies);

            return View(companies);
        }

        /*
            The Symbols action calls the GetSymbols method that returns a list of Companies.
            This list of Companies is passed to the Symbols View.
        */
        public IActionResult Symbols()
        {
            //Set ViewBag variable first
            ViewBag.dbSuccessComp = 0;
            List<Company> companies = GetSymbols();

            //Save companies in TempData, so they do not have to be retrieved again
            TempData["Companies"] = JsonConvert.SerializeObject(companies);

            return View(companies);
        }

        public List<ShortInterestList> GetShortInterestList(string symbol)
        {

            string IEXTrading_API_PATH = BASE_URL + "stock/" + symbol + "short-interest";
            string SITList = "";
            List<ShortInterestList> SIT = new List<ShortInterestList>();
            httpClient.BaseAddress = new Uri(IEXTrading_API_PATH);

            HttpResponseMessage respose = httpClient.GetAsync(IEXTrading_API_PATH).GetAwaiter().GetResult();

            if (respose.IsSuccessStatusCode)
            {
                SITList = respose.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            }
            if (!SITList.Equals(""))
            {
                SIT = JsonConvert.DeserializeObject<List<ShortInterestList>>(SITList);
                SIT.GetRange(0, SIT.Count);
            }
            return SIT;
        }
        [Route("{id}")]
        public IActionResult shortInterestList(string id)
        {
            String symbols = id;
            //Set ViewBag variable first
            ViewBag.dbSuccessComp = 0;
            List<ShortInterestList> shortInterestLists = GetShortInterestList(symbols);

            //Save companies in TempData, so they do not have to be retrieved again
            TempData["shortInterestList"] = JsonConvert.SerializeObject(shortInterestLists);
            //Console.WriteLine(divident);
            return View(shortInterestLists);
        }

        public List<Book> GetBook(string symbol)
        {

            string IEXTrading_API_PATH = BASE_URL + "stock/" + symbol + "book";
            string BKlist = "";
            List<Book> bk = new List<Book>();
            httpClient.BaseAddress = new Uri(IEXTrading_API_PATH);

            HttpResponseMessage respose = httpClient.GetAsync(IEXTrading_API_PATH).GetAwaiter().GetResult();

            if (respose.IsSuccessStatusCode)
            {
                BKlist = respose.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            }
            if (!BKlist.Equals(""))
            {
                bk = JsonConvert.DeserializeObject<List<Book>>(BKlist);
                bk.GetRange(0, bk.Count);
            }
            return bk;
        }

        public IActionResult Book(string id)
        {
            String symbols = id;
            //Set ViewBag variable first
            ViewBag.dbSuccessComp = 0;
            List<Book> booklist = GetBook(symbols);

            //Save companies in TempData, so they do not have to be retrieved again
            TempData["BookList"] = JsonConvert.SerializeObject(booklist);
            //Console.WriteLine(divident);
            return View(booklist);
        }

        public List<Dividend> GetDividend(string symbol)
        {

            string IEXTrading_API_Dividend = BASE_URL + "stock/" + symbol + "/dividends/2y";
            string dividendList = "";
            List<Dividend> dividends = new List<Dividend>();
            httpClient.BaseAddress = new Uri(IEXTrading_API_Dividend);

            HttpResponseMessage respose = httpClient.GetAsync(IEXTrading_API_Dividend).GetAwaiter().GetResult();

            if (respose.IsSuccessStatusCode)
            {
                dividendList = respose.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            }
            if (!dividendList.Equals(""))
            {
                dividends = JsonConvert.DeserializeObject<List<Dividend>>(dividendList);
                dividends.GetRange(0, dividends.Count);
            }
            return dividends;
        }
        //[Route("{id}")]
        public IActionResult Dividend(string id)
        {
            String symbols = id;
            //Set ViewBag variable first
            ViewBag.dbSuccessComp = 0;
            List<Dividend> dividend = GetDividend(symbols);

            //Save companies in TempData, so they do not have to be retrieved again
            TempData["dividend"] = JsonConvert.SerializeObject(dividend);
            return View(dividend);
        }

        public double GetPrice(string symbol)
        {

            string IEXTrading_API_Price = BASE_URL + "/stock/" + symbol + "/price";
            double price = 0;
            // List<Price> prices = new List<Price>();
            httpClient.BaseAddress = new Uri(IEXTrading_API_Price);

            HttpResponseMessage respose = httpClient.GetAsync(IEXTrading_API_Price).GetAwaiter().GetResult();

            if (respose.IsSuccessStatusCode)
            {
                price = Convert.ToDouble(respose.Content.ReadAsStringAsync().GetAwaiter().GetResult());
            }

            return price;
        }


        public IActionResult Price(string id)
        {
            String symbols = id;
            //Set ViewBag variable first
            ViewBag.dbSuccessComp = 0;
            double Price = GetPrice(symbols);

            //Save companies in TempData, so they do not have to be retrieved again
            TempData["Price"] = JsonConvert.SerializeObject(Price);
            ViewBag.Message = Price;
            return View(Price);
        }

        public IActionResult PopulateSymbols()
        {
            // Retrieve the companies that were saved in the symbols method
            //String data = HttpContext.Session.GetType("companies");
            List<Company> companies = JsonConvert.DeserializeObject<List<Company>>(TempData["Companies"].ToString());

            foreach (Company company in companies)
            {
                //Database will give PK constraint violation error when trying to insert record with existing PK.
                //So add company only if it doesnt exist, check existence using symbol (PK)
                if (dbContext.Companies.Where(c => c.symbol.Equals(company.symbol)).Count() == 0)
                {
                    dbContext.Companies.Add(company);
                }
            }

            dbContext.SaveChanges();
            ViewBag.dbSuccessComp = 1;
            return View("Index", companies);
        }


        

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult AboutUs()
        {
            //ViewBag.Link = "<a href='" + github.com / chncyx8 / Assignment4 + "'>Github</a>";
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
