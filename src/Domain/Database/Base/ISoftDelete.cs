namespace Database.Base;

public interface ISoftDelete
{
    public bool IsDeleted { get; set; }
}