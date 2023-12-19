using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SalonS.Services;

namespace SalonS.Pages
{
    public class LoginModel : PageModel
    {
        private KundeRepository _kundeRepository;

        public LoginModel(KundeRepository kundeRepository)
        {
            _kundeRepository = kundeRepository;
        }



        [BindProperty]
        public string Email { get; set; }

        [BindProperty]
        public string Adgangskode { get; set; }

        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            if (Email == null || Adgangskode == null)
            {
                return Page();
            }

            if (!_kundeRepository.CheckKunde(Email, Adgangskode))
            {
                return Page();
            }

            return RedirectToPage("Index");
        }
    }
}