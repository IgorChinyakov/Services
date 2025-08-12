using CSharpFunctionalExtensions;
using Domain.Shared;

namespace Domain.ValueObjects.Location
{
    public class TimeZone : ValueObject
    {
        public string Value { get; }

        private TimeZone(string value)
        {
            Value = value;
        }

        public static Result<TimeZone, Error> Create(string value)
        {
            if (string.IsNullOrWhiteSpace(value) ||
                !TimeZoneInfo.TryFindSystemTimeZoneById(value, out var _))
                return Error.Create("invalid timezone");

            return new TimeZone(value);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
