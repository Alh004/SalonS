namespace SalonS.model
{
    public class Kunde
    {
        /*
         * Instans felt
         */
        private int _kundeNummer;
        private string _navn;
        private string _tlf;
        private string _email;
        private string _adgangskode;
        private bool _isAdmin;

        /*
         * Properties
         */
        public int Kundenummer
        {
            get { return _kundeNummer; }
            set { _kundeNummer = value; }
        }

        public string Navn
        {
            get { return _navn; }
            set { _navn = value; }
        }

        public string Tlf
        {
            get { return _tlf; }
            set { _tlf = value; }
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        public string Adgangskode
        {
            get { return _adgangskode; }
            set { _adgangskode = value; }
        }

        public bool IsAdmin
        {
            get { return _isAdmin; }
            set { _isAdmin = value; }
        }

        public Kunde()
        {
            _kundeNummer = 0;
            _navn = "";
            _tlf = "";
            _email = "";
            _adgangskode = "";
            _isAdmin = false;
        }

        public Kunde(int kundenummer, string navn, string tlf, string email, string adgangskode, bool isAdmin)
        {
            _kundeNummer = kundenummer;
            _navn = navn;
            _tlf = tlf;
            _email = email;
            _adgangskode = adgangskode;
            _isAdmin = isAdmin;
        }

        public override string ToString()
        {
            return
                $"{{{nameof(Kundenummer)}={Kundenummer.ToString()}, {nameof(Navn)}={Navn}, {nameof(Adgangskode)}={_adgangskode}, {nameof(IsAdmin)}={IsAdmin.ToString()}}}";
        }
    }
}