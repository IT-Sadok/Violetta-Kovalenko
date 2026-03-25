using BookingApp.DAL.Entities;
using BookingApp.DAL.Interfaces;
using System.Linq;

namespace BookingApp.DAL.Repositories
{
    internal sealed class InMemoryRepository : IRepository
    {
        private readonly List<Host> _hosts = new();

        public List<Host> GetAllHosts()
        {
            return _hosts.ToList();
        }

        public Host? GetHostById(int id)
        {
            if (id <= 0)
            {
                return null;
            }
            return _hosts.FirstOrDefault(h => h.Id == id);
        }

        public bool AddHost(Host host)
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
                host.Id = _hosts.Count == 0 ? 1 : _hosts.Max(h => h.Id) + 1;
            }

            host.Apartments ??= new List<Apartment>();
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
            if (hostId <= 0)
            {
                return false;
            }

            Host? currentHost = _hosts.FirstOrDefault(h => h.Id == hostId);
            if (currentHost == null)
            {
                return false;
            }

            return _hosts.Remove(currentHost);
        }

        public List<Apartment> GetAllApartments()
        {
            return _hosts.SelectMany(h => h.Apartments ?? Enumerable.Empty<Apartment>()).ToList();
        }

        public Apartment? GetApartmentById(int id)
        {
            if (id <= 0)
            {
                return null;
            }

            return _hosts.SelectMany(h => h.Apartments ?? Enumerable.Empty<Apartment>())
                .FirstOrDefault(a => a.Id == id);
        }

        public List<Apartment> GetApartmentsByHostId(int hostId)
        {
            return GetHostById(hostId)?.Apartments?.ToList() ?? new List<Apartment>();
        }

        public bool AddApartment(int hostId, Apartment apartment)
        {
            if (apartment == null)
            {
                throw new ArgumentNullException(nameof(apartment));
            }

            if (hostId <= 0)
            {
                return false;
            }

            Host? currentHost = _hosts.FirstOrDefault(h => h.Id == hostId);

            if (currentHost == null)
            {
                return false;
            }

            currentHost.Apartments ??= new List<Apartment>();

            if (apartment.Id != 0 && GetApartmentById(apartment.Id) != null)
            {
                return false;
            }

            if (apartment.Id == 0)
            {
                apartment.Id = GetNextApartmentId();
            }

            currentHost.Apartments.Add(apartment);
            return true;
        }

        public bool RemoveApartment(int hostId, Apartment apartment)
        {
            if (apartment == null)
            {
                throw new ArgumentNullException(nameof(apartment));
            }

            if (hostId <= 0)
            {
                return false;
            }

            Host? currentHost = _hosts.FirstOrDefault(h => h.Id == hostId);

            if (currentHost == null)
            {
                return false;
            }

            return currentHost.Apartments?.Remove(apartment) == true;
        }

        public bool ReplaceApartment(int hostId, Apartment apartment)
        {
            if (apartment == null)
            {
                throw new ArgumentNullException(nameof(apartment));
            }

            if (hostId <= 0)
            {
                return false;
            }

            Host? currentHost = _hosts.FirstOrDefault(h => h.Id == hostId);

            if (currentHost?.Apartments == null)
            {
                return false;
            }

            var index = currentHost.Apartments.FindIndex(a => a.Id == apartment.Id);
            if (index < 0)
            {
                return false;
            }

            if (apartment.HostId != hostId)
            {
                apartment.HostId = hostId;
            }

            currentHost.Apartments[index] = apartment;
            return true;
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

        private int GetNextApartmentId()
        {
            var all = _hosts.SelectMany(h => h.Apartments ?? Enumerable.Empty<Apartment>());
            return all.Any() ? all.Max(a => a.Id) + 1 : 1;
        }
    }
}
