using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class Averager
    {
        ReviewRepository RevRepo;

        public Averager(string file)
        {
            RevRepo = new ReviewRepository(file);
        }

        public double FindAverage(int restaurantid)
        {

            var items = RevRepo.Find(x => x.RestaurantID
                                            == restaurantid).Select(x => x);
            return items.Select(x => x.Rating).Average();


        }
    }
}
