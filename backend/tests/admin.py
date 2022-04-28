from django.contrib import admin
from tests.models import Category, Test, Question


@admin.register(Test)
class TestAdmin(admin.ModelAdmin):
    list_display = ["title", "time_for_test"]


@admin.register(Category)
class CategoryAdmin(admin.ModelAdmin):
    list_display = ["title", "parent"]


@admin.register(Question)
class QuestionAdmin(admin.ModelAdmin):
    list_display = ["body_question"]
