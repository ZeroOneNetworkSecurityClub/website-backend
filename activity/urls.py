#!/usr/bin/env python3
# auther: aipno
# -*- coding: utf-8 -*-

from django.urls import path
from activity.views import activity_list

urlpatterns = [
    path('list', activity_list, name='activity_list'),
]
