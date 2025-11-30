using Microsoft.EntityFrameworkCore;
using WebsiteBackend.Data;
using WebsiteBackend.Models;

namespace WebsiteBackend.Repositories
{
    public class ContactRepository : Repository<Contact>, IContactRepository
    {
        public ContactRepository(AppDbContext context) : base(context)
        {
        }
        
        public async Task<Contact?> GetContactWithAllDetailsAsync()
        {
            return await _context.Contact
                .Include(c => c.Details)
                .Include(c => c.SocialLinks)
                .Include(c => c.JoinUs)
                    .ThenInclude(ju => ju.Conditions)
                .Include(c => c.JoinUs)
                    .ThenInclude(ju => ju.Steps)
                .FirstOrDefaultAsync();
        }
        
        public async Task<IEnumerable<ContactDetail>> GetContactDetailsAsync()
        {
            var contact = await _context.Contact.Include(c => c.Details).FirstOrDefaultAsync();
            return contact?.Details ?? Enumerable.Empty<ContactDetail>();
        }
        
        public async Task<IEnumerable<SocialLink>> GetSocialLinksAsync()
        {
            var contact = await _context.Contact.Include(c => c.SocialLinks).FirstOrDefaultAsync();
            return contact?.SocialLinks ?? Enumerable.Empty<SocialLink>();
        }
        
        public async Task<JoinUsInfo?> GetJoinUsInfoAsync()
        {
            var contact = await _context.Contact
                .Include(c => c.JoinUs)
                    .ThenInclude(ju => ju.Conditions)
                .Include(c => c.JoinUs)
                    .ThenInclude(ju => ju.Steps)
                .FirstOrDefaultAsync();
            return contact?.JoinUs;
        }
    }
}