namespace Shared.DomainObject;

public class CreateCampaignDomainObject(string title, string description, DateTime startDate, DateTime endDate)
{
    public string Title { get; private set; } = title;
    public string Description { get; private set; } = description;
    public DateTime StartDate { get; private set; } = startDate;
    public DateTime EndDate { get; private set; } = endDate;
}