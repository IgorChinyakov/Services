using CSharpFunctionalExtensions;

namespace Domain.ValueObjects.Ids
{
    public class PositionId : ValueObject, IComparable<PositionId>
    {
        public Guid Value { get; }

        private PositionId(Guid value)
        {
            Value = value;
        }

        public static PositionId New() => new PositionId(Guid.NewGuid());

        public static PositionId Create(Guid value) => new PositionId(value);

        public static PositionId Empty() => new PositionId(Guid.Empty);

        public int CompareTo(PositionId? other)
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
