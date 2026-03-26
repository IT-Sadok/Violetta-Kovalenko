using BookingApp.BBL.Services;
using BookingApp.DAL.Data;
using BookingApp.DAL.Interfaces;
using BookingApp.DAL.Persistences;
using BookingApp.DAL.Repositories;
using BookingApp.UI;

namespace BookingApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string dataDir = Path.Combine(AppContext.BaseDirectory, "Data");
            string jsonPath = Path.Combine(dataDir, "booking-state.json");

            IBookingJsonPersistence persistence = new BookingJsonPersistence(jsonPath);
            IRepository repository = new InMemoryRepository();

            if (File.Exists(jsonPath))
            {
                repository.Initialize(persistence.Load());
            }
            else
            {
                repository.Initialize(BookingSystemSeeder.GetHosts());
            }

            var hostService = new HostService(repository, persistence);

            var ui = new ConsoleBooking(hostService);

            ui.Start();
        }
    }
}
