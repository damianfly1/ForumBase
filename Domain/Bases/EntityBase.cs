using CSharpFunctionalExtensions;
using Domain.Models.Entities;

namespace Domain.Bases;

public abstract class EntityBase : Entity<Guid>
{
    public DateTime CreatedAt { get; set; }
    public DateTime? LastUpdatedAt { get; set; }
    public User? CreatedBy { get; set; }
    public User? LastUpdatedBy { get; set; }
}
