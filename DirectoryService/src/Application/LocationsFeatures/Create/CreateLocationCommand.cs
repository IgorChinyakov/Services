using Contracts.DTOs;

namespace Application.LocationsFeatures.Create
{
    public record CreateLocationCommand(
        string Name,
        AddressDto Address,
        string TimeZone);
}