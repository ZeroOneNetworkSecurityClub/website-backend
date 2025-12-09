from about.models import History
from about.serializers import HistorySerializer
from utils.response import Response


def history_list(request):
    histories = History.objects.all()
    data = HistorySerializer(histories, many=True).data
    return Response.success(data=data)
