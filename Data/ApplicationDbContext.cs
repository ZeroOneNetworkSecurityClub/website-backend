using Microsoft.EntityFrameworkCore;
using website_backend.Models;

namespace website_backend.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Activity> Activities { get; set; }
    public DbSet<Member> Members { get; set; }
    public DbSet<About> About { get; set; }
    public DbSet<HistoryItem> HistoryItems { get; set; }
    public DbSet<OrganizationItem> OrganizationItems { get; set; }
    public DbSet<Contact> Contact { get; set; }
    public DbSet<ContactDetail> ContactDetails { get; set; }
    public DbSet<SocialLink> SocialLinks { get; set; }
    public DbSet<JoinUsInfo> JoinUsInfo { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // 配置About实体
        modelBuilder.Entity<About>()
            .Ignore(a => a.Missions)
            .HasMany(a => a.History)
            .WithOne(h => h.About)
            .HasForeignKey(h => h.AboutId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<About>()
            .HasMany(a => a.Organization)
            .WithOne(o => o.About)
            .HasForeignKey(o => o.AboutId)
            .OnDelete(DeleteBehavior.Cascade);

        // 配置Contact实体
        modelBuilder.Entity<Contact>()
            .HasMany(c => c.Details)
            .WithOne(d => d.Contact)
            .HasForeignKey(d => d.ContactId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Contact>()
            .HasMany(c => c.SocialLinks)
            .WithOne(s => s.Contact)
            .HasForeignKey(s => s.ContactId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Contact>()
            .HasOne(c => c.JoinUs)
            .WithOne(j => j.Contact)
            .HasForeignKey<JoinUsInfo>(j => j.ContactId)
            .OnDelete(DeleteBehavior.Cascade);

        // 配置JoinUsInfo实体，忽略Conditions和Steps属性
        modelBuilder.Entity<JoinUsInfo>()
            .Ignore(j => j.Conditions)
            .Ignore(j => j.Steps);
    }
}