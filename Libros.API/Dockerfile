FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Libros.API/Libros.API.csproj", "Libros.API/"]
COPY ["Libros.Infrastructure/Libros.Infrastructure.csproj", "Libros.Infrastructure/"]
COPY ["Libros.Domain/Libros.Domain.csproj", "Libros.Domain/"]
RUN dotnet restore "Libros.API/Libros.API.csproj"
COPY . .
WORKDIR "/src/Libros.API"
RUN dotnet build "Libros.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Libros.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Libros.API.dll"]