using System.ComponentModel.DataAnnotations;

namespace WebsiteBackend.Models
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }
        
        public ICollection<ContactDetail> Details { get; set; } = new List<ContactDetail>();
        
        public ICollection<SocialLink> SocialLinks { get; set; } = new List<SocialLink>();
        
        public JoinUsInfo JoinUs { get; set; }
    }
    
    public class ContactDetail
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [StringLength(50)]
        public string Type { get; set; }
        
        [Required]
        [StringLength(200)]
        public string Value { get; set; }
        
        public int ContactId { get; set; }
        public Contact Contact { get; set; }
    }
    
    public class SocialLink
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        
        [Required]
        [StringLength(200)]
        public string Url { get; set; }
        
        public int ContactId { get; set; }
        public Contact Contact { get; set; }
    }
    
    public class JoinUsInfo
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string Description { get; set; }
        
        public ICollection<JoinUsCondition> Conditions { get; set; } = new List<JoinUsCondition>();
        
        public ICollection<JoinUsStep> Steps { get; set; } = new List<JoinUsStep>();
        
        [Required]
        [StringLength(200)]
        public string ApplicationUrl { get; set; }
        
        public int ContactId { get; set; }
        public Contact Contact { get; set; }
    }
    
    public class JoinUsCondition
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string Content { get; set; }
        
        public int JoinUsInfoId { get; set; }
        public JoinUsInfo JoinUsInfo { get; set; }
    }
    
    public class JoinUsStep
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string Content { get; set; }
        
        public int JoinUsInfoId { get; set; }
        public JoinUsInfo JoinUsInfo { get; set; }
    }
}