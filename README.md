# ODataExample

1) Restore [AdventureWorks2019](https://github.com/Microsoft/sql-server-samples/releases/download/adventureworks/AdventureWorks2019.bak) locally for sample Data. [AdventureWorks sample databases](https://learn.microsoft.com/en-us/sql/samples/adventureworks-install-configure?view=sql-server-ver16&tabs=ssms)
2) Set Default Connection string in [User Secrets](https://learn.microsoft.com/it-it/aspnet/core/security/app-secrets?view=aspnetcore-7.0&tabs=windows) of project *HotChocolateEfCoreExample.Api*
```
{
"ConnectionStrings": {
  "DefaultConnection": "Server={myServerAddress};Database={myDataBase};User Id={myUsername};Password={myPassword};"
}
```
 
