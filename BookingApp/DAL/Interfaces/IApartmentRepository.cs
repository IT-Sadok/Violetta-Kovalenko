using BookingApp.Models;

namespace BookingApp.DAL.Interfaces
{
    internal interface IApartmentRepository
    {
        public List<Apartment> GetAllApartments();
        public List<Apartment> GetAllApartmentsByHostId(int id);
        public Apartment? GetApartmentById(int id);
        public bool CreateApartment(Apartment apartment);
        public bool UpdateApartment(Apartment apartment);
        public bool DeleteApartment(int id);
    }
}
