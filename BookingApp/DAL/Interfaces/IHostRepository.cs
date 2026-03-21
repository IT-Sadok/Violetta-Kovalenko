using BookingApp.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.DAL.Interfaces
{
    internal interface IHostRepository
    {
        public List<Host> GetAllHosts();
        public Host? GetHostById(int id);
    }
}
