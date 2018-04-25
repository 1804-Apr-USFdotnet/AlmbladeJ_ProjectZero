
namespace RestaurantsReviews
{
    public interface IUser
    {
        int UserID { get; set; }
        string Username { get; set; }
        string Email { get; set; }
        string Group { get; set; }
        int NumberOfReviews { get; set; }
    }
}
