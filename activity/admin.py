from django.contrib import admin
from activity.models import Activity


# 注册模型（Admin后台将显示该模型的管理入口）
admin.site.register(Activity)
