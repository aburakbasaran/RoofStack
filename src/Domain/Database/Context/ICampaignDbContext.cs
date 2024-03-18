using Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace Database.Context;

public interface ICampaignDbContext
{
    DbSet<CampaignEntity> Campaigns { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());
    int SaveChanges();
}