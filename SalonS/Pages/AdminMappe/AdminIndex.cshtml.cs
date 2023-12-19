using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SalonS.model;
using SalonS.Services;

namespace SalonSNy.Pages.admin
{
    public class AdminIndexModel : PageModel
    {
        private KundeRepository _kunder;

        public Kunde KundeLoggedIn { get; private set; }

        public AdminIndexModel(KundeRepository kunder)
        {
            _kunder = kunder;
        }

        public IActionResult OnGet()
        {
            if (_kunder is null || _kunder.KundeLoggedIn is null || !_kunder.KundeLoggedIn.IsAdmin) {
                return RedirectToPage("/LoginMappe/Login");
            }

            KundeLoggedIn = _kunder.KundeLoggedIn;   

            return Page();
        }

    }
}