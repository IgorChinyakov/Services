using CSharpFunctionalExtensions;
using Domain.Entities;
using Domain.ValueObjects.Department;
using Domain.ValueObjects.Ids;
using Domain.ValueObjects.Shared;

namespace Domain.Models
{
    public class Department : Entity<DepartmentId>
    {
        private readonly List<Department> _departments = [];

        private readonly List<Position> _positions = [];

        private readonly List<Location> _locations = [];

        public Name Name { get; private set; }

        public Identifier Identifier { get; private set; }

        public DepartmentId? ParentId { get; private set; }

        public Department? Parent { get; private set; }

        public IsActive IsActive { get; private set; }

        public CreatedAt CreatedAt { get; private set; }

        public UpdatedAt UpdatedAt { get; private set; }

        public IReadOnlyList<Department> Departments => _departments;

        public IReadOnlyList<Position> Positions => _positions;

        public IReadOnlyList<Location> Locations => _locations;

        public short Depth
            => Parent == null ? (short)0 : (short)(Parent.Depth + 1);

        public string Path
            => Parent == null ? Identifier.Value : $"{Parent.Path}.{Identifier.Value}";

        public int ChildrenCount
            => _departments.Count();

        public Department(
            Identifier identifier,
            Name name,
            IsActive isActive,
            CreatedAt createdAt,
            UpdatedAt updatedAt)
        {
            Identifier = identifier;
            Name = name;
            IsActive = isActive;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }
    }
}
