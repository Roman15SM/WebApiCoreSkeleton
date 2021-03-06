FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["WebApiCore/WebApiCore.csproj", "WebApiCore/"]
COPY ["WebApiCore.DAL/WebApiCore.DAL.csproj", "WebApiCore.DAL/"]
COPY ["WebApiCore.Services/WebApiCore.Business.csproj", "WebApiCore.Services/"]
COPY ["WebApiCore.Repositories/WebApiCore.Repositories.csproj", "WebApiCore.Repositories/"]
COPY ["WebApiCore.Dtos/WebApiCore.Dtos.csproj", "WebApiCore.Dtos/"]
RUN dotnet restore "WebApiCore/WebApiCore.csproj"
COPY . .
WORKDIR "/src/WebApiCore"
RUN dotnet build "WebApiCore.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WebApiCore.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebApiCore.dll"]