import os
import uuid

from django.core.files.storage import FileSystemStorage
from django.db import models


class CustomFileStorage(FileSystemStorage):
    """
    自定义文件存储类
    """

    def __init__(self, location=None, base_url=None):
        """
        初始化自定义文件存储类

        Args:
            location (str, optional): 文件存储的物理路径。如果未指定，则使用默认路径'file/'
            base_url (str, optional): 文件访问的基础URL。如果未指定，则使用默认配置

        Returns:
            None
        """
        if location is None:
            location = 'file/'
        super().__init__(location, base_url)

    def get_available_name(self, name, max_length=None):
        """
        覆盖父类的方法，确保文件名唯一
        """
        # 获取文件扩展名
        ext = os.path.splitext(name)[1]
        # 生成新的UUID文件名
        new_name = f'{uuid.uuid4().hex}{ext}'
        return super().get_available_name(new_name, max_length)


class Object(models.Model):
    """
    对象模型
    """
    id = models.AutoField(primary_key=True)
    # 对象文件在本地存储的uuid文件名
    file_field = models.FileField(storage=CustomFileStorage(), verbose_name='对象文件')
    # 源文件名
    file_name = models.CharField(max_length=255, verbose_name='文件名')
    # 创建时间
    created_at = models.DateTimeField(auto_now_add=True, verbose_name='创建时间')
