dotnet ef migrations add Grants -c PersistedGrantDbContext -o Data/Migrations/PersistedGrantDb
dotnet ef migrations script -c PersistedGrantDbContext -o Data/Migrations/PersistedGrantDb.sql

dotnet ef migrations add Config -c ConfigurationDbContext -o Data/Migrations/ConfigurationDb
dotnet ef migrations script -c ConfigurationDbContext -o Data/Migrations/ConfigurationDb.sql

dotnet ef migrations add Users -c ApplicationDbContext -o Data/Migrations/Users
dotnet ef migrations script -c ApplicationDbContext -o Data/Migrations/Users.sql
