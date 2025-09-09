using CSharpFunctionalExtensions;
using Domain.Entities;
using Domain.Shared;

namespace Application.Database
{
    public interface ILocationsRepository
    {
        Task<Guid> Add(Location location);

        Task<UnitResult<Error>> SaveChanges();
    }
}