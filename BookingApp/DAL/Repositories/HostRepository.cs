using BookingApp.DAL.Data;
using BookingApp.DAL.Interfaces;
using BookingApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.DAL.Repositories
{
    internal class HostRepository : IHostRepository
    {
        private readonly List<Host> _host;
        public HostRepository() 
        {
            _host = DataSeederForBookingSystem.GetHosts();
        }

        public List<Host> GetAllHosts()
        {
            return _host;
        }

        public Host? GetHostById(int id)
        {
            return _host.FirstOrDefault(h => h.Id == id);
        }
    }
}
