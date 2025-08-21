# Use .NET 8.0 SDK image for build and debugging
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore

# Copy entire source and build
COPY . ./
RUN dotnet publish -c Debug -o out  # IMPORTANT: Debug configuration for debugging

# Runtime image with debugger enabled
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/out .

EXPOSE 10000
# Add debugger tools (needed for remote debugging)
RUN apt-get update && apt-get install -y unzip curl && \
    curl -sSL https://aka.ms/getvsdbgsh | bash /dev/stdin -v latest -l /vsdbg

ENTRYPOINT ["dotnet", "AzaliaJwellery.dll"]
