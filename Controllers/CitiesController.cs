using Microsoft.AspNetCore.Mvc;

namespace CityinfoAPI.Controllers
{
    public class CitiesController : ControllerBase 
    {
        public JsonResult GetCities()
        {
            return new JsonResult(
                new List<object>
                {
                    new { id = 1, Name = "New York City"},
                    new { id = 2, Name = "London"}
                });
        }
       
    }
}
