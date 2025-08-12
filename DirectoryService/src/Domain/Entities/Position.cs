using CSharpFunctionalExtensions;
using Domain.ValueObjects.Ids;
using Domain.ValueObjects.Position;
using Domain.ValueObjects.Shared;

namespace Domain.Entities
{
    public class Position : Entity<PositionId>
    {
        public Name Name { get; private set; }

        public Description? Description { get; private set; }

        public IsActive IsActive { get; private set; }

        public CreatedAt CreatedAt { get; private set; }

        public UpdatedAt UpdatedAt { get; private set; }

        public Position(
            Name name,
            Description? description,
            IsActive isActive,
            CreatedAt createdAt,
            UpdatedAt updatedAt)
        {
            Name = name;
            Description = description;
            IsActive = isActive;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }
    }
}
