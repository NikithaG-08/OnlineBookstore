FROM mcr.microsoft.com/dotnet/sdk:11.0 AS build
WORKDIR /src

COPY Bookstore.API/Bookstore.API.csproj Bookstore.API/
RUN dotnet restore Bookstore.API/Bookstore.API.csproj

COPY Bookstore.API/ Bookstore.API/
WORKDIR /src/Bookstore.API
RUN dotnet publish Bookstore.API.csproj -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:11.0 AS final
WORKDIR /app

COPY --from=build /app/publish .
ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080

ENTRYPOINT ["dotnet", "Bookstore.API.dll"]