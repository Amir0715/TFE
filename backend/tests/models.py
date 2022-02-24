from django.db import models
from django.db.models.fields.related import ForeignKey, ManyToManyField
from django.db import timezone


class BaseModel(models.Model):
    created_at = models.Datetime(auto_now_add=True)
    updated_at = models.Datetime(auto_now=True)


class VariantOfAnswer(BaseModel):
    # Убрать blank
    value_of_answer = models.TextField(verbose_name='Вариант ответа')

    def __str__(self):
        return self.value_of_answer

    class Meta:
        # for admin panel
        verbose_name = 'Вариант ответа'
        verbose_name_plural = 'Варианты ответа'


class Question(BaseModel):
    # M2M какой verbose_name?
    body_question = models.TextField(verbose_name='Тело вопроса')
    category = models.ForeignKey(
        'Category', on_delete=models.RESTRICT, verbose_name='Категория', related_name='categories')
    variant_answers = models.ManyToManyField(
        VariantOfAnswer, through='QuestionVariantOfAnswer')

    def __str__(self):
        return self.body_question

    class Meta:
        # for admin panel
        verbose_name = 'Вопрос'
        verbose_name_plural = 'Вопросы'


class QuestionVariantOfAnswer(BaseModel):
    # По сути сами создаём третью и явно указываем её в question.
    question = models.ForeignKey(
        'Question', on_delete=models.RESTRICT, verbose_name='Вопрос', related_name='questions')
    variant_of_answer = models.ForeignKey(
        'VariantOfAnswer', on_delete=models.RESTRICT, verbose_name='Вариант ответа', related_name='variants_of_questions')
    is_correct = models.BooleanField(default=False)


class Category(BaseModel):
    title = models.TextField(verbose_name='Категория')

    def __str__(self):
        return self.title

    class Meta:
        verbose_name = 'Категория'
        verbose_name_plural = 'Категории'


class AnswersFromHuman(BaseModel):

    # question - id вопроса на который ответил пользователь
    question = models.ForeignKey(
        'Question', on_delete=models.RESTRICT, verbose_name='Вопрос на который отвечают', related_name='active_question')
    # answers_from_user Many to Many - так как может быть много ответов на один вопрос.
    answers_from_user = models.ManyToManyField(
        VariantOfAnswer, verbose_name='Вариант ответа пользователя')
    complited_test = models.ForeignKey(
        'ComlitedUserTest', on_delete=models.RESTRICT, verbose_name='Принадлежит тесту', related_name='answers')


class ComplitedUserTest(BaseModel):
    test = models.ForeignKey('Test', on_delete=models.RESTRICT,
                             verbose_name='Пройденный тест', related_name='complited_tests')
    started_at = models.DateTimeField(
        auto_now_add=True, verbose_name='Время начало теста')
    end_at = models.DateTimeField(verbose_name='Время окончания теста')
    score_from_test = models.PositiveSmallIntegerField(
        verbose_name='Количество баллов за тест')


class Test(BaseModel):
    title = models.CharField(max_length=100, verbose_name='Название теста')
    description = models.CharField(
        max_length=300, verbose_name='Описание теста')
    time_for_test = models.DurationField()
    # TODO один тест может содержать много одинаковых вопросов, подумать под unique?
    question = models.ManyToManyField(
        'Question', verbose_name='Вопрос', related_name='tests')

    def __str__(self):
        return self.title
