# TODO: views:
#   - Клиент получает список тестов
#   - Клиент получает список пользователей которые прошли тест
#   - Клиент получает список вопросов теста
#   - Клиент получает список доступных ответов вопроса теста

from rest_framework import viewsets
from tests.models import Test
from tests.serializers import TestSerializer


class TestViewSet(viewsets.ModelViewSet):
    queryset = Test.objects.all()
    serializer_class = TestSerializer
