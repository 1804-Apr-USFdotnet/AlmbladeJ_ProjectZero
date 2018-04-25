using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantsReviews
{
    public class Review : IReview
    {
        public int ReviewID { get; set; }
        public int Rating { get; set; }
        public int RestaurantID { get; set; }
        public int UserID { get; set; }
        public string ReviewText { get; set; }
    }
}
