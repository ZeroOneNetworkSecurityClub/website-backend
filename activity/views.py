from requests import Response
from rest_framework.decorators import api_view

from activity.models import Activity
from activity.serializers import ActivitySerializer
from utils.response import Response


#  活动列表
@api_view(['GET'])
def activity_list(request):
    activities = Activity.objects.all().order_by('date')
    serializer = ActivitySerializer(activities, many=True)
    return Response.success(data=serializer.data)

# 活动分页
@api_view(['POST'])
def activity_page(request):

    page = request.GET.get('page', 1)
    page_size = request.GET.get('page_size', 8)
    
    try:
        page = int(page)
        page_size = int(page_size)
    except ValueError:
        page = 1
        page_size = 10
    
    start = (page - 1) * page_size
    end = start + page_size
    
    activities = Activity.objects.all()[start:end]
    total_activities = Activity.objects.count()
    total_pages = (total_activities + page_size - 1) // page_size
    
    serializer = ActivitySerializer(activities, many=True)
    return Response.paginated(serializer.data, total_activities, page, page_size, total_pages=total_pages)

# 活动详情
@api_view(['POST'])
def activity_detail(request, pk):
    try:
        activity = Activity.objects.get(pk=pk)
        serializer = ActivitySerializer(activity)
        return Response.success(data=serializer.data)
    except Activity.DoesNotExist:
        return Response.error(message='活动不存在', code=404)