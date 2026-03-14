using BookingApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.BBL.Interfaces
{
    internal interface IApartmentServiсe
    {
        public List<Apartment> GetAllApartments();
        public List<Apartment> GetAllApartmentsByHostId(int id);
        public Apartment? GetApartmentById(int id);
        public bool CreateApartment(Apartment apartment);
        public bool UpdateApartment(Apartment apartment);
        public bool DeleteApartment(int id);
    }
}
