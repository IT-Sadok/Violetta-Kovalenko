using BookingApp.DAL.Entities;
using BookingApp.DAL.Interfaces;
using BookingApp.DAL.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace BookingApp.DAL.Storage
{
    internal sealed class InMemoryStorage : IInMemoryStorage
    {
        private readonly List<Host> _hosts = new();
        public IReadOnlyList<Host> Hosts => _hosts;

        public bool AddHost(Host host)
        {
            if (host == null)
            {
                throw new ArgumentNullException(nameof(host));
            }
            _hosts.Add(host);
            return true;
        }

        public bool ReplaceHost(Host host)
        {
            if (host == null)
            {
                throw new ArgumentNullException(nameof(host));
            }

            var index = _hosts.FindIndex(h => h.Id == host.Id);
            if (index < 0)
                return false;

            _hosts[index] = host;
            return true;
        }

        public bool RemoveHost(int hostId)
        {
            if(hostId < 0)
            {
                throw new ArgumentNullException(nameof(hostId));
            }

            Host? currentHost = _hosts.FirstOrDefault(h => h.Id == hostId);
            if (currentHost == null)
            {
                return false;
            }

            return _hosts.Remove(currentHost);
        }

        public void Initialize(IEnumerable<Host> hosts)
        {
            if (hosts == null)
            {
                throw new ArgumentNullException(nameof(hosts));
            }

            _hosts.Clear();
            _hosts.AddRange(hosts);
        }

        public bool AddApartment(int idHost, Apartment apartment)
        {
            if(idHost < 0 && apartment == null) 
            {  
                throw new ArgumentNullException(nameof(apartment));
            }

            Host? currentHost = _hosts.FirstOrDefault(a => a.Id == idHost);

            if(currentHost == null)
            {
                return false;
            }

            currentHost.Apartments?.Add(apartment);

            return true;
        }

        public bool RemoveApartment(int idHost, Apartment apartment)
        {
            if(idHost < 0 &&  apartment == null)
            {
                throw new ArgumentNullException(nameof(apartment));

            }

            Host? currentHost = _hosts.FirstOrDefault(h => h.Id == idHost);

            if (currentHost == null)
            {
                return false;
            }

            currentHost.Apartments?.Remove(apartment);

            return true;
        }

        public bool ReplaceApartment(int idHost, Apartment apartment)
        {
            if (idHost < 0 && apartment == null)
            {
                throw new ArgumentNullException(nameof(apartment));

            }

            Host? currentHost = _hosts.FirstOrDefault(h => h.Id == idHost);

            if (currentHost == null)
            {
                return false;
            }

            currentHost.Apartments[apartment.Id] = apartment;

            return true;
        }
    }
}
