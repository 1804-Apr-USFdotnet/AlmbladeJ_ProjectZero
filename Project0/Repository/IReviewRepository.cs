using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantsReviews;

namespace Repository
{
    public interface IReviewRepository : IRepository<Review>
    {
        void Add(int userid, int restaurantid, int rating, string text);
    }
}
