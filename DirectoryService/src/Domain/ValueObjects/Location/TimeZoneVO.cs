using CSharpFunctionalExtensions;
using Domain.Shared;

namespace Domain.ValueObjects.Location
{
    public class TimeZoneVO : ValueObject
    {
        public string Value { get; }

        private TimeZoneVO(string value)
        {
            Value = value;
        }

        public static Result<TimeZoneVO, Error> Create(string value)
        {
            if (string.IsNullOrWhiteSpace(value) ||
                !TimeZoneInfo.TryFindSystemTimeZoneById(value, out var _))
                return Error.Create("invalid timezone");

            return new TimeZoneVO(value);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
