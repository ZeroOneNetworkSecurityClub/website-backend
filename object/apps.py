from django.apps import AppConfig


class ObjectConfig(AppConfig):
    name = 'object'

    """
    Django信号是一种观察者模式的实现，允许某些发送者通知一组接收者发生了某个动作。
    这是一种解耦应用组件的方式，使得不同部分可以在事件发生时执行相应操作而不必直接依赖彼此。
    
    Django信号工作机制:
    信号发送者(Sender): 触发事件的对象或类
    信号(Signal): 代表特定事件的实例
    接收者(Receiver): 响应信号的函数
    连接(Connection): 将信号与接收者绑定的过程
    
    Django内置信号类型
    pre_save / post_save: 模型保存前后
    pre_delete / post_delete: 模型删除前后
    m2m_changed: 多对多关系变更
    request_started / request_finished: 请求开始/结束
    """

    # 注册信号
    def ready(self):
        import object.signals