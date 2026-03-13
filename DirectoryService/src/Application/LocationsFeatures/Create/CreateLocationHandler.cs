using Application.Database;
using CSharpFunctionalExtensions;
using Domain.Entities;
using Domain.Shared;
using Domain.ValueObjects.Location;
using Microsoft.Extensions.Logging;

namespace Application.LocationsFeatures.Create
{
    public class CreateLocationHandler
    {
        private readonly ILocationsRepository _locationsRepository;
        private readonly ILogger<CreateLocationHandler> _logger;

        public CreateLocationHandler(
            ILocationsRepository locationsRepository, 
            ILogger<CreateLocationHandler> logger)
        {
            _locationsRepository = locationsRepository;
            _logger = logger;
        }

        public async Task<Result<Guid, Errors>> Handle(
            CreateLocationCommand command,
            CancellationToken cancellationToken = default)
        {
            var name = Name.Create(command.Name);
            if (name.IsFailure)
            {
                _logger.LogError("create location failure: name is invalid");
                return name.Error.ToErrorsList();
            }

            var address = Address.Create(
                command.Address.Country,
                command.Address.City,
                command.Address.Street,
                command.Address.Apartment);
            if (address.IsFailure)
            {
                _logger.LogError("create location failure: address is invalid");
                return new Errors(address.Error);
            }

            var timeZone = TimeZoneVO.Create(
                command.TimeZone);
            if (timeZone.IsFailure)
            {
                _logger.LogError("create location failure: timeZone is invalid");
                return timeZone.Error.ToErrorsList();
            }

            var location = new Location(name.Value, address.Value, timeZone.Value);
            var result = await _locationsRepository.Add(location);

            await _locationsRepository.SaveChanges(cancellationToken);

            _logger.LogInformation("location with id {id} has been created", location.Id);

            return result;
        }
    }
}
