namespace DAL.Context
{
    public class WatchDogDbContext : DbContext
    {
        public WatchDogDbContext(DbContextOptions<WatchDogDbContext> options) : base(options) 
        { 
        }
    }
}
