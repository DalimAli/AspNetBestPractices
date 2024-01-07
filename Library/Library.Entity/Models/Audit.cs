namespace Library.Entity.Models
{
    public class Audit
    {
        public DateTime CreatedAt { get; set; }  = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }  
    }
}
