
//using BookingApp.Models;
using BookingApp.DAL.Entities;

namespace BookingApp.DAL.Interfaces
{
    internal interface IHostRepository
    {
        public List<Host> GetAllHosts();
        public Host? GetHostById(int id);
        public bool CreateHost(Host host);
        public bool UpdateHost(Host host);
        public bool DeleteHost(int id);
        public List<Apartment> GetAllApartments();
        public List<Apartment> GetApartmentsByHostId(int hostId);
        public Apartment? GetApartmentById(int id);
    }
}
