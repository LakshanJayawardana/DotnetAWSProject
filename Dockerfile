#Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /source
COPY *.csproj ./
RUN dotnet restore "./BookStoreAPI/BookStoreAPI.csproj" --disable-parallel

COPY . ./
RUN dotnet publish  "./BookStoreAPI/BookStoreAPI.csproj" -c release -o /app --no-restore

# Serve stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /source
COPY --from=build-env /source ./

EXPOSE 5000

ENTRYPOINT ["dotnet", "BookStoreAPI.dll"]
