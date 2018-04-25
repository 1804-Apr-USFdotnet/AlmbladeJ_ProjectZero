using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantsReviews
{
    public interface IReview
    {
         int ReviewID { get; set; }
         int Rating { get; set; }
         int RestaurantID { get; set; }
         int UserID { get; set; }
         string ReviewText { get; set; }
    }
}
