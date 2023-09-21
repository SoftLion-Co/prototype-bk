#Build Stage
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /source
COPY . .
RUN dotnet restore "./API/API.csproj" --disable-parallel
RUN dotnrt publish "./API/API.csproj" -c release -o /app --no-restore

#Serve Stage
FROM mcr.microsoft.com/dotnet/sdk:7.0-focal
WORKDIR /app
COPY --from=build /app ./

expose 8880

ENTRYPOINT ["dotnet", "API.dll"]