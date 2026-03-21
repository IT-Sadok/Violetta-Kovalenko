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
<<<<<<< HEAD
            _apartmentRepository = apartmentRepository;
        }

        public List<Apartment> GetAllApartmentsByHostId(int id)
        {
            return _apartmentRepository.GetAllApartmentsByHostId(id);
=======
            _hostRepository = hostRepository;
>>>>>>> feature/homework-1
        }

        public List<Apartment> GetAllApartments() => _hostRepository.GetAllApartments();

<<<<<<< HEAD
        public Apartment? GetApartmentById(int id)
        {
            return _apartmentRepository.GetApartmentById(id);
        }

                public bool CreateApartment(Apartment apartment)
        {
            return _apartmentRepository.CreateApartment(apartment);
        }

        public bool DeleteApartment(int id)
        {
            return _apartmentRepository.DeleteApartment(id);
        }

        public bool UpdateApartment(Apartment apartment)
        {
            return _apartmentRepository.UpdateApartment(apartment);
        }

=======
        public List<Apartment> GetAllApartmentByHostId(int id) => _hostRepository.GetApartmentsByHostId(id);

        public Apartment? GetApartmentById(int id) => id <= 0 ? null : _hostRepository.GetApartmentById(id);
>>>>>>> feature/homework-1
    }
}
