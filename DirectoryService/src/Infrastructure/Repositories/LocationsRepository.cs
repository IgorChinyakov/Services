using Application.Database;
using Domain.Entities;
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

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}
