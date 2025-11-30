using WebsiteBackend.Models;
using WebsiteBackend.Repositories;

namespace WebsiteBackend.Services
{
    public class MemberService : IMemberService
    {
        private readonly IMemberRepository _memberRepository;
        private readonly ICacheService _cacheService;
        
        public MemberService(IMemberRepository memberRepository, ICacheService cacheService)
        {
            _memberRepository = memberRepository;
            _cacheService = cacheService;
        }
        
        public async Task<IEnumerable<Member>> GetAllMembersAsync(string? type = null)
        {
            var cacheKey = string.IsNullOrEmpty(type) ? "members:all" : $"members:type:{type}";
            
            // Try to get from cache first
            var cachedMembers = await _cacheService.GetAsync<IEnumerable<Member>>(cacheKey);
            if (cachedMembers != null)
            {
                return cachedMembers;
            }
            
            // If not in cache, get from database
            IEnumerable<Member> members;
            if (!string.IsNullOrEmpty(type))
            {
                members = await _memberRepository.GetMembersByTypeAsync(type);
            }
            else
            {
                members = await _memberRepository.GetAllAsync();
            }
            
            // Cache the result
            await _cacheService.SetAsync(cacheKey, members);
            
            return members;
        }
        
        public async Task<Member?> GetMemberByIdAsync(int id)
        {
            var cacheKey = $"members:{id}";
            
            // Try to get from cache first
            var cachedMember = await _cacheService.GetAsync<Member>(cacheKey);
            if (cachedMember != null)
            {
                return cachedMember;
            }
            
            // If not in cache, get from database
            var member = await _memberRepository.GetByIdAsync(id);
            
            // Cache the result if found
            if (member != null)
            {
                await _cacheService.SetAsync(cacheKey, member);
            }
            
            return member;
        }
    }
}