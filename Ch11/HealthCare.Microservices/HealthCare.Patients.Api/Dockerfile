#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["HealthCare.Patients.Api/HealthCare.Patients.Api.csproj", "HealthCare.Patients.Api/"]
COPY ["HealthCare.SharedAssets/HealthCare.SharedAssets.csproj", "HealthCare.SharedAssets/"]
RUN dotnet restore "HealthCare.Patients.Api/HealthCare.Patients.Api.csproj"
COPY . .
WORKDIR "/src/HealthCare.Patients.Api"
RUN dotnet build "HealthCare.Patients.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "HealthCare.Patients.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HealthCare.Patients.Api.dll"]