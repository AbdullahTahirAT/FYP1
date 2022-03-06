
FROM mcr.microsoft.com/dotnet/aspnet AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["./RSSFeeds.csproj", "src/"]
RUN dotnet restore "src/RSSFeeds.csproj"
COPY . .
WORKDIR "/src/"
RUN dotnet build "RSSFeeds.csproj" -c Release -o /app/build
FROM build AS publish
RUN dotnet publish "RSSFeeds.csproj" -c Release -o /app/publish
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RSSFeeds.dll"]