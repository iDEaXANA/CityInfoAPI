namespace CityinfoAPI.Models
{
    public class CityDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public int NumberOfPointsOfInterest
        {
            get
            {
                return PointsOfInterest.Count;
            }
        }
        public ICollection<PointOfInterestDTO> PointsOfInterest { get; set; } = new List<PointOfInterestDTO>();
        //This can help avoid null reference exceptions when working with collections.
        // Icollection = Collection of Objects
        // = List of Objects

    }
}