using System.ComponentModel.DataAnnotations;

namespace CarShowroom.Models
{
    public class Brands
    {
        [Key]
        public int Id { get; set; }
        public string? BrandName { get; set; }
    }
}
