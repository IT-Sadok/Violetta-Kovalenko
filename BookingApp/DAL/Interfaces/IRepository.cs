using BookingApp.DAL.Entities;

namespace BookingApp.DAL.Interfaces
{
    internal interface IRepository
    {
        public List<Host> GetAllHosts();
        public Host? GetHostById(int id);
        public bool AddHost(Host host);
        public bool RemoveHost(int hostId);
        public bool ReplaceHost(Host host);

        public List<Apartment> GetAllApartments();
        public Apartment? GetApartmentById(int id);
        public List<Apartment> GetApartmentsByHostId(int hostId);
        public bool AddApartment(int hostId, Apartment apartment);
        public bool RemoveApartment(int hostId, Apartment apartment);
        public bool ReplaceApartment(int hostId, Apartment apartment);

        public void Initialize(IEnumerable<Host> hosts);
    }
}
