using BookingApp.BBL.Interfaces;
using BookingApp.DAL.Entities;
using BookingApp.DAL.Enums;
using System.Globalization;
using System.Linq;
using System.Text;

namespace BookingApp.UI
{
    internal class ConsoleBooking
    {
        private readonly IHostService _hostService;

        public ConsoleBooking(IHostService hostService)
        {
            _hostService = hostService;
        }

        public void Start()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== СИСТЕМА БРОНЮВАННЯ ===");
                Console.WriteLine("1. Хости");
                Console.WriteLine("2. Апартаменти");
                Console.WriteLine("0. Вийти");
                Console.Write("\nОберіть: ");

                switch (Console.ReadLine())
                {
                    case "1": MenuHosts(); break;
                    case "2": MenuApartments(); break;
                    case "0": return;
                    default: Pause("Невірний вибір"); break;
                }
            }
        }

        private void MenuHosts()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== ХОСТИ ===");
                Console.WriteLine("1. Список хостів");
                Console.WriteLine("2. Переглянути хоста");
                Console.WriteLine("3. Додати");
                Console.WriteLine("4. Редагувати");
                Console.WriteLine("5. Видалити");
                Console.WriteLine("0. Назад");
                Console.Write("\nОберіть: ");

                switch (Console.ReadLine())
                {
                    case "1": ShowHosts(); break;
                    case "2": ViewHost(); break;
                    case "3": CreateHost(); break;
                    case "4": UpdateHost(); break;
                    case "5": DeleteHost(); break;
                    case "0": return;
                    default: Pause("Невірний вибір"); break;
                }
            }
        }

        private void ShowHosts()
        {
            Console.Clear();
            var hosts = _hostService.GetAllHosts();

            if (hosts.Count == 0)
            {
                Pause("Хости відсутні.");
                return;
            }

            Console.WriteLine("=== СПИСОК ХОСТІВ ===\n");
            foreach (var h in hosts)
            {
                Console.WriteLine($"{h.Id}. {h.DisplayName ?? h.FirstName + " " + h.LastName} | {h.Email} | Рейтинг: {h.Rating}");
            }

            Console.Write("\nID хоста (Enter - назад): ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                Console.Write("1 - деталі хоста, 2 - апартаменти: ");
                if (Console.ReadLine() == "1")
                    ShowHostDetails(id);
                else
                    ShowHostApartments(id);
            }
        }

        private void ViewHost()
        {
            Console.Clear();
            var hosts = _hostService.GetAllHosts();
            if (hosts.Count == 0) { Pause("Хости відсутні."); return; }

            foreach (var h in hosts) Console.WriteLine($"{h.Id}. {h.FirstName} {h.LastName}");
            int id = ParseInt(Input("\nID хоста")) ?? 0;
            ShowHostDetails(id);
        }

        private void ShowHostDetails(int id)
        {
            Console.Clear();
            var host = _hostService.GetHostById(id);

            if (host == null) { Pause("Не знайдено."); return; }

            Console.WriteLine($"=== {host.DisplayName ?? host.FirstName + " " + host.LastName} ===\n");
            Console.WriteLine($"Ім'я: {host.FirstName} {host.LastName}");
            Console.WriteLine($"Email: {host.Email}");
            Console.WriteLine($"Телефон: {host.PhoneNumber}");
            Console.WriteLine($"Рейтинг: {host.Rating} | Відгуків: {host.ReviewsCount}");
            if (!string.IsNullOrEmpty(host.Description))
                Console.WriteLine($"Опис: {host.Description}");

            Pause();
        }

        private void CreateHost()
        {
            Console.Clear();
            Console.WriteLine("=== ДОДАТИ ХОСТА ===\n");

            var host = new Host
            {
                FirstName = Input("Ім'я"),
                LastName = Input("Прізвище"),
                Email = Input("Email"),
                DisplayName = Input("Відображуване ім'я"),
                PhoneNumber = Input("Телефон"),
                Rating = ParseDouble(Input("Рейтинг")) ?? 0,
                ReviewsCount = ParseInt(Input("Відгуків")) ?? 0
            };

            if (_hostService.CreateHost(host))
                Pause("Додано!");
            else
                Pause("Помилка.");
        }

        private void UpdateHost()
        {
            Console.Clear();
            var hosts = _hostService.GetAllHosts();
            if (hosts.Count == 0) { Pause("Хости відсутні."); return; }

            foreach (var h in hosts) Console.WriteLine($"{h.Id}. {h.FirstName} {h.LastName}");
            int id = ParseInt(Input("\nID хоста")) ?? 0;
            var host = _hostService.GetHostById(id);

            if (host == null) { Pause("Не знайдено."); return; }

            host.FirstName = Input("Ім'я", host.FirstName);
            host.LastName = Input("Прізвище", host.LastName);
            host.Email = Input("Email", host.Email);
            host.DisplayName = Input("Відображуване ім'я", host.DisplayName);
            host.PhoneNumber = Input("Телефон", host.PhoneNumber);

            if (_hostService.UpdateHost(host))
                Pause("Оновлено!");
            else
                Pause("Помилка.");
        }

        private void DeleteHost()
        {
            Console.Clear();
            var hosts = _hostService.GetAllHosts();
            if (hosts.Count == 0) { Pause("Хости відсутні."); return; }

            foreach (var h in hosts) Console.WriteLine($"{h.Id}. {h.FirstName} {h.LastName}");
            int id = ParseInt(Input("\nID для видалення")) ?? 0;

            Console.Write("Підтвердити (так/ні): ");
            if (Console.ReadLine()?.ToLower() == "так" && _hostService.DeleteHost(id))
                Pause("Видалено!");
            else
                Pause("Скасовано або помилка.");
        }

        private void MenuApartments()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== АПАРТАМЕНТИ ===");
                Console.WriteLine("1. Всі апартаменти");
                Console.WriteLine("2. За хостом");
                Console.WriteLine("3. Переглянути апартамент");
                Console.WriteLine("4. Додати");
                Console.WriteLine("5. Редагувати");
                Console.WriteLine("6. Видалити");
                Console.WriteLine("0. Назад");
                Console.Write("\nОберіть: ");

                switch (Console.ReadLine())
                {
                    case "1": ShowAllApartments(); break;
                    case "2": ShowApartmentsByHost(); break;
                    case "3": ViewApartment(); break;
                    case "4": CreateApartment(); break;
                    case "5": UpdateApartment(); break;
                    case "6": DeleteApartment(); break;
                    case "0": return;
                    default: Pause("Невірний вибір"); break;
                }
            }
        }

        private void ShowAllApartments()
        {
            Console.Clear();
            var list = _hostService.GetAllApartments();

            if (list.Count == 0) { Pause("Апартаменти відсутні."); return; }

            Console.WriteLine("=== ВСІ АПАРТАМЕНТИ ===\n");
            foreach (var a in list)
                Console.WriteLine($"{a.Id}. {a.Title} | {a.PricePerNight} {a.Currency} | {a.Address.City}");

            Console.Write("\nID для деталей (Enter - назад): ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                ShowApartmentDetails(list.FirstOrDefault(a => a.Id == id));
            }
        }

        private void ViewApartment()
        {
            Console.Clear();
            var list = _hostService.GetAllApartments();
            if (list.Count == 0) { Pause("Апартаменти відсутні."); return; }

            foreach (var a in list) Console.WriteLine($"{a.Id}. {a.Title}");
            int id = ParseInt(Input("\nID апартаменту")) ?? 0;
            var apt = list.FirstOrDefault(a => a.Id == id);
            ShowApartmentDetails(apt);
        }

        private void ShowApartmentsByHost()
        {
            Console.Clear();
            var hosts = _hostService.GetAllHosts();
            if (hosts.Count == 0) { Pause("Хости відсутні."); return; }

            foreach (var h in hosts) Console.WriteLine($"{h.Id}. {h.FirstName} {h.LastName}");
            int hostId = ParseInt(Input("\nID хоста")) ?? 0;
            ShowHostApartments(hostId);
        }

        private void ShowHostApartments(int hostId)
        {
            Console.Clear();
            var list = _hostService.GetApartmentsByHostId(hostId);

            if (list.Count == 0) { Pause("Немає апартаментів."); return; }

            Console.WriteLine("=== АПАРТАМЕНТИ ХОСТА ===\n");
            foreach (var a in list)
                Console.WriteLine($"{a.Id}. {a.Title} | {a.PricePerNight} {a.Currency}");

            Console.Write("\nID для деталей (Enter - назад): ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var apt = list.FirstOrDefault(a => a.Id == id);
                ShowApartmentDetails(apt);
            }
        }

        private static void ShowApartmentDetails(Apartment? apt)
        {
            Console.Clear();

            if (apt == null) { Pause("Не знайдено."); return; }

            Console.WriteLine($"=== {apt.Title} ===\n");
            Console.WriteLine($"Тип: {apt.Type} | Місто: {apt.Address.City}");
            Console.WriteLine($"Гостей: {apt.MaxGuests} | Спальні: {apt.Bedrooms} | Ліжка: {apt.Beds}");
            Console.WriteLine($"Ціна: {apt.PricePerNight} {apt.Currency}/ніч");
            Console.WriteLine($"Рейтинг: {apt.Rating} | Відгуків: {apt.ReviewsCount}");
            Console.WriteLine($"Доступний: {(apt.IsAvailable ? "Так" : "Ні")}");

            Pause();
        }

        private void CreateApartment()
        {
            Console.Clear();
            Console.WriteLine("=== ДОДАТИ АПАРТАМЕНТ ===\n");

            var hosts = _hostService.GetAllHosts();
            if (hosts.Count == 0) { Pause("Спочатку додайте хоста."); return; }
            foreach (var h in hosts) Console.WriteLine($"{h.Id}. {h.FirstName} {h.LastName}");

            int hostId = ParseInt(Input("\nID хоста")) ?? 0;
            if (_hostService.GetHostById(hostId) == null) { Pause("Хоста не знайдено."); return; }

            var apt = new Apartment
            {
                HostId = hostId,
                Title = Input("Назва"),
                Description = Input("Опис"),
                Type = ApartmentType.Apartment,
                Address = new Address
                {
                    Country = Input("Країна"),
                    City = Input("Місто"),
                    Street = Input("Вулиця"),
                    BuildingNumber = Input("Номер будинку"),
                    PostalCode = Input("Індекс")
                },
                MaxGuests = ParseInt(Input("Макс. гостей")) ?? 2,
                Bedrooms = ParseInt(Input("Спальні")) ?? 1,
                Beds = ParseInt(Input("Ліжка")) ?? 1,
                Bathrooms = ParseInt(Input("Ванні")) ?? 1,
                Area = ParseDouble(Input("Площа")) ?? 50,
                PricePerNight = ParseDecimal(Input("Ціна за ніч")) ?? 1000,
                Currency = Currency.UAH,
                Rating = ParseDouble(Input("Рейтинг")) ?? 0,
                ReviewsCount = ParseInt(Input("Відгуків")) ?? 0,
                IsAvailable = true
            };

            if (_hostService.CreateApartment(hostId, apt))
                Pause("Додано!");
            else
                Pause("Помилка (перевірте ID хоста).");
        }

        private void UpdateApartment()
        {
            Console.Clear();
            var list = _hostService.GetAllApartments();
            if (list.Count == 0) { Pause("Апартаменти відсутні."); return; }

            foreach (var a in list) Console.WriteLine($"{a.Id}. {a.Title}");
            int id = ParseInt(Input("\nID апартаменту")) ?? 0;
            var apt = list.FirstOrDefault(a => a.Id == id);

            if (apt == null) { Pause("Не знайдено."); return; }

            apt.Title = Input("Назва", apt.Title);
            apt.Description = Input("Опис", apt.Description);
            apt.MaxGuests = ParseInt(Input("Макс. гостей", apt.MaxGuests.ToString())) ?? apt.MaxGuests;
            apt.PricePerNight = ParseDecimal(Input("Ціна", apt.PricePerNight.ToString())) ?? apt.PricePerNight;
            apt.IsAvailable = Input("Доступний (так/ні)", apt.IsAvailable ? "так" : "ні").ToLower() == "так";

            if (_hostService.UpdateApartment(apt.HostId, apt))
                Pause("Оновлено!");
            else
                Pause("Помилка.");
        }

        private void DeleteApartment()
        {
            Console.Clear();
            var list = _hostService.GetAllApartments();
            if (list.Count == 0) { Pause("Апартаменти відсутні."); return; }

            foreach (var a in list) Console.WriteLine($"{a.Id}. {a.Title}");
            int id = ParseInt(Input("\nID для видалення")) ?? 0;
            var apt = list.FirstOrDefault(a => a.Id == id);
            if (apt == null) { Pause("Не знайдено."); return; }

            Console.Write("Підтвердити (так/ні): ");
            if (Console.ReadLine()?.ToLower() == "так" && _hostService.DeleteApartment(apt.HostId, apt))
                Pause("Видалено!");
            else
                Pause("Скасовано або помилка.");
        }

        private static string Input(string prompt, string? defaultValue = null)
        {
            Console.Write($"{prompt}" + (defaultValue != null ? $" [{defaultValue}]" : "") + ": ");
            var s = Console.ReadLine();
            return string.IsNullOrWhiteSpace(s) && defaultValue != null ? defaultValue : (s ?? "");
        }

        private static int? ParseInt(string s)
        {
            return int.TryParse(s?.Trim(), out int v) ? v : null;
        }

        private static double? ParseDouble(string s)
        {
            return double.TryParse(s?.Trim().Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out double v) ? v : null;
        }

        private static decimal? ParseDecimal(string s)
        {
            return decimal.TryParse(s?.Trim().Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out decimal v) ? v : null;
        }

        private static void Pause(string? msg = null)
        {
            if (msg != null) Console.WriteLine("\n" + msg);
            Console.WriteLine("\nНатисніть клавішу...");
            Console.ReadKey();
        }
    }
}
