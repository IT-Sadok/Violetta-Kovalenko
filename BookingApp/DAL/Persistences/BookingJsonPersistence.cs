using BookingApp.DAL.Entities;
using BookingApp.DAL.Interfaces;
using System.Text.Json;

namespace BookingApp.DAL.Persistences
{
    internal class BookingJsonPersistence : IBookingJsonPersistence
    {
        private readonly string _filePath;

        public BookingJsonPersistence(string filePath)
        {
            _filePath = filePath ?? throw new ArgumentNullException(nameof(filePath));
        }

        public List<Host> Load()
        {
            if (!File.Exists(_filePath))
            {
                return new List<Host>();
            }

            string jsonString = File.ReadAllText(_filePath);

            List<Host>? hosts = JsonSerializer.Deserialize<List<Host>>(jsonString);

            return hosts ?? new List<Host>();
        }

        public void Save(List<Host> hosts) {

            ArgumentNullException.ThrowIfNull(hosts);

            string? directory = Path.GetDirectoryName(Path.GetFullPath(_filePath));
            if (!string.IsNullOrEmpty(directory))
            {
                Directory.CreateDirectory(directory);
            }

            string jsonString = JsonSerializer.Serialize(hosts,
                               new JsonSerializerOptions { WriteIndented = true });

            File.WriteAllText(_filePath, jsonString);
        }
    }
}