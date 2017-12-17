using Microsoft.EntityFrameworkCore;

namespace hotel.Persistence
{
    public class HotelDbContext: DbContext
    {
     public HotelDbContext(DbContextOptions<HotelDbContext> options)
        :base(options)
     {
         
     }   
    }
}