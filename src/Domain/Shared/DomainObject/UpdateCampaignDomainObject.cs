namespace Shared.DomainObject;

public class UpdateCampaignDomainObject(int id, string title, string description, DateTime startDate, DateTime endDate)
{
    public int Id { get; private set; } = id;
    public string Title { get; private set; } = title;
    public string Description { get; private set; } = description;
    public DateTime StartDate { get; private set; } = startDate;
    public DateTime EndDate { get; private set; } = endDate;
}