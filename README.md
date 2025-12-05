Django App基本配置如下

```python
app/
├── __init__.py
├── admin.py     # 后台管理配置
├── apps.py      # 应用配置
├── migrations/  # 数据库迁移文件
├── models.py    # 数据模型（核心）
├── tests.py     # 测试文件
└── views.py     # 视图函数（处理请求）
————————————————
```







```python
myproject/
├── manage.py          # 项目管理脚本（核心工具）
└── myproject/         # 主配置目录
    ├── __init__.py
    ├── settings.py    # 项目配置文件
    ├── urls.py        # 主路由配置
    ├── asgi.py        # ASGI部署配置
    └── wsgi.py        # WSGI部署配置
————————————————
```





```
{
  "success": true,
  "code": 200,
  "message": "Success",
  "data": [
    {
      "id": 1,
      "title": "年度安全挑战赛",
      "description": "检验你的实战能力，与顶尖选手同台竞技",
      "content": "比赛",
      "type": "CTF竞赛",
      "startTime_at": "2025-12-04T06:00:00Z",
      "endTime_at": "2025-12-04T18:00:00Z"
    }
  ],
  "timestamp": "2025-12-04T19:44:08.264691"
}
```

