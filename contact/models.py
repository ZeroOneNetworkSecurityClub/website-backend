from django.db import models

class Details(models.Model):
    """
    详情表
    """
    id = models.AutoField(primary_key=True)
    type = models.CharField(max_length=100,verbose_name='详情')
    value = models.CharField(max_length=100,verbose_name='详情')

    class Meta:
        verbose_name = '详情'
        verbose_name_plural = '详情'


class Social(models.Model):
    """
    社交信息表
    """
    id = models.AutoField(primary_key=True)
    name = models.CharField(max_length=100,verbose_name='社交信息')
    url = models.CharField(max_length=100,verbose_name='社交信息链接')

    class Meta:
        verbose_name = '社交信息'
        verbose_name_plural = '社交信息'


class JoinUs(models.Model):
    """
    加入我们表
    """
    id = models.AutoField(primary_key=True)
    description = models.CharField(max_length=100,verbose_name='加入我们')
    conditions = models.CharField(max_length=100,verbose_name='加入条件')
    steps = models.CharField(max_length=100,verbose_name='加入步骤')
    applicationUrl = models.CharField(max_length=100,verbose_name='申请链接')

    class Meta:
        verbose_name = '加入我们'
        verbose_name_plural = '加入我们'


class Contact(models.Model):
    """
    联系我们表
    """
    id = models.AutoField(primary_key=True)
    details = models.ForeignKey(Details, on_delete=models.CASCADE, verbose_name='详情')
    socialLinks = models.ForeignKey(Social, on_delete=models.CASCADE, verbose_name='社交信息')
    joinUs = models.ForeignKey(JoinUs, on_delete=models.CASCADE, verbose_name='加入我们')

    class Meta:
        verbose_name = '联系我们'
        verbose_name_plural = '联系我们'
