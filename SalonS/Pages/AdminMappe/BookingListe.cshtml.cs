using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SalonS.Services;

namespace SalonS.Pages.AdminMappe
{
    public class BookinglisteModel : PageModel
    {
        private readonly BookingRepository _bookingRepository;
        private readonly KundeRepository _kundeRepository;

        public BookinglisteModel(BookingRepository bookingRepository, KundeRepository kundeRepository)
        {
            _bookingRepository = bookingRepository;
            _kundeRepository = kundeRepository;
        }

        public List<model.Booking?> Bookings { get; set; }
        public List<model.Kunde> Kunder { get; set; }

        [BindProperty]
        public string Navn { get; set; }

        public string Tlf { get; set; }

        public void OnGet()
        {
            Bookings = _bookingRepository.HentAlleBooking();
            Kunder = _kundeRepository.GetKunde();
        }

        public IActionResult OnPost()
        {
            // Your post logic goes here, if needed
            return Page();
        }
    }
}