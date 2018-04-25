using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository;
using RestaurantsReviews;


namespace Project0
{
    class Program
    {
        static void Main(string[] args)
        {
            UnitOfWork WorkUnit = new UnitOfWork("./Content/Restaurants.json", "./Content/Reviews.json");

            WorkUnit.SaveRestaurants();
            WorkUnit.SaveReviews();
            WorkUnit.Restaurants.Add("Taco Bell", "112 12th street", "tampa", 35568, 1231231234, "tacobell.com");
            
        }
    }
}
