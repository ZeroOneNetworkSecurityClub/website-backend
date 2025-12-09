from rest_framework import serializers

from object.models import Object


class ObjectSerializer(serializers.ModelSerializer):
    file_url = serializers.SerializerMethodField()
    file_size = serializers.SerializerMethodField()

    class Meta:
        model = Object
        fields = ['id', 'file_name', 'file_url', 'file_size', 'created_at']
        read_only_fields = ['id', 'created_at']

    def get_file_url(self, obj):
        """获取文件的完整URL"""
        if obj.file_field:
            request = self.context.get('request')
            if request:
                return request.build_absolute_uri(obj.file_field.url)
            return obj.file_field.url
        return None

    def get_file_size(self, obj):
        """获取文件大小"""
        if obj.file_field and hasattr(obj.file_field, 'size'):
            return obj.file_field.size
        return None
