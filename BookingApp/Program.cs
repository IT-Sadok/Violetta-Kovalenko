using BookingApp.BBL.Services;
using BookingApp.DAL.Data;
using BookingApp.DAL.Interfaces;
using BookingApp.DAL.Repositories;
using BookingApp.UI;

namespace BookingApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IRepository repository = new InMemoryRepository();
            repository.Initialize(BookingSystemSeeder.GetHosts());

            var hostService = new HostService(repository);

            var ui = new ConsoleBooking(hostService);

            ui.Start();
        }
    }
}
