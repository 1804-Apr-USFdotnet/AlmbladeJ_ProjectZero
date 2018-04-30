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
        public ReviewRepository(RRRavesDBEntities db) : base(db) { }

        public new void Add(Review entity)
        {
            RRRavesDBEntities.Set<Review>().Add(entity);
            int RestId = (int)entity.Restaurant;
            RRRavesDBEntities.Set<Restaurant>().Find(RestId).AveRating = this.AverageRatings(RestId);
        }

        public new void AddRange(IEnumerable<Review> entities)
        {
            RRRavesDBEntities.Set<Review>().AddRange(entities);
            foreach (var item in entities)
            {
                int RestId = (int)item.Restaurant;
                RRRavesDBEntities.Set<Restaurant>().Find(RestId).AveRating = this.AverageRatings(RestId);
            }
            
        }

        public new void Remove(Review entity)
        {
            RRRavesDBEntities.Set<Review>().Remove(entity);
            int RestId = (int)entity.Restaurant;
            RRRavesDBEntities.Set<Restaurant>().Find(RestId).AveRating = this.AverageRatings(RestId);
        }

        public new void RemoveRange(IEnumerable<Review> entities)
        {
            RRRavesDBEntities.Set<Review>().RemoveRange(entities);
            foreach (var item in entities)
            {
                int RestId = (int)item.Restaurant;
                RRRavesDBEntities.Set<Restaurant>().Find(RestId).AveRating = this.AverageRatings(RestId);
            }
        }

        public void Edit(int id, string field, string newvalue)
        {
            switch (field)
            {
                case "Rating":
                    RRRavesDBEntities.Set<Review>().Find(id).Rating = Convert.ToInt32(newvalue);
                    break;
                case "ReviewText":
                    RRRavesDBEntities.Set<Review>().Find(id).ReviewText = newvalue;
                    break;
                default:
                    break;

            }
        }

        public decimal AverageRatings(int RestaurantID)
        {
            return (decimal)RRRavesDBEntities.Set<Review>().Where(x => x.Restaurant == RestaurantID).Average(x => x.Rating);
               
        }

        public RRRavesDBEntities RRRavesDBEntities { get { return db as RRRavesDBEntities; } }
    }
}
