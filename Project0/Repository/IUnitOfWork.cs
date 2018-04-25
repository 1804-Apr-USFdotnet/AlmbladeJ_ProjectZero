using System;

namespace Repository
{
    interface IUnitOfWork
    {
        IReviewRepository Reviews { get; set; }
        IRestaurantRepository Restaurants { get; set; }

        void SaveRestaurants();
        void SaveReviews();
    }
}
