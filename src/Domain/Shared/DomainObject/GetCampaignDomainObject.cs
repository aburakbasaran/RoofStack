namespace Shared.DomainObject;

public class GetCampaignDomainObject(int id, string title, string description)
{
    public int Id { get; private set; } = id;
    public string Title { get; private set; } = title;
    public string Description { get; private set; } = description;
}