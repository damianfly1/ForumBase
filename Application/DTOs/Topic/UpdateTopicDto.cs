namespace Application.DTOs.Topic;

public class UpdateTopicDto
{
    public string Name { get; set; }
    public bool IsPinned { get; set; }
    public bool IsClosed { get; set; }
}
