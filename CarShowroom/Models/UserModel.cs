using System.ComponentModel.DataAnnotations;

namespace CarShowroom.Models
{
    public class UserModel
    {
        [Key]
        public long Id { get; set; }
        public long ChatId { get; set; }
        public string? UserName { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? LanguageCode { get; set; }
        public string? CardNumber { get; set; }
        public string? CardBalance { get; set; }
    }
}
