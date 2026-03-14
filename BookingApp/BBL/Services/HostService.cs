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
    internal class HostService : IHostService
    {
        private readonly IHostRepository _hostRepository;

        public HostService(IHostRepository hostRepository)
        {
            _hostRepository = hostRepository;
        }

        public bool CreateHost(Host host)
        {
            return _hostRepository.CreateHost(host);
        }

        public bool DeleteHost(int id)
        {
            return _hostRepository.DeleteHost(id);
        }

        public List<Host> GetAllHosts()
        {
            return _hostRepository.GetAllHosts();
        }

        public Host? GetHostById(int id)
        {
            return _hostRepository.GetHostById(id);
        }

        public bool UpdateHost(Host host)
        {
            return _hostRepository.UpdateHost(host);
        }
    }
}
