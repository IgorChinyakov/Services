using CSharpFunctionalExtensions;

namespace Domain.ValueObjects.Shared
{
    public class CreatedAt : ValueObject
    {
        public DateTime Value { get; }

        private CreatedAt(DateTime value)
        {
            Value = value;
        }

        public static CreatedAt Create() => new CreatedAt(DateTime.UtcNow);

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
