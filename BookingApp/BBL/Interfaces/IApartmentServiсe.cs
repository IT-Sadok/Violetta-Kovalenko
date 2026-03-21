using BookingApp.DAL.Entities;
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
        public List<Apartment> GetAllApartmentByHostId(int id);
        public Apartment? GetApartmentById(int id);
    }
}
