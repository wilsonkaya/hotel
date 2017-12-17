using hotel.Models;
using Microsoft.EntityFrameworkCore;

namespace hotel.Persistence
{
    public class HotelDbContext: DbContext
    {
        public DbSet<Room> Rooms {get; set;}
        public DbSet<Customer> Customers {get; set;}
     public HotelDbContext(DbContextOptions<HotelDbContext> options)
        :base(options)
     {
         
     }   
    }
}