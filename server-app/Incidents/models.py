from django.db import models


class Incident(models.Model):
    incident_type = models.CharField(max_length=200, null=False)
    county = models.CharField(max_length=200, null=False)
    city = models.CharField(max_length=200, default="")
    state = models.CharField(max_length=200, null=False)
    latitude = models.DecimalField(max_digits=9, decimal_places=6, default=0)
    longitude = models.DecimalField(max_digits=9, decimal_places=6, default=0)
