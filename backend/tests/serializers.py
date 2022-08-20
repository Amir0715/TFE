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


class TestShortInfoSerializer(serializers.ModelSerializer):
    class Meta:
        model = Test
        fields = ["id", "title", "description", "question_count"]


class RecursiveSrializer(serializers.Serializer):
    '''
    Рекурсивная сериалазиация потомков
    '''

    def to_representation(self, value):
        serializer = self.parent.parent.__class__(value, context=self.context)
        return serializer.data


class CategoriesWithTests(serializers.ModelSerializer):
    children = RecursiveSrializer(many=True, required=False)
    tests = TestShortInfoSerializer(many=True)

    class Meta:
        model = Category
        fields = ["id", "title", "tests", "children"]
