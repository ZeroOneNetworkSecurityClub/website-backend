using WebsiteBackend.Models;
using WebsiteBackend.Repositories;

namespace WebsiteBackend.Services
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _contactRepository;
        private readonly ICacheService _cacheService;
        
        public ContactService(IContactRepository contactRepository, ICacheService cacheService)
        {
            _contactRepository = contactRepository;
            _cacheService = cacheService;
        }
        
        public async Task<Contact?> GetContactWithAllDetailsAsync()
        {
            var cacheKey = "contact:alldetails";
            
            // Try to get from cache first
            var cachedContact = await _cacheService.GetAsync<Contact>(cacheKey);
            if (cachedContact != null)
            {
                return cachedContact;
            }
            
            // If not in cache, get from database
            var contact = await _contactRepository.GetContactWithAllDetailsAsync();
            
            // Cache the result if found
            if (contact != null)
            {
                await _cacheService.SetAsync(cacheKey, contact);
            }
            
            return contact;
        }
        
        public async Task<IEnumerable<ContactDetail>> GetContactDetailsAsync()
        {
            var cacheKey = "contact:details";
            
            // Try to get from cache first
            var cachedDetails = await _cacheService.GetAsync<IEnumerable<ContactDetail>>(cacheKey);
            if (cachedDetails != null)
            {
                return cachedDetails;
            }
            
            // If not in cache, get from database
            var details = await _contactRepository.GetContactDetailsAsync();
            
            // Cache the result
            await _cacheService.SetAsync(cacheKey, details);
            
            return details;
        }
        
        public async Task<IEnumerable<SocialLink>> GetSocialLinksAsync()
        {
            var cacheKey = "contact:social";
            
            // Try to get from cache first
            var cachedSocialLinks = await _cacheService.GetAsync<IEnumerable<SocialLink>>(cacheKey);
            if (cachedSocialLinks != null)
            {
                return cachedSocialLinks;
            }
            
            // If not in cache, get from database
            var socialLinks = await _contactRepository.GetSocialLinksAsync();
            
            // Cache the result
            await _cacheService.SetAsync(cacheKey, socialLinks);
            
            return socialLinks;
        }
        
        public async Task<JoinUsInfo?> GetJoinUsInfoAsync()
        {
            var cacheKey = "contact:joinus";
            
            // Try to get from cache first
            var cachedJoinUsInfo = await _cacheService.GetAsync<JoinUsInfo>(cacheKey);
            if (cachedJoinUsInfo != null)
            {
                return cachedJoinUsInfo;
            }
            
            // If not in cache, get from database
            var joinUsInfo = await _contactRepository.GetJoinUsInfoAsync();
            
            // Cache the result if found
            if (joinUsInfo != null)
            {
                await _cacheService.SetAsync(cacheKey, joinUsInfo);
            }
            
            return joinUsInfo;
        }
    }
}