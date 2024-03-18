using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Database.Entities;

public class CampaignEntityConfiguration : IEntityTypeConfiguration<CampaignEntity>
{
    public void Configure(EntityTypeBuilder<CampaignEntity> builder)
    {
        builder.ToTable("Campaigns");
        builder.HasKey(q => q.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
    }
}