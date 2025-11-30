using WebsiteBackend.Models;
using WebsiteBackend.Repositories;

namespace WebsiteBackend.Services
{
    public class AboutService : IAboutService
    {
        private readonly IAboutRepository _aboutRepository;
        private readonly ICacheService _cacheService;
        
        public AboutService(IAboutRepository aboutRepository, ICacheService cacheService)
        {
            _aboutRepository = aboutRepository;
            _cacheService = cacheService;
        }
        
        public async Task<About?> GetAboutWithAllDetailsAsync()
        {
            var cacheKey = "about:alldetails";
            
            // Try to get from cache first
            var cachedAbout = await _cacheService.GetAsync<About>(cacheKey);
            if (cachedAbout != null)
            {
                return cachedAbout;
            }
            
            // If not in cache, get from database
            var about = await _aboutRepository.GetAboutWithAllDetailsAsync();
            
            // Cache the result if found
            if (about != null)
            {
                await _cacheService.SetAsync(cacheKey, about);
            }
            
            return about;
        }
        
        public async Task<string> GetBackgroundAsync()
        {
            var cacheKey = "about:background";
            
            // Try to get from cache first
            var cachedBackground = await _cacheService.GetAsync<string>(cacheKey);
            if (!string.IsNullOrEmpty(cachedBackground))
            {
                return cachedBackground;
            }
            
            // If not in cache, get from database
            var background = await _aboutRepository.GetBackgroundAsync();
            
            // Cache the result
            await _cacheService.SetAsync(cacheKey, background);
            
            return background;
        }
        
        public async Task<IEnumerable<string>> GetMissionsAsync()
        {
            var cacheKey = "about:missions";
            
            // Try to get from cache first
            var cachedMissions = await _cacheService.GetAsync<IEnumerable<string>>(cacheKey);
            if (cachedMissions != null)
            {
                return cachedMissions;
            }
            
            // If not in cache, get from database
            var missions = await _aboutRepository.GetMissionsAsync();
            var missionContents = missions.Select(m => m.Content).ToList();
            
            // Cache the result
            await _cacheService.SetAsync(cacheKey, missionContents);
            
            return missionContents;
        }
        
        public async Task<IEnumerable<HistoryItem>> GetHistoryAsync()
        {
            var cacheKey = "about:history";
            
            // Try to get from cache first
            var cachedHistory = await _cacheService.GetAsync<IEnumerable<HistoryItem>>(cacheKey);
            if (cachedHistory != null)
            {
                return cachedHistory;
            }
            
            // If not in cache, get from database
            var history = await _aboutRepository.GetHistoryAsync();
            
            // Cache the result
            await _cacheService.SetAsync(cacheKey, history);
            
            return history;
        }
        
        public async Task<IEnumerable<OrganizationItem>> GetOrganizationAsync()
        {
            var cacheKey = "about:organization";
            
            // Try to get from cache first
            var cachedOrganization = await _cacheService.GetAsync<IEnumerable<OrganizationItem>>(cacheKey);
            if (cachedOrganization != null)
            {
                return cachedOrganization;
            }
            
            // If not in cache, get from database
            var organization = await _aboutRepository.GetOrganizationAsync();
            
            // Cache the result
            await _cacheService.SetAsync(cacheKey, organization);
            
            return organization;
        }
    }
}