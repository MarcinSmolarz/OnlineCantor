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

namespace OnlineCantor.Pages.Currencies
{
    [Authorize(Roles = StaticDetails.AdminEndUser)]
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
            _External = External; //sprawdziæ czy potrzebne
            if (ModelState.IsValid)
            {
                await _db.Currency.AddAsync(Currency);
                //await _db.Currency.AddAsync(CurrencyOverhaulData);
                //await _db.Currency.AddAsync(CurrencyValueData);
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
