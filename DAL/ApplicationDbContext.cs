using DAL.Entity;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    internal class ApplicationDbContext : DbContext
    {
        DbSet<Bus> Busses { get; set; }
        DbSet<BusStop> BusStops { get; set; }
        DbSet<Trip> Trips { get; set; }
        DbSet<Schedule> Schedules { get; set; }
        DbSet<Card> Cards { get; set; }
        DbSet<Passanger> Passangers { get; set; }
        DbSet<Driver> Drivers { get; set; }

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
