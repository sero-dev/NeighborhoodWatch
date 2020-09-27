# Generated by Django 3.1.1 on 2020-09-27 04:57

from django.db import migrations, models


class Migration(migrations.Migration):

    dependencies = [
        ('Incidents', '0001_initial'),
    ]

    operations = [
        migrations.AddField(
            model_name='incident',
            name='city',
            field=models.CharField(default='', max_length=200),
        ),
        migrations.AddField(
            model_name='incident',
            name='latitude',
            field=models.DecimalField(decimal_places=6, default=0, max_digits=9),
        ),
        migrations.AddField(
            model_name='incident',
            name='longitude',
            field=models.DecimalField(decimal_places=6, default=0, max_digits=9),
        ),
    ]
