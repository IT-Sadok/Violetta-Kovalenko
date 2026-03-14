using BookingApp.BBL.Services;
using BookingApp.Data.Seeders;
using BookingApp.DAL.Interfaces;
using BookingApp.DAL.Repositories;
using BookingApp.DAL.Storage;
using BookingApp.UI;

namespace BookingApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IInMemoryStorage storage = new InMemoryStorage();
            storage.Initialize(BookingSystemSeeder.GetHosts(), BookingSystemSeeder.GetApartments());

            var hostRepository = new HostRepository(storage);
            var apartmentRepository = new ApartmentRepository(storage);

            var hostService = new HostService(hostRepository);
            var apartmentService = new ApartmentService(apartmentRepository);

            var ui = new ConsoleBooking(hostService, apartmentService);

            ui.Start();
        }
    }
}
