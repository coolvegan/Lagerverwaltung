namespace Marmelade.Data;

public abstract class BaseEntity
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime ModifiedAt { get; set; } = DateTime.Now;
    public string CreatedBy { get; set; } = "Marco Kittel";
    public string UpdatedBy { get; set; } = "Marco Kittel";
}


