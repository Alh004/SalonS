using SalonS.Models;
using System.Collections.Generic;
using SalonS.Models.Kunde;
using SalonS.ServicAs;

namespace SalonS.Services
{
    public class AdminRepository : IAdminRepository
    {
        private readonly IKundeRepository _kundeRepository;
        private List<Admin> _katalogAdmin = new List<Admin>();

        public Admin? AdminLoggedIn { get; private set; }

        public AdminRepository(IKundeRepository kundeRepository, bool mockData = false)
        {
            _kundeRepository = kundeRepository;

            if (mockData)
            {
                _katalogAdmin.Add(new Admin("saad", "42546563", "hsfh@live.dk", "2000"));
                _katalogAdmin.Add(new Admin("saaad", "98234576", "yhbh@gmail.com", "2450"));
                _katalogAdmin.Add(new Admin("ok", "12456587", "peop@outlook.gb", "4312"));
            }
        }

        // Admin-specific methods
        public bool CheckAdmin(string email, string adgangskode)
        {
            // Implementation specific to checking an Admin
        }
        

        public void LogoutAdmin()
        {
            AdminLoggedIn = null;
        }

        Kunde IAdminRepository.RemoveKunde(int kundeNummer)
        {
            throw new NotImplementedException();
        }

        public Kunde HentKunde(int kundeNummer)
        {
            throw new NotImplementedException();
        }

        void IAdminRepository.AddKunde(Kunde kunde)
        {
            AddKunde(kunde);
        }

        void IAdminRepository.UpdateKunde(Kunde kunde)
        {
            UpdateKunde(kunde);
        }

        Kunde? IAdminRepository.GetKunde(int id)
        {
            return GetKunde(id);
        }

        // Delegated Kunde management methods
        public void AddKunde(Kunde kunde)
        {
            _kundeRepository.AddKunde(kunde);
        }

        public Kunde? GetKunde(int kundenummer)
        {
            return _kundeRepository.GetKunde(kundenummer);
        }

        public List<Kunde> GetAlleKunder()
        {
            return _kundeRepository.CheckKunde();
        }

        public void UpdateKunde(Kunde kunde)
        {
            _kundeRepository.UpdateKunde(kunde);
        }

        public void RemoveKunde(int kundenummer)
        {
            _kundeRepository.RemoveKunde(kundenummer);
        }

        public bool CheckKunde(string email, string adgangskode)
        {
            return _kundeRepository.CheckKunde(email, adgangskode);
        }


        // LogoutKunde - If admins also manage their own login state as Kunde
        public void LogoutKunde()
        {
            _kundeRepository.LogoutKunde();
        }

        // ... other methods as needed for admin tasks ...
    }
}

