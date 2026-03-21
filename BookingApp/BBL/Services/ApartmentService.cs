using BookingApp.BBL.Interfaces;
using BookingApp.DAL.Entities;
using BookingApp.DAL.Interfaces;

namespace BookingApp.BBL.Services
{
    internal class ApartmentService : IApartmentServiсe
    {
        private readonly IHostRepository _hostRepository;

        public ApartmentService(IHostRepository hostRepository)
        {
            _hostRepository = hostRepository;
        }

        public List<Apartment> GetAllApartments() => _hostRepository.GetAllApartments();

        public List<Apartment> GetAllApartmentByHostId(int id) => _hostRepository.GetApartmentsByHostId(id);

        public Apartment? GetApartmentById(int id) => id <= 0 ? null : _hostRepository.GetApartmentById(id);
    }
}
