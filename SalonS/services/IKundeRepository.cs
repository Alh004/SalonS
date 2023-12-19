using Microsoft.Extensions.Primitives;

namespace SalonS.Services
{
    public interface IKundeRepository
    {   
        Kunde? KundeLoggedIn { get; }
        void AddKunde(Kunde kunde);
        bool CheckKunde(string email, string adgangskode);
        void LogoutKunde();
        public List<Kunde> GetKunde();
        Kunde? GetKundeNr(int kundenummer);
        public void Edit(Kunde kunde);
        // Combined methods
        void RemoveKunde(Kunde kunde);
    }
}