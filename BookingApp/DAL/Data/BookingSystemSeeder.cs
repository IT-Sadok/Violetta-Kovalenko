using BookingApp.DAL.Entities;
using BookingApp.DAL.Enums;

namespace BookingApp.DAL.Data
{
    internal static class BookingSystemSeeder
    {
        public static List<Host> GetHosts()
        {
            return new List<Host>
            {
                new Host
                {
                    Id = 1,
                    FirstName = "Олександр",
                    LastName = "Коваль",
                    DisplayName = "Олександр • Superhost",
                    Email = "oleksandr@example.com",
                    PhoneNumber = "+380501112233",
                    Rating = 4.9,
                    ReviewsCount = 134,
                    Apartments =
                    [
                        new Apartment
                        {
                            Id = 1,
                            HostId = 1,
                            Title = "Апартаменти в центрі Києва",
                            Description = "Сучасна квартира біля Майдану Незалежності.",
                            Type = ApartmentType.Apartment,
                            Address = new Address
                            {
                                Country = "Україна",
                                City = "Київ",
                                Street = "Хрещатик",
                                BuildingNumber = "15",
                                PostalCode = "01001"
                            },
                            MaxGuests = 4,
                            Bedrooms = 2,
                            Beds = 2,
                            Bathrooms = 1,
                            Area = 65,
                            PricePerNight = 2500,
                            Currency = Currency.UAH,
                            Rating = 9.4,
                            ReviewsCount = 87,
                            IsAvailable = true,
                            Facilities =
                            [
                                Facilities.WiFi,
                                Facilities.AirConditioning,
                                Facilities.Kitchen,
                                Facilities.WashingMachine,
                                Facilities.Parking,
                                Facilities.Balcony
                            ]
                        }
                    ]
                },
                new Host
                {
                    Id = 2,
                    FirstName = "Марія",
                    LastName = "Іваненко",
                    DisplayName = "Марія",
                    Email = "maria@example.com",
                    PhoneNumber = "+380671234567",
                    Rating = 4.8,
                    ReviewsCount = 98,
                    Apartments =
                    [
                        new Apartment
                        {
                            Id = 2,
                            HostId = 2,
                            Title = "Студія з видом на Дніпро",
                            Description = "Затишна студія з панорамними вікнами.",
                            Type = ApartmentType.Studio,
                            Address = new Address
                            {
                                Country = "Україна",
                                City = "Київ",
                                Street = "Набережне шосе",
                                BuildingNumber = "8",
                                PostalCode = "04070"
                            },
                            MaxGuests = 2,
                            Bedrooms = 1,
                            Beds = 1,
                            Bathrooms = 1,
                            Area = 40,
                            PricePerNight = 1800,
                            Currency = Currency.UAH,
                            Rating = 9.1,
                            ReviewsCount = 45,
                            IsAvailable = true,
                            Facilities =
                            [
                                Facilities.WiFi,
                                Facilities.SeaView,
                                Facilities.SmartTV,
                                Facilities.Elevator
                            ]
                        }
                    ]
                },
                new Host
                {
                    Id = 3,
                    FirstName = "Ігор",
                    LastName = "Петренко",
                    DisplayName = "Ігор",
                    Email = "ihor@example.com",
                    PhoneNumber = "+380931112244",
                    Rating = 4.7,
                    ReviewsCount = 76,
                    Apartments =
                    [
                        new Apartment
                        {
                            Id = 3,
                            HostId = 3,
                            Title = "Львівська квартира біля Оперного",
                            Description = "Історичний центр міста.",
                            Type = ApartmentType.Apartment,
                            Address = new Address
                            {
                                Country = "Україна",
                                City = "Львів",
                                Street = "проспект Свободи",
                                BuildingNumber = "12",
                                PostalCode = "79000"
                            },
                            MaxGuests = 3,
                            Bedrooms = 1,
                            Beds = 2,
                            Bathrooms = 1,
                            Area = 55,
                            PricePerNight = 1600,
                            Currency = Currency.UAH,
                            Rating = 9.6,
                            ReviewsCount = 102,
                            IsAvailable = true,
                            Facilities =
                            [
                                Facilities.WiFi,
                                Facilities.Heating,
                                Facilities.Kitchen,
                                Facilities.PetFriendly
                            ]
                        },
                        new Apartment
                        {
                            Id = 4,
                            HostId = 3,
                            Title = "Вілла біля моря",
                            Description = "Простора вілла з приватним басейном.",
                            Type = ApartmentType.Villa,
                            Address = new Address
                            {
                                Country = "Україна",
                                City = "Одеса",
                                Street = "Фонтанська дорога",
                                BuildingNumber = "55",
                                PostalCode = "65000"
                            },
                            MaxGuests = 8,
                            Bedrooms = 4,
                            Beds = 5,
                            Bathrooms = 3,
                            Area = 200,
                            PricePerNight = 7500,
                            Currency = Currency.UAH,
                            Rating = 9.8,
                            ReviewsCount = 54,
                            IsAvailable = true,
                            Facilities =
                            [
                                Facilities.WiFi,
                                Facilities.PrivatePool,
                                Facilities.SeaView,
                                Facilities.BBQArea,
                                Facilities.Garden,
                                Facilities.Parking,
                                Facilities.AirConditioning
                            ]
                        }
                    ]
                }
            };
        }
    }
}
