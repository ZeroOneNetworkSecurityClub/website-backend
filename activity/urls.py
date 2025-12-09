#!/usr/bin/env python3
# auther: aipno
# -*- coding: utf-8 -*-

from django.urls import path

from activity.views import activity_list, activity_detail, activity_page

urlpatterns = [
    path('list', activity_list, name='activity_list'),

    path('page', activity_page, name='activity_page'),

    path('detail/<int:pk>', activity_detail, name='activity_detail'),
]
