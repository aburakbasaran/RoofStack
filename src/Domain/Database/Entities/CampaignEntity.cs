using Database.Base;

namespace Database.Entities;

public class CampaignEntity(string title, string description, DateTime startDate, DateTime endDate, bool isDeleted)
    : BaseEntity, ISoftDelete
{
    public string Title { get; set; } = title;
    public string Description { get; set; } = description;
    public DateTime StartDate { get; set; } = startDate;
    public DateTime EndDate { get; set; } = endDate;
    public bool IsDeleted { get; set; } = isDeleted;

    public void Update(string title, string description, DateTime startDate, DateTime endDate)
    {
        Title = title;
        Description = description;
        StartDate = startDate;
        EndDate = endDate;
    }
}