#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["AddressBook.API/AddressBook.API.csproj", "AddressBook.API/"]
COPY ["AddressBook.Infrastructure/AddressBook.Infrastructure.csproj", "AddressBook.Infrastructure/"]
COPY ["AddressBook.Domain/AddressBook.Domain.csproj", "AddressBook.Domain/"]
COPY ["AddressBook.Application/AddressBook.Application.csproj", "AddressBook.Application/"]
RUN dotnet restore "AddressBook.API/AddressBook.API.csproj"
COPY . .
WORKDIR "/src/AddressBook.API"
RUN dotnet build "AddressBook.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AddressBook.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AddressBook.API.dll"]
