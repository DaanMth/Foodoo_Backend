FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["FoodooBackend.common/FoodooBackend.common.csproj", "FoodooBackend.common/"]
RUN dotnet restore "FoodooBackend.common/FoodooBackend.common.csproj"
COPY . .
WORKDIR "/src/FoodooBackend.common"
RUN dotnet build "FoodooBackend.common.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FoodooBackend.common.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FoodooBackend.common.dll"]
