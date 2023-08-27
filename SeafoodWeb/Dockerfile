# syntax=docker/dockerfile:1

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
# EXPOSE 443
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["./SeafoodApi/SeafoodApi.csproj", "SeafoodApi/"]
RUN dotnet restore "SeafoodApi/SeafoodApi.csproj"
COPY . .
WORKDIR "/src/SeafoodApi"
RUN dotnet build "SeafoodApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SeafoodApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SeafoodApi.dll"]