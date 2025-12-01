using website_backend.Models;

namespace website_backend.DTOs;

/**
 * 关于我们信息
 */
public class AboutDto
{
    public string? Background { get; set; }

    public List<string>? Missions { get; set; }

    public List<HistoryItemDto>? History { get; set; }

    public List<OrganizationItemDto>? Organization { get; set; }
}

/**
 * 历史记录项
 */
public class HistoryItemDto
{
    public int Id { get; set; }

    public string Year { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public int AboutId { get; set; }
}

/**
 * 组织机构项
 */
public class OrganizationItemDto
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public int AboutId { get; set; }
}


// 扩展方法类，提供About实体到DTO转换的扩展方法
public static class AboutDtoExtensions
{
    // 将About实体对象转换为AboutDto数据传输对象
    // 要转换的About实体对象
    // 转换后的AboutDto对象，包含背景信息、使命列表、历史记录列表和组织机构列表
    // 此方法执行以下转换：
    // 1. 直接映射Background字段
    // 2. 映射Missions集合，若为空则返回空列表
    // 3. 映射History集合到HistoryItemDto列表
    // 4. 映射Organization集合到OrganizationItemDto列表
    public static AboutDto ToDto(this About about)
    {
        // 参数验证
        if (about == null)
        {
            throw new ArgumentNullException(nameof(about), "About实体对象不能为空");
        }
        
        return new AboutDto
        {
            // 映射背景信息
            Background = about.Background,
            
            // 映射使命列表，使用空合并操作符处理可能为null的情况
            Missions = about.Missions ?? new List<string>(),
            
            // 映射历史记录列表，使用条件运算符和ToList确保返回List类型
            History = about.History?.Select(h => new HistoryItemDto
            {
                Id = h.Id,
                Year = h.Year,
                Description = h.Description,
                AboutId = h.AboutId
            }).ToList(),
            
            // 映射组织机构列表，使用条件运算符和ToList确保返回List类型
            Organization = about.Organization?.Select(o => new OrganizationItemDto
            {
                Id = o.Id,
                Name = o.Name,
                Description = o.Description,
                AboutId = o.AboutId
            }).ToList()
        };
    }
}