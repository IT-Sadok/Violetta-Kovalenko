using BookingApp.Models;

namespace BookingApp.DAL.Interfaces
{
    internal interface IInMemoryStorage
    {
        IReadOnlyList<Host> Hosts { get; }
        IReadOnlyList<Apartment> Apartments { get; }

        bool AddHost(Host host);
        bool RemoveHost(int hostId);
        bool ReplaceHost(Host host);
        bool AddApartment(Apartment apartment);
        bool RemoveApartment(int apartmentId);
        bool ReplaceApartment(Apartment apartment);

        void Initialize(IEnumerable<Host> hosts, IEnumerable<Apartment> apartments);
    }
}
