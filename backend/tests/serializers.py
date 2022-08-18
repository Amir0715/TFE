from rest_framework import serializers
from tests.models import Test, Category


class CategorySerializer(serializers.ModelSerializer):
    class Meta:
        model = Category
        fields = ["id", "title"]


class TestSerializer(serializers.ModelSerializer):
    category = CategorySerializer()

    class Meta:
        model = Test
        fields = ["id", "title", "description", "category", "question_count"]
