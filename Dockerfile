FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-alpine AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-alpine AS build
WORKDIR /src
COPY ["Src/Nager.Date/Nager.Date.csproj", "Nager.Date/"]
RUN dotnet restore "Nager.Date/Nager.Date.csproj"
COPY ["Src/Nager.Date.WebsiteCore/Nager.Date.WebsiteCore.csproj", "Nager.Date.WebsiteCore/"]
RUN dotnet restore "Nager.Date.WebsiteCore/Nager.Date.WebsiteCore.csproj"
COPY ./Src/ .
WORKDIR "/src/Nager.Date.WebsiteCore"
RUN dotnet build "Nager.Date.WebsiteCore.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Nager.Date.WebsiteCore.csproj" --runtime alpine-x64 -c Release -o /app/publish /p:PublishTrimmed=true

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Nager.Date.WebsiteCore.dll"]