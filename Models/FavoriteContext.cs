using Microsoft.EntityFrameworkCore;

namespace API.Models
{
    public class FavoriteContext :DbContext
    {
        public FavoriteContext(DbContextOptions<FavoriteContext> options) : base(options) 
        {
        
        }
        public DbSet<Favorites> favorites {get; set;}
    }
    
}
