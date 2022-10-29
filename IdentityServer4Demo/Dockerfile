FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["IdentityServer4Demo/IdentityServer4Demo.csproj", "IdentityServer4Demo/"]
RUN dotnet restore "IdentityServer4Demo/IdentityServer4Demo.csproj"
COPY . .
WORKDIR "/src/IdentityServer4Demo"
RUN dotnet build "IdentityServer4Demo.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "IdentityServer4Demo.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "IdentityServer4Demo.dll"]
