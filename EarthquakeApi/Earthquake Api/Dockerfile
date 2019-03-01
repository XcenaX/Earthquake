FROM microsoft/aspnetcore:2.0 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0 AS build
WORKDIR /src
COPY Earthquake Api/Earthquake Api.csproj Earthquake Api/
RUN dotnet restore Earthquake Api/Earthquake Api.csproj
COPY . .
WORKDIR /src/Earthquake Api
RUN dotnet build Earthquake Api.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish Earthquake Api.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Earthquake Api.dll"]
