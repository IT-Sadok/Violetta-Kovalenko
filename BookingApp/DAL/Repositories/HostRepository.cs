using BookingApp.DAL.Interfaces;
using BookingApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace BookingApp.DAL.Repositories
{
    internal class HostRepository : IHostRepository
    {
        private readonly IInMemoryStorage _storage;

        public HostRepository(IInMemoryStorage storage)
        {
            _storage = storage ?? throw new ArgumentNullException(nameof(storage));
        }

        public List<Host> GetAllHosts()
        {
            return _storage.Hosts.ToList();
        }

        public Host? GetHostById(int id)
        {
            if (id <= 0)
            {
                return null;
            }
            return _storage.Hosts.FirstOrDefault(h => h.Id == id);
        }

        public bool CreateHost(Host host)
        {
            if (host == null)
            {
                throw new ArgumentNullException(nameof(host));
            }

            if (host.Id != 0 && GetHostById(host.Id) != null)
            {
                return false;
            }

            if (host.Id == 0)
            {
                host.Id = GetNextHostId();
            }

            return _storage.AddHost(host);
        }

        private int GetNextHostId()
        {
            var maxId = _storage.Hosts.Count > 0 ? _storage.Hosts.Max(h => h.Id) : 0;
            return maxId + 1;
        }

        public bool UpdateHost(Host host)
        {
            if (host == null)
            {
                throw new ArgumentNullException(nameof(host));
            }
            return _storage.ReplaceHost(host);
        }

        public bool DeleteHost(int id)
        {
            if (id <= 0)
            {
                return false;
            }
            return _storage.RemoveHost(id);
        }
    }
}
