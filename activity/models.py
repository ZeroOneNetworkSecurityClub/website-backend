from django.db import models

class Activity(models.Model):
    id = models.AutoField(primary_key=True)
    # 活动标题
    title = models.CharField(max_length=100,verbose_name='标题')      # 字符串字段
    # 活动描述
    description = models.TextField(verbose_name='简介')               # 文本字段
    # 活动内容
    content = models.TextField(verbose_name='活动详细内容')
    # 活动封面
    cover = models.TextField(verbose_name='活动封面')
    # 活动类型
    type = models.CharField(max_length=100,verbose_name='活动类型')
    # 活动开始时间
    startTime_at = models.DateTimeField(verbose_name='开始时间')
    # 活动结束时间
    endTime_at = models.DateTimeField(verbose_name='结束时间')

    def __str__(self):
        return self.title # 后台显示标题

    class Meta:
        verbose_name = '活动'
        verbose_name_plural = '活动'  # 复数形式
