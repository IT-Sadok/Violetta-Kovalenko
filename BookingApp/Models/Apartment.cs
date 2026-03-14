using BookingApp.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Models
{
    internal class Apartment
    {
        public int Id { get; set; }
        public int HostId { get; set; }

        public required string Title { get; set; }
        public string? Description { get; set; }
        public ApartmentType Type { get; set; }

        public required Address Address { get; set; }

        public int MaxGuests { get; set; }
        public int Bedrooms { get; set; }
        public int Beds { get; set; }
        public int Bathrooms { get; set; }
        public double Area { get; set; }

        public decimal PricePerNight { get; set; }
        public Currency Currency { get; set; }

        public double Rating { get; set; }
        public int ReviewsCount { get; set; }
        public bool IsAvailable { get; set; }

        public List<Facilities>? Facilities { get; set; }

        
    }
}
