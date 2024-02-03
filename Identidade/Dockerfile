FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app
COPY IdentidadeAPI.csproj ./
RUN dotnet restore
COPY . ./
RUN dotnet publish IdentidadeAPI.csproj -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT [ "dotnet", "IdentidadeAPI.dll" ]

# docker build -t identidade-api:1.0 .

#removendo containers
# docker rm $(docker ps -aq) --force
