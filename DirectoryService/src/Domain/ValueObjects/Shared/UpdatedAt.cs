using CSharpFunctionalExtensions;

namespace Domain.ValueObjects.Shared
{
    public class UpdatedAt : ValueObject
    {
        public DateTime Value { get; }

        private UpdatedAt(DateTime value)
        {
            Value = value;
        }

        public static Result<UpdatedAt, string> Create(DateTime value)
        {
            if (value < DateTime.UtcNow)
                return "invalid datetime";

            return new UpdatedAt(value);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
