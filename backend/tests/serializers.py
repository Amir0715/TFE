from rest_framework import serializers
from tests.models import Question, Test, Category, VariantForQuestion


class VariantForQuestionSerializer(serializers.ModelSerializer):
    class Meta:
        model = VariantForQuestion
        fields = ["id", "value", "is_correct"]


class QuestionSerializer(serializers.ModelSerializer):
    variant_answers = VariantForQuestionSerializer(many=True)

    class Meta:
        model = Question
        fields = ["id", "title", "body", "type", "variant_answers"]


class CategorySerializer(serializers.ModelSerializer):
    class Meta:
        model = Category
        fields = ["id", "title", "parent"]


class TestSerializer(serializers.ModelSerializer):
    category = CategorySerializer()
    questions = QuestionSerializer(many=True)

    class Meta:
        model = Test
        fields = ["id", "title", "description",
                  "category", "question_count", "questions"]
