from rest_framework import serializers
from tests.models import Test

class TestSerializer(serializers.ModelSerializer):
    class Meta:
        model = Test
