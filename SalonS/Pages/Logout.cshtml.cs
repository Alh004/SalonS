using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SalonS.Services;

namespace SalonSNy.Pages.LoginMappe
{
    public class LogoutModel : PageModel
    {
        private KundeRepository _kundeRepository;

        public LogoutModel(KundeRepository kundeRepository)
        {
            _kundeRepository = kundeRepository;
        }

        public IActionResult OnGet()
        {
            _kundeRepository.LogoutKunde();

            return RedirectToPage("Index");
        }
    }
}