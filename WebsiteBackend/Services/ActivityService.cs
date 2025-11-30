using WebsiteBackend.Models;
using WebsiteBackend.Repositories;

namespace WebsiteBackend.Services
{
    public class ActivityService : IActivityService
    {
        private readonly IActivityRepository _activityRepository;
        private readonly ICacheService _cacheService;
        
        public ActivityService(IActivityRepository activityRepository, ICacheService cacheService)
        {
            _activityRepository = activityRepository;
            _cacheService = cacheService;
        }
        
        public async Task<IEnumerable<Activity>> GetAllActivitiesAsync(string? type = null)
        {
            var cacheKey = string.IsNullOrEmpty(type) ? "activities:all" : $"activities:type:{type}";
            
            // Try to get from cache first
            var cachedActivities = await _cacheService.GetAsync<IEnumerable<Activity>>(cacheKey);
            if (cachedActivities != null)
            {
                return cachedActivities;
            }
            
            // If not in cache, get from database
            IEnumerable<Activity> activities;
            if (!string.IsNullOrEmpty(type))
            {
                activities = await _activityRepository.GetActivitiesByTypeAsync(type);
            }
            else
            {
                activities = await _activityRepository.GetAllAsync();
            }
            
            // Cache the result
            await _cacheService.SetAsync(cacheKey, activities);
            
            return activities;
        }
        
        public async Task<IEnumerable<Activity>> GetLatestActivitiesAsync(int limit = 3)
        {
            var cacheKey = $"activities:latest:{limit}";
            
            // Try to get from cache first
            var cachedActivities = await _cacheService.GetAsync<IEnumerable<Activity>>(cacheKey);
            if (cachedActivities != null)
            {
                return cachedActivities;
            }
            
            // If not in cache, get from database
            var activities = await _activityRepository.GetLatestActivitiesAsync(limit);
            
            // Cache the result
            await _cacheService.SetAsync(cacheKey, activities);
            
            return activities;
        }
        
        public async Task<Activity?> GetActivityByIdAsync(int id)
        {
            var cacheKey = $"activities:{id}";
            
            // Try to get from cache first
            var cachedActivity = await _cacheService.GetAsync<Activity>(cacheKey);
            if (cachedActivity != null)
            {
                return cachedActivity;
            }
            
            // If not in cache, get from database
            var activity = await _activityRepository.GetByIdAsync(id);
            
            // Cache the result if found
            if (activity != null)
            {
                await _cacheService.SetAsync(cacheKey, activity);
            }
            
            return activity;
        }
    }
}