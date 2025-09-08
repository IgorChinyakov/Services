using CSharpFunctionalExtensions;
using Domain.Shared;
using Domain.ValueObjects.Location;

namespace Domain.ValueObjects.Shared
{
    public class UpdatedAt : ValueObject
    {
        public DateTime Value { get; }

        private UpdatedAt(DateTime value)
        {
            Value = value;
        }

        public static Result<UpdatedAt, Error> Create(DateTime value)
        {
            if (value < DateTime.UtcNow)
                return GeneralErrors.Validation(nameof(UpdatedAt));

            return new UpdatedAt(value);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
