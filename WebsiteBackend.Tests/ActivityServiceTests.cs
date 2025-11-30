using Moq;
using WebsiteBackend.Models;
using WebsiteBackend.Repositories;
using WebsiteBackend.Services;
using Xunit;

namespace WebsiteBackend.Tests
{
    public class ActivityServiceTests
    {
        private readonly Mock<IActivityRepository> _mockActivityRepository;
        private readonly Mock<ICacheService> _mockCacheService;
        private readonly ActivityService _activityService;
        
        public ActivityServiceTests()
        {
            _mockActivityRepository = new Mock<IActivityRepository>();
            _mockCacheService = new Mock<ICacheService>();
            _activityService = new ActivityService(_mockActivityRepository.Object, _mockCacheService.Object);
        }
        
        [Fact]
        public async Task GetAllActivitiesAsync_ShouldReturnActivitiesFromRepository_WhenCacheIsEmpty()
        {
            // Arrange
            var activities = new List<Activity>
            {
                new Activity { Id = 1, Title = "Test Activity 1", Status = "upcoming" },
                new Activity { Id = 2, Title = "Test Activity 2", Status = "past" }
            };
            
            _mockCacheService.Setup(c => c.GetAsync<IEnumerable<Activity>>(It.IsAny<string>())).ReturnsAsync((IEnumerable<Activity>?)null);
            _mockActivityRepository.Setup(r => r.GetAllAsync()).ReturnsAsync(activities);
            
            // Act
            var result = await _activityService.GetAllActivitiesAsync();
            
            // Assert
            Assert.Equal(activities, result);
            _mockCacheService.Verify(c => c.GetAsync<IEnumerable<Activity>>("activities:all"), Times.Once);
            _mockActivityRepository.Verify(r => r.GetAllAsync(), Times.Once);
            _mockCacheService.Verify(c => c.SetAsync("activities:all", activities, It.IsAny<TimeSpan?>()), Times.Once);
        }
        
        [Fact]
        public async Task GetAllActivitiesAsync_ShouldReturnActivitiesFromCache_WhenCacheHasData()
        {
            // Arrange
            var activities = new List<Activity>
            {
                new Activity { Id = 1, Title = "Test Activity 1", Status = "upcoming" }
            };
            
            _mockCacheService.Setup(c => c.GetAsync<IEnumerable<Activity>>("activities:all")).ReturnsAsync(activities);
            
            // Act
            var result = await _activityService.GetAllActivitiesAsync();
            
            // Assert
            Assert.Equal(activities, result);
            _mockCacheService.Verify(c => c.GetAsync<IEnumerable<Activity>>("activities:all"), Times.Once);
            _mockActivityRepository.Verify(r => r.GetAllAsync(), Times.Never);
        }
        
        [Fact]
        public async Task GetLatestActivitiesAsync_ShouldReturnLimitedActivities()
        {
            // Arrange
            var activities = new List<Activity>
            {
                new Activity { Id = 1, Title = "Test Activity 1" },
                new Activity { Id = 2, Title = "Test Activity 2" },
                new Activity { Id = 3, Title = "Test Activity 3" }
            };
            
            _mockCacheService.Setup(c => c.GetAsync<IEnumerable<Activity>>(It.IsAny<string>())).ReturnsAsync((IEnumerable<Activity>?)null);
            _mockActivityRepository.Setup(r => r.GetLatestActivitiesAsync(2)).ReturnsAsync(activities.Take(2).ToList());
            
            // Act
            var result = await _activityService.GetLatestActivitiesAsync(2);
            
            // Assert
            Assert.Equal(2, result.Count());
            _mockActivityRepository.Verify(r => r.GetLatestActivitiesAsync(2), Times.Once);
        }
    }
}