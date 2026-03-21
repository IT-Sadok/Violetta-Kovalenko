using BookingApp.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.BBL.Interfaces
{
    internal interface IHostService
    {
        public List<Host> GetAllHosts();
        public Host? GetHostById(int id);
        public bool CreateHost(Host host);
        public bool UpdateHost(Host host);
        public bool DeleteHost(int id);
    }
}   
