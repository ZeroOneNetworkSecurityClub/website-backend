import os
from pathlib import Path

# 在项目内部像这样构建路径：BASE_DIR / 'subdir'。
BASE_DIR = Path(__file__).resolve().parent.parent

# 快速启动开发设置 - 不适合生产
# 安全警告：请保守生产中使用的密钥！
SECRET_KEY = 'django-insecure-0^+5#zm#*=1@!u$f+cib=90hjvcgk@2fa&di(=zo**+o+ky%82'

# 安全警告：不要在生产环境中开启调试运行！
DEBUG = True

ALLOWED_HOSTS = []

# 应用配置
INSTALLED_APPS = [
    'django.contrib.admin',
    'django.contrib.auth',
    'django.contrib.contenttypes',
    'django.contrib.sessions',
    'django.contrib.messages',
    'django.contrib.staticfiles',
    'activity',
    'object',
    'member',
    'about',
    'contact',
]

MIDDLEWARE = [
    'django.middleware.security.SecurityMiddleware',
    'django.contrib.sessions.middleware.SessionMiddleware',
    'django.middleware.common.CommonMiddleware',
    # 'django.middleware.csrf.CsrfViewMiddleware',
    'django.contrib.auth.middleware.AuthenticationMiddleware',
    'django.contrib.messages.middleware.MessageMiddleware',
    'django.middleware.clickjacking.XFrameOptionsMiddleware',
]

ROOT_URLCONF = 'website_backend.urls'

WSGI_APPLICATION = 'website_backend.wsgi.application'

# 数据库
DATABASES = {
    'default': {
        'ENGINE': 'django.db.backends.mysql',  # 数据库引擎
        'NAME': 'club_website',  # 数据库名
        'USER': 'root',  # MySQL用户名
        'PASSWORD': '123456',  # MySQL密码
        'HOST': 'localhost',  # 数据库地址
        'PORT': '3306',  # 端口 (默认3306)
    }
}

# 对象文件 URL 前缀
MEDIA_URL = '/file/'
# 对象文件根目录
MEDIA_ROOT = os.path.join(BASE_DIR, 'file/')

# 模板设置
TEMPLATES = [
    {
        'BACKEND': 'django.template.backends.django.DjangoTemplates',
        'DIRS': [BASE_DIR / 'templates'],  # Optional
        'APP_DIRS': True,  # This is CRITICAL for admin
        'OPTIONS': {
            'context_processors': [
                'django.template.context_processors.debug',
                'django.template.context_processors.request',
                'django.contrib.auth.context_processors.auth',
                'django.contrib.messages.context_processors.messages',
            ],
        },
    },
]

# 密码验证
AUTH_PASSWORD_VALIDATORS = [
    {
        'NAME': 'django.contrib.auth.password_validation.UserAttributeSimilarityValidator',
    },
    {
        'NAME': 'django.contrib.auth.password_validation.MinimumLengthValidator',
    },
    {
        'NAME': 'django.contrib.auth.password_validation.CommonPasswordValidator',
    },
    {
        'NAME': 'django.contrib.auth.password_validation.NumericPasswordValidator',
    },
]

# 国际化
LANGUAGE_CODE = 'zh-hans'

TIME_ZONE = 'Asia/Shanghai'

USE_I18N = True

USE_TZ = False

# 静态文件 (CSS, JavaScript, Images)
STATIC_URL = 'static/'
