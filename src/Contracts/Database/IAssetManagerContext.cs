using AssetManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Contracts.Database
{
    public interface IAssetManagerContext
    {
        DbSet<Asset> Assets { get; }
        DbSet<Category> Categories { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
