
using System;
using System.Collections.Generic;

namespace SalonS.Services
{
    public interface IBookingRepository
    {
        // Retrieves all bookings.
        
        List<Booking?> HentAlleBooking();

        // Retrieves a specific booking by its ID.
        Booking? GetBookingById(int bookingId);

        // Adds a new booking to the repository.
        void Tilføj(Booking? booking);

        // Updates an existing booking.
        void OpdaterBooking(Booking booking);

        // Deletes a booking by its ID.
        void Delete(int bookingId);

        // Generates a new, unique booking ID.
        int GenerateUniqueBookingId();

        // Checks if a booking time is already taken.
        bool IsDoubleBooking(DateTime date, string time, string barber);

        // Finds a customer by their ID.
        Kunde? FindByCustomerId(int kundenummer);

        public List<Booking> GetCustomerBookings(int kundenummer);
    }
}