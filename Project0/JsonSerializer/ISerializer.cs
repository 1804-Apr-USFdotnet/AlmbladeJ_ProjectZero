using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonSerializer
{
    public interface ISerializer
    {
        void RestaurantToJson(string filepath);
        void JsonToRestaurant(string filepath);
    }
}
