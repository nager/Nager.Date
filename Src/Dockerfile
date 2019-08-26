FROM mcr.microsoft.com/dotnet/core/sdk:2.1 AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY . ./
#COPY *.csproj ./
RUN cd ./Nager.Date.WebsiteCore && dotnet restore
#RUN dotnet restore

# Copy everything else and build
#COPY . ./
RUN cd ./Nager.Date.WebsiteCore && dotnet publish -f netcoreapp2.1 -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:2.1
WORKDIR /app
COPY --from=build-env /app/Nager.Date.WebsiteCore/out .
ENTRYPOINT ["dotnet", "Nager.Date.WebsiteCore.dll"]
