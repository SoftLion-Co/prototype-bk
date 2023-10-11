FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app

COPY ["API/API.csproj", "./src/API/"]
COPY ["BLL/BLL.csproj", "./src/BLL/"]
COPY ["DAL/DAL.csproj", "./src/DAL/"]

WORKDIR /app/src/API
RUN dotnet restore

WORKDIR /app/src
COPY . .

WORKDIR /app/src/API
RUN dotnet build -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "API.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "API.dll"]

EXPOSE 1289
EXPOSE 1298
