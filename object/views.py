from django.core.exceptions import ObjectDoesNotExist
from rest_framework.decorators import api_view

from object.serializers import ObjectSerializer
from utils.response import Response
from .models import Object


@api_view(['GET'])
def object_list(request):
    try:
        file_obj = Object.objects.all()
        data = ObjectSerializer(file_obj, many=True, context={'request': request})
        return Response.success(data=data.data)
    except ObjectDoesNotExist:
        return Response.error(message='请求失败', code=400)


@api_view(['POST'])
def upload_file(request):
    if request.FILES.get('file'):
        file = request.FILES.get('file')

        # 使用模型保存
        file_obj = Object(file_field=file)
        file_obj.file_name = file.name
        file_obj.save()

        return Response.success(data={'file_id': file_obj.id})

    return Response.error(message='文件上传失败')


@api_view(['POST'])
def delete_file(request):
    file_id = request.GET.get('file_id')
    try:
        file_obj = Object.objects.get(id=file_id)
        # 执行删除操作
        file_obj.delete()
        return Response.success(message='文件删除成功')
    except ObjectDoesNotExist:
        return Response.error(message='文件不存在', code=404)


@api_view(['POST'])
def rename_file(request):
    file_id = request.GET.get('file_id')
    new_name = request.GET.get('new_name')
    try:
        file_obj = Object.objects.get(id=file_id)
        file_obj.file_name = new_name
        file_obj.save()
        return Response.success(message='文件重命名成功')
    except ObjectDoesNotExist:
        return Response.error(message='文件不存在', code=404)
