FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Sample.Exceptions.WebApi/Sample.Exceptions.WebApi.csproj", "src/Sample.Exceptions.WebApi/"]
COPY ["src/Sample.Exceptions.WebApi.Core/Sample.Exceptions.WebApi.Core.csproj", "src/Sample.Exceptions.WebApi.Core/"]
RUN dotnet restore "src/Sample.Exceptions.WebApi/Sample.Exceptions.WebApi.csproj"
COPY . .
WORKDIR "/src/src/Sample.Exceptions.WebApi"
RUN dotnet build "Sample.Exceptions.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Sample.Exceptions.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Sample.Exceptions.WebApi.dll"]