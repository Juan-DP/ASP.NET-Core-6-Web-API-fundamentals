using CityInfo.API.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;

namespace CityInfo.API.Controllers
{
    [Route("api/cities/{cityId}/poiId")]
    [ApiController]
    public class PointsOfInterestController : Controller
    {
        [HttpGet]
        public ActionResult<IEnumerable<PointsOfInterestDto>> Index(int cityId)
        {
            var city = CitiesDataStore.Instance.Cities.FirstOrDefault(x => x.Id == cityId);

            if (city == null) { 
                return NoContent();
            }

            return Ok(city.PointsOfInterest);
        }

        [HttpGet("{poiId}", Name = "GetPOI")]
        public ActionResult<IEnumerable<PointsOfInterestDto>> Get(int cityId, int poiId) {
            var city = CitiesDataStore.Instance.Cities.FirstOrDefault(x => x.Id == cityId);

            if (city == null)
            {
                return NoContent();
            }

            var poi = city.PointsOfInterest.FirstOrDefault(y => y.Id == poiId);

            if (poi == null)
            {
                return NoContent();
            }
            return Ok(poi);
        }

        [HttpPost]
        public ActionResult<PointsOfInterestDto> Create(int cityId, PointsOfInterestCreateDto poi) { 

            var cities = CitiesDataStore.Instance.Cities.FirstOrDefault(x => x.Id == cityId);

            if (cities == null)
            {
                return NoContent();
            }

            var newPOI = new PointsOfInterestDto()
            {
                Id = 4,
                Name = poi.Name,
                Description = poi.Description,
            };
            cities.PointsOfInterest.Add(newPOI);

            return CreatedAtRoute("GetPOI", new { cityId = cityId, poiId = newPOI.Id }, newPOI);

        }

        [HttpPut("{poiId}")]
        public ActionResult Update(int cityId, int poiId, PointOfInterestUpdateDto poi)
        {

            var city = CitiesDataStore.Instance.Cities.FirstOrDefault(x => x.Id == cityId);

            if (city == null)
            {
                return NoContent();
            }
            var updatedPoi = city.PointsOfInterest.FirstOrDefault(y => y.Id == poiId);

            if (updatedPoi == null)
            {
                return NoContent();
            }

            updatedPoi.Name = poi.Name;
            updatedPoi.Description = poi.Description;

            return NoContent();

        }

        [HttpPatch("{poiId}")]
        public ActionResult Patch(int cityId, int poiId, JsonPatchDocument<PointOfInterestUpdateDto> patchDocument)
        {

            var city = CitiesDataStore.Instance.Cities.FirstOrDefault(x => x.Id == cityId);

            if (city == null)
            {
                return NoContent();
            }
            var storePoi = city.PointsOfInterest.FirstOrDefault(y => y.Id == poiId);

            if (storePoi == null)
            {
                return NoContent();
            }

            var patchedPoi = new PointOfInterestUpdateDto()
            {
                Name = storePoi.Name,
                Description = storePoi.Description,
            };

            patchDocument.ApplyTo(patchedPoi, ModelState);

            if (!ModelState.IsValid) { 
                return BadRequest();
            }


            storePoi.Name = patchedPoi.Name;
            storePoi.Description = patchedPoi.Description;

            return NoContent();

        }

        [HttpDelete]
        public ActionResult Delete(int cityId, int poiId)
        {

            var city = CitiesDataStore.Instance.Cities.FirstOrDefault(x => x.Id == cityId);

            if (city == null)
            {
                return NoContent();
            }
            var storePoi = city.PointsOfInterest.FirstOrDefault(y => y.Id == poiId);

            if (storePoi == null)
            {
                return NoContent();
            }

            city.PointsOfInterest.Remove(storePoi);

            return NoContent();

        }
    }
}
