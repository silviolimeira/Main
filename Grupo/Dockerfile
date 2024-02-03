FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app
COPY Sl.Grupo.csproj ./
RUN dotnet restore
COPY . ./
RUN dotnet publish Sl.Grupo.csproj -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT [ "dotnet", "Sl.Grupo.dll" ]

# docker build -t grupo:1.0 .

#removendo containers
# docker rm $(docker ps -aq) --force
