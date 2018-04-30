using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository;

namespace RestaurantAndReviewFunctions
{
    public class RestaurantFunctions
    {
        public RestaurantFunctions() {

        }

        public void AddRestaurant(Restaurant r)
        {
            using (var WorkUnit = new UnitOfWork(new RRRavesDBEntities()))
            {
                WorkUnit.RestaurantRepo.Add(r);
                WorkUnit.Complete();
            }
        }
    }
}
