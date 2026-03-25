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

        public List<Apartment> GetAllApartmentsByHostId(int id)
        {
            return _hostRepository.GetApartmentsByHostId(id);
        }

        public List<Apartment> GetAllApartments() => _hostRepository.GetAllApartments();
        public Apartment? GetApartmentById(int id)
        {
            return _hostRepository.GetApartmentById(id);
        }

        public bool CreateApartment(Apartment apartment)
        {
            return _hostRepository.CreateApartment(apartment);
        }

        public bool DeleteApartment(int id)
        {
            return _hostRepository.DeleteApartment(id);
        }

        public bool UpdateApartment(Apartment apartment)
        {
            return _hostRepository.UpdateApartment(apartment);
        }

        public List<Apartment> GetAllApartmentByHostId(int id)
        {
            return _hostRepository.GetApartmentsByHostId(id);
        }


    }
}
