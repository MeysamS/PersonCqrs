dotnet ef --startup-project ../PersonCQRS.Api/ migrations add InitialDatabase --context BinanceDbContext
dotnet ef --startup-project ../PersonCQRS.Api/ database update --context BinanceDbContext