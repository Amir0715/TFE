from django.contrib import admin
from tests.models import Category, Test, Question, TestTimerSetting, VariantForQuestion, PassedTest, AnswerToQuestion, TestSetting


@admin.register(Test)
class TestAdmin(admin.ModelAdmin):
    list_display = ("title", "author", "category_title", "question_count")
    readonly_fields = ("created_at", "updated_at")

    fieldsets = (
        (None, {
            "fields": ("title", "description", "category", "author")
        }),
        ("Служебная", {
            "fields": ("created_at", "updated_at")
        })
    )


@admin.register(TestSetting)
class TestSettingAdmin(admin.ModelAdmin):
    list_display = ["id", "name"]
    readonly_fields = ("created_at", "updated_at")

    fieldsets = (
        (None, {
            "fields": ("name", "conflicts")
        }),
        ("Служебная", {
            "fields": ("created_at", "updated_at")
        })
    )


@admin.register(TestTimerSetting)
class TestTimerSettingAdmin(admin.ModelAdmin):
    list_display = ["id", "test", "timer_value"]
    readonly_fields = ("created_at", "updated_at")

    fieldsets = (
        (None, {
            "fields": ("test", "setting", "timer_value")
        }),
        ("Служебная", {
            "fields": ("created_at", "updated_at")
        })
    )


@admin.register(Category)
class CategoryAdmin(admin.ModelAdmin):
    list_display = ["id", "title", "parent"]
    readonly_fields = ("created_at", "updated_at")
    fieldsets = (
        (None, {
            "fields": ("title", "description", "parent")
        }),
        ("Служебная", {
            "fields": ("created_at", "updated_at")
        })
    )


@admin.register(Question)
class QuestionAdmin(admin.ModelAdmin):
    list_display = ["id", "title", "test", "type"]
    readonly_fields = ("created_at", "updated_at")
    fieldsets = (
        (None, {
            "fields": ("title", "body", "test", "type")
        }),
        ("Служебная", {
            "fields": ("created_at", "updated_at")
        })
    )


@admin.register(VariantForQuestion)
class VariantForQuestionAdmin(admin.ModelAdmin):
    list_display = ["id", "question", "value", "is_correct"]
    readonly_fields = ("created_at", "updated_at")
    fieldsets = (
        (None, {
            "fields": ("question", "value", "is_correct")
        }),
        ("Служебная", {
            "fields": ("created_at", "updated_at")
        })
    )


@admin.register(PassedTest)
class PassedTestAdmin(admin.ModelAdmin):
    list_display = ["id", "user", "test"]
    readonly_fields = ("created_at", "updated_at")
    fieldsets = (
        (None, {
            "fields": ("user", "test")
        }),
        ("Служебная", {
            "fields": ("created_at", "updated_at")
        })
    )


@admin.register(AnswerToQuestion)
class AnswerToQuestionAdmin(admin.ModelAdmin):
    list_display = ["id", "passed_test", "question"]
    readonly_fields = ("created_at", "updated_at")
    fieldsets = (
        (None, {
            "fields": ("passed_test", "question", "selected_variant", "open_answer")
        }),
        ("Служебная", {
            "fields": ("created_at", "updated_at")
        })
    )
