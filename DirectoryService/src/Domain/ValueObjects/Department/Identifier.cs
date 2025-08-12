using CSharpFunctionalExtensions;
using Domain.Constants;
using Domain.Shared;

namespace Domain.ValueObjects.Department
{
    public class Identifier : ValueObject
    {
        public string Value { get; }

        private Identifier(string value)
        {
            Value = value;
        }

        public static Result<Identifier, Error> Create(string value)
        {
            if (string.IsNullOrWhiteSpace(value) ||
                value.Length < DepartmentConstants.IDENTIFIER_MIN_LENGTH ||
                value.Length > DepartmentConstants.IDENTIFIER_MAX_LENGTH ||
                value.All(c => char.IsLetter(c) && ((c > 'a' && c < 'z') || (c > 'A' && c < 'Z'))))
                return Error.Create("invalid identifier");

            return new Identifier(value);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
