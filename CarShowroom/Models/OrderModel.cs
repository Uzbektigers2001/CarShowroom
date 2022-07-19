namespace CarShowroom.Models
{
    public class OrderModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int CarId { get; set; }
        public bool? Sold { get; set; }
        public DateTime Time { get; set; }
    }
}
