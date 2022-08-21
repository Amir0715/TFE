from django.urls import include, path

# from django.conf.urls import url
from tests.views import GetAllTestSettings, GetAllQuestionSettings
from drf_spectacular.views import (
    SpectacularAPIView,
    SpectacularRedocView,
    SpectacularSwaggerView,
)

from rest_framework.routers import DefaultRouter

router = DefaultRouter()

urlpatterns = router.urls
urlpatterns += [
    path("schema/", SpectacularAPIView.as_view(), name="schema"),
    # Optional UI:
    path(
        "schema/swagger-ui/",
        SpectacularSwaggerView.as_view(url_name="schema"),
        name="swagger-ui",
    ),
    path(
        "schema/redoc/", SpectacularRedocView.as_view(url_name="schema"), name="redoc"
    ),
    path("settings/test/<int:pk>/", GetAllTestSettings.as_view()),
    path("settings/question/<int:pk>/", GetAllQuestionSettings.as_view()),
]
