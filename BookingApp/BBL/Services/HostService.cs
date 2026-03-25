using BookingApp.BBL.Interfaces;
using BookingApp.DAL.Interfaces;
using BookingApp.DAL.Entities;

namespace BookingApp.BBL.Services
{
    internal class HostService : IHostService
    {
        private readonly IRepository _repository;

        public HostService(IRepository repository)
        {
            _repository = repository;
        }

        public bool CreateHost(Host host) => _repository.AddHost(host);

        public bool DeleteHost(int id) => _repository.RemoveHost(id);

        public List<Host> GetAllHosts() => _repository.GetAllHosts();

        public Host? GetHostById(int id) => _repository.GetHostById(id);

        public bool UpdateHost(Host host) => _repository.ReplaceHost(host);

        public List<Apartment> GetAllApartments() => _repository.GetAllApartments();

        public Apartment? GetApartmentById(int id) => _repository.GetApartmentById(id);

        public List<Apartment> GetApartmentsByHostId(int hostId) => _repository.GetApartmentsByHostId(hostId);

        public bool CreateApartment(int hostId, Apartment apartment) => _repository.AddApartment(hostId, apartment);

        public bool UpdateApartment(int hostId, Apartment apartment) => _repository.ReplaceApartment(hostId, apartment);

        public bool DeleteApartment(int hostId, Apartment apartment) => _repository.RemoveApartment(hostId, apartment);
    }
}
