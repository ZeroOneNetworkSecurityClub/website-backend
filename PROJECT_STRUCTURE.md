# 零壹网络安全社团网站后端项目结构说明

## 1. 项目整体结构概述

本项目是基于.NET 8框架开发的Web API后端系统，采用分层架构设计，主要包含以下核心模块：
- 活动模块：管理社团活动信息
- 成员模块：管理社团成员信息
- 社团信息模块：管理社团背景、宗旨、发展历程和组织结构
- 联系信息模块：管理社团联系方式和加入信息

项目采用了Entity Framework Core作为ORM框架，使用MySQL作为数据库，实现了完整的RESTful API服务。

## 2. 文件夹结构与功能

| 文件夹名称 | 路径 | 主要功能和职责 |
|------------|------|----------------|
| Controllers | website-backend\Controllers | 处理HTTP请求，实现API端点，返回统一格式的响应 |
| Data | website-backend\Data | 数据库上下文配置、数据迁移和初始化逻辑 |
| Middleware | website-backend\Middleware | 自定义中间件，处理HTTP请求和响应 |
| Models | website-backend\Models | 数据模型定义，包括实体类和枚举类型 |
| Properties | website-backend\Properties | 项目属性配置，包括启动设置 |
| Services | website-backend\Services | 业务逻辑实现，处理核心业务规则 |
| obj | website-backend\obj | 编译输出目录，包含临时编译文件和依赖项信息 |

## 3. 文件功能说明

### 3.1 根目录文件

| 文件名称 | 路径 | 类型 | 功能说明 |
|----------|------|------|----------|
| API_DOCUMENTATION.md | website-backend\API_DOCUMENTATION.md | Markdown | API接口文档，定义了所有可用端点、请求参数和响应结构 |
| LICENSE | website-backend\LICENSE | 文本文件 | 项目许可证文件 |
| Program.cs | website-backend\Program.cs | C#源代码 | 项目入口文件，配置服务和HTTP请求管道 |
| README.md | website-backend\README.md | Markdown | 项目说明文档 |
| appsettings.Development.json | website-backend\appsettings.Development.json | JSON | 开发环境配置文件 |
| appsettings.json | website-backend\appsettings.json | JSON | 主配置文件，包含数据库连接字符串等配置信息 |
| website-backend.csproj | website-backend\website-backend.csproj | 项目文件 | 定义项目依赖项和编译设置 |

### 3.2 Controllers文件夹

| 文件名称 | 路径 | 类型 | 功能说明 |
|----------|------|------|----------|
| AboutController.cs | website-backend\Controllers\AboutController.cs | C#源代码 | 处理社团信息相关的API请求，包括获取社团背景、宗旨、发展历程和组织结构 |
| ActivityController.cs | website-backend\Controllers\ActivityController.cs | C#源代码 | 处理活动相关的API请求，包括获取所有活动、最新活动和活动详情 |
| ContactController.cs | website-backend\Controllers\ContactController.cs | C#源代码 | 处理联系信息相关的API请求，包括获取联系方式、社交媒体链接和加入信息 |
| MemberController.cs | website-backend\Controllers\MemberController.cs | C#源代码 | 处理成员相关的API请求，包括获取所有成员和成员详情 |

### 3.3 Data文件夹

| 文件名称 | 路径 | 类型 | 功能说明 |
|----------|------|------|----------|
| ApplicationDbContext.cs | website-backend\Data\ApplicationDbContext.cs | C#源代码 | 数据库上下文类，定义数据库表映射和关系配置 |
| DbInitializer.cs | website-backend\Data\DbInitializer.cs | C#源代码 | 数据库初始化类，用于填充初始测试数据 |

### 3.4 Middleware文件夹

| 文件名称 | 路径 | 类型 | 功能说明 |
|----------|------|------|----------|
| ResponseMiddleware.cs | website-backend\Middleware\ResponseMiddleware.cs | C#源代码 | 响应中间件，用于统一处理API响应格式 |

### 3.5 Models文件夹

| 文件名称 | 路径 | 类型 | 功能说明 |
|----------|------|------|----------|
| About.cs | website-backend\Models\About.cs | C#源代码 | 社团信息模型，包括背景、宗旨、发展历程和组织结构 |
| Activity.cs | website-backend\Models\Activity.cs | C#源代码 | 活动模型，包括活动标题、日期、地点、描述等信息 |
| ApiResponse.cs | website-backend\Models\ApiResponse.cs | C#源代码 | API统一响应模型，定义了成功/失败状态、数据和消息字段 |
| Contact.cs | website-backend\Models\Contact.cs | C#源代码 | 联系信息模型，包括联系方式、社交媒体链接和加入信息 |
| Member.cs | website-backend\Models\Member.cs | C#源代码 | 成员模型，包括成员姓名、职位、描述等信息 |

### 3.6 Properties文件夹

| 文件名称 | 路径 | 类型 | 功能说明 |
|----------|------|------|----------|
| launchSettings.json | website-backend\Properties\launchSettings.json | JSON | 项目启动设置，定义了开发服务器的配置 |

### 3.7 Services文件夹

| 文件名称 | 路径 | 类型 | 功能说明 |
|----------|------|------|----------|
| AboutService.cs | website-backend\Services\AboutService.cs | C#源代码 | 社团信息业务逻辑，处理社团信息的查询操作 |
| ActivityService.cs | website-backend\Services\ActivityService.cs | C#源代码 | 活动业务逻辑，处理活动的查询操作 |
| ContactService.cs | website-backend\Services\ContactService.cs | C#源代码 | 联系信息业务逻辑，处理联系信息的查询操作 |
| MemberService.cs | website-backend\Services\MemberService.cs | C#源代码 | 成员业务逻辑，处理成员的查询操作 |

## 4. 关键文件之间的依赖关系

### 4.1 核心依赖关系

```
Program.cs
├── ApplicationDbContext.cs (数据上下文)
├── ResponseMiddleware.cs (响应中间件)
├── IActivityService.cs (活动服务接口)
├── IMemberService.cs (成员服务接口)
├── IAboutService.cs (社团信息服务接口)
└── IContactService.cs (联系信息服务接口)

Controllers
├── ActivityController.cs
│   └── IActivityService.cs
├── MemberController.cs
│   └── IMemberService.cs
├── AboutController.cs
│   └── IAboutService.cs
└── ContactController.cs
    └── IContactService.cs

Services
├── ActivityService.cs
│   ├── ApplicationDbContext.cs
│   └── Activity.cs
├── MemberService.cs
│   ├── ApplicationDbContext.cs
│   └── Member.cs
├── AboutService.cs
│   ├── ApplicationDbContext.cs
│   └── About.cs
└── ContactService.cs
    ├── ApplicationDbContext.cs
    └── Contact.cs

Data
├── ApplicationDbContext.cs
│   └── Models (所有数据模型)
└── DbInitializer.cs
    ├── ApplicationDbContext.cs
    └── Models (所有数据模型)
```

### 4.2 配置文件依赖

```
Program.cs
└── appsettings.json (数据库连接字符串)
```

## 5. 核心模块功能说明

### 5.1 活动模块

- **功能**：管理社团活动信息，包括活动列表、最新活动和活动详情
- **主要文件**：Activity.cs、ActivityService.cs、ActivityController.cs
- **API端点**：
  - GET /api/activities - 获取所有活动
  - GET /api/activities/latest - 获取最新活动
  - GET /api/activities/{id} - 获取活动详情

### 5.2 成员模块

- **功能**：管理社团成员信息，包括成员列表和成员详情
- **主要文件**：Member.cs、MemberService.cs、MemberController.cs
- **API端点**：
  - GET /api/members - 获取所有成员
  - GET /api/members/{id} - 获取成员详情

### 5.3 社团信息模块

- **功能**：管理社团背景、宗旨、发展历程和组织结构
- **主要文件**：About.cs、AboutService.cs、AboutController.cs
- **API端点**：
  - GET /api/about - 获取完整社团信息
  - GET /api/about/background - 获取社团背景
  - GET /api/about/mission - 获取社团宗旨
  - GET /api/about/history - 获取发展历程
  - GET /api/about/organization - 获取组织结构

### 5.4 联系信息模块

- **功能**：管理社团联系方式、社交媒体链接和加入信息
- **主要文件**：Contact.cs、ContactService.cs、ContactController.cs
- **API端点**：
  - GET /api/contact - 获取完整联系信息
  - GET /api/contact/details - 获取联系方式
  - GET /api/contact/social - 获取社交媒体链接
  - GET /api/contact/join - 获取加入我们信息

## 6. 技术栈与依赖

| 技术/依赖 | 版本 | 用途 |
|-----------|------|------|
| .NET | 8.0 | 开发框架 |
| ASP.NET Core | 8.0 | Web API框架 |
| Entity Framework Core | 8.0 | ORM框架 |
| MySql.EntityFrameworkCore | 8.0.0 | MySQL数据库驱动 |
| Swashbuckle.AspNetCore | 6.6.2 | Swagger文档生成 |

## 7. 项目启动与运行

### 7.1 开发环境

```bash
# 安装依赖
dotnet restore

# 构建项目
dotnet build

# 运行项目
dotnet run
```

### 7.2 访问API

- API基地址：`http://localhost:5132/api`
- Swagger文档：`http://localhost:5132/swagger`

## 8. 数据库配置

### 8.1 连接信息

| 配置项 | 值 |
|--------|-----|
| 服务器 | localhost |
| 端口 | 3306 |
| 数据库 | club_website |
| 用户名 | root |
| 密码 | 123456 |

### 8.2 数据库初始化

项目启动时会自动执行以下操作：
1. 检查并创建数据库（如果不存在）
2. 应用数据库迁移
3. 初始化测试数据

## 9. 代码规范与最佳实践

- 采用分层架构，分离关注点
- 使用依赖注入管理服务实例
- 实现统一的API响应格式
- 配置CORS支持跨域请求
- 使用异步编程模型提高性能
- 实现完整的错误处理机制

## 10. 总结

本项目是一个功能完整、结构清晰的Web API后端系统，采用了现代的.NET 8技术栈和最佳实践。通过分层架构设计，实现了业务逻辑与数据访问的分离，便于维护和扩展。项目包含了完整的API文档和测试数据，便于新团队成员快速理解和上手。