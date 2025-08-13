using CSharpFunctionalExtensions;

namespace Domain.ValueObjects.Ids
{
    public class DepartmentId : ValueObject, IComparable<DepartmentId>
    {
        public Guid Value { get; }

        private DepartmentId(Guid value)
        {
            Value = value;
        }

        public static DepartmentId New() => new DepartmentId(Guid.NewGuid());

        public static DepartmentId Create(Guid value) => new DepartmentId(value);

        public static DepartmentId Empty() => new DepartmentId(Guid.Empty);

        public int CompareTo(DepartmentId? other)
        {
            if(other == null)
                throw new ArgumentNullException("other");

            return Value.CompareTo(other.Value);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
