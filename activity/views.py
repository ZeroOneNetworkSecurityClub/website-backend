from django.shortcuts import render
from requests import Response
from rest_framework.decorators import api_view

from activity.models import Activity
from activity.serializers import ActivitySerializer
from utils.response import Response


@api_view(['GET'])
def activity_list(request):
    activities = Activity.objects.all()
    serializer = ActivitySerializer(activities, many=True)
    return Response.success(data=serializer.data)