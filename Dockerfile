FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app
COPY . .
RUN dotnet publish -c Release -o publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build-env /app/publish .
EXPOSE 8080
ENTRYPOINT ["dotnet", "Clean.Architecture.API.dll"]