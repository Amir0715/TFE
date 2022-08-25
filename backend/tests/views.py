from rest_framework import viewsets
from rest_framework.views import APIView
from rest_framework.response import Response
from tests.models import Category, Test
from tests.serializers import CategoriesWithTests, CategorySerializer, TestSerializer
from django.shortcuts import get_object_or_404


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
