using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Repository
{
    public class ReviewRepository : Repository<Review>, IReviewRepository
    {
        public ReviewRepository(PlutoContext db) : base(db) { }

        public new void Add(Review entity)
        {
            PlutoContext.Set<Review>().Add(entity);
            int RestId = (int)entity.Restaurant;
            PlutoContext.Set<Restaurant>().Find(RestId).AveRating = this.AverageRatings(RestId);
        }

        public new void AddRange(IEnumerable<Review> entities)
        {
            PlutoContext.Set<Review>().AddRange(entities);
            foreach (var item in entities)
            {
                int RestId = (int)item.Restaurant;
                PlutoContext.Set<Restaurant>().Find(RestId).AveRating = this.AverageRatings(RestId);
            }
            
        }

        public new void Remove(Review entity)
        {
            PlutoContext.Set<Review>().Remove(entity);
            int RestId = (int)entity.Restaurant;
            PlutoContext.Set<Restaurant>().Find(RestId).AveRating = this.AverageRatings(RestId);
        }

        public new void RemoveRange(IEnumerable<Review> entities)
        {
            PlutoContext.Set<Review>().RemoveRange(entities);
            foreach (var item in entities)
            {
                int RestId = (int)item.Restaurant;
                PlutoContext.Set<Restaurant>().Find(RestId).AveRating = this.AverageRatings(RestId);
            }
        }

        public decimal AverageRatings(int RestaurantID)
        {
            return (decimal)PlutoContext.Set<Review>().Where(x => x.Restaurant == RestaurantID).Average(x => x.Rating);
               
        }

        public PlutoContext PlutoContext { get { return db as PlutoContext; } }
    }
}
