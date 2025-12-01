# 零壹网络安全社团网站 API 文档

## 1. 概述

本文档描述了零壹网络安全社团网站的API接口规范，包括所有可用端点、请求参数、响应结构和认证要求。API采用RESTful设计风格，使用JSON格式进行数据交换。

### 1.1 基础URL

```
http://localhost:5132/api
```

### 1.2 认证方式

目前API未实现认证机制，所有端点均可匿名访问。未来可能会添加JWT认证，届时需要在请求头中添加`Authorization`字段：

```
Authorization: Bearer <token>
```

### 1.3 响应格式

所有API响应均采用以下格式：

```json
{
  "Success": true,
  "Data": {},
  "Message": "请求成功"
}
```

错误响应：

```json
{
  "Success": false,
  "Data": null,
  "Message": "错误信息"
}
```

## 2. 活动模块 (Activity)

### 2.1 获取所有活动

**HTTP方法**: GET
**端点**: `/activities`
**功能**: 获取所有活动列表

#### 请求参数

| 参数名 | 类型 | 位置 | 必需 | 描述 |
|--------|------|------|------|------|
| type | string | query | 否 | 活动类型，可选值：`upcoming`（即将举行）、`past`（过往） |

#### 响应结构

```json
{
  "Success": true,
  "Data": [
    {
      "Id": number,
      "Title": string,
      "Date": string,
      "Location": string,
      "Description": string,
      "Status": string, // "upcoming" 或 "past"
      "Icon": string,
      "CreatedAt": string,
      "UpdatedAt": string
    }
  ],
  "Message": "请求成功"
}
```

#### 示例请求

```bash
GET /api/activities
GET /api/activities?type=upcoming
```

### 2.2 获取最新活动

**HTTP方法**: GET
**端点**: `/activities/latest`
**功能**: 获取最新的N个活动

#### 请求参数

| 参数名 | 类型 | 位置 | 必需 | 描述 |
|--------|------|------|------|------|
| limit | number | query | 否 | 返回的活动数量，默认值：3 |

#### 响应结构

与获取所有活动的响应结构相同

#### 示例请求

```bash
GET /api/activities/latest
GET /api/activities/latest?limit=5
```

### 2.3 获取活动详情

**HTTP方法**: GET
**端点**: `/activities/{id}`
**功能**: 获取指定ID的活动详情

#### 请求参数

| 参数名 | 类型 | 位置 | 必需 | 描述 |
|--------|------|------|------|------|
| id | number | path | 是 | 活动ID |

#### 响应结构

```json
{
  "Success": true,
  "Data": {
    "Id": number,
    "Title": string,
    "Date": string,
    "Location": string,
    "Description": string,
    "Status": string,
    "Icon": string,
    "CreatedAt": string,
    "UpdatedAt": string
  },
  "Message": "请求成功"
}
```

#### 示例请求

```bash
GET /api/activities/1
```

## 3. 成员模块 (Member)

### 3.1 获取所有成员

**HTTP方法**: GET
**端点**: `/members`
**功能**: 获取所有成员列表

#### 请求参数

| 参数名 | 类型 | 位置 | 必需 | 描述 |
|--------|------|------|------|------|
| type | string | query | 否 | 成员类型，可选值：`core`（核心成员）、`general`（普通成员） |

#### 响应结构

```json
{
  "Success": true,
  "Data": [
    {
      "Id": number,
      "Name": string,
      "Position": string,
      "Description": string,
      "Type": string, // "Core" 或 "General"
      "Avatar": string,
      "JoinedAt": string
    }
  ],
  "Message": "请求成功"
}
```

#### 示例请求

```bash
GET /api/members
GET /api/members?type=core
```

### 3.2 获取成员详情

**HTTP方法**: GET
**端点**: `/members/{id}`
**功能**: 获取指定ID的成员详情

#### 请求参数

| 参数名 | 类型 | 位置 | 必需 | 描述 |
|--------|------|------|------|------|
| id | number | path | 是 | 成员ID |

#### 响应结构

```json
{
  "Success": true,
  "Data": {
    "Id": number,
    "Name": string,
    "Position": string,
    "Description": string,
    "Type": string,
    "Avatar": string,
    "JoinedAt": string
  },
  "Message": "请求成功"
}
```

#### 示例请求

```bash
GET /api/members/1
```

## 4. 社团信息模块 (About)

### 4.1 获取完整社团信息

**HTTP方法**: GET
**端点**: `/about`
**功能**: 获取社团的完整信息，包括背景、宗旨、发展历程和组织结构

#### 请求参数

无

#### 响应结构

```json
{
  "Success": true,
  "Data": {
    "Id": number,
    "Background": string,
    "Missions": [string],
    "History": [
      {
        "Id": number,
        "Year": string,
        "Description": string,
        "AboutId": number
      }
    ],
    "Organization": [
      {
        "Id": number,
        "Name": string,
        "Description": string,
        "AboutId": number
      }
    ]
  },
  "Message": "请求成功"
}
```

#### 示例请求

```bash
GET /api/about
```

### 4.2 获取社团背景

**HTTP方法**: GET
**端点**: `/about/background`
**功能**: 获取社团背景信息

#### 请求参数

无

#### 响应结构

```json
{
  "Success": true,
  "Data": string,
  "Message": "请求成功"
}
```

#### 示例请求

```bash
GET /api/about/background
```

### 4.3 获取社团宗旨

**HTTP方法**: GET
**端点**: `/about/mission`
**功能**: 获取社团宗旨

#### 请求参数

无

#### 响应结构

```json
{
  "Success": true,
  "Data": [string],
  "Message": "请求成功"
}
```

#### 示例请求

```bash
GET /api/about/mission
```

### 4.4 获取发展历程

**HTTP方法**: GET
**端点**: `/about/history`
**功能**: 获取社团发展历程

#### 请求参数

无

#### 响应结构

```json
{
  "Success": true,
  "Data": [
    {
      "Id": number,
      "Year": string,
      "Description": string,
      "AboutId": number
    }
  ],
  "Message": "请求成功"
}
```

#### 示例请求

```bash
GET /api/about/history
```

### 4.5 获取组织结构

**HTTP方法**: GET
**端点**: `/about/organization`
**功能**: 获取社团组织结构

#### 请求参数

无

#### 响应结构

```json
{
  "Success": true,
  "Data": [
    {
      "Id": number,
      "Name": string,
      "Description": string,
      "AboutId": number
    }
  ],
  "Message": "请求成功"
}
```

#### 示例请求

```bash
GET /api/about/organization
```

## 5. 联系信息模块 (Contact)

### 5.1 获取完整联系信息

**HTTP方法**: GET
**端点**: `/contact`
**功能**: 获取完整的联系信息，包括联系方式、社交媒体和加入我们的信息

#### 请求参数

无

#### 响应结构

```json
{
  "Success": true,
  "Data": {
    "Id": number,
    "Details": [
      {
        "Id": number,
        "Type": string,
        "Value": string,
        "ContactId": number
      }
    ],
    "SocialLinks": [
      {
        "Id": number,
        "Name": string,
        "Url": string,
        "ContactId": number
      }
    ],
    "JoinUs": {
      "Id": number,
      "Description": string,
      "Conditions": [string],
      "Steps": [string],
      "ApplicationUrl": string,
      "ContactId": number
    }
  },
  "Message": "请求成功"
}
```

#### 示例请求

```bash
GET /api/contact
```

### 5.2 获取联系方式

**HTTP方法**: GET
**端点**: `/contact/details`
**功能**: 获取联系方式，如邮箱、QQ群等

#### 请求参数

无

#### 响应结构

```json
{
  "Success": true,
  "Data": [
    {
      "Id": number,
      "Type": string,
      "Value": string,
      "ContactId": number
    }
  ],
  "Message": "请求成功"
}
```

#### 示例请求

```bash
GET /api/contact/details
```

### 5.3 获取社交媒体链接

**HTTP方法**: GET
**端点**: `/contact/social`
**功能**: 获取社交媒体链接，如GitHub、微博等

#### 请求参数

无

#### 响应结构

```json
{
  "Success": true,
  "Data": [
    {
      "Id": number,
      "Name": string,
      "Url": string,
      "ContactId": number
    }
  ],
  "Message": "请求成功"
}
```

#### 示例请求

```bash
GET /api/contact/social
```

### 5.4 获取加入我们信息

**HTTP方法**: GET
**端点**: `/contact/join`
**功能**: 获取加入社团的条件和方式

#### 请求参数

无

#### 响应结构

```json
{
  "Success": true,
  "Data": {
    "Id": number,
    "Description": string,
    "Conditions": [string],
    "Steps": [string],
    "ApplicationUrl": string,
    "ContactId": number
  },
  "Message": "请求成功"
}
```

#### 示例请求

```bash
GET /api/contact/join
```

## 6. 错误处理

API可能返回以下错误状态码：

| 状态码 | 描述 |
|--------|------|
| 200 | 请求成功 |
| 400 | 请求参数错误 |
| 404 | 资源不存在 |
| 500 | 服务器内部错误 |

### 6.1 错误响应示例

```json
{
  "Success": false,
  "Data": null,
  "Message": "请求的资源不存在"
}
```

## 7. 速率限制

目前API未实现速率限制，所有端点均可自由访问。未来可能会添加速率限制，届时将在本文档中更新。

## 8. 版本控制

当前API版本为v1，未来版本更新将通过URL路径进行区分，如：

```
http://localhost:5132/api/v2/activities
```

## 9. 变更日志

### 2025-12-01
- 更新API文档，修正响应格式为camelCase
- 修正基础URL端口为5132
- 完善响应结构，添加完整的模型字段
- 确保所有端点文档与实际实现一致
- 更新所有响应示例以匹配实际API输出

### 2025-11-30
- 初始版本发布
- 实现活动、成员、社团信息和联系信息模块
- 所有端点均支持GET请求

## 10. 开发说明

### 10.1 前端集成

前端使用axios进行API调用，配置如下：

```javascript
import axios from 'axios';

const apiClient = axios.create({
  baseURL: '/api',
  timeout: 10000,
  headers: {
    'Content-Type': 'application/json'
  }
});
```

### 10.2 跨域处理

在开发环境中，Vite配置了代理，将`/api`请求代理到后端服务器。生产环境中需要确保后端服务器配置了正确的CORS头。

## 11. 联系方式

如有API相关问题或建议，请联系：

- 邮箱：contact@lingyi-sec.com
- QQ群：123456789
- 微信公众号：零壹网络安全社团

---

**文档版本**: v1.1.0
**最后更新**: 2025-12-01
