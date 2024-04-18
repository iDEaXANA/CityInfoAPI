using System.ComponentModel.DataAnnotations;

namespace CityinfoAPI.Models
{
    public class PointOfInterestForCreationDTO
    {
        [Required(ErrorMessage = "A name must be provided.")] // Everything has a name!
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(200)]
        public string? Description { get; set; }
    }
}