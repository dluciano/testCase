FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 56232
EXPOSE 45268

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY src/IdentityServer/Clay.IdentityServer.csproj src/IdentityServer/
COPY src/Clay.DAL/Clay.DAL.csproj src/Clay.DAL/
COPY src/Clay.Entities/Clay.Entities.csproj src/Clay.Entities/
RUN dotnet restore src/IdentityServer/Clay.IdentityServer.csproj
COPY . .
WORKDIR /src/src/IdentityServer
RUN dotnet build Clay.IdentityServer.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish Clay.IdentityServer.csproj -c Release -o /app
RUN ./updatedb.bat

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Clay.IdentityServer.dll"]
