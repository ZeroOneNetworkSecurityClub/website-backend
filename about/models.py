from django.db import models

class AboutUs(models.Model):
    """
    关于我们
    """
    id = models.AutoField(primary_key=True)
    background = models.CharField(max_length=100,verbose_name='标题')
    missions = models.TextField(verbose_name='描述')
    history = models.TextField(verbose_name='内容')
    organization = models.DateTimeField(auto_now_add=True)

    class Meta:
        verbose_name = '关于我们'
        verbose_name_plural = '关于我们'


class History(models.Model):
    """
    历史
    """
    id = models.AutoField(primary_key=True)
    year = models.CharField(max_length=100,verbose_name='时间')
    title = models.CharField(max_length=100,verbose_name='标题')
    tag = models.CharField(max_length=100,verbose_name='标签')
    content = models.TextField(verbose_name='内容')

    class Meta:
        verbose_name = '历史'
        verbose_name_plural = '历史'

class Organization(models.Model):
    """
    组织架构
    """
    id = models.AutoField(primary_key=True)
    name = models.CharField(max_length=100,verbose_name='标题')
    description = models.TextField(verbose_name='内容')

    class Meta:
        verbose_name = '组织架构'
        verbose_name_plural = '组织架构'