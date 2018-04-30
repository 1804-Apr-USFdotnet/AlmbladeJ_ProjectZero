using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository;

namespace SearchFunction
{
    class DisplayAll : IDisplayAll
    {
        public List<Restaurant> RestaurantsByName()
        {
            using (var WorkUnit = new UnitOfWork(new PlutoContext()))
            {
                return WorkUnit.RestaurantRepo.GetAll().OrderBy(x => x.Name).ToList();
            }
        }

        public List<Restaurant> RestaurantsByRating()
        {
            using (var WorkUnit = new UnitOfWork(new PlutoContext()))
            {
                return WorkUnit.RestaurantRepo.GetAll().OrderByDescending(x => x.AveRating).ToList();
            }
        }

        public List<Review> ReviewsAscending()
        {
            using (var WorkUnit = new UnitOfWork(new PlutoContext()))
            {
                return WorkUnit.ReviewRepo.GetAll().OrderBy(x => x.Rating).ToList();
            }
        }

        public List<Review> ReviewsDescending()
        {
            using (var WorkUnit = new UnitOfWork(new PlutoContext()))
            {
                return WorkUnit.ReviewRepo.GetAll().OrderByDescending(x => x.Rating).ToList();
            }
        }
    }
}
