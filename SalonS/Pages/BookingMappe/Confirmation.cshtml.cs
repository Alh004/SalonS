using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SalonS.model;
using SalonS.Services;
using System;

public class BookingConfirmationModel : PageModel
{
    private readonly BookingRepository _bookingRepository;
    private readonly KundeRepository _kundeRepository; // Add this

    public BookingConfirmationModel(BookingRepository bookingRepository, KundeRepository kundeRepository)
    {
        _bookingRepository = bookingRepository;
        _kundeRepository = kundeRepository; // Initialize
    }

    public Booking? Booking { get; private set; }

    public void OnGet()
    {
        // Assuming KundeRepository can give you the logged-in customer's ID
        var loggedInCustomerId = _kundeRepository.KundeLoggedIn?.Kundenummer;

        if (loggedInCustomerId.HasValue)
        {
            // Fetch the most recent booking for the logged-in customer
            Booking = _bookingRepository.GetMostRecentBookingForCustomer(loggedInCustomerId.Value);
        }

        if (Booking == null)
        {
            // Redirect to an error page if no recent booking found or not logged in
            RedirectToPage("Error"); // Adjust as needed
        }
    }
}