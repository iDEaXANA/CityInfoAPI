using System.Drawing;
using CityinfoAPI.Models;

namespace CityinfoAPI
{
    public class CitiesDataStore
    {
        public List<CityDTO> Cities { get; set; } // CityDTO = object, get/set for read/write perms.

        public static CitiesDataStore Current { get; } = new CitiesDataStore(); // Singleton Pattern, hence get only. 

        public CitiesDataStore()
        {
            Cities = new List<CityDTO>()
            {
                new CityDTO()
                {
                    Id = 1,
                    Name = "New York City",
                    Description = "The one with that big park.",
                    PointsOfInterest = new List<PointOfInterestDTO>()
                        {
                            new PointOfInterestDTO() {
                                Id = 1,
                                Name = "Big Apple",
                                Description = "Tasty rats"},
                             new PointOfInterestDTO() {
                                Id = 2,
                                Name = "Broadway",
                                Description = "Drama"},
                        }
                },
                new CityDTO()
                {
                    Id = 2,
                    Name = "Algiers",
                    Description = "The one that's worse than Oran.",
                    PointsOfInterest = new List<PointOfInterestDTO>()
                        {
                            new PointOfInterestDTO() {
                                Id = 1,
                                Name = "Big Apple",
                                Description = "Tasty rats"},
                             new PointOfInterestDTO() {
                                Id = 2,
                                Name = "Broadway",
                                Description = "Drama"},
                        }
                },
                new CityDTO()
                {
                    Id = 3,
                    Name = "Paris",
                    Description = "The one with the tower that got sold twice.",
                    PointsOfInterest = new List<PointOfInterestDTO>()
                        {
                            new PointOfInterestDTO() {
                                Id = 1,
                                Name = "Big Apple",
                                Description = "Tasty rats"},
                             new PointOfInterestDTO() {
                                Id = 2,
                                Name = "Broadway",
                                Description = "Drama"},
                        }
                }

            };
        }
    }
}