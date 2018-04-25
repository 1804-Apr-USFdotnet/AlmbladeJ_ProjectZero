namespace RestaurantsReviews
{
    public class User : IUser
    {
        public int UserID { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Group { get; set; }
        public int NumberOfReviews { get; set; }
    }
}
