using System.ComponentModel.DataAnnotations;

namespace CarShowroom.Models
{
    public class CarModel
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Brand { get; set; }
        public int BrandId { get; set; }
        public string? Country { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public double? Price { get; set; }
        public int? Position { get; set; }
        public string? Description { get; set; }
        public string? PictureUrl { get; set; }

    }
}
