using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace CityInfo.API.Models
{
    public class PointsOfInterestCreateDto
    {
        [Required]
        [MaxLength(32)]
        public string Name { get; set; }

        [Required]
        [MaxLength(64)]
        public string? Description { get; set; }
    }
}
