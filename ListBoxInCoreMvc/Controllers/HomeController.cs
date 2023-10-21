using ListBoxInCoreMvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;
using System.Text;

namespace ListBoxInCoreMvc.Controllers
{
    public class HomeController : Controller
    {

        //private readonly ILogger<HomeController> _logger;
        private List<City> CityList;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        public HomeController()
        {
            CityList = new List<City>()
            {
                new City(){ CityId = 1, CityName = "London", IsSelected = false },
                new City(){ CityId = 2, CityName = "New York", IsSelected = false },
                new City(){ CityId = 3, CityName = "Sydney", IsSelected = false },
                new City(){ CityId = 4, CityName = "Mumbai", IsSelected = false },
                new City(){ CityId = 5, CityName = "Cambridge", IsSelected = false },
                new City(){ CityId = 6, CityName = "Delhi", IsSelected = false },
                new City(){ CityId = 7, CityName = "Hyderabad", IsSelected = false }
            };
        }

        [HttpGet]
        public ActionResult Index()
        {
            List<SelectListItem> citiesSelectListItems = new List<SelectListItem>();

            foreach (City city in CityList)
            {
                SelectListItem selectList = new SelectListItem()
                {
                    Text = city.CityName,
                    Value = city.CityId.ToString(),
                    Selected = city.IsSelected
                };
                citiesSelectListItems.Add(selectList);
            }
            CitiesViewModel citiesViewModel = new CitiesViewModel()
            {
                Cities = citiesSelectListItems
            };

            return View(citiesViewModel);
        }

        [HttpPost]
        public string Index(IEnumerable<int> selectedCities)
        {
            if (selectedCities == null)
            {
                return "No Cities Selected";
            }
            else
            {
                var CityNames = CityList.
                                Where(t => selectedCities.Contains(t.CityId)).
                                Select(item => item.CityName).ToList();
                StringBuilder sb = new StringBuilder();
                sb.Append("Your Selected City Names - " + string.Join(",", CityNames));
                return sb.ToString();
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}