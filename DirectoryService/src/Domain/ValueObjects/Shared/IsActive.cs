using CSharpFunctionalExtensions;

namespace Domain.ValueObjects.Shared
{
    public class IsActive : ValueObject
    {
        public bool Value { get; }

        private IsActive(bool value)
        {
            Value = value;
        }

        public static IsActive Create(bool value) => new IsActive(value);

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
