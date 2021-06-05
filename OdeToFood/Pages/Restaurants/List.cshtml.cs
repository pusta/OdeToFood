using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using OdeToFood.data;
using OdeToFood.Core;

namespace OdeToFood.Pages.Restaurants
{
    public class ListModel : PageModel
    {

        
        public string Message { get; set; }
        public IEnumerable<Restaurant> Restaurants { get; set; }
        private readonly IConfiguration config;
        private readonly IRestaurantData RestaurantData;
        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }


        public ListModel(IConfiguration config, IRestaurantData restaurantData)
        {
            this.RestaurantData = restaurantData;
            this.config = config;
            
        }
        public void OnGet(string searchTerm)
        {
            
            Message = config["Message"];
            Restaurants = RestaurantData.GetRestaurantsByName(SearchTerm);
        }
    }
}