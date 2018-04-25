using System;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using System.IO;
using NLog;

namespace Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private string RestaurantSource;
        private string ReviewSource;

        public UnitOfWork(string restaurantsource, string reviewsource)
        {
            try
            {
                Restaurants = new RestaurantRepository(restaurantsource, reviewsource);
                Reviews = new ReviewRepository(reviewsource);
                RestaurantSource = restaurantsource;
                ReviewSource = reviewsource;
            } catch (Exception e)
            {
                var logger = NLog.LogManager.GetCurrentClassLogger();
                logger.Debug(e, e.Message);
            }

        }

        public IReviewRepository Reviews { get; set; }
        public IRestaurantRepository Restaurants { get; set; }

        public void SaveRestaurants()
        {
            try
            {
                using (StreamWriter file = File.CreateText(RestaurantSource))
                {
                    JsonSerializer ser = new JsonSerializer();
                    ser.Serialize(file, Restaurants.GetAll());
                }
            } catch (Exception e)
            {
                var logger = NLog.LogManager.GetCurrentClassLogger();
                logger.Debug(e, e.Message);
            }
        }

        public void SaveReviews()
        {
            try
            {
                using (StreamWriter file = File.CreateText(ReviewSource))
                {
                    JsonSerializer ser = new JsonSerializer();
                    ser.Serialize(file, Reviews.GetAll());
                }
            }
            catch (Exception e)
            {
                var logger = NLog.LogManager.GetCurrentClassLogger();
                logger.Debug(e, e.Message);
            }
        }
    }
}
