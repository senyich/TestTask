export PATH="$PATH:/root/.dotnet/tools"
dotnet ef database update --project /app/TestTask.DataAccess/TestTask.DataAccess.dll --startup-project /app/TestTask.API.dll --context TestTask.DataAccess.UsersContext

exec dotnet TestTask.API.dll