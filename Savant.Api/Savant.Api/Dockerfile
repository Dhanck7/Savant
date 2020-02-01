FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["Savant.Api/Savant.Api.csproj", "Savant.Api/"]
RUN dotnet restore "Savant.Api/Savant.Api.csproj"
COPY . .
WORKDIR "/src/Savant.Api"
RUN dotnet build "Savant.Api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Savant.Api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Savant.Api.dll"]