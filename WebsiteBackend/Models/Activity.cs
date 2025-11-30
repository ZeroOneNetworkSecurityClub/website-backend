using System.ComponentModel.DataAnnotations;

namespace WebsiteBackend.Models
{
    public class Activity
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [StringLength(200)]
        public string Title { get; set; }
        
        [Required]
        public DateTime Date { get; set; }
        
        [Required]
        [StringLength(200)]
        public string Location { get; set; }
        
        [Required]
        public string Description { get; set; }
        
        [Required]
        [StringLength(20)]
        public string Status { get; set; }
        
        [StringLength(200)]
        public string Icon { get; set; }
        
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}