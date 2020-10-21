using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VolterV2.Model;

namespace VolterV2.Pages.Currencies
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }
        [BindProperty]
        public Currency Currency { get; set; }
        [BindProperty]
        public decimal _External { get; set; }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPost(decimal External)
        {
            _External = External;
            if (ModelState.IsValid)
            {
                await _db.Currency.AddAsync(Currency);
                await _db.SaveChangesAsync();
                return RedirectToPage("CurrencyList");
            }
            else
            {
                return Page();
            }
        }
    }
}
