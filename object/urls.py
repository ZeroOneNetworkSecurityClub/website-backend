from django.urls import path

from object.views import upload_file, delete_file, object_list, rename_file

urlpatterns = [
    path(r'upload', upload_file, name='文件上传'),

    path(r'delete', delete_file, name='文件删除'),

    path(r'list', object_list, name='文件列表'),

    path(r'rename', rename_file, name='文件重命名'),
]
