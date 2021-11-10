FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["FoodooBackend.Api/FoodooBackend.Api.csproj", "FoodooBackend.Api/"]
RUN dotnet restore "FoodooBackend.Api/FoodooBackend.Api.csproj"
COPY . .
WORKDIR "/src/FoodooBackend.Api"
RUN dotnet build "FoodooBackend.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FoodooBackend.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FoodooBackend.Api.dll"]
