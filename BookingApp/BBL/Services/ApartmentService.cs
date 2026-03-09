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
        public List<Apartment> GetAllApartmentByHostId(int id)
        {
            return _apartmentRepository.GetAllApartmentByHostId(id);
        }

        public List<Apartment> GetAllApartments()
        {
            return _apartmentRepository.GetAllApartments();
        }

        public Apartment? GetApartmentById(int id)
        {
            if( id <= 0 )
            {
                return null;
            }

            return _apartmentRepository.GetApartmentById(id);
        }
    }
}
