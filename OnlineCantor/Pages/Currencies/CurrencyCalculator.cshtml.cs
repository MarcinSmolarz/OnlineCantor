using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineCantor.Data;
using OnlineCantor.Model;

namespace OnlineCantor.Pages.Currencies
{
    public class CurrencyCalculatorModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public CurrencyCalculatorModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public int SourceCurrency { get; set; }
        [BindProperty]
        public int DestinationCurrency { get; set; }
        [BindProperty]
        public decimal SourceCurrencyValue { get; set; }
        public decimal Result { get; set; }
        public string SResult { get; set; }
        
        public SelectList Options { get; set; }
        public void OnGet()
        {
            Options = new SelectList(_db.Currency, nameof(Currency.Id), nameof(Currency.ShortName));
        }
        public async Task<IActionResult> OnPost(int SourceCurrency, int DestinationCurrency, decimal SourceCurrencyValue)
        {
            if (ModelState.IsValid)
            {
                var sourceCurrency = await _db.Currency.FindAsync(SourceCurrency);
                var destinationCurrency = await _db.Currency.FindAsync(DestinationCurrency);
                decimal sourceValue = SourceCurrencyValue;
                Result = Decimal.Multiply(sourceCurrency.Value, sourceValue) / destinationCurrency.Value;
                SResult = String.Format("{0:0.00}", Result);
            }
            Options = new SelectList(_db.Currency, nameof(Currency.Id), nameof(Currency.ShortName));
            return Page();
        }
    }
}
