
namespace RestaurantsReviews
{
    public class Restaurant : IRestaurant
    {
        public int RestaurantID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public int ZipCode { get; set; }
        public int Phone { get; set; }
        public string Website { get; set; }
        public double AverageRating { get; set; }
    }
}
