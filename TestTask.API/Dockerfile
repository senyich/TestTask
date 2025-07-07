FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY TestTask.API.sln .
COPY TestTask.API/*.csproj ./TestTask.API/
COPY TestTask.Application/*.csproj ./TestTask.Application/
COPY TestTask.DataAccess/*.csproj ./TestTask.DataAccess/

RUN dotnet restore

COPY . .

WORKDIR /src/TestTask.API
RUN dotnet publish -c Release -o /app

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app .

ENTRYPOINT ["dotnet", "TestTask.API.dll"]