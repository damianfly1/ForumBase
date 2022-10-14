namespace Domain.Services;

public interface IForumService
{
    Task GetForumNested(Guid id);
}
