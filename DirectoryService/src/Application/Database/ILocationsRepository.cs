using Domain.Entities;

namespace Application.Database
{
    public interface ILocationsRepository
    {
        Task<Guid> Add(Location location);

        Task SaveChanges();
    }
}