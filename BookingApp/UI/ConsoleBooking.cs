using BookingApp.BBL.Interfaces;
using BookingApp.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.UI
{
    internal class ConsoleBooking
    {
        private readonly IHostService _hostService;
        private readonly IApartmentServiсe _apartmentService;

        public ConsoleBooking(IHostService hostService, IApartmentServiсe apartmentService)
        {
            _hostService = hostService;
            _apartmentService = apartmentService;
        }

        public void Start()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;

            while (true)
            {
                Console.Clear();

                Console.WriteLine("=== СИСТЕМА БРОНЮВАННЯ ===");
                Console.WriteLine("1. Переглянути всіх хостів");
                Console.WriteLine("2. Переглянути всі апартаменти");
                Console.WriteLine("0. Вийти");
                Console.WriteLine();

                Console.Write("Оберіть дію: ");
                string? choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ShowHosts();
                        break;

                    case "2":
                        ShowAllApartments();
                        break;

                    case "0":
                        return;

                    default:
                        Console.WriteLine("Невірний вибір.");
                        Pause();
                        break;
                }
            }
        }

        private void ShowHosts()
        {
            Console.Clear();

            List<Host> hosts = _hostService.GetAllHosts();

            if (!hosts.Any())
            {
                Console.WriteLine("Хости відсутні.");
                Pause();
                return;
            }

            Console.WriteLine("=== СПИСОК ХОСТІВ ===");

            foreach (var host in hosts)
            {
                Console.WriteLine($"{host.Id}. {host.DisplayName ?? $"{host.FirstName} {host.LastName}"} | Рейтинг: {host.Rating}");
            }

            Console.WriteLine();
            Console.Write("Введіть ID хоста щоб переглянути його апартаменти: ");

            if (!int.TryParse(Console.ReadLine(), out int hostId))
            {
                Console.WriteLine("Некоректний ID.");
                Pause();
                return;
            }

            ShowHostApartments(hostId);
        }

        private void ShowHostApartments(int hostId)
        {
            Console.Clear();

            List<Apartment> apartments = _apartmentService.GetAllApartmentByHostId(hostId);

            if (!apartments.Any())
            {
                Console.WriteLine("У цього хоста немає апартаментів.");
                Pause();
                return;
            }

            Console.WriteLine("=== АПАРТАМЕНТИ ХОСТА ===");

            foreach (var apartment in apartments)
            {
                Console.WriteLine($"{apartment.Id}. {apartment.Title} | {apartment.PricePerNight} {apartment.Currency}");
            }

            Console.WriteLine();
            Console.Write("Введіть ID апартаменту щоб переглянути деталі: ");

            if (!int.TryParse(Console.ReadLine(), out int apartmentId))
            {
                Console.WriteLine("Некоректний ID.");
                Pause();
                return;
            }

            ShowApartmentDetails(apartmentId);
        }

        private void ShowAllApartments()
        {
            Console.Clear();

            List<Apartment> apartments = _apartmentService.GetAllApartments();

            Console.WriteLine("=== ВСІ АПАРТАМЕНТИ ===");

            foreach (var apartment in apartments)
            {
                Console.WriteLine($"{apartment.Id}. {apartment.Title} | {apartment.PricePerNight} {apartment.Currency}");
            }

            Pause();
        }

        private void ShowApartmentDetails(int apartmentId)
        {
            Console.Clear();

            Apartment? apartment = _apartmentService.GetApartmentById(apartmentId);

            if (apartment == null)
            {
                Console.WriteLine("Апартамент не знайдено.");
                Pause();
                return;
            }

            Console.WriteLine("=== ІНФОРМАЦІЯ ПРО АПАРТАМЕНТ ===");

            Console.WriteLine($"Назва: {apartment.Title}");
            Console.WriteLine($"Тип: {apartment.Type}");
            Console.WriteLine($"Адреса: {apartment.Address.City}, {apartment.Address.Street}");
            Console.WriteLine($"Макс. гостей: {apartment.MaxGuests}");
            Console.WriteLine($"Спальні: {apartment.Bedrooms}");
            Console.WriteLine($"Ліжка: {apartment.Beds}");
            Console.WriteLine($"Ванні кімнати: {apartment.Bathrooms}");
            Console.WriteLine($"Площа: {apartment.Area} м²");

            Console.WriteLine($"Ціна за ніч: {apartment.PricePerNight} {apartment.Currency}");
            Console.WriteLine($"Рейтинг: {apartment.Rating} ({apartment.ReviewsCount} відгуків)");

            Console.WriteLine($"Доступність: {(apartment.IsAvailable ? "Доступний" : "Недоступний")}");

            if (apartment.Facilities != null)
            {
                Console.WriteLine("Зручності:");

                foreach (var facility in apartment.Facilities)
                {
                    Console.WriteLine($"- {facility}");
                }
            }

            Pause();
        }

        private void Pause()
        {
            Console.WriteLine();
            Console.WriteLine("Натисніть будь-яку клавішу для продовження...");
            Console.ReadKey();
        }
    }
}

