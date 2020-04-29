FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /app

# copy csproj and restore as distinct layers
COPY *.csproj .
RUN dotnet tool restore
RUN dotnet restore

# copy everything else and build app
COPY . .
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS runtime
WORKDIR /app

EXPOSE 80
# EXPOSE 5000

COPY --from=build /app/out .

CMD ASPNETCORE_URLS=http://*:$PORT dotnet Escalada.dll
