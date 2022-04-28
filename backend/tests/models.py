from django.db import models


class BaseModel(models.Model):
    created_at = models.DateTimeField(verbose_name="Время создания", auto_now_add=True)
    updated_at = models.DateTimeField(verbose_name="Время обновления", auto_now=True)

    class Meta:
        abstract = True


class VariantOfAnswer(BaseModel):
    # Убрать blank
    value_of_answer = models.TextField(verbose_name="Вариант ответа")

    def __str__(self):
        return self.value_of_answer

    class Meta:
        # for admin panel
        verbose_name = "Вариант ответа"
        verbose_name_plural = "Варианты ответа"


class Question(BaseModel):
    # M2M какой verbose_name?
    body_question = models.TextField(verbose_name="Тело вопроса")

    variant_answers = models.ManyToManyField(
        verbose_name="Варианты", to="VariantOfAnswer", through="QuestionVariantOfAnswer"
    )

    def __str__(self):
        return self.body_question

    class Meta:
        # for admin panel
        verbose_name = "Вопрос"
        verbose_name_plural = "Вопросы"


class QuestionVariantOfAnswer(BaseModel):
    # По сути сами создаём третью и явно указываем её в question.
    question = models.ForeignKey(
        verbose_name="Вопрос",
        to="Question",
        on_delete=models.RESTRICT,
        related_name="questions",
    )
    variant_of_answer = models.ForeignKey(
        verbose_name="Вариант ответа",
        to="VariantOfAnswer",
        on_delete=models.RESTRICT,
        related_name="variants_of_questions",
    )
    is_correct = models.BooleanField(default=False)


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


class AnswersFromHuman(BaseModel):

    # question - id вопроса на который ответил пользователь
    question = models.ForeignKey(
        verbose_name="Вопрос на который отвечают",
        to="Question",
        on_delete=models.RESTRICT,
        related_name="active_question",
    )
    # answers_from_user Many to Many - так как может быть много ответов на один вопрос.
    answers_from_user = models.ManyToManyField(
        verbose_name="Вариант ответа пользователя",
        to="VariantOfAnswer",
    )
    complited_test = models.ForeignKey(
        verbose_name="Принадлежит тесту",
        to="ComplitedUserTest",
        on_delete=models.RESTRICT,
        related_name="answers",
    )

    class Meta:
        verbose_name = "Ответ пользователя"
        verbose_name_plural = "Ответы пользователя"


class ComplitedUserTest(BaseModel):
    test = models.ForeignKey(
        verbose_name="Пройденный тест",
        to="Test",
        on_delete=models.RESTRICT,
        related_name="complited_tests",
    )
    started_at = models.DateTimeField(
        verbose_name="Время начало теста",
        auto_now_add=True,
    )
    end_at = models.DateTimeField(verbose_name="Время окончания теста")
    score_from_test = models.PositiveIntegerField(
        verbose_name="Количество баллов за тест"
    )

    class Meta:
        verbose_name = "Пройденный тест пользователя"
        verbose_name_plural = "Пройденные тесты пользователей"


class Test(BaseModel):
    title = models.CharField(verbose_name="Название теста", max_length=100)
    description = models.TextField(verbose_name="Описание теста")
    time_for_test = models.DurationField(
        verbose_name="Ограничение по времени", blank=True, null=True
    )
    question = models.ManyToManyField(
        verbose_name="Вопрос",
        to="Question",
        through="TestQuestion",
        related_name="tests",
    )
    category = models.ForeignKey(
        verbose_name="Категория",
        to="Category",
        on_delete=models.RESTRICT,
        related_name="categories",
    )

    def __str__(self):
        return self.title

    class Meta:
        verbose_name = "Тест"
        verbose_name_plural = "Тесты"


class TestQuestion(BaseModel):
    test = models.ForeignKey(verbose_name="Тест", to="Test", on_delete=models.CASCADE)
    question = models.ForeignKey(
        verbose_name="Вопрос", to="Question", on_delete=models.CASCADE
    )

    class Meta:
        verbose_name = "Ответ на тест"
        verbose_name_plural = "Ответы на тесты"
        unique_together = ("test", "question")
