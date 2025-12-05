from django.http import JsonResponse, HttpResponse
from django.shortcuts import redirect


class Response:
    """
    响应工具类
    用法:
        return Response.success(data={'id': 1})
        return Response.error('操作失败', code=400)
        return Response.redirect('/home/')
    """

    @staticmethod
    def success(data=None, message='Success', status=200):
        """成功响应"""
        response_data = {
            'success': True,
            'code': status,
            'message': message,
            'data': data,
            'timestamp': Response._get_timestamp()
        }
        return JsonResponse(response_data, status=status)

    @staticmethod
    def error(message='Error', data=None, code=400, status=400):
        """错误响应"""
        response_data = {
            'success': False,
            'code': code,
            'message': message,
            'data': data,
            'timestamp': Response._get_timestamp()
        }
        return JsonResponse(response_data, status=status)

    @staticmethod
    def json(data, status=200, **kwargs):
        """直接返回JSON"""
        if isinstance(data, dict) and 'success' not in data:
            data = {
                'success': True,
                'code': status,
                'data': data,
                'timestamp': Response._get_timestamp()
            }
        return JsonResponse(data, status=status, **kwargs)

    @staticmethod
    def html(html_content, status=200):
        """返回HTML"""
        return HttpResponse(html_content, content_type='text/html', status=status)

    @staticmethod
    def text(text_content, status=200):
        """返回纯文本"""
        return HttpResponse(text_content, content_type='text/plain', status=status)

    @staticmethod
    def redirect(url, permanent=False):
        """重定向"""
        return redirect(url, permanent=permanent)

    @staticmethod
    def not_found(message='资源不存在'):
        """404响应"""
        return Response.error(message, code=404, status=404)

    @staticmethod
    def forbidden(message='没有权限'):
        """403响应"""
        return Response.error(message, code=403, status=403)

    @staticmethod
    def bad_request(message='请求参数错误'):
        """400响应"""
        return Response.error(message, code=400, status=400)

    @staticmethod
    def server_error(message='服务器内部错误'):
        """500响应"""
        return Response.error(message, code=500, status=500)

    @staticmethod
    def paginated(data_list, total, page, page_size, **kwargs):
        """分页响应"""
        return Response.success({
            'list': data_list,
            'pagination': {
                'total': total,
                'page': page,
                'page_size': page_size,
                'total_pages': (total + page_size - 1) // page_size,
                'has_next': page * page_size < total,
                'has_previous': page > 1
            },
            **kwargs
        })

    @staticmethod
    def _get_timestamp():
        """获取当前时间戳"""
        from datetime import datetime
        return datetime.now().isoformat()


def success(data=None, message='Success', status=200):
    """快捷成功响应函数"""
    return Response.success(data, message, status)


def error(message='Error', data=None, code=400, status=400):
    """快捷错误响应函数"""
    return Response.error(message, data, code, status)


def json_resp(data, status=200, **kwargs):
    """快捷JSON响应函数"""
    return Response.json(data, status, **kwargs)