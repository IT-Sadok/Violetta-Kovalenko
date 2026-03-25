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
            storage.Initialize(BookingSystemSeeder.GetHosts());

            var hostRepository = new HostRepository(storage);

            var hostService = new HostService(hostRepository);
            var apartmentService = new ApartmentService(hostRepository);

            var ui = new ConsoleBooking(hostService, apartmentService);

            ui.Start();
        }
    }
}
