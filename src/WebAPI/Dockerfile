FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base

RUN sed -i 's/\[openssl_init\]/# [openssl_init]/' /etc/ssl/openssl.cnf

RUN printf "\n\n[openssl_init]\nssl_conf = ssl_sect" >> /etc/ssl/openssl.cnf
RUN printf "\n\n[ssl_sect]\nsystem_default = ssl_default_sect" >> /etc/ssl/openssl.cnf
RUN printf "\n\n[ssl_default_sect]\nMinProtocol = TLSv1\nCipherString = DEFAULT@SECLEVEL=0\n" >> /etc/ssl/openssl.cnf

WORKDIR /app
EXPOSE 80 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY "progweb_Backend.sln" "progweb_Backend.sln"

COPY ["WebAPI/WebAPI.csproj", "WebAPI/WebAPI.csproj"]
COPY ["Controllers/Controllers.csproj", "Controllers/Controllers.csproj"]
COPY ["Shared/Shared.csproj", "Shared/Shared.csproj"]
COPY ["Infrastructure/Infrastructure.csproj", "Infrastructure/Infrastructure.csproj"]
COPY ["ApplicationCore/ApplicationCore.csproj", "ApplicationCore/ApplicationCore.csproj"]

COPY "docker-compose.dcproj" "docker-compose.dcproj"

RUN dotnet restore "progweb_Backend.sln"

COPY . .
WORKDIR "/src/WebAPI"
RUN dotnet publish --no-restore -c Release -o /app

FROM build AS publish

FROM base AS final
RUN ln -snf /usr/share/zoneinfo/$TZ /etc/localtime && echo $TZ > /etc/timezone
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "WebAPI.dll"]
