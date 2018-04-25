using RestaurantsReviews;
using System.Collections.Generic;

namespace SearchFunction
{
    interface ISearchRestaurants
    {
        List<Restaurant> SearchFor(string term);
    }
}
