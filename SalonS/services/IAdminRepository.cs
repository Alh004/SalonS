using SalonS.Models;
using SalonS.Models.Kunde;

namespace SalonS.ServicAs

{
    public interface IAdminRepository
    {
        Admin? AdminLoggedIn { get; }
        bool CheckAdmin(string email, string adgangskode);
        void LogoutAdmin();
        Kunde RemoveKunde(int kundeNummer);
        Kunde HentKunde(int kundeNummer);
        void AddKunde(Kunde kunde);
        void UpdateKunde(Kunde kunde);
        Kunde? GetKunde(int id);
        bool CheckKunde(string email, string adgangskode);
    }
}