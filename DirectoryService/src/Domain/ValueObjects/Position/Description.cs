using CSharpFunctionalExtensions;
using Domain.Constants;
using Domain.Shared;

namespace Domain.ValueObjects.Position
{
    public class Description : ValueObject
    {
        public string Value { get; }

        private Description(string value)
        {
            Value = value;
        }

        public static Result<Description, Error> Create(string value)
        {
            if (string.IsNullOrWhiteSpace(value) ||
                value.Length > PositionConstants.DESCRIPTION_MAX_LENGTH)
                return Error.Create("invalid description");

            return new Description(value);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
