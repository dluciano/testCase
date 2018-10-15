FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 53740
EXPOSE 44353

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["src/Clay.WebApi/Clay.WebApi.csproj", "src/Clay.WebApi/"]
RUN dotnet restore "src/Clay.WebApi/Clay.WebApi.csproj"
COPY . .
WORKDIR "/src/src/Clay.WebApi"
RUN dotnet build "Clay.WebApi.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Clay.WebApi.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Clay.WebApi.dll"]