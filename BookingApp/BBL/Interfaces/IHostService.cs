using BookingApp.DAL.Entities;

namespace BookingApp.BBL.Interfaces
{
    internal interface IHostService
    {
        public List<Host> GetAllHosts();
        public Host? GetHostById(int id);
        public bool CreateHost(Host host);
        public bool UpdateHost(Host host);
        public bool DeleteHost(int id);

        public List<Apartment> GetAllApartments();
        public Apartment? GetApartmentById(int id);
        public List<Apartment> GetApartmentsByHostId(int hostId);
        public bool CreateApartment(int hostId, Apartment apartment);
        public bool UpdateApartment(int hostId, Apartment apartment);
        public bool DeleteApartment(int hostId, Apartment apartment);

        void SaveChanges();
    }
}
