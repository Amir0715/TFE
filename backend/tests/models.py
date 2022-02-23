from django.db import models
from django.db.models.fields.related import ForeignKey, ManyToManyField
from django.db import timezone


class VariantOfAnswer(models.BaseModel):
    value_of_answer = models.TextField(
        blank=True, verbose_name='Вариант ответа')

    def __str__(self):
        return self.value_of_answer

    class Meta:
        # for admin panel
        verbose_name = 'Вариант ответа'
        verbose_name_plural = 'Варианты ответа'


class Question(models.BaseModel):
    body_question = models.TextField(blank=True, verbose_name='Тело вопроса')
    category = models.ForeignKey(
        'Category', on_delete=models.CASCADE, verbose_name='Категория')
    variant_answer = models.ManyToManyField(VariantOfAnswer)
    try_answer = models.ManyToManyField(VariantOfAnswer)

    def __str__(self):
        return self.body_question

    class Meta:
        # for admin panel
        verbose_name = 'Вопрос'
        verbose_name_plural = 'Вопросы'


class Category(models.Basemodel):
    title = models.TextField(blank=True, verbose_name='Категория')

    def __str__(self):
        return self.title

    class Meta:
        verbose_name = 'Категория'
        verbose_name_plural = 'Категории'


class AnswersFromHuman(models.Basemodel):
    question = models.ForeignKey(
        'Question', on_delete=models.CASCADE, verbose_name='Вопрос')
    # Вот тут чето не понятно.!!!
    answer_from_user = models.ForeignKey(
        'VariantOfAnswer', on_delete=models.CASCADE, verbose_name='Вариант ответа от пользователя')
    # Вот тут чето не понятно.!!!

    

class Test(models.Basemodel):
    pass
