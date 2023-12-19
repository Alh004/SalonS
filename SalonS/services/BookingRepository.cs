namespace SalonS.Services
{
    public class BookingRepository : IBookingRepository
    {
        public readonly List<Kunde?> KunderRepo = new List<Kunde?>();

        public readonly Dictionary<string, Booking?> KatalogBooking;
        
        
        public Dictionary<int, List<Booking?>> CustomerBookings { get; set; } = new Dictionary<int, List<Booking?>>();


        /*
         * Constructor
         */

        public BookingRepository(bool mockData = false)
        {
            KatalogBooking = new Dictionary<string, Booking?>();

            if (mockData)
            {
                PopulateBookingRepository();
            }
        }

        private void PopulateBookingRepository()
        {
            
           // KatalogBooking.Add("1", new Booking(1, DateTime.Parse("2023-12-01"), "09:23", "Ali", "Buzzcut", 300,
               // new Kunde(1, "ali", "55235465", "test.dk", "ggg")));
            
           
        }

   public List<Booking> GetCustomerBookings(int kundenummer)
        {
            if (CustomerBookings.TryGetValue(kundenummer, out var bookings))
            {
                return bookings;
            }
            return new List<Booking>();
        }


        public Booking HentBookingId(int bookingId)
        {
            return KatalogBooking.Values.FirstOrDefault(b => b.BookingId == bookingId) ?? throw new InvalidOperationException();
        }

        public Dictionary<string, Booking?> GetAll()
        {
            return KatalogBooking;
        }

        public Booking? GetBookingById(int bookingId)
        {
            KatalogBooking.TryGetValue(bookingId.ToString(), out var booking);
            return booking;
        }

        public void Tilføj(Booking? booking)
        {
            // Ensure a unique BookingId is assigned
            if (booking.BookingId <= 0)
            {
                booking.BookingId = GenerateUniqueBookingId();
            }

            // Add the booking to KatalogBooking
            KatalogBooking.Add(booking.BookingId.ToString(), booking);

            // Update CustomerBookings dictionary
            if (!CustomerBookings.ContainsKey(booking.Kunde.Kundenummer))
            {
                CustomerBookings[booking.Kunde.Kundenummer] = new List<Booking?>();
            }
            CustomerBookings[booking.Kunde.Kundenummer].Add(booking);
        }


        public void Delete(int id)
        {
            var booking = HentBookingId(id);
            KatalogBooking.Remove(booking.BookingId.ToString());
        }

        public Kunde? FindByCustomerId(int kundenummer)
        {
            return KunderRepo.FirstOrDefault(x => x?.Kundenummer == kundenummer);
        }

        public void OpdaterBooking(Booking booking)
        {
            booking.Dato = booking.Dato;
            booking.Tid = booking.Tid;
            booking.Frisør = booking.Frisør;
            booking.Klip = booking.Klip;
            booking.Pris = booking.Pris;
        }

        public bool IsDoubleBooking(DateTime date, string tid, string frisør)
        {
            return KatalogBooking.Values.Any(b =>
                b.Dato.Date == date.Date &&
                b.Tid == tid &&
                b.Frisør == frisør);
        }
        
        public int GenerateUniqueBookingId()
        {
            if (KatalogBooking.Count == 0)
            {
                return 1; // Start with ID 1 if there are no bookings
            }

            // Convert the string keys to integers, get the max, and increment by one
            return KatalogBooking.Keys.Select(key => int.Parse(key)).Max() + 1;
        }
        
        public Booking? GetMostRecentBookingForCustomer(int customerId)
        {
            return KatalogBooking.Values
                .Where(booking => booking.Kunde?.Kundenummer == customerId)
                .OrderByDescending(booking => booking.Dato)
                .ThenByDescending(booking => booking.Tid)
                .FirstOrDefault();
        }

        
        public List<Kunde?> HentAlleKunder()
        {
            return KunderRepo.ToList();
        }

        public List<Booking?> HentAlleBooking()
        {
            return KatalogBooking.Values.ToList();
        }
    }
}
