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
                yield return GeneralErrors.Validation(nameof(Country));

            if (string.IsNullOrWhiteSpace(city))
                yield return GeneralErrors.Validation(nameof(City));

            if (string.IsNullOrWhiteSpace(street))
                yield return GeneralErrors.Validation(nameof(Street));

            if (string.IsNullOrWhiteSpace(apartment))
                yield return GeneralErrors.Validation(nameof(Apartment));
        }
    }
}
