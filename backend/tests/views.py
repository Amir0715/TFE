from rest_framework import viewsets
from tests.models import Question, Test, TestSetting, QuestionSetting
from tests.serializers import TestSerializer
from rest_framework.views import APIView
from rest_framework.response import Response


class GetAllTestSettings(APIView):
    def get(self, request, pk):
        dict_for_set_test_settings = {}
        settings_for_test = TestSetting.objects.all()
        test = Test.objects.get(pk=pk)
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
        question = Question.objects.get(pk=pk)

        for setting in setting_for_question:
            if hasattr(question, setting.name):
                dict_for_set_question_settings[setting.name] = getattr(
                    question, setting.name
                ).to_dict()
            else:
                dict_for_set_question_settings[setting.name] = None
        return Response(dict_for_set_question_settings)
