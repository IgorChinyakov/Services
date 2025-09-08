using CSharpFunctionalExtensions;
using Domain.ValueObjects.Ids;
using Domain.ValueObjects.Position;
using Domain.ValueObjects.Shared;

namespace Domain.Entities
{
    public class Position : Entity<PositionId>
    {
        private readonly List<Department> _departments = [];

        // ef core
        private Position() { }

        public Name Name { get; private set; }

        public Description? Description { get; private set; }

        public IsActive IsActive { get; private set; }

        public CreatedAt CreatedAt { get; private set; }

        public UpdatedAt? UpdatedAt { get; private set; }

        public IReadOnlyList<Department> Departments => _departments;

        public Position(
            Name name,
            Description? description)
        {
            Name = name;
            Description = description;
            IsActive = IsActive.Create(true);
            CreatedAt = CreatedAt.Create();
            Id = PositionId.New();
        }
    }
}
