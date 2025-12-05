from django.contrib import admin
from django.urls import path,include # 导入include用于路由分发


urlpatterns = [
    path(r'admin/', admin.site.urls), # Admin后台路由
    path(r'api/activity/',include('activity.urls')), # 将"/activity/"开头的URL交给activity处理

]
