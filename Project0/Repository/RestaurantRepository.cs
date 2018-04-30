using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RestaurantRepository : Repository<Restaurant>, IRestaurantRepository
    {
        public RestaurantRepository(PlutoContext db) : base(db) { }

        public IEnumerable<Restaurant> GetTopThree()
        {
            return PlutoContext.Set<Restaurant>().OrderByDescending(x => x.AveRating).Take(3);
        }

        public PlutoContext PlutoContext { get { return db as PlutoContext; } }
    }
}
