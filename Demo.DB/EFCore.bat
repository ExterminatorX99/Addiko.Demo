dotnet ef migrations add Initial -c AppDbContext -s ..\Demo.Api\

dotnet ef database update -c AppDbContext -s ..\Demo.Api\
