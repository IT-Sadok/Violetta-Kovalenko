using BookingApp.BBL.Services;
using BookingApp.DAL.Repositories;
using BookingApp.UI;
using System;

namespace BookingApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var hostRepository = new HostRepository();
            var apartmentRepository = new ApartmentRepository(hostRepository);

            var hostService = new HostService(hostRepository);
            var apartmentService = new ApartmentService(apartmentRepository);

            var ui = new ConsoleBooking(hostService, apartmentService);

            ui.Start();
        }
    }
}
