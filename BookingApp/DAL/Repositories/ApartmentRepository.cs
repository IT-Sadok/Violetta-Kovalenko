using BookingApp.DAL.Interfaces;
using BookingApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace BookingApp.DAL.Repositories
{
    internal class ApartmentRepository : IApartmentRepository
    {
        private readonly IInMemoryStorage _storage;

        public ApartmentRepository(IInMemoryStorage storage)
        {
            _storage = storage ?? throw new ArgumentNullException(nameof(storage));
        }

        public List<Apartment> GetAllApartments()
        {
            return _storage.Apartments.ToList();
        }

        public List<Apartment> GetAllApartmentsByHostId(int id)
        {
            if (id <= 0)
            {
                return new List<Apartment>();
            }
            return _storage.Apartments
                .Where(a => a.HostId == id)
                .ToList();
        }

        public Apartment? GetApartmentById(int id)
        {
            if (id <= 0)
            {
                return null;
            }
            return _storage.Apartments.FirstOrDefault(a => a.Id == id);
        }

        public bool CreateApartment(Apartment apartment)
        {
            if (apartment == null)
            {
                throw new ArgumentNullException(nameof(apartment));
            }

            if (!_storage.Hosts.Any(h => h.Id == apartment.HostId))
            {
                return false;
            }

            if (apartment.Id != 0 && GetApartmentById(apartment.Id) != null)
            {
                return false;
            }

            if (apartment.Id == 0)
            {
                apartment.Id = GetNextApartmentId();
            }

            return _storage.AddApartment(apartment);
        }

        private int GetNextApartmentId()
        {
            var maxId = _storage.Apartments.Count > 0 ? _storage.Apartments.Max(a => a.Id) : 0;
            return maxId + 1;
        }

        public bool UpdateApartment(Apartment apartment)
        {
            if (apartment == null)
            {
                throw new ArgumentNullException(nameof(apartment));
            }
            return _storage.ReplaceApartment(apartment);
        }

        public bool DeleteApartment(int id)
        {
            if (id <= 0)
            {
                return false;
            }
            return _storage.RemoveApartment(id);
        }
    }
}
