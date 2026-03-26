using BookingApp.DAL.Entities;

namespace BookingApp.DAL.Interfaces
{
    internal interface IBookingJsonPersistence
    {
        public void Save(List<Host> hosts);
        public List<Host> Load();
    }
}
