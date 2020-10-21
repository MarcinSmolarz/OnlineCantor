using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VolterV2.Model;

namespace VolterV2.Pages.Currencies
{
    public class EditModel : PageModel
    {
        private ApplicationDbContext _db;

        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }
        [BindProperty]
        public Currency Currency { get; set; }
        public async Task OnGet(int id)
        {
            Currency = await _db.Currency.FindAsync(id);
        }
        public async Task<IActionResult> OnPost()
        {
            if(ModelState.IsValid)
            {
                var CurrencyFromDb = await _db.Currency.FindAsync(Currency.Id);
                CurrencyFromDb.Name = Currency.Name;
                CurrencyFromDb.ShortName = Currency.ShortName;
                CurrencyFromDb.Value = Currency.Value;

                await _db.SaveChangesAsync();
                return RedirectToPage("CurrencyList");
            }
            return RedirectToPage();
        }
    }
}
