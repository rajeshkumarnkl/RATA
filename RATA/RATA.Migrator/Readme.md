Create Migrations
The provided source code doesn’t include migrations. If you just compile and run the solution it will throw an exception, as EF would not know how you what it to Migrate();.

But please don’t worry migrations are very easy to create.

If you are using Visual Studio for Windows :

Change your startup project from Client to Migrator.
Open Package Manager Console: go to View->Other Windows->Package Manager Console.
Set the default project to Shared, EF will look for the context model inside and add migrations there.
Enter the following command to create the initial migration:
add-migration Initial -Context MauiEF.Shared.Services.LocalDatabase -Verbose
