using CSharpFunctionalExtensions;
using Domain.ValueObjects.Ids;
using Domain.ValueObjects.Location;
using Domain.ValueObjects.Shared;

namespace Domain.Entities
{
    public class Location : Entity<LocationId>
    {

        public Name Name { get; private set; }

        public IsActive IsActive { get; private set; }

        public CreatedAt CreatedAt { get; private set; }

        public UpdatedAt UpdatedAt { get; private set; }

        public Address Address { get; private set; }

        public Location(
            Name name,
            IsActive isActive,
            CreatedAt createdAt,
            UpdatedAt updatedAt,
            Address address)
        {
            Name = name;
            IsActive = isActive;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
            Address = address;
        }
    }
}
