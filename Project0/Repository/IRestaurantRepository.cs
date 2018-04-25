using RestaurantsReviews;
using System.Collections.Generic;

namespace Repository
{
    public interface IRestaurantRepository : IRepository<Restaurant>
    {
        void Add(string name,
                       string address,
                       string city,
                       int zip,
                       int phone,
                       string website);
        List<Restaurant> GetTop3();
    }
}
