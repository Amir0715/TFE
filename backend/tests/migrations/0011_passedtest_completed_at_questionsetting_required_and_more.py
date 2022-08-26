# Generated by Django 4.1 on 2022-08-26 18:23

from django.db import migrations, models
import django.db.models.deletion


class Migration(migrations.Migration):

    dependencies = [
        ("tests", "0010_auto_20220826_1815"),
    ]

    operations = [
        migrations.AddField(
            model_name="passedtest",
            name="completed_at",
            field=models.DateTimeField(
                blank=True, null=True, verbose_name="Время завершения теста"
            ),
        ),
        migrations.AddField(
            model_name="questionsetting",
            name="required",
            field=models.BooleanField(
                default=False, verbose_name="Необходимая настройка"
            ),
            preserve_default=False,
        ),
        migrations.CreateModel(
            name="QuestionOrderNumberSetting",
            fields=[
                (
                    "id",
                    models.BigAutoField(
                        auto_created=True,
                        primary_key=True,
                        serialize=False,
                        verbose_name="ID",
                    ),
                ),
                (
                    "created_at",
                    models.DateTimeField(
                        auto_now_add=True, verbose_name="Время создания"
                    ),
                ),
                (
                    "updated_at",
                    models.DateTimeField(
                        auto_now=True, verbose_name="Время обновления"
                    ),
                ),
                (
                    "order_number",
                    models.PositiveIntegerField(
                        verbose_name="Порядковый номер вопроса"
                    ),
                ),
                (
                    "question",
                    models.OneToOneField(
                        on_delete=django.db.models.deletion.CASCADE,
                        related_name="order_number",
                        to="tests.question",
                        verbose_name="Вопрос",
                    ),
                ),
                (
                    "setting",
                    models.ForeignKey(
                        on_delete=django.db.models.deletion.CASCADE,
                        related_name="order_number_values",
                        to="tests.questionsetting",
                        verbose_name="Настройка",
                    ),
                ),
            ],
            options={
                "verbose_name": "Значение настройки Порядковый номер",
                "verbose_name_plural": "Значения настройки Порядковый номер",
            },
        ),
    ]
