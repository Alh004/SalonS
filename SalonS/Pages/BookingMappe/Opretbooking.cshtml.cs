using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SalonS.model;
using SalonS.Services;

public class BookingModel : PageModel
{
    private readonly BookingRepository _bookingRepo;
    private readonly KundeRepository _kundeRepo;

    public BookingModel(BookingRepository bookingRepo, KundeRepository kundeRepo)
    {
        _bookingRepo = bookingRepo;
        _kundeRepo = kundeRepo;
    }

    [BindProperty]
    public Booking? NewBooking { get; set; }

    public string ErrorMessage { get; set; }

    public void OnGet()
    {
        // Initialize any data needed for the form
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        if (_kundeRepo.KundeLoggedIn == null)
        {
            ErrorMessage = "Du skal være logget ind for at booke en tid.";
            return Page(); // Stay on the same page to show the error message
        }

        NewBooking.Kunde = _kundeRepo.KundeLoggedIn;
        _bookingRepo.Tilføj(NewBooking);

        // Redirect to a confirmation page with booking ID
        return RedirectToPage("/BookingMappe/Confirmation", new { bookingId = NewBooking.BookingId });
    }
}