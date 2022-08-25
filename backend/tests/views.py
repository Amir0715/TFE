from django.shortcuts import get_object_or_404
from tests.models import Question, Test, TestSetting, QuestionSetting, Category
from tests.serializers import TestSerializer, CategoriesWithTests, CategorySerializer
from rest_framework import viewsets
from rest_framework.views import APIView
from rest_framework.response import Response


class GetAllTestSettings(APIView):
    def get(self, request, pk):
        dict_for_set_test_settings = {}
        settings_for_test = TestSetting.objects.all()
        test = get_object_or_404(Test, pk=pk)
        for setting in settings_for_test:
            if hasattr(test, setting.name):
                dict_for_set_test_settings[setting.name] = getattr(
                    test, setting.name
                ).to_dict()
            else:
                dict_for_set_test_settings[setting.name] = None

        return Response(dict_for_set_test_settings)


class GetAllQuestionSettings(APIView):
    def get(self, request, pk):
        dict_for_set_question_settings = {}
        setting_for_question = QuestionSetting.objects.all()
        question = get_object_or_404(Question, pk=pk)
        for setting in setting_for_question:
            if hasattr(question, setting.name):
                dict_for_set_question_settings[setting.name] = getattr(
                    question, setting.name
                ).to_dict()
            else:
                dict_for_set_question_settings[setting.name] = None
        return Response(dict_for_set_question_settings)


class TestViewSet(viewsets.ModelViewSet):
    queryset = Test.objects.all()
    serializer_class = TestSerializer


class CategoryListApiView(APIView):
    def get(self, request):
        categories = Category.objects.all()
        return Response(CategorySerializer(categories, many=True).data)


class CategoriesDetailApiView(APIView):
    def get(self, request, pk, format=None):
        category = get_object_or_404(Category, pk=pk)
        return Response(CategorySerializer(category).data)


class CategoriesDetailTestsApiView(APIView):
    def get(self, request, pk, format=None):
        category = get_object_or_404(Category, pk=pk)
        return Response(CategoriesWithTests(category).data)
