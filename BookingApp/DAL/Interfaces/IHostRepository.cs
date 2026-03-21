using BookingApp.DAL.Entities;

namespace BookingApp.DAL.Interfaces
{
    internal interface IHostRepository
    {
        List<Host> GetAllHosts();
        Host? GetHostById(int id);
        List<Apartment> GetAllApartments();
        List<Apartment> GetApartmentsByHostId(int hostId);
        Apartment? GetApartmentById(int id);
    }
}
