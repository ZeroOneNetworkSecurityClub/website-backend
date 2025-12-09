#!/usr/bin/env python3
# auther: aipno
# -*- coding: utf-8 -*-
from django.urls import path

from about.views import history_list

urlpatterns = [
    path('history/list', history_list, name='history_list'),
]