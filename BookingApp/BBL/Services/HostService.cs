using BookingApp.BBL.Interfaces;
using BookingApp.DAL.Interfaces;
using BookingApp.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.BBL.Services
{
    internal class HostService : IHostService
    {
        private readonly IHostRepository _hostRepository;

        public HostService(IHostRepository hostRepository)
        {
            _hostRepository = hostRepository;
        }
        public List<Host> GetAllHosts()
        {
            return _hostRepository.GetAllHosts();
        }

        public Host? GetHostById(int id)
        {
            if(id <= 0)
            {
                return null;
            }

            return _hostRepository.GetHostById(id);
        }
    }
}
