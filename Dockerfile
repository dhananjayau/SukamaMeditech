#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Rocky/Rocky.csproj", "Rocky/"]
RUN dotnet restore "Rocky/Rocky.csproj"
COPY . .
WORKDIR "/src/Rocky"
RUN dotnet build "Rocky/Rocky.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Rocky/Rocky.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Rocky.dll"]