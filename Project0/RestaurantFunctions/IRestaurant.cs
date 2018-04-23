﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantFunctions
{
    interface IRestaurant
    {
        int RestaurantID { get; set; }
        string Name { get; set; }
        string Address { get; set; }
        string Phone { get; set; }
        string City { get; set; }
        string Zip { get; set; }
    }
}
