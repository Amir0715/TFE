#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["TFE.Presentation.WebApi/TFE.WebApi.csproj", "TFE.Presentation.WebApi/"]
COPY ["TFE.Core.Application/TFE.Application.csproj", "TFE.Core.Application/"]
COPY ["TFE.Core.Domain/TFE.Domain.csproj", "TFE.Core.Domain/"]
COPY ["TFE.Persistence/TFE.Infrastructure.csproj", "TFE.Persistence/"]
RUN dotnet restore "TFE.Presentation.WebApi/TFE.WebApi.csproj"
COPY . .
WORKDIR "/src/TFE.Presentation.WebApi"
RUN dotnet build "TFE.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TFE.WebApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TFE.WebApi.dll"]