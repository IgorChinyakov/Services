using Application.Database;
using CSharpFunctionalExtensions;
using Domain.Entities;
using Domain.Shared;
using Infrastructure.DBContexts;

namespace Infrastructure.Repositories
{
    public class LocationsRepository : ILocationsRepository
    {
        private readonly ApplicationDbContext _context;

        public LocationsRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Add(Location location)
        {
            await _context.Locations.AddAsync(location);

            return location.Id.Value;
        }

        public async Task SaveChanges(CancellationToken cancellationToken = default)
            => await _context.SaveChangesAsync(cancellationToken);
    }
}
