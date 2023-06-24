using CityInfo.API.Models;

namespace CityInfo.API
{
    public class CitiesDataStore
    {

        public List<CityDto> Cities { get; set; }

        private static CitiesDataStore? instance;
        public static CitiesDataStore Instance { get { return instance ?? new CitiesDataStore(); } }

        public CitiesDataStore()
        {
            this.Cities = new List<CityDto> {
                new CityDto { Id = 1 , Name = "Caracas", Description = "Bad city", PointsOfInterest = new List<PointsOfInterestDto>() {
                    new PointsOfInterestDto { Id = 1 , Name = "La vega", Description = "Bad place"},
                    new PointsOfInterestDto { Id = 2, Name = "Forum" , Description = "Good brunch place"},
                    new PointsOfInterestDto { Id = 3, Name = "O Diplomata"   , Description = "Excelent place"}} },
                new CityDto { Id = 2, Name = "Funchal" , Description = "Good city"},
                new CityDto { Id = 3, Name = "Porto"   , Description = "Good city"}
};
        }
    }
}
