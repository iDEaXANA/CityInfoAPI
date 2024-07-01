using CityinfoAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CityinfoAPI.Controllers
{
    [ApiController]
    [Route("api/cities")]
    public class CitiesController : ControllerBase
    {

        private readonly CitiesDataStore _citiesDataStore;

        public CitiesController(CitiesDataStore citiesDataStore)
        {
            _citiesDataStore = citiesDataStore ?? throw new ArgumentNullException(nameof(citiesDataStore));
        }
        [HttpGet]
        public ActionResult<IEnumerable<CityDTO>> GetCities()
        {
            return Ok(_citiesDataStore.Cities); //empty list doesn't warrant a 'Not Found'
        }

        [HttpGet("{id}")]
        public ActionResult<CityDTO> GetCity(int id)
        {
            //find city
            var cityToReturn = _citiesDataStore.Cities
            .FirstOrDefault(c => c.Id == id);

            if (cityToReturn == null)
            {
                return NotFound();
            }

            return Ok(cityToReturn);
        }
    }
}
