FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["IronForgeFitness.API/IronForgeFitness.API.csproj", "IronForgeFitness.API/"]
COPY ["IronForgeFitness.Infrastructure/IronForgeFitness.Infrastructure.csproj", "IronForgeFitness.Infrastructure/"]
COPY ["IronForgeFitness.Application/IronForgeFitness.Application.csproj", "IronForgeFitness.Application/"]
COPY ["IronForgeFitness.Domain/IronForgeFitness.Domain.csproj", "IronForgeFitness.Domain/"]
RUN dotnet restore "IronForgeFitness.API/IronForgeFitness.API.csproj"
COPY . .
WORKDIR "/src/IronForgeFitness.API"
RUN dotnet build "IronForgeFitness.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "IronForgeFitness.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "IronForgeFitness.API.dll"]