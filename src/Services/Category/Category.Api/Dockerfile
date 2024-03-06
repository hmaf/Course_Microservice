#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Services/Category/Category.Api/Category.Api.csproj", "src/Services/Category/Category.Api/"]
COPY ["src/Services/Category/Category.Application/Category.Application.csproj", "src/Services/Category/Category.Application/"]
COPY ["src/Services/Category/Category.Domain/Category.Domain.csproj", "src/Services/Category/Category.Domain/"]
COPY ["src/Services/Category/Category.Infrastractor/Category.Infrastractor.csproj", "src/Services/Category/Category.Infrastractor/"]
RUN dotnet restore "./src/Services/Category/Category.Api/./Category.Api.csproj"
COPY . .
WORKDIR "/src/src/Services/Category/Category.Api"
RUN dotnet build "./Category.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Category.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Category.Api.dll"]