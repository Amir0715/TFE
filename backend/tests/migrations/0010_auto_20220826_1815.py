# Generated by Django 4.1 on 2022-08-26 18:15

from django.db import migrations


def create_settings(apps, schema_editor):
    QuestionSetting = apps.get_model('tests', 'QuestionSetting')
    QuestionSetting(name="point").save()


class Migration(migrations.Migration):

    dependencies = [
        ("tests", "0009_alter_questionpointsetting_question_and_more"),
    ]

    operations = [migrations.RunPython(create_settings), ]