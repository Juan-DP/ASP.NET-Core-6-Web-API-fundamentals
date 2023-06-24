using Microsoft.AspNetCore.Mvc;

namespace CityInfo.API.Controllers
{
    [ApiController]
    [Route("api/cities")]
    public class CitiesController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetCities()
        {
            var cities = CitiesDataStore.Instance.Cities;

            if (cities == null)
            {
                return NotFound();
            }

            return Ok(cities);
        }

        [HttpGet("id")]
        public IActionResult GetCity(int id)
        {
            var city = CitiesDataStore.Instance.Cities.FirstOrDefault(x => x.Id == id);

            if (city == null)
            {
                return NotFound();
            }

            return Ok(city);
        }
    }
}
