# ODataExample

1) Restore [AdventureWorks2019](https://github.com/Microsoft/sql-server-samples/releases/download/adventureworks/AdventureWorks2019.bak) locally for sample Data. [AdventureWorks sample databases](https://learn.microsoft.com/en-us/sql/samples/adventureworks-install-configure?view=sql-server-ver16&tabs=ssms)
2) Set Default Connection string in [User Secrets](https://learn.microsoft.com/it-it/aspnet/core/security/app-secrets?view=aspnetcore-7.0&tabs=windows) of project *ODataExample.Api*
```
{
"ConnectionStrings": {
  "DefaultConnection": "Server={myServerAddress};Database={myDataBase};User Id={myUsername};Password={myPassword};"
}
```
# Bonus: Kendo Grid for JQuery with OData Binding

1) Run the Api
2) Open [Product.html](src/ODataExample.Api/KendoGridExample/Product.html) for performing CRUD operations to Product entity

