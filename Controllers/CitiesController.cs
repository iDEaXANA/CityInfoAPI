using CityinfoAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CityinfoAPI.Controllers
{
    [ApiController]
    [Route("api/cities")]
    public class CitiesController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<CityDTO>> GetCities()
        {
            return Ok(CitiesDataStore.Current.Cities); //empty list doesn't warrant a 'Not Found'
        }

        [HttpGet("{id}")]
        public ActionResult<CityDTO> GetCity(int id)
        {
            //find city
            var cityToReturn = CitiesDataStore.Current.Cities
            .FirstOrDefault(c => c.Id == id);

            if (cityToReturn == null)
            {
                return NotFound();
            }

            return Ok(cityToReturn);
        }
    }
}
