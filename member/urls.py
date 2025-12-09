#!/usr/bin/env python3
# auther: aipno
# -*- coding: utf-8 -*-
from django.urls import path

from member.views import member_list

urlpatterns = [
    path('list', member_list, name='member_list'),
]
