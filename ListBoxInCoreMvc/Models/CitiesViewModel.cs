using Microsoft.AspNetCore.Mvc.Rendering;

namespace ListBoxInCoreMvc.Models
{
    public class CitiesViewModel
    {
        public IEnumerable<int>? SelectedCities { get; set; }
        public IEnumerable<SelectListItem>? Cities { get; set; }
    }
}
