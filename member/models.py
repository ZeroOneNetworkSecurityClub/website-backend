from django.db import models

class Member(models.Model):
    """
    成员详情表
    """
    id = models.AutoField(primary_key=True)
    # 成员名称
    name = models.CharField(max_length=100,verbose_name='成员名称')
    # 职位
    position = models.CharField(max_length=100,verbose_name='成员职位')
    # 描述
    description = models.TextField(verbose_name='描述')
    # 头像
    avatar = models.TextField(verbose_name='头像')
    # 加入时间
    joinedAt = models.DateTimeField(verbose_name='加入时间')

    def __str__(self):
        return self.name

    class Meta:
        verbose_name = '成员'
        verbose_name_plural = verbose_name
