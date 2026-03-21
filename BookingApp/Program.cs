using BookingApp.BBL.Services;
<<<<<<< HEAD
using BookingApp.Data.Seeders;
using BookingApp.DAL.Interfaces;
=======
>>>>>>> feature/homework-1
using BookingApp.DAL.Repositories;
using BookingApp.DAL.Storage;
using BookingApp.UI;

namespace BookingApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
<<<<<<< HEAD
            IInMemoryStorage storage = new InMemoryStorage();
            storage.Initialize(BookingSystemSeeder.GetHosts(), BookingSystemSeeder.GetApartments());

            var hostRepository = new HostRepository(storage);
            var apartmentRepository = new ApartmentRepository(storage);
=======
            var hostRepository = new HostRepository();
>>>>>>> feature/homework-1

            var hostService = new HostService(hostRepository);
            var apartmentService = new ApartmentService(hostRepository);

            var ui = new ConsoleBooking(hostService, apartmentService);

            ui.Start();
        }
    }
}
