using System.Data.Entity;
using System.Configuration;


namespace Repository
{
    public class PlutoContext : DbContext
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["RRRavesDBEntities"].ToString();
        public PlutoContext() : base(connectionString)
        {
            Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Review> Reviews { get; set; }
    }
}
