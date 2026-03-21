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

            var hostService = new HostService(hostRepository);
            var apartmentService = new ApartmentService(hostRepository);

            var ui = new ConsoleBooking(hostService, apartmentService);

            ui.Start();
        }
    }
}
