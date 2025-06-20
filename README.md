Я немного перевыполнил таску, сделав полноценные CRUD операции для пользователей.
<br><br>
Также я немного отошел от дизайна в задаче, сделав его более блочным и удобным.
<br><br>
В API есть CRUD операции как для пользователей, так и для их типов, но на UI можно взаимодействовать только с пользователями.
<br><br>
Технологичесикй стек: 
  Backend: C# .Net 8.0, ASP.Net, EntityFrameworkCore, PostgreSQL
  Frontend: Js, React, TailwindCSS, Vite(сборщик приложения)
<br><br>
Инструкция к запуску:
1) Поменять в ./TestTask.API/TestTask.API/appsettings.json строку подключения с вашим пользователем psql
2) Создать миграции и через них обновить базу данных
```bash
dotnet ef migrations add --project TestTask.DataAccess/TestTask.DataAccess.csproj --startup-project TestTask.API/TestTask.API.csproj --context TestTask.DataAccess.UsersContext --configuration Debug Initial --output-dir Migrations
dotnet ef database update --project TestTask.DataAccess/TestTask.DataAccess.csproj --startup-project TestTask.API/TestTask.API.csproj --context TestTask.DataAccess.UsersContext --configuration Debug 20250620051153_Initial
```
3) Запустить проект через dotnet SDK или собрать в бинарник

```bash
dotnet publish -c Release -r win-x64 --self-contained true /p:PublishSingleFile=true
```
