using SalonS.model;
using SalonS.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace SalonS.Pages.AdminMappe
{
    public class IndexAdminModel : PageModel
    {
        private KundeRepository _kunder;

        public model.Kunde KundeLoggedIn { get; set; }

        public IndexAdminModel(KundeRepository kunder)
        {
            _kunder = kunder;
        }

        public IActionResult OnGet()
        {
            if (_kunder is null || _kunder.KundeLoggedIn is null || !_kunder.KundeLoggedIn.IsAdmin)
            {
                return RedirectToPage("/Login");
            }

            KundeLoggedIn = _kunder.KundeLoggedIn;

            return Page();
        }
    }

}