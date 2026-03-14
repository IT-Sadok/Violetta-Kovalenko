using BookingApp.BBL.Interfaces;
using BookingApp.DAL.Interfaces;
using BookingApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.BBL.Services
{
    internal class ApartmentService : IApartmentServiсe
    {
        private readonly IApartmentRepository _apartmentRepository;

        public ApartmentService(IApartmentRepository apartmentRepository)
        {
            _apartmentRepository = apartmentRepository;
        }

        public List<Apartment> GetAllApartmentsByHostId(int id)
        {
            return _apartmentRepository.GetAllApartmentsByHostId(id);
        }

        public List<Apartment> GetAllApartments()
        {
            return _apartmentRepository.GetAllApartments();
        }

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

    }
}
