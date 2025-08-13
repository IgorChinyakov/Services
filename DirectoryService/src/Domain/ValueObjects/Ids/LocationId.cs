using CSharpFunctionalExtensions;

namespace Domain.ValueObjects.Ids
{
    public class LocationId : ValueObject, IComparable<LocationId>
    {
        public Guid Value { get; }

        private LocationId(Guid value)
        {
            Value = value;
        }

        public static LocationId New() => new LocationId(Guid.NewGuid());

        public static LocationId Create(Guid value) => new LocationId(value);

        public static LocationId Empty() => new LocationId(Guid.Empty);

        public int CompareTo(LocationId? other)
        {
            if (other == null)
                throw new ArgumentNullException("other");

            return Value.CompareTo(other.Value);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
