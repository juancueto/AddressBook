# AddressBook

docker run --cap-add SYS_PTRACE -e 'ACCEPT_EULA=1' -e 'MSSQL_SA_PASSWORD=yourStrong(!)Password' -p 1433:1433 --name azuresqledge -d mcr.microsoft.com/azure-sql-edge

dotnet ef migrations add Initial --startup-project AddressBook.API --project AddressBook.Infrastructure

dotnet ef database update --project AddressBook.Infrastructure --startup-project AddressBook.API

dotnet ef migrations script --idempotent --startup-project AddressBook.API --project AddressBook.Infrastructure

dotnet ef migrations script --startup-project AddressBook.API --project AddressBook.Infrastructure

docker-compose down

docker-compose up -d --build

docker-compose up -d

