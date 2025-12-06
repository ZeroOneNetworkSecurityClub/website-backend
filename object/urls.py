from django.urls import path
from object.views import upload_file, delete_file

urlpatterns = [
    path('upload', upload_file,name='文件上传'),

    path('delete', delete_file,name='文件删除'),
]