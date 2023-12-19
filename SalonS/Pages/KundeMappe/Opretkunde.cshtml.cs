using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
// Ensure this namespace is correct for your Kunde model
using SalonS.Services;
using static SalonS.model.Kunde; // Ensure this namespace is correct for your KundeRepository

namespace SalonS.Pages.Kunde
{
    public class Opretkunde : PageModel
    {
        private readonly KundeRepository _kundeRepo; // Repository for handling Kunde data

        public Opretkunde(KundeRepository kundeRepo)
        {
            _kundeRepo = kundeRepo; // Dependency injection of the KundeRepository
        }

        [BindProperty, Required(ErrorMessage = "Indtast Navn"), Display(Name = "Navn")]
        public string Navn { get; set; }
        
        [BindProperty, Required(ErrorMessage = "Indtast Telefon Nummer"), Display(Name = "Tlf.nr")]
        public string Tlf { get; set; }
        
        [BindProperty, Required(ErrorMessage = "Indtast Email"), Display(Name = "Email")]
        public string Email { get; set; }
        
        [BindProperty, Required(ErrorMessage = "Indtast Adgangskode"), Display(Name = "Adgangskode")]
        public string Adgangskode { get; set; }
        
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Create a new Kunde instance
            var newKunde = new model.Kunde()
            {
                Navn = Navn,
                Tlf = Tlf,
                Email = Email,
                Adgangskode = Adgangskode // Consider hashing this password
            };

            // Save the new customer using the repository
            _kundeRepo.AddKunde(newKunde);

            // Redirect to the booking creation page
            return RedirectToPage("/Loginside/Login");
        }
    }
}