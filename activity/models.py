from django.db import models


class Activity(models.Model):
    """
    活动详情表
    """
    id = models.AutoField(primary_key=True)
    # 活动标题
    title = models.CharField(max_length=100, verbose_name='标题')
    # 活动时间
    date = models.DateTimeField(verbose_name='活动时间')
    # 活动类型
    type = models.CharField(max_length=100, verbose_name='活动类型')
    # 活动地点
    location = models.CharField(max_length=100, verbose_name='地点')
    # 活动描述
    description = models.TextField(verbose_name='简介')
    # 活动内容
    content = models.TextField(verbose_name='活动详细内容')
    # 活动封面
    cover = models.TextField(verbose_name='封面')
    # 活动状态
    status = models.CharField(max_length=100, verbose_name='状态')
    # 活动标签
    tag = models.TextField(verbose_name='活动标签')
    # 创建时间
    createdAt = models.DateTimeField(auto_now_add=True)
    # 更新时间
    updatedAt = models.DateTimeField(auto_now=True)

    def __str__(self):
        return self.title

    class Meta:
        verbose_name = '活动'
        verbose_name_plural = verbose_name
