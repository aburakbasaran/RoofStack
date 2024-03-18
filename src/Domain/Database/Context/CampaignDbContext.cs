using Database.Entities;
using Microsoft.EntityFrameworkCore;


namespace Database.Context;

public class CampaignDbContext : DbContext, ICampaignDbContext
{


    //dotnet ef migrations add InitialCreate --project src\Domain\Database --startup-project src\Host\Host
    //dotnet ef database update --project src\Domain\Database --startup-project src\Host\Host

    public CampaignDbContext(DbContextOptions<CampaignDbContext> options) : base(options)
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CampaignEntityConfiguration());
        base.OnModelCreating(modelBuilder);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        return base.SaveChangesAsync(cancellationToken);
    }

    public override int SaveChanges()
    {
        return base.SaveChanges();
    }

    public DbSet<CampaignEntity> Campaigns { get; set; }
}