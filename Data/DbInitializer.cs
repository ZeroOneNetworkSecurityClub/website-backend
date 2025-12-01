using System.Text.Json;
using website_backend.Models;

namespace website_backend.Data;

public static class DbInitializer
{
    public static void Initialize(ApplicationDbContext context)
    {
        // 检查是否已经有数据
        if (context.Activities.Any() || context.Members.Any() || context.About.Any() || context.Contact.Any())
        {
            return; // 数据库已经初始化
        }

        // 初始化活动数据
        var activities = new List<Activity>
        {
            new Activity
            {
                Title = "网络安全知识讲座",
                Date = DateTime.Now.AddDays(7),
                Location = "教学楼A101",
                Description = "邀请业内专家讲解网络安全最新趋势和防护技巧",
                Status = ActivityStatus.Upcoming,
                Icon = "book",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            },
            new Activity
            {
                Title = "CTF竞赛培训",
                Date = DateTime.Now.AddDays(14),
                Location = "实验楼B203",
                Description = "针对CTF竞赛的专项培训，包括Web安全、逆向工程等",
                Status = ActivityStatus.Upcoming,
                Icon = "trophy",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            },
            new Activity
            {
                Title = "社团招新活动",
                Date = DateTime.Now.AddMonths(-1),
                Location = "图书馆前广场",
                Description = "新学期社团招新，欢迎对网络安全感兴趣的同学加入",
                Status = ActivityStatus.Past,
                Icon = "party",
                CreatedAt = DateTime.Now.AddMonths(-1),
                UpdatedAt = DateTime.Now.AddMonths(-1)
            }
        };

        context.Activities.AddRange(activities);
        context.SaveChanges();

        // 初始化成员数据
        var members = new List<Member>
        {
            new Member
            {
                Name = "张三",
                Position = "社长",
                Description = "负责社团整体规划和管理",
                Type = MemberType.Core,
                Avatar = "https://via.placeholder.com/150",
                JoinedAt = DateTime.Now.AddYears(-2)
            },
            new Member
            {
                Name = "李四",
                Position = "技术总监",
                Description = "负责技术培训和竞赛指导",
                Type = MemberType.Core,
                Avatar = "https://via.placeholder.com/150",
                JoinedAt = DateTime.Now.AddYears(-1)
            },
            new Member
            {
                Name = "王五",
                Position = "普通成员",
                Description = "对Web安全感兴趣的大一新生",
                Type = MemberType.General,
                Avatar = "https://via.placeholder.com/150",
                JoinedAt = DateTime.Now.AddMonths(-1)
            }
        };

        context.Members.AddRange(members);
        context.SaveChanges();

        // 初始化社团信息
        var about = new About
        {
            Background = "零壹网络安全社团成立于2023年，是一个致力于推广网络安全知识、培养网络安全人才的学生社团。",
            Missions = new List<string> { "推广网络安全知识", "培养网络安全人才", "参与网络安全竞赛", "服务校园网络安全" },
            History = new List<HistoryItem>
            {
                new HistoryItem { Year = "2023", Description = "社团成立，招收首批成员" },
                new HistoryItem { Year = "2024", Description = "首次参加省赛并获得三等奖" },
                new HistoryItem { Year = "2025", Description = "社团成员突破100人" }
            },
            Organization = new List<OrganizationItem>
            {
                new OrganizationItem { Name = "技术部", Description = "负责技术培训和竞赛" },
                new OrganizationItem { Name = "宣传部", Description = "负责社团宣传和活动策划" },
                new OrganizationItem { Name = "外联部", Description = "负责对外合作和赞助" }
            }
        };

        context.About.Add(about);
        context.SaveChanges();

        // 初始化联系信息
        var contact = new Contact();
        context.Contact.Add(contact);
        context.SaveChanges();

        // 添加联系详情
        var contactDetails = new List<ContactDetail>
        {
            new ContactDetail { Type = "邮箱", Value = "contact@lingyi-sec.com", ContactId = contact.Id },
            new ContactDetail { Type = "QQ群", Value = "123456789", ContactId = contact.Id }
        };
        context.ContactDetails.AddRange(contactDetails);

        // 添加社交媒体链接
        var socialLinks = new List<SocialLink>
        {
            new SocialLink { Name = "GitHub", Url = "https://github.com/lingyi-sec", ContactId = contact.Id },
            new SocialLink { Name = "微博", Url = "https://weibo.com/lingyi-sec", ContactId = contact.Id }
        };
        context.SocialLinks.AddRange(socialLinks);

        // 添加加入我们信息
        var joinUsInfo = new JoinUsInfo
        {
            Description = "欢迎对网络安全感兴趣的同学加入我们！",
            ConditionsJson = JsonSerializer.Serialize(new List<string> { "对网络安全感兴趣", "遵守社团章程", "积极参与活动" }),
            StepsJson = JsonSerializer.Serialize(new List<string> { "填写申请表", "参加面试", "通过培训" }),
            ApplicationUrl = "https://example.com/join",
            ContactId = contact.Id
        };
        context.JoinUsInfo.Add(joinUsInfo);

        context.SaveChanges();
    }
}