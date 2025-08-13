using CSharpFunctionalExtensions;
using Domain.Shared;

namespace Domain.ValueObjects.Department
{
    public class Depth : ValueObject
    {
        public short Value { get; }

        private Depth(short value)
        {
            Value = value;
        }

        public static Result<Depth, Error> Create(short value)
        {
            if (value < 0)
                return Error.Create("invalid depth");

            return new Depth(value);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
