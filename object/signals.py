#!/usr/bin/env python3
# auther: aipno
# -*- coding: utf-8 -*-
import os

from django.db.models.signals import post_delete
from django.dispatch import receiver

from object.models import Object


# 信号处理器
@receiver(post_delete, sender=Object)
def delete_file_from_storage(sender, instance, **kwargs):
    """
    当Object记录被删除时，同时删除本地文件

    Args:
        sender: 发送信号的模型类(Object)
        instance: 被删除的模型实例
        **kwargs: 其他参数
    """
    # 检查文件字段是否存在且文件在磁盘上存在
    if instance.file_field and os.path.isfile(instance.file_field.path):
        try:
            os.remove(instance.file_field.path)
        except OSError:
            # 如果文件已经被手动删除，忽略错误
            pass
