using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantFunctions;

namespace ReviewFunctions
{
    interface IReview
    {
        int Rating { get; set; }
        string ReviewText { get; set; }

    }
}
