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
    public class RestaurantRepository : IRepository<Restaurant>, IRestaurantRepository
    {
        private JsonSerializer serializer;
        private List<Restaurant> entityList;
        private string ReviewFile;
        private Averager average;


        public RestaurantRepository(string FileSource, string ReviewSource)
        {
            try
            {
                serializer = new JsonSerializer();
                if (!File.Exists(FileSource))
                {
                    File.CreateText(FileSource);
                }
                if (!File.Exists(ReviewSource))
                {
                    File.CreateText(ReviewSource);
                }
                entityList = new List<Restaurant>();
                string s = File.ReadAllText(FileSource);
                var jArray = JArray.Parse(File.ReadAllText(FileSource));
                foreach (var item in jArray)
                {
                    entityList.Add(item.ToObject<Restaurant>());
                }
                ReviewFile = ReviewSource;
                average = new Averager(ReviewSource);
            }
            catch (Exception e)
            {
                var logger = NLog.LogManager.GetCurrentClassLogger();
                logger.Debug(e, e.Message);
            }
        }

        public void Add(string name,
                       string address,
                       string city,
                       int zip,
                       int phone,
                       string website)
        {
            int i = entityList.Count() + 1;
            Restaurant temp = new Restaurant()
            {
                RestaurantID = i,
                Name = name,
                Address = address,
                City = city,
                ZipCode = zip,
                Phone = phone,
                Website = website,
                AverageRating = 0
            };
            entityList.Add(temp);
        }

        public List<Restaurant> Find(Predicate<Restaurant> predicate)
        {
            var restaurants = (List<Restaurant>)entityList.FindAll(predicate);
            foreach (var item in restaurants)
            {
                item.AverageRating = average.FindAverage(item.RestaurantID);
            }
            return restaurants;
        }

        public Restaurant Get(int id)
        {
            var rest = (Restaurant)entityList.Where(x => x.RestaurantID == id);
            rest.AverageRating = average.FindAverage(rest.RestaurantID);
            return rest;
        }

        public List<Restaurant> GetAll()
        {
            foreach (var item in entityList)
            {
                item.AverageRating = average.FindAverage(item.RestaurantID);
            }
            return entityList;
        }

        public List<Restaurant> GetTop3()
        {
            List<Restaurant> top3;
            top3 = (List<Restaurant>)entityList.OrderByDescending(x => x.AverageRating).Take(3);
            entityList.OrderBy(x => x.RestaurantID);
            return top3;
        }

        public void Remove(Restaurant entity)
        {
            entityList.Remove(entity);
        }

        public void RemoveRange(int indexAt, int number)
        {
            entityList.RemoveRange(indexAt, number);
        }
    }
}
