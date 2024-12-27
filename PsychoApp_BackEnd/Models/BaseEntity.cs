public abstract class BaseEntity
{
    public bool IsDeleted { get; set; } = false; 
    public DateTime? DeletedAt { get; set; } 
}
