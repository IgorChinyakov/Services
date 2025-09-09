using Contracts.DTOs;

namespace Contracts.Requests
{
    public record CreateLocationRequest(
        string Name,
        AddressDto Address,
        string TimeZone);
}
