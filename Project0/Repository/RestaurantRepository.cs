using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RestaurantRepository : Repository<Restaurant>, IRestaurantRepository
    {
        public RestaurantRepository(PlutoContext db) : base(db) { }

        public IEnumerable<Restaurant> GetTopThree()
        {
            return PlutoContext.Set<Restaurant>().OrderByDescending(x => x.AveRating).Take(3);
        }

        public void Edit(int id, string field, string newvalue)
        {
            switch (field)
            {
                case "Name":
                    db.Set<Restaurant>().Find(id).Name = newvalue;
                    break;
                case "Address":
                    db.Set<Restaurant>().Find(id).Address = newvalue;
                    break;
                case "City":
                    db.Set<Restaurant>().Find(id).City = newvalue;
                    break;
                case "ZipCode":
                    db.Set<Restaurant>().Find(id).Zipcode = newvalue;
                    break;
                case "Phone":
                    db.Set<Restaurant>().Find(id).Phone = newvalue;
                    break;
                case "Website":
                    db.Set<Restaurant>().Find(id).Website = newvalue;
                    break;
                default:
                    break;

            }
        }

        public PlutoContext PlutoContext { get { return db as PlutoContext; } }
    }
}
