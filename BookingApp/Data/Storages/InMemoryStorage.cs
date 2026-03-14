using BookingApp.DAL.Interfaces;
using BookingApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace BookingApp.DAL.Storage
{
    internal sealed class InMemoryStorage : IInMemoryStorage
    {
        private readonly List<Host> _hosts = new();
        private readonly List<Apartment> _apartments = new();

        public IReadOnlyList<Host> Hosts => _hosts;
        public IReadOnlyList<Apartment> Apartments => _apartments;

        public bool AddHost(Host host)
        {
            if (host == null)
            {
                throw new ArgumentNullException(nameof(host));
            }
            _hosts.Add(host);
            return true;
        }

        public bool RemoveHost(int hostId)
        {
            var host = _hosts.FirstOrDefault(h => h.Id == hostId);
            if (host == null)
            {
                return false;
            }

            _apartments.RemoveAll(a => a.HostId == hostId);
            _hosts.Remove(host);
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

        public bool AddApartment(Apartment apartment)
        {
            if (apartment == null)
            {
                throw new ArgumentNullException(nameof(apartment));
            }
            _apartments.Add(apartment);
            return true;
        }

        public bool RemoveApartment(int apartmentId)
        {
            var apartment = _apartments.FirstOrDefault(a => a.Id == apartmentId);
            if (apartment == null)
            {
                return false;
            }

            _apartments.Remove(apartment);
            return true;
        }

        public bool ReplaceApartment(Apartment apartment)
        {
            if (apartment == null)
            {
                throw new ArgumentNullException(nameof(apartment));
            }

            var index = _apartments.FindIndex(a => a.Id == apartment.Id);
            if (index < 0)
                return false;

            _apartments[index] = apartment;
            return true;
        }

        public void Initialize(IEnumerable<Host> hosts, IEnumerable<Apartment> apartments)
        {
            if (hosts == null)
            {
                throw new ArgumentNullException(nameof(hosts));
            }
            if (apartments == null)
            {
                throw new ArgumentNullException(nameof(apartments));
            }

            _hosts.Clear();
            _apartments.Clear();

            _hosts.AddRange(hosts);
            _apartments.AddRange(apartments);
        }
    }
}
