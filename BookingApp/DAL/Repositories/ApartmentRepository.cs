using BookingApp.DAL.Interfaces;
using BookingApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.DAL.Repositories
{
    internal class ApartmentRepository : IApartmentRepository
    {
        private readonly IHostRepository _hostRepository;

        public ApartmentRepository(IHostRepository hostRepository)
        {
            _hostRepository = hostRepository;
        }
        public List<Apartment> GetAllApartmentByHostId(int id)
        {
            Host? hostbyId = _hostRepository.GetHostById(id);

            return hostbyId?.Apartments?.ToList() ?? new List<Apartment>();
        }

        public List<Apartment> GetAllApartments()
        {
            List<Host> hosts = _hostRepository.GetAllHosts();

            return hosts
                .SelectMany(h => h.Apartments ?? new List<Apartment>())
                .ToList();
        }

        public Apartment? GetApartmentById(int id)
        {
            List<Host> hosts = _hostRepository.GetAllHosts();

            return hosts.SelectMany(h => h.Apartments ?? new List<Apartment>())
                .FirstOrDefault(a => a.Id == id);
        }
    }
}
