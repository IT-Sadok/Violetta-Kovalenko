using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.DAL.Entities
{
    internal class Host
    {
        public int Id { get; set; }

        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public string? DisplayName { get; set; }
        public string? Description { get; set; }

        public required string Email { get; set; }
        public string? PhoneNumber { get; set; }

        public double Rating { get; set; }
        public int ReviewsCount { get; set; }
    }
}
