namespace API.Models
{
    public class TopicModel
    {
        public string? Name { get; set; }
        public bool IsPinned { get; set; }
        public bool IsClosed { get; set; }
    }
}