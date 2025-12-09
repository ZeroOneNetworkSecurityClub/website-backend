from member.models import Member
from member.serializer import MemberSerializer
from utils.response import Response


def member_list(request):
    members = Member.objects.all()
    data = MemberSerializer(members, many=True).data
    return Response.success(data=data)
