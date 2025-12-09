from django.conf.urls.static import static
from django.contrib import admin
from django.urls import path, include  # 导入include用于路由分发

from website_backend import settings

urlpatterns = [
    path(r'admin/', admin.site.urls), # Admin后台路由
    path(r'api/activity/',include('activity.urls')), # 将"/activity/"开头的URL交给activity处理
    path(r'api/object/',include('object.urls')), # 将"/object/"开头的URL交给object处理
    path(r'api/about/',include('about.urls')), # 将"/about/"开头的URL交给about处理
    path(r'api/member/',include('member.urls')), # 将"/member/"开头的URL交给member处理
]

# 在开发环境中为媒体文件提供服务
if settings.DEBUG:
    urlpatterns += static(settings.MEDIA_URL, document_root=settings.MEDIA_ROOT)