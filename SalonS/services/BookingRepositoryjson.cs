using System.Text.Json;


namespace SalonS.Services
{
    public class BookingRepositoryjson : IBookingRepository
    {
        // instance field
        Dictionary<string, Booking> _bookingKatalog;

        // properties
        public Dictionary<string, Booking> BookingKatalog
        {
            get { return _bookingKatalog; }
            set { _bookingKatalog = value; }
        }

        // constructor
        public BookingRepositoryjson()
        {
            BookingKatalog = ReadFromJson();
        }



    /*
     * metoder
     */
    public Dictionary<string, Booking> GetAll()
    {
        throw new NotImplementedException();
    }

    public Booking? GetBookingById(int bookingId)
    {
        throw new NotImplementedException();
    }

    void IBookingRepository.Tilføj(Booking? booking)
    {
        throw new NotImplementedException();
    }

    public void OpdaterBooking(Booking booking)
    {
        throw new NotImplementedException();
    }
    public void Delete(int id)
    {
        throw new NotImplementedException();
    }

    public int GenerateUniqueBookingId()
    {
        throw new NotImplementedException();
    }

    public string GenerateNewBookingId()
    {
        throw new NotImplementedException();
    }

    public bool IsDoubleBooking(DateTime date, string time, string barber)
    {
        throw new NotImplementedException();
    }

    public Kunde? FindByCustomerId(int customerId)
    {
        throw new NotImplementedException();
    }

    public void AddNyBookingTid(Booking booking)
    {
        throw new NotImplementedException();
    }

    public Booking Tilføj(Booking booking)
    {
        if (BookingKatalog.ContainsKey(booking.Tid))
        {
            BookingKatalog.Add(booking.Tid, booking);


            WriteToJson();
            return booking;
        }

        throw new ArgumentException($"Tid {booking.Tid} findes i forvejen");
    }

    public List<Kunde?> HentAlleKunder(int Kundenummer)
    {
        throw new NotImplementedException();
    }

    public List<Kunde?> HentAlleKunder()
    {
        throw new NotImplementedException();
    }

    public List<Booking?> HentAlleBooking()
    {
        throw new NotImplementedException();
    }

    public Booking HentBookingID(int id)
    {
        throw new NotImplementedException();
    }


    public List<Booking> HentKundeBooking(int kundenummer)
    {
        throw new NotImplementedException();
    }

    public List<Booking> GetCustomerBookings(int kundenummer)
    {
        throw new NotImplementedException();
    }

    public List<Booking>? Bookings { get; set; }
    public List<Booking> HentAlleBooking(int kundenummer)
    {
        throw new NotImplementedException();
    }
    
    public Booking Slet(string tid)
    {
        Booking slettetBooking = HentBooking(tid);
        BookingKatalog.Remove(tid);

        WriteToJson();
        return slettetBooking;
    }

    public Booking Opdater (Booking booking)
    {
        Booking editBooking = HentBooking(booking.Tid);
        BookingKatalog[booking.Tid] = booking;
        
        

        WriteToJson();
        return booking;
    }



    public Booking HentBooking(string tid)
    {
        if (BookingKatalog.ContainsKey(tid))
        {
            return BookingKatalog[tid];
        }
        else
        {
            // opdaget en fejl
            throw new KeyNotFoundException($"Tid {tid} findes ikke");
        }
    }

    public List<Booking> HentAlleBookings()
    {
        return BookingKatalog.Values.ToList();
    }

    public Booking HentBookingUdFraTid(string Tid)
    {
        Booking resBooking = null;

        foreach (Booking b in BookingKatalog.Values)
        {
            if (b.Tid == Tid)
            {
                return b;
            }
        }

        return resBooking;
    }

    public List<Booking> Search(string? tid, string? frisør, string? klip, int pris)
    {
        List<Booking> retBookings = new List<Booking>(HentAlleBookings());

        if (tid is not null)
        {
            retBookings = retBookings.FindAll(b => b.Tid == tid);
        }

        if (frisør is not null)
        {
            retBookings = retBookings.FindAll(b => b.Frisør.Contains(frisør));
        }

        

        return retBookings;
    }


    private bool NumberASC = true;

    public List<Booking> SortTid()
    {
        List<Booking> retBookings = HentAlleBookings();

        retBookings.Sort(new SortByTid());

        if (!NumberASC)
        {
            retBookings.Reverse();
        }

        NumberASC = !NumberASC;

        return retBookings;
    }

    private class SortByTid : IComparer<Booking>
    {
        public int Compare (Booking? x, Booking? y)
        {
            if(x == null || y == null)
            {
                return 0;
            }

            //if (x.Tid > y.Tid)
            //{
            //    return 1;
            //}
            //else
            //{
            //    return -1;
            //}

            return x.Tid.CompareTo(y.Tid);
        }
    }
    
    public override string ToString()
    {
        String pænTekst = String.Join(", ", _bookingKatalog.Values);

        return $"{{{nameof(_bookingKatalog)}={pænTekst}}}";
    }


    /*
     * Hjælpe metoder til at læse og skrive til en fil i json format
     */

    private const string Filename = "BookingRepository.json";

    private Dictionary<string, Booking> ReadFromJson()
    {
        if (File.Exists(Filename))
        {
            StreamReader reader = File.OpenText(Filename);
            Dictionary<string, Booking> BookingKatalog = JsonSerializer.Deserialize<Dictionary<string, Booking>>(reader.ReadToEnd());
            reader.Close();
            return BookingKatalog;
        }
        else
        {
            return new Dictionary<string, Booking>();
        }
    }

    private void WriteToJson()
    {
        FileStream fs = new FileStream(Filename, FileMode.Create);
        Utf8JsonWriter writer = new Utf8JsonWriter(fs);
        JsonSerializer.Serialize(writer, BookingKatalog);
        fs.Close();
    }
    }
}

        
        




