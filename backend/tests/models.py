from django.db import models
from django.conf import settings


class BaseModel(models.Model):
    created_at = models.DateTimeField(
        verbose_name="Время создания", auto_now_add=True)
    updated_at = models.DateTimeField(
        verbose_name="Время обновления", auto_now=True)

    class Meta:
        abstract = True


class Test(BaseModel):
    title = models.CharField(verbose_name="Название теста", max_length=100)
    description = models.TextField(verbose_name="Описание теста")
    category = models.ForeignKey(
        verbose_name="Категория",
        to="Category",
        on_delete=models.RESTRICT,
        related_name="tests",
    )
    author = models.ForeignKey(
        verbose_name="Автор",
        to=settings.AUTH_USER_MODEL,
        on_delete=models.RESTRICT
    )

    def __str__(self):
        return self.title

    def question_count(self) -> int:
        return self.questions.count()

    def category_title(self) -> str:
        return self.category.title

    class Meta:
        verbose_name = "Тест"
        verbose_name_plural = "Тесты"


class Category(BaseModel):
    title = models.CharField(verbose_name="Название категории", max_length=40)
    description = models.TextField(verbose_name="Описание категории")
    parent = models.ForeignKey(
        verbose_name="Родитель",
        to="self",
        null=True,
        on_delete=models.RESTRICT,
        blank=True,
        related_name="children",
    )

    def __str__(self):
        return self.title

    class Meta:
        verbose_name = "Категория"
        verbose_name_plural = "Категории"
        unique_together = ("id", "parent_id")


class QuestionType(models.IntegerChoices):
    Close = 1
    CloseWithFew = 2
    Open = 3


class Question(BaseModel):
    title = models.CharField(verbose_name="Загаловок вопроса", max_length=255)
    body = models.TextField(verbose_name="Описание вопроса")
    test = models.ForeignKey(
        verbose_name="Тест",
        to="Test",
        on_delete=models.CASCADE,
        related_name="questions"
    )
    type = models.IntegerField(choices=QuestionType.choices)

    def __str__(self):
        return self.title

    def variant_count(self) -> int:
        return self.variant_answers.count()

    class Meta:
        # for admin panel
        verbose_name = "Вопрос"
        verbose_name_plural = "Вопросы"


class QuestionSetting(BaseModel):
    name = models.CharField(verbose_name="Название настройки", max_length=255)
    # related_name не указан, так что используй conflicts_set
    conflicts = models.ManyToManyField(
        verbose_name="Конфликтующие настройки",
        to="self",
        null=True,
        blank=True
    )

    def __str__(self) -> str:
        return self.name

    class Meta:
        verbose_name = "Настройка вопроса"
        verbose_name_plural = "Настройки для вопросов"


class QuestionPointSetting(BaseModel):
    point = models.PositiveIntegerField(verbose_name="Кол-во баллов за этот вопрос")
    question = models.OneToOneField(
        verbose_name="Вопрос",
        to="Question",
        on_delete=models.CASCADE,
        related_name="point_settings",
        unique=True
    )
    setting = models.ForeignKey(
        verbose_name="Настройка",
        to="QuestionSetting",
        on_delete=models.CASCADE,
        related_name="point_values"
    )

    class Meta:
        verbose_name = "Значение настройки Кол-во баллов"
        verbose_name_plural = "Значения настройки Кол-во баллов"


class VariantForQuestion(BaseModel):
    question = models.ForeignKey(
        verbose_name="Вопрос",
        to="Question",
        on_delete=models.CASCADE,
        related_name="variant_answers"
    )
    value = models.TextField(verbose_name="Вариант ответа")
    is_correct = models.BooleanField(
        verbose_name="Правильный ответ", default=False)

    def __str__(self):
        return self.value

    class Meta:
        verbose_name = "Вариант ответа"
        verbose_name_plural = "Варианты ответа"
        unique_together = ("id", "question_id")


class PassedTest(BaseModel):
    user = models.ForeignKey(
        verbose_name="Прошедший",
        to=settings.AUTH_USER_MODEL,
        on_delete=models.CASCADE,
        related_name="passed_tests"
    )
    test = models.ForeignKey(
        verbose_name="Тест",
        to="Test",
        on_delete=models.CASCADE,
        related_name="passed"
    )

    class Meta:
        verbose_name = "Пройденный тест"
        verbose_name_plural = "Пройденные тесты"


class AnswerToQuestion(BaseModel):
    question = models.ForeignKey(
        verbose_name="Вопрос",
        to="Question",
        on_delete=models.CASCADE,
        related_name="answers"
    )
    selected_variant = models.ForeignKey(
        verbose_name="Выбранный ответ",
        to="VariantForQuestion",
        on_delete=models.CASCADE,
        related_name="in_answers",
        null=True,
        blank=True
    )
    passed_test = models.ForeignKey(
        verbose_name="Пренадлежит прохождению",
        to="PassedTest",
        on_delete=models.CASCADE,
        related_name="answers"
    )
    open_answer = models.TextField(
        verbose_name="Открытый ответ",
        blank=True
    )

    class Meta:
        verbose_name = "Ответ пользователя"
        verbose_name_plural = "Ответы пользователей"


class TestSetting(BaseModel):
    name = models.CharField(verbose_name="Название настройки", max_length=255)
    # related_name не указан, так что используй conflicts_set
    conflicts = models.ManyToManyField(
        verbose_name="Конфликтующие настройки",
        to="self",
        null=True,
        blank=True
    )

    def __str__(self) -> str:
        return self.name

    class Meta:
        verbose_name = "Настройка теста"
        verbose_name_plural = "Настройки для тестов"


class TestTimerSetting(BaseModel):
    test = models.OneToOneField(
        verbose_name="Тест",
        to="Test",
        on_delete=models.CASCADE,
        related_name="timer_settings",
        unique=True
    )
    setting = models.ForeignKey(
        verbose_name="Настройка",
        to="TestSetting",
        on_delete=models.CASCADE,
        related_name="timer_values"
    )
    timer_value = models.DurationField(verbose_name="Длительность")

    class Meta:
        verbose_name = "Значение настройки Таймера"
        verbose_name_plural = "Значения настройек Таймера"


class TestAvailabilityTimeRangeSetting(BaseModel):
    test = models.OneToOneField(
        verbose_name="Тест",
        to="Test",
        on_delete=models.CASCADE,
        related_name="availability_time_range_settings",
        unique=True
    )
    setting = models.ForeignKey(
        verbose_name="Настройка",
        to="TestSetting",
        on_delete=models.CASCADE,
        related_name="availability_time_range_values"
    )
    start_time = models.DateTimeField(verbose_name="Время начало доступа")
    end_time = models.DateTimeField(verbose_name="Время конца доступа")

    class Meta:
        verbose_name = "Значение настройки Доступность по времени"
        verbose_name_plural = "Значения настройки Доступность по времени"
