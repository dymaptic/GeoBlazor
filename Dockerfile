FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
ARG ARCGIS_API_KEY
ARG GEOBLAZOR_LICENSE_KEY
ENV ARCGIS_API_KEY=${ARCGIS_API_KEY}
ENV GEOBLAZOR_LICENSE_KEY=${GEOBLAZOR_LICENSE_KEY}

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

RUN pwsh -Command "./buildAppSettings.ps1 \
    -ArcGISApiKey '$env:ARCGIS_API_KEY' \
    -LicenseKey '$env:GEOBLAZOR_LICENSE_KEY' \
    -OutputPaths @( \
       './test/dymaptic.GeoBlazor.Core.Test.WebApp/dymaptic.GeoBlazor.Core.Test.WebApp.Client/wwwroot/appsettings.json', \
       './test/dymaptic.GeoBlazor.Core.Test.WebApp/dymaptic.GeoBlazor.Core.Test.WebApp.Client/wwwroot/appsettings.Production.json', \
       './test/dymaptic.GeoBlazor.Core.Test.WebApp/dymaptic.GeoBlazor.Core.Test.WebApp/appsettings.json', \
       './test/dymaptic.GeoBlazor.Core.Test.WebApp/dymaptic.GeoBlazor.Core.Test.WebApp/appsettings.Production.json')"

WORKDIR /work

COPY ./test/dymaptic.GeoBlazor.Core.Test.Blazor.Shared ./test/dymaptic.GeoBlazor.Core.Test.Blazor.Shared
COPY ./test/dymaptic.GeoBlazor.Core.Test.WebApp ./test/dymaptic.GeoBlazor.Core.Test.WebApp

RUN dotnet restore ./test/dymaptic.GeoBlazor.Core.Test.WebApp/dymaptic.GeoBlazor.Core.Test.WebApp/dymaptic.GeoBlazor.Core.Test.WebApp.csproj /p:UsePackageReference=true

RUN dotnet publish ./test/dymaptic.GeoBlazor.Core.Test.WebApp/dymaptic.GeoBlazor.Core.Test.WebApp/dymaptic.GeoBlazor.Core.Test.WebApp.csproj -c Release /p:UsePackageReference=true -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:10.0-alpine

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
ENV ASPNETCORE_URLS="https://+:8443;http://+:8080"
ENV ASPNETCORE_Kestrel__Certificates__Default__Path=/https/aspnetapp.pfx
ENV ASPNETCORE_Kestrel__Certificates__Default__Password=password

USER info
EXPOSE 8080 8443
ENTRYPOINT ["dotnet", "dymaptic.GeoBlazor.Core.Test.WebApp.dll"]
