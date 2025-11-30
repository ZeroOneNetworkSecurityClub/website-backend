using System.ComponentModel.DataAnnotations;

namespace WebsiteBackend.Models
{
    public class About
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string Background { get; set; }
        
        public ICollection<Mission> Missions { get; set; } = new List<Mission>();
        
        public ICollection<HistoryItem> History { get; set; } = new List<HistoryItem>();
        
        public ICollection<OrganizationItem> Organization { get; set; } = new List<OrganizationItem>();
    }
    
    public class Mission
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string Content { get; set; }
        
        public int AboutId { get; set; }
        public About About { get; set; }
    }
    
    public class HistoryItem
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [StringLength(50)]
        public string Year { get; set; }
        
        [Required]
        public string Description { get; set; }
        
        public int AboutId { get; set; }
        public About About { get; set; }
    }
    
    public class OrganizationItem
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        
        [Required]
        public string Description { get; set; }
        
        public int AboutId { get; set; }
        public About About { get; set; }
    }
}