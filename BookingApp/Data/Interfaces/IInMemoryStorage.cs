using BookingApp.DAL.Entities;

namespace BookingApp.DAL.Interfaces
{
    internal interface IInMemoryStorage
    {
        public IReadOnlyList<Host> Hosts { get; }

        public bool AddHost(Host host);
        public bool RemoveHost(int hostId);
        public bool ReplaceHost(Host host);
        public bool AddApartment(int idHost, Apartment apartment);
        public bool RemoveApartment(int idHost, Apartment apartment);
        public bool ReplaceApartment(int idHost, Apartment apartment);

        public void Initialize(IEnumerable<Host> hosts);
    }
}
