# Get base SDK Image from Microsoft
FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build-env
WORKDIR /api

# Copy csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:3.1
WORKDIR /api
EXPOSE 80
COPY --from=build-env /api/out .
ENTRYPOINT ["dotnet", "FocusMentorship.dll"]