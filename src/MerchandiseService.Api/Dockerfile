FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/MerchandiseService.Api/MerchandiseService.Api.csproj", "MerchandiseService.Api/"]
RUN dotnet restore "MerchandiseService.Api/MerchandiseService.Api.csproj"
COPY src .
WORKDIR "/src/MerchandiseService.Api"
RUN dotnet build "MerchandiseService.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MerchandiseService.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MerchandiseService.Api.dll"]
