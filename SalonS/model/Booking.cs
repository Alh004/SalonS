namespace SalonS.model;

public class Booking
{
    public int BookingId { get; set; } // Add this property
    private DateTime _dato;
    private string _tid;
    private string _frisør;
    private string _klip;
    private int _pris;
    private Kunde? _kunde;

    /*
     * Properties
     */
    public string Tid
    {
        get { return _tid; }
        set { _tid = value; }
    }

    public string Frisør
    {
        get { return _frisør; }
        set { _frisør = value; }
    }

    public string Klip
    {
        get { return _klip; }
        set { _klip = value; }
    }

    public int Pris
    {
        get { return _pris; }
        set { _pris = value; }
    }

    public DateTime Dato // Property for date
    {
        get { return _dato; }
        set { _dato = value; }
    }

    public Kunde? Kunde
    {
        get { return _kunde; }
        set { _kunde = value; }
    }
    
    // Default Constructor
    public Booking()
    {
        _dato = DateTime.Today; // Initialize with today's date
        _tid = "";
        _frisør = "";
        _klip = "";
        _pris = 0;
        _kunde = null;
    }

    // Parameterized Constructor
    public Booking(int bookingId, DateTime dato, string tid, string frisør, string klip, int pris, Kunde? kunde)
    {
        BookingId = bookingId; // Set BookingId = i;
        _dato = dato;
        _tid = tid;
        _frisør = frisør;
        _klip = klip;
        _pris = pris;
        _kunde = kunde;
    }
}