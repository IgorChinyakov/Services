using CSharpFunctionalExtensions;
using Domain.Shared;

namespace Domain.ValueObjects.Location
{
    public class Address : ValueObject
    {
        public string Country { get; }

        public string City { get; }

        public string Street { get; }

        public string Apartment { get; }

        private Address(
            string country,
            string city,
            string street,
            string apartment)
        {
            Country = country;
            City = city;
            Street = street;
            Apartment = apartment;
        }

        public static Result<Address, IEnumerable<Error>> Create(
            string country,
            string city,
            string street,
            string apartment)
        {
            var errors = Validate(country, city, street, apartment);
            if (errors.Any())
                return Result.Failure<Address, IEnumerable<Error>>(errors);

            return new Address(country, city, street, apartment);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Country;
            yield return City;
            yield return Street;
            yield return Apartment;
        }

        private static IEnumerable<Error> Validate(
            string country,
            string city,
            string street,
            string apartment)
        {
            if (string.IsNullOrWhiteSpace(country))
                yield return Error.Create("invalid country");

            if (string.IsNullOrWhiteSpace(city))
                yield return Error.Create("invalid city");

            if (string.IsNullOrWhiteSpace(street))
                yield return Error.Create("invalid street");

            if (string.IsNullOrWhiteSpace(apartment))
                yield return Error.Create("invalid apartment");
        }
    }
}
