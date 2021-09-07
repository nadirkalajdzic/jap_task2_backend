namespace jap_task2_backend.Models
{
    public class Rating
    {
        public int Id { get; set; }
        public float Value { get; set; }
        public int VideoId { get; set; }
        public int UserId { get; set; }
    }
}
