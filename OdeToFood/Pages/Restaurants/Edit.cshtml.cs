using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using OdeToFood.Core;
using OdeToFood.data;

namespace OdeToFood.Pages.Restaurants
{
    public class EditModel : PageModel
    {
        private readonly IRestaurantData restaturantData;
        private readonly IHtmlHelper htmlHelper;

        [BindProperty]
        public Restaurant Restaurant { get; set; }
        public IEnumerable<SelectListItem> Cuisines { get; set; }

        public EditModel(IRestaurantData restaturantData, IHtmlHelper htmlHelper)
        {
            this.restaturantData = restaturantData;
            this.htmlHelper = htmlHelper;
        }

        public IActionResult OnGet(int? restaurantId)
        {
            Cuisines = htmlHelper.GetEnumSelectList<CuisineType>();
            if (restaurantId.HasValue)
            {
                Restaurant = restaturantData.GetById(restaurantId.Value);
            }
            else
            {


                Restaurant = new Restaurant();


            }
           if(Restaurant == null)
            {
                return RedirectToPage("./NotFound");

            }
            return Page();

        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                restaturantData.Update(Restaurant);
                restaturantData.Commit();
                return RedirectToPage("./Detail", new { restaurantId = Restaurant.Id });

            }
            Cuisines = htmlHelper.GetEnumSelectList<CuisineType>();
            return Page();
        }
    }
}
