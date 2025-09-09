using Application.Database;
using CSharpFunctionalExtensions;
using Domain.Entities;
using Domain.Shared;
using Domain.ValueObjects.Location;

namespace Application.LocationsFeatures.Create
{
    public class CreateLocationHandler
    {
        private readonly ILocationsRepository _locationsRepository;

        public CreateLocationHandler(ILocationsRepository locationsRepository)
        {
             _locationsRepository = locationsRepository;
        }

        public async Task<Result<Guid, Errors>> Handle(
            CreateLocationCommand command,
            CancellationToken cancellationToken = default)
        {
            var name = Name.Create(command.Name);
            if (name.IsFailure)
                return name.Error.ToErrorsList();

            var address = Address.Create(
                command.Address.Country,
                command.Address.City,
                command.Address.Street,
                command.Address.Apartment);
            if (address.IsFailure)
                return new Errors(address.Error);

            var timeZone = TimeZoneVO.Create(
                command.TimeZone);
            if (timeZone.IsFailure)
                return timeZone.Error.ToErrorsList();

            var location = new Location(name.Value, address.Value, timeZone.Value);
            var result = await _locationsRepository.Add(location);

            await _locationsRepository.SaveChanges();

            return result;
        }
    }
}
