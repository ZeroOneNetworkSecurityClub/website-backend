using Microsoft.EntityFrameworkCore;
using WebsiteBackend.Models;

namespace WebsiteBackend.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        
        public DbSet<Activity> Activities { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<About> About { get; set; }
        public DbSet<Mission> Missions { get; set; }
        public DbSet<HistoryItem> HistoryItems { get; set; }
        public DbSet<OrganizationItem> OrganizationItems { get; set; }
        public DbSet<Contact> Contact { get; set; }
        public DbSet<ContactDetail> ContactDetails { get; set; }
        public DbSet<SocialLink> SocialLinks { get; set; }
        public DbSet<JoinUsInfo> JoinUsInfo { get; set; }
        public DbSet<JoinUsCondition> JoinUsConditions { get; set; }
        public DbSet<JoinUsStep> JoinUsSteps { get; set; }
        public DbSet<User> Users { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure relationships
            modelBuilder.Entity<Mission>()
                .HasOne(m => m.About)
                .WithMany(a => a.Missions)
                .HasForeignKey(m => m.AboutId)
                .OnDelete(DeleteBehavior.Cascade);
            
            modelBuilder.Entity<HistoryItem>()
                .HasOne(h => h.About)
                .WithMany(a => a.History)
                .HasForeignKey(h => h.AboutId)
                .OnDelete(DeleteBehavior.Cascade);
            
            modelBuilder.Entity<OrganizationItem>()
                .HasOne(o => o.About)
                .WithMany(a => a.Organization)
                .HasForeignKey(o => o.AboutId)
                .OnDelete(DeleteBehavior.Cascade);
            
            modelBuilder.Entity<ContactDetail>()
                .HasOne(cd => cd.Contact)
                .WithMany(c => c.Details)
                .HasForeignKey(cd => cd.ContactId)
                .OnDelete(DeleteBehavior.Cascade);
            
            modelBuilder.Entity<SocialLink>()
                .HasOne(sl => sl.Contact)
                .WithMany(c => c.SocialLinks)
                .HasForeignKey(sl => sl.ContactId)
                .OnDelete(DeleteBehavior.Cascade);
            
            modelBuilder.Entity<JoinUsInfo>()
                .HasOne(ju => ju.Contact)
                .WithOne(c => c.JoinUs)
                .HasForeignKey<JoinUsInfo>(ju => ju.ContactId)
                .OnDelete(DeleteBehavior.Cascade);
            
            modelBuilder.Entity<JoinUsCondition>()
                .HasOne(juc => juc.JoinUsInfo)
                .WithMany(ju => ju.Conditions)
                .HasForeignKey(juc => juc.JoinUsInfoId)
                .OnDelete(DeleteBehavior.Cascade);
            
            modelBuilder.Entity<JoinUsStep>()
                .HasOne(jus => jus.JoinUsInfo)
                .WithMany(ju => ju.Steps)
                .HasForeignKey(jus => jus.JoinUsInfoId)
                .OnDelete(DeleteBehavior.Cascade);
            
            // Add unique constraints or indexes if needed
            modelBuilder.Entity<Activity>()
                .HasIndex(a => a.Status);
            
            modelBuilder.Entity<Member>()
                .HasIndex(m => m.Type);
        }
    }
}