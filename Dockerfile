# syntax=docker/dockerfile:1.4
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
RUN --mount=type=cache,target=/root/.npm npm install

WORKDIR /work
COPY ./src/ ./src/
COPY ./*.ps1 ./
COPY ./Directory.Build.* ./
COPY ./.gitignore ./.gitignore
COPY ./nuget.config ./nuget.config
COPY ./build-tools ./build-tools
COPY ./build-scripts/ScriptBuilder.cs ./build-scripts/ScriptBuilder.cs

RUN dotnet ./build-tools/GeoBlazorBuild.dll -v current

COPY ./test/dymaptic.GeoBlazor.Core.Test.Blazor.Shared/dymaptic.GeoBlazor.Core.Test.Blazor.Shared.csproj ./test/dymaptic.GeoBlazor.Core.Test.Blazor.Shared.csproj
COPY ./test/dymaptic.GeoBlazor.Core.Test.WebApp/dymaptic.GeoBlazor.Core.Test.WebApp/dymaptic.GeoBlazor.Core.Test.WebApp.csproj ./test/dymaptic.GeoBlazor.Core.Test.WebApp/dymaptic.GeoBlazor.Core.Test.WebApp/dymaptic.GeoBlazor.Core.Test.WebApp.csproj
COPY ./test/dymaptic.GeoBlazor.Core.Test.WebApp/dymaptic.GeoBlazor.Core.Test.WebApp.Client/dymaptic.GeoBlazor.Core.Test.WebApp.Client.csproj ./test/dymaptic.GeoBlazor.Core.Test.WebApp/dymaptic.GeoBlazor.Core.Test.WebApp.Client/dymaptic.GeoBlazor.Core.Test.WebApp.Client.csproj

# Use UsePackageReference=false to build from source (enables code coverage with PDB symbols)
RUN --mount=type=cache,target=/root/.nuget/packages \
    dotnet restore ./test/dymaptic.GeoBlazor.Core.Test.WebApp/dymaptic.GeoBlazor.Core.Test.WebApp/dymaptic.GeoBlazor.Core.Test.WebApp.csproj /p:UsePackageReference=false

COPY ./test/dymaptic.GeoBlazor.Core.Test.Blazor.Shared ./test/dymaptic.GeoBlazor.Core.Test.Blazor.Shared
COPY ./test/dymaptic.GeoBlazor.Core.Test.WebApp ./test/dymaptic.GeoBlazor.Core.Test.WebApp

RUN dotnet ./build-tools/BuildAppSettings.dll \
    -k "$ARCGIS_API_KEY" \
    -l "$GEOBLAZOR_LICENSE_KEY" \
    -o "./test/dymaptic.GeoBlazor.Core.Test.WebApp/dymaptic.GeoBlazor.Core.Test.WebApp.Client/wwwroot/appsettings.json" \
    -o "./test/dymaptic.GeoBlazor.Core.Test.WebApp/dymaptic.GeoBlazor.Core.Test.WebApp.Client/wwwroot/appsettings.Production.json" \
    -o "./test/dymaptic.GeoBlazor.Core.Test.WebApp/dymaptic.GeoBlazor.Core.Test.WebApp/appsettings.json" \
    -o "./test/dymaptic.GeoBlazor.Core.Test.WebApp/dymaptic.GeoBlazor.Core.Test.WebApp/appsettings.Production.json" \
    -w "$WFS_SERVERS"

# Build from source with debug symbols for code coverage
# UsePackageReference=false builds GeoBlazor from source instead of NuGet
# DebugSymbols=true and DebugType=portable ensure PDB files are generated
RUN --mount=type=cache,target=/root/.nuget/packages \
    dotnet publish ./test/dymaptic.GeoBlazor.Core.Test.WebApp/dymaptic.GeoBlazor.Core.Test.WebApp/dymaptic.GeoBlazor.Core.Test.WebApp.csproj \
    -c Release \
    /p:UsePackageReference=false \
    /p:DebugSymbols=true \
    /p:DebugType=portable \
    /p:GeneratePack=false \
    -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:10.0

# Re-declare ARGs for this stage (ARGs don't persist across stages)
ARG HTTP_PORT=8080
ARG HTTPS_PORT=9443

# Generate a self-signed certificate for HTTPS and install bash for entrypoint script
# Also install libxml2 which is required for dotnet-coverage profiler
RUN apt-get update && apt-get install -y --no-install-recommends openssl bash libxml2 \
    && rm -rf /var/lib/apt/lists/* \
    && mkdir -p /https /coverage \
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

# Install .NET SDK for dotnet-coverage tool (in runtime image)
COPY --from=build /usr/share/dotnet /usr/share/dotnet
ENV PATH="/usr/share/dotnet:/tools:$PATH"
ENV DOTNET_ROOT=/usr/share/dotnet

# Install dotnet-coverage tool to a shared location accessible by all users
RUN mkdir -p /tools && \
    /usr/share/dotnet/dotnet tool install --tool-path /tools dotnet-coverage && \
    chmod -R 755 /tools

# Create user and set working directory
RUN groupadd -r info && useradd -r -g info info \
    && chown -R info:info /coverage
WORKDIR /app
COPY --from=build /app/publish .

# Configure Kestrel for HTTPS
ENV ASPNETCORE_URLS="https://+:${HTTPS_PORT};http://+:${HTTP_PORT}"
ENV ASPNETCORE_Kestrel__Certificates__Default__Path=/https/aspnetapp.pfx
ENV ASPNETCORE_Kestrel__Certificates__Default__Password=password

# Coverage configuration (can be overridden via environment)
ENV COVERAGE_ENABLED=false
ENV COVERAGE_FORMAT=xml

# Copy entrypoint script
COPY ./test/dymaptic.GeoBlazor.Core.Test.Automation/docker-entrypoint.sh /docker-entrypoint.sh
RUN chmod +x /docker-entrypoint.sh

USER info
EXPOSE ${HTTP_PORT} ${HTTPS_PORT}
ENTRYPOINT ["/docker-entrypoint.sh"]
CMD ["dotnet", "dymaptic.GeoBlazor.Core.Test.WebApp.dll"]
