# AddressBook

## Running Docker Commpose

Run docker-compose
```
docker-compose up -d
````

Rebuild docker image 
```
docker-compose up -d --build
````

Stop docker compose
```
docker-compose down
```

Create a new migration
```
dotnet ef migrations add my_migration --startup-project AddressBook.API --project AddressBook.Infrastructure
````
## Database

Apply migrations to the db
```
dotnet ef database update --project AddressBook.Infrastructure --startup-project AddressBook.API
````

Create migration scripts
```
dotnet ef migrations script --startup-project AddressBook.API --project AddressBook.Infrastructure
```

Execute the script file Contacts.sql to insert data to the contacts table.

## Runnin Single Page Application

Install dependencies
```
yarn
```
Start server
```
yarn dev
```




