using CSharpFunctionalExtensions;
using Domain.ValueObjects.Ids;
using Domain.ValueObjects.Location;
using Domain.ValueObjects.Shared;

namespace Domain.Entities
{
    public class Location : Entity<LocationId>
    {
        private readonly List<Department> _departments = [];

        // ef core
        private Location() { }

        public Name Name { get; private set; }

        public IsActive IsActive { get; private set; }

        public CreatedAt CreatedAt { get; private set; }

        public UpdatedAt UpdatedAt { get; private set; }

        public Address Address { get; private set; }

        public TimeZoneVO TimeZone { get; private set; }

        public IReadOnlyList<Department> Departments => _departments;

        public Location(
            Name name,
            IsActive isActive,
            CreatedAt createdAt,
            UpdatedAt updatedAt,
            Address address,
            TimeZoneVO timeZone)
        {
            Name = name;
            IsActive = isActive;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
            Address = address;
            TimeZone = timeZone;
            Id = LocationId.New();
        }
    }
}
