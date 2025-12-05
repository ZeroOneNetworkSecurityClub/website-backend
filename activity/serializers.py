#!/usr/bin/env python3
# auther: aipno
# -*- coding: utf-8 -*-
from rest_framework import serializers
from activity.models import Activity

# 序列化类，继承自serializers.ModelSerializer
class ActivitySerializer(serializers.ModelSerializer):
    class Meta:             # 定义与序列化器相关的元数据
        model = Activity    # 关联模型
        fields = '__all__'  # 序列化所有字段