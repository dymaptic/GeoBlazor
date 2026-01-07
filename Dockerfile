FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
ARG ARCGIS_API_KEY
ARG GEOBLAZOR_LICENSE_KEY
ARG WFS_SERVERS
ARG HTTP_PORT
ARG HTTPS_PORT
ENV ARCGIS_API_KEY=${ARCGIS_API_KEY}
ENV GEOBLAZOR_LICENSE_KEY=${GEOBLAZOR_LICENSE_KEY}
ENV WFS_SERVERS=${WFS_SERVERS}

RUN apt-get update \
    && apt-get install -y ca-certificates curl gnupg \
    && mkdir -p /etc/apt/keyrings \
    && curl -fsSL https://deb.nodesource.com/gpgkey/nodesource-repo.gpg.key | gpg --dearmor -o /etc/apt/keyrings/nodesource.gpg \
    && echo "deb [signed-by=/etc/apt/keyrings/nodesource.gpg] https://deb.nodesource.com/node_22.x nodistro main" | tee /etc/apt/sources.list.d/nodesource.list \
    && apt-get update \
    && apt-get install -y nodejs

WORKDIR /work
WORKDIR /work/src/dymaptic.GeoBlazor.Core
COPY ./src/dymaptic.GeoBlazor.Core/package.json ./package.json
RUN npm install

WORKDIR /work
COPY ./src/ ./src/
COPY ./*.ps1 ./
COPY ./Directory.Build.* ./
COPY ./.gitignore ./.gitignore
COPY ./nuget.config ./nuget.config

RUN pwsh -Command "./GeoBlazorBuild.ps1 -pkg"

COPY ./test/dymaptic.GeoBlazor.Core.Test.Blazor.Shared/dymaptic.GeoBlazor.Core.Test.Blazor.Shared.csproj ./test/dymaptic.GeoBlazor.Core.Test.Blazor.Shared.csproj
COPY ./test/dymaptic.GeoBlazor.Core.Test.WebApp/dymaptic.GeoBlazor.Core.Test.WebApp/dymaptic.GeoBlazor.Core.Test.WebApp.csproj ./test/dymaptic.GeoBlazor.Core.Test.WebApp/dymaptic.GeoBlazor.Core.Test.WebApp/dymaptic.GeoBlazor.Core.Test.WebApp.csproj
COPY ./test/dymaptic.GeoBlazor.Core.Test.WebApp/dymaptic.GeoBlazor.Core.Test.WebApp.Client/dymaptic.GeoBlazor.Core.Test.WebApp.Client.csproj ./test/dymaptic.GeoBlazor.Core.Test.WebApp/dymaptic.GeoBlazor.Core.Test.WebApp.Client/dymaptic.GeoBlazor.Core.Test.WebApp.Client.csproj

RUN dotnet restore ./test/dymaptic.GeoBlazor.Core.Test.WebApp/dymaptic.GeoBlazor.Core.Test.WebApp/dymaptic.GeoBlazor.Core.Test.WebApp.csproj /p:UsePackageReference=true

COPY ./test/dymaptic.GeoBlazor.Core.Test.Blazor.Shared ./test/dymaptic.GeoBlazor.Core.Test.Blazor.Shared
COPY ./test/dymaptic.GeoBlazor.Core.Test.WebApp ./test/dymaptic.GeoBlazor.Core.Test.WebApp

RUN pwsh -Command './buildAppSettings.ps1 \
    -ArcGISApiKey $env:ARCGIS_API_KEY \
    -LicenseKey $env:GEOBLAZOR_LICENSE_KEY \
    -OutputPaths @( \
       "./test/dymaptic.GeoBlazor.Core.Test.WebApp/dymaptic.GeoBlazor.Core.Test.WebApp.Client/wwwroot/appsettings.json", \
       "./test/dymaptic.GeoBlazor.Core.Test.WebApp/dymaptic.GeoBlazor.Core.Test.WebApp.Client/wwwroot/appsettings.Production.json", \
       "./test/dymaptic.GeoBlazor.Core.Test.WebApp/dymaptic.GeoBlazor.Core.Test.WebApp/appsettings.json", \
       "./test/dymaptic.GeoBlazor.Core.Test.WebApp/dymaptic.GeoBlazor.Core.Test.WebApp/appsettings.Production.json") \
    -WfsServers $env:WFS_SERVERS'

RUN dotnet publish ./test/dymaptic.GeoBlazor.Core.Test.WebApp/dymaptic.GeoBlazor.Core.Test.WebApp/dymaptic.GeoBlazor.Core.Test.WebApp.csproj -c Release /p:UsePackageReference=true /p:PipelineBuild=true -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:10.0-alpine

# Re-declare ARGs for this stage (ARGs don't persist across stages)
ARG HTTP_PORT=8080
ARG HTTPS_PORT=9443

# Generate a self-signed certificate for HTTPS
RUN apk add --no-cache openssl \
    && mkdir -p /https \
    && openssl req -x509 -nodes -days 365 -newkey rsa:2048 \
        -keyout /https/aspnetapp.key \
        -out /https/aspnetapp.crt \
        -subj "/CN=test-app" \
        -addext "subjectAltName=DNS:test-app,DNS:localhost" \
    && openssl pkcs12 -export -out /https/aspnetapp.pfx \
        -inkey /https/aspnetapp.key \
        -in /https/aspnetapp.crt \
        -password pass:password \
    && chmod 644 /https/aspnetapp.pfx

# Create user and set working directory
RUN addgroup -S info && adduser -S info -G info
WORKDIR /app
COPY --from=build /app/publish .

# Configure Kestrel for HTTPS
ENV ASPNETCORE_URLS="https://+:${HTTPS_PORT};http://+:${HTTP_PORT}"
ENV ASPNETCORE_Kestrel__Certificates__Default__Path=/https/aspnetapp.pfx
ENV ASPNETCORE_Kestrel__Certificates__Default__Password=password

USER info
EXPOSE ${HTTP_PORT} ${HTTPS_PORT}
ENTRYPOINT ["dotnet", "dymaptic.GeoBlazor.Core.Test.WebApp.dll"]
