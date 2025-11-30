using System.ComponentModel.DataAnnotations;

namespace WebsiteBackend.Models
{
    public class Member
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        
        [Required]
        [StringLength(100)]
        public string Position { get; set; }
        
        [Required]
        public string Description { get; set; }
        
        [Required]
        [StringLength(20)]
        public string Type { get; set; }
        
        [StringLength(200)]
        public string Avatar { get; set; }
        
        public DateTime JoinedAt { get; set; } = DateTime.Now;
    }
}