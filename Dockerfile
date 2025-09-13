# Stage 1: build
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# copy csproj & restore
COPY BookSystemApi.csproj .
RUN dotnet restore

# copy all & build
COPY . .
RUN dotnet publish -c Release -o /app

# Stage 2: runtime
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app
COPY --from=build /app ./

# expose port
EXPOSE 5000
EXPOSE 5001

# environment default
ENV DOTNET_RUNNING_IN_CONTAINER=true \
    DOTNET_USE_POLLING_FILE_WATCHER=true \
    DOTNET_HOST_PATH=/usr/share/dotnet/dotnet \
    DOTNET_NOLOGO=true

ENTRYPOINT ["dotnet", "BookSystemApi.dll"]
