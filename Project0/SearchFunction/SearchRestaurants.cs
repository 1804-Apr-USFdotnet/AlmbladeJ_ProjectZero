using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Repository;

namespace SearchFunction
{
    public class SearchRestaurants : ISearchRestaurants
    {
        public SearchRestaurants()
        {
        }

        public List<Restaurant> GetTopRestaurants()
        {
            using (var WorkUnit = new UnitOfWork(new PlutoContext()))
            {
                return WorkUnit.RestaurantRepo.GetTopThree().ToList();
            }
        }

        public List<Restaurant> FindRestaurants(string s)
        {
            using (var WorkUnit = new UnitOfWork(new PlutoContext()))
            {
                return WorkUnit.RestaurantRepo.Find(x => x.Name.Contains(s)).ToList();
            }
        }
    }
}
