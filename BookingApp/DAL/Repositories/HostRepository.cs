using BookingApp.DAL.Data;
using BookingApp.DAL.Entities;
using BookingApp.DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace BookingApp.DAL.Repositories
{
    internal class HostRepository : IHostRepository
    {
        private readonly List<Host> _hosts;

        public HostRepository()
        {
            _hosts = DataSeederForBookingSystem.GetHosts();
        }

        public List<Host> GetAllHosts() => _hosts;

        public Host? GetHostById(int id) => _hosts.FirstOrDefault(h => h.Id == id);

        public List<Apartment> GetAllApartments() =>
            _hosts.SelectMany(h => h.Apartments ?? new List<Apartment>()).ToList();

        public List<Apartment> GetApartmentsByHostId(int hostId) =>
            GetHostById(hostId)?.Apartments?.ToList() ?? new List<Apartment>();

        public Apartment? GetApartmentById(int id) =>
            _hosts.SelectMany(h => h.Apartments ?? new List<Apartment>()).FirstOrDefault(a => a.Id == id);
    }
}
