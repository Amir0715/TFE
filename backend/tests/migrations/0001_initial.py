# Generated by Django 4.0.4 on 2022-04-28 17:29

from django.db import migrations, models
import django.db.models.deletion


class Migration(migrations.Migration):

    initial = True

    dependencies = [
    ]

    operations = [
        migrations.CreateModel(
            name='Category',
            fields=[
                ('id', models.BigAutoField(auto_created=True, primary_key=True, serialize=False, verbose_name='ID')),
                ('created_at', models.DateTimeField(auto_now_add=True, verbose_name='Время создания')),
                ('updated_at', models.DateTimeField(auto_now=True, verbose_name='Время обновления')),
                ('title', models.CharField(max_length=40, verbose_name='Название категории')),
                ('description', models.TextField(verbose_name='Описание категории')),
                ('parent', models.ForeignKey(null=True, on_delete=django.db.models.deletion.RESTRICT, to='tests.category', verbose_name='Родитель')),
            ],
            options={
                'verbose_name': 'Категория',
                'verbose_name_plural': 'Категории',
            },
        ),
        migrations.CreateModel(
            name='Question',
            fields=[
                ('id', models.BigAutoField(auto_created=True, primary_key=True, serialize=False, verbose_name='ID')),
                ('created_at', models.DateTimeField(auto_now_add=True, verbose_name='Время создания')),
                ('updated_at', models.DateTimeField(auto_now=True, verbose_name='Время обновления')),
                ('body_question', models.TextField(verbose_name='Тело вопроса')),
            ],
            options={
                'verbose_name': 'Вопрос',
                'verbose_name_plural': 'Вопросы',
            },
        ),
        migrations.CreateModel(
            name='Test',
            fields=[
                ('id', models.BigAutoField(auto_created=True, primary_key=True, serialize=False, verbose_name='ID')),
                ('created_at', models.DateTimeField(auto_now_add=True, verbose_name='Время создания')),
                ('updated_at', models.DateTimeField(auto_now=True, verbose_name='Время обновления')),
                ('title', models.CharField(max_length=100, verbose_name='Название теста')),
                ('description', models.TextField(verbose_name='Описание теста')),
                ('time_for_test', models.DurationField(blank=True, null=True, verbose_name='Ограничение по времени')),
                ('category', models.ForeignKey(on_delete=django.db.models.deletion.RESTRICT, related_name='categories', to='tests.category', verbose_name='Категория')),
            ],
            options={
                'verbose_name': 'Тест',
                'verbose_name_plural': 'Тесты',
            },
        ),
        migrations.CreateModel(
            name='VariantOfAnswer',
            fields=[
                ('id', models.BigAutoField(auto_created=True, primary_key=True, serialize=False, verbose_name='ID')),
                ('created_at', models.DateTimeField(auto_now_add=True, verbose_name='Время создания')),
                ('updated_at', models.DateTimeField(auto_now=True, verbose_name='Время обновления')),
                ('value_of_answer', models.TextField(verbose_name='Вариант ответа')),
            ],
            options={
                'verbose_name': 'Вариант ответа',
                'verbose_name_plural': 'Варианты ответа',
            },
        ),
        migrations.CreateModel(
            name='TestQuestion',
            fields=[
                ('id', models.BigAutoField(auto_created=True, primary_key=True, serialize=False, verbose_name='ID')),
                ('created_at', models.DateTimeField(auto_now_add=True, verbose_name='Время создания')),
                ('updated_at', models.DateTimeField(auto_now=True, verbose_name='Время обновления')),
                ('question', models.ForeignKey(on_delete=django.db.models.deletion.CASCADE, to='tests.question', verbose_name='Вопрос')),
                ('test', models.ForeignKey(on_delete=django.db.models.deletion.CASCADE, to='tests.test', verbose_name='Тест')),
            ],
            options={
                'verbose_name': 'Ответ на тест',
                'verbose_name_plural': 'Ответы на тесты',
                'unique_together': {('test', 'question')},
            },
        ),
        migrations.AddField(
            model_name='test',
            name='question',
            field=models.ManyToManyField(related_name='tests', through='tests.TestQuestion', to='tests.question', verbose_name='Вопрос'),
        ),
        migrations.CreateModel(
            name='QuestionVariantOfAnswer',
            fields=[
                ('id', models.BigAutoField(auto_created=True, primary_key=True, serialize=False, verbose_name='ID')),
                ('created_at', models.DateTimeField(auto_now_add=True, verbose_name='Время создания')),
                ('updated_at', models.DateTimeField(auto_now=True, verbose_name='Время обновления')),
                ('is_correct', models.BooleanField(default=False)),
                ('question', models.ForeignKey(on_delete=django.db.models.deletion.RESTRICT, related_name='questions', to='tests.question', verbose_name='Вопрос')),
                ('variant_of_answer', models.ForeignKey(on_delete=django.db.models.deletion.RESTRICT, related_name='variants_of_questions', to='tests.variantofanswer', verbose_name='Вариант ответа')),
            ],
            options={
                'abstract': False,
            },
        ),
        migrations.AddField(
            model_name='question',
            name='variant_answers',
            field=models.ManyToManyField(through='tests.QuestionVariantOfAnswer', to='tests.variantofanswer', verbose_name='Варианты'),
        ),
        migrations.CreateModel(
            name='ComplitedUserTest',
            fields=[
                ('id', models.BigAutoField(auto_created=True, primary_key=True, serialize=False, verbose_name='ID')),
                ('created_at', models.DateTimeField(auto_now_add=True, verbose_name='Время создания')),
                ('updated_at', models.DateTimeField(auto_now=True, verbose_name='Время обновления')),
                ('started_at', models.DateTimeField(auto_now_add=True, verbose_name='Время начало теста')),
                ('end_at', models.DateTimeField(verbose_name='Время окончания теста')),
                ('score_from_test', models.PositiveIntegerField(verbose_name='Количество баллов за тест')),
                ('test', models.ForeignKey(on_delete=django.db.models.deletion.RESTRICT, related_name='complited_tests', to='tests.test', verbose_name='Пройденный тест')),
            ],
            options={
                'verbose_name': 'Пройденный тест пользователя',
                'verbose_name_plural': 'Пройденные тесты пользователей',
            },
        ),
        migrations.CreateModel(
            name='AnswersFromHuman',
            fields=[
                ('id', models.BigAutoField(auto_created=True, primary_key=True, serialize=False, verbose_name='ID')),
                ('created_at', models.DateTimeField(auto_now_add=True, verbose_name='Время создания')),
                ('updated_at', models.DateTimeField(auto_now=True, verbose_name='Время обновления')),
                ('answers_from_user', models.ManyToManyField(to='tests.variantofanswer', verbose_name='Вариант ответа пользователя')),
                ('complited_test', models.ForeignKey(on_delete=django.db.models.deletion.RESTRICT, related_name='answers', to='tests.complitedusertest', verbose_name='Принадлежит тесту')),
                ('question', models.ForeignKey(on_delete=django.db.models.deletion.RESTRICT, related_name='active_question', to='tests.question', verbose_name='Вопрос на который отвечают')),
            ],
            options={
                'verbose_name': 'Ответ пользователя',
                'verbose_name_plural': 'Ответы пользователя',
            },
        ),
    ]
