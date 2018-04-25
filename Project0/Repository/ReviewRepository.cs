using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Schema;
using Newtonsoft.Json.Linq;
using System.IO;
using RestaurantsReviews;

namespace Repository
{
    class ReviewRepository : IRepository<Review>, IReviewRepository
    {
        private JsonSerializer serializer;
        private List<Review> entityList;

        public ReviewRepository(string FileSource)
        {
            try
            {
                serializer = new JsonSerializer();
                if (!File.Exists(FileSource))
                {
                    File.Create(FileSource);
                }
                entityList = new List<Review>();
                entityList = JObject.Parse(File.ReadAllText(FileSource)).ToObject<List<Review>>();
            }
            catch (Exception e)
            {
                var logger = NLog.LogManager.GetCurrentClassLogger();
                logger.Debug(e, e.Message);
            }
        }

        public void Add(int userid, int restaurantid, int rating, string text)
        {
            int i = entityList.Count() + 1;
            entityList.Add(new Review()
            {
                ReviewID = i,
                UserID = userid,
                RestaurantID = restaurantid,
                Rating = rating,
                ReviewText = text
            });
        }

        public List<Review> Find(Predicate<Review> predicate)
        {
            return (List<Review>)entityList.FindAll(predicate);
        }

        public Review Get(int id)
        {
            return (Review)entityList.Where(x => x.ReviewID == id);
        }

        public List<Review> GetAll()
        {
            return entityList;
        }



        public void Remove(Review entity)
        {
            entityList.Remove(entity);
        }

        public void RemoveRange(int indexAt, int number)
        {
            entityList.RemoveRange(indexAt, number);
        }

        //public double GetRatingAverage(int restaurantid)
        //{
        //    var items = entityList.Where(x => x.RestaurantID
        //                                    == restaurantid).Select(x => x);
        //    return items.Select(x => x.Rating).Average();
        //}
    }
}
