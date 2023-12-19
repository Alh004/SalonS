namespace SalonS.Services;

public class KundeRepository : IKundeRepository
{
    //Instans felt
    private List<Kunde> _kunder = new List<Kunde>();

    public Kunde? KundeLoggedIn { get; private set; } // Use non-nullable Kunde


    public KundeRepository(bool mockData = false)
    {
        KundeLoggedIn = null;
        //_kunderRepo = JsonFileServices.ReadFromJson<Kunde>(_fileName);

        if (mockData)
        {

            // Add mock Kunde
            _kunder.Add(new Kunde(1, "ali", "4254231", "test.dk", "ggg", true));
            // ... other Kunde ...
            _kunder.Add(new Kunde(2, "Dani", "4254231", "test.dk2", "ggg2", false));
            // ... other Kunde ...
            _kunder.Add(new Kunde(3, "Saad", "4254231", "test.dk4", "ggg4", false));
            // ... other Kunde ...
            _kunder.Add(new Kunde(4, "Abdi", "4254231", "test.dk4", "ggg3", false));
            // ... other Kunde ...

            // Add mock Admin
            //.Add(new Admin("admin", "admin42546563", "admin", "admin", true));
            // ... other Admin ...
        }
    }



    //KUNDE TING EFTER DET HER




    public void AddKunde(Kunde kunde)
    {
        _kunder.Add(new Kunde());
        //JsonFileServices.WriteToJson(_usersRepo, _fileName);

    }



    public void LogoutKunde()
    {
        KundeLoggedIn = null;

    }

    public List<Kunde> GetKunde()
    {
        return _kunder;
    }

    public Kunde? GetKundeNr(int kundenummer)
    {
        return _kunder.FirstOrDefault(x => x?.Kundenummer == kundenummer);
    }


    public bool CheckKunde(string email, string adgangskode)
    {
        Kunde? foundUser = _kunder.Find(u => u.Email == email && u.Adgangskode == adgangskode);
        if (foundUser != null)
        {
            KundeLoggedIn = foundUser;
            return true;
        }
        else
        {
            return false;
        }
    }



    public void RemoveKunde(Kunde kunde)
    {

        {
            _kunder.Remove(kunde);
            //JsonFileServices.WriteToJson(_usersRepo, _fileName);
        }
    }

    public void UpdateKunde(Kunde kunde)
    {
        var existingUser = _kunder.FirstOrDefault(x => x?.Kundenummer == kunde.Kundenummer);
        if (existingUser != null)
        {
            var userIndex = _kunder.IndexOf(existingUser);
            _kunder.Remove(existingUser);
            _kunder.Insert(userIndex, kunde);

            // JsonFileServices.WriteToJson(_usersRepo, _fileName);
        }
    }

    public void Edit(Kunde kunde)
    {
        kunde.Kundenummer = kunde.Kundenummer;
        kunde.Navn = kunde.Navn;
        kunde.Tlf = kunde.Tlf;
        kunde.Email = kunde.Email;
        kunde.Adgangskode = kunde.Adgangskode;
    }
}

    