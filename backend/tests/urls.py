from django.urls import include, path

# from django.conf.urls import url
from tests.views import CategoriesDetailApiView, TestViewSet, CategoryListApiView, CategoriesDetailTestsApiView
from drf_spectacular.views import (
    SpectacularAPIView,
    SpectacularRedocView,
    SpectacularSwaggerView,
)

from rest_framework.routers import DefaultRouter

router = DefaultRouter()
router.register(r"tests", TestViewSet, basename="test")

urlpatterns = router.urls
urlpatterns += [
    path("categories/<int:pk>/tests/", CategoriesDetailTestsApiView.as_view()),
    path("categories/<int:pk>/", CategoriesDetailApiView.as_view()),
    path("categories/", CategoryListApiView.as_view()),

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
]
