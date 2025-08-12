using CSharpFunctionalExtensions;
using Domain.Constants;
using Domain.Shared;

namespace Domain.ValueObjects.Department
{
    public class Name : ValueObject
    {
        public string Value { get; }

        private Name(string value)
        {
            Value = value;
        }

        public static Result<Name, Error> Create(string value)
        {
            if (string.IsNullOrWhiteSpace(value) ||
                value.Length < DepartmentConstants.NAME_MIN_LENGTH ||
                value.Length > DepartmentConstants.NAME_MAX_LENGTH)
                return Error.Create("invalid name");

            return new Name(value);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
