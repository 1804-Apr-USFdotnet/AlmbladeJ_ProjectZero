using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantsReviews
{
    public interface IRestaurant
    {
         int RestaurantID { get; set; }
         string Name { get; set; }
         string Address { get; set; }
         string City { get; set; }
         int ZipCode { get; set; }
         int Phone { get; set; }
         string Website { get; set; }
         double AverageRating { get; set; }

    }
}
