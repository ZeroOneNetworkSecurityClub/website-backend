#!/usr/bin/env python3
# auther: aipno
# -*- coding: utf-8 -*-

from django.urls import path
from . import views


urlpatterns = [
    path(r'list',views.activity_list,name='activity_list'),
]
