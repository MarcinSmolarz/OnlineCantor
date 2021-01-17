using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OnlineCantor.Data;
using OnlineCantor.Model;
using OnlineCantor.Utility;
using RestSharp;

namespace OnlineCantor.Pages.Currencies
{
    [Authorize(Roles = StaticDetails.AdminEndUser)]
    public class AdminPanelModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public AdminPanelModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            IRestClient client = new RestClient("http://api.nbp.pl/api");
            IRestRequest request = new RestRequest("exchangerates/tables/A?format=json", Method.GET);
            IRestResponse response = client.Get(request);
            Chilkat.JsonObject json = new Chilkat.JsonObject();
            json.Load(response.Content);
            Chilkat.JsonArray jCurrencies = json.ArrayOf("rates");
            int numCurrencies = jCurrencies.Size;
            for (int i = 0; i < numCurrencies; i++)
            {
                Chilkat.JsonObject empObj = jCurrencies.ObjectAt(i);
                string tName = empObj.StringOf("currency");
                string tCode = empObj.StringOf("code");
                string tMid = empObj.StringOf("mid");
                tMid = tMid.Replace('.', ',');
                decimal Mid = Convert.ToDecimal(tMid);
                Currency currency = new Currency(tName, tCode, Mid, DateTime.Now);
                await _db.Currency.AddAsync(currency);
                await _db.SaveChangesAsync();
            }
            return RedirectToPage("CurrencyList");
        }

    }
}
