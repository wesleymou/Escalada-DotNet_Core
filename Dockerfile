# FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
# FROM mcr.microsoft.com/dotnet/core/sdk:3.1

# EXPOSE 5000
# EXPOSE 80

# COPY . /app
# COPY bin/Debug/netcoreapp3.1/publish/ /app
# WORKDIR /app

# RUN dotnet build

# ENTRYPOINT ["dotnet", "run"]
# ENTRYPOINT ["dotnet", "escalada.dll"]

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /app

# copy csproj and restore as distinct layers
COPY *.csproj .
RUN dotnet restore

# copy everything else and build app
COPY . .
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS runtime
WORKDIR /app
EXPOSE 80
EXPOSE 5000
COPY --from=build /app/out .
RUN ls
# ENTRYPOINT ["dotnet", "escalada.dll"]
CMD ASPNETCORE_URLS=http://*:$PORT dotnet escalada.dll
