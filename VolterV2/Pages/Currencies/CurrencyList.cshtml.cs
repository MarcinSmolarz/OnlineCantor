using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using VolterV2.Model;

namespace VolterV2.Pages.Currencies
{
    public class CurrencyListModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        
        public CurrencyListModel(ApplicationDbContext db)
        {
            _db = db; 
        }
        public IList<Currency> Currencies { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }
        public async Task OnGet(string SearchTerm)
        {
            var currencies = from m in _db.Currency
                             select m;
            if(!string.IsNullOrEmpty(SearchTerm))
            {
                currencies = currencies.Where(s => s.Name.Contains(SearchTerm) || s.ShortName.Contains(SearchTerm));
            }            
            Currencies = await currencies.ToListAsync();
        }
        public async Task<IActionResult> OnPostDelete(int id)
        {
            var currency = await _db.Currency.FindAsync(id);
            if (currency == null)
            {
                return NotFound();
            }
            _db.Currency.Remove(currency);
            await _db.SaveChangesAsync();

            return RedirectToPage("CurrencyList");
        }
    }
}
