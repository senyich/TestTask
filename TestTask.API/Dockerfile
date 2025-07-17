FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Копируем только файлы решения и проектов
COPY TestTask.API.sln .
COPY TestTask.API/*.csproj ./TestTask.API/
COPY TestTask.Application/*.csproj ./TestTask.Application/
COPY TestTask.DataAccess/*.csproj ./TestTask.DataAccess/
RUN dotnet restore

# Копируем остальные файлы
COPY TestTask.API/. ./TestTask.API/
COPY TestTask.Application/. ./TestTask.Application/
COPY TestTask.DataAccess/. ./TestTask.DataAccess/

WORKDIR /src/TestTask.API
RUN dotnet publish -c Release -o /app

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app .

RUN dotnet tool install --global dotnet-ef

COPY --from=build /src/TestTask.DataAccess/bin/Release/net8.0/ ./TestTask.DataAccess/
COPY --from=build /src/TestTask.API/bin/Release/net8.0/ ./TestTask.API/

COPY entrypoint.sh .
RUN chmod +x entrypoint.sh

ENTRYPOINT ["./entrypoint.sh"]