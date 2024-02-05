FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app
COPY Sl.GrupoAPI.csproj ./
RUN dotnet restore
COPY . ./
RUN dotnet publish Sl.GrupoAPI.csproj -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT [ "dotnet", "Sl.GrupoAPI.dll" ]

# Expose port 8081 in case accessing from other container
# Expose port externally from docker-compose.yml
EXPOSE 8081

# docker build -t grupo:1.0 .

#removendo containers
# docker rm $(docker ps -aq) --force
