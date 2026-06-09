# syntax=docker/dockerfile:1.7.0
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
ARG HTTP_PORT
ARG HTTPS_PORT

# Install NodeJS and NPM
RUN apt-get update \
    && apt-get install -y ca-certificates curl gnupg \
    && mkdir -p /etc/apt/keyrings \
    && curl -fsSL https://deb.nodesource.com/gpgkey/nodesource-repo.gpg.key | gpg --dearmor -o /etc/apt/keyrings/nodesource.gpg \
    && echo "deb [signed-by=/etc/apt/keyrings/nodesource.gpg] https://deb.nodesource.com/node_22.x nodistro main" | tee /etc/apt/sources.list.d/nodesource.list \
    && apt-get update \
    && apt-get install -y nodejs

# Install NPM Packages
WORKDIR /work
WORKDIR /work/src/dymaptic.GeoBlazor.Core
COPY ./src/dymaptic.GeoBlazor.Core/package*.json ./
RUN --mount=type=cache,id=npm-cache,target=/root/.npm npm ci --no-audit --prefer-offline

WORKDIR /work

# Update GeoBlazor Build Scripts
COPY ./build-tools/build-scripts ./build-tools/build-scripts
COPY ./build-tools/utilities ./build-tools/utilities
RUN --mount=type=cache,id=nuget-cache,target=/root/.nuget/packages \
    dotnet run ./build-tools/build-scripts/ScriptBuilder.cs 

# Copy Source Files
COPY ./Directory.Build.* ./
COPY ./.gitignore ./.gitignore
COPY ./nuget.config ./nuget.config
COPY ./src/ ./src/

# Create GeoBlazor NuGet Packages.
# GBObjCacheRoot redirects every project's obj/ to /work/obj-cache/<project>/ (see Directory.Build.props),
# so the single cache mount below preserves MSBuild incremental compile state across container builds.
# bin/ stays default, so all hardcoded bin paths (source generators) keep working. sharing=locked
# serializes parallel builds.
RUN --mount=type=cache,id=nuget-cache,target=/root/.nuget/packages \
    --mount=type=cache,id=gbcore-objcache,sharing=locked,target=/work/obj-cache \
    GBObjCacheRoot=/work/obj-cache \
    dotnet ./build-tools/linux-x64/GeoBlazorBuild.dll -pkg -obf -c "Release"

# Test-level Directory.Build.props (carries the MapStaticAssets JS exclusion for the WebApp host)
COPY ./test/Directory.Build.* ./test/
COPY ./test/dymaptic.GeoBlazor.Core.Test.Blazor.Shared ./test/dymaptic.GeoBlazor.Core.Test.Blazor.Shared
COPY ./test/dymaptic.GeoBlazor.Core.Test.WebApp ./test/dymaptic.GeoBlazor.Core.Test.WebApp

# Keep frequently-changing appsettings secrets late so earlier build layers stay cacheable.
ARG ARCGIS_API_KEY
ARG GEOBLAZOR_LICENSE_KEY
ARG WFS_SERVERS

# Create appsettings files
RUN dotnet ./build-tools/linux-x64/BuildAppSettings.dll \
    -k "${ARCGIS_API_KEY}" \
    -l "${GEOBLAZOR_LICENSE_KEY}" \
    -o "./test/dymaptic.GeoBlazor.Core.Test.WebApp/dymaptic.GeoBlazor.Core.Test.WebApp.Client/wwwroot/appsettings.json" \
    -o "./test/dymaptic.GeoBlazor.Core.Test.WebApp/dymaptic.GeoBlazor.Core.Test.WebApp.Client/wwwroot/appsettings.Production.json" \
    -o "./test/dymaptic.GeoBlazor.Core.Test.WebApp/dymaptic.GeoBlazor.Core.Test.WebApp/appsettings.json" \
    -o "./test/dymaptic.GeoBlazor.Core.Test.WebApp/dymaptic.GeoBlazor.Core.Test.WebApp/appsettings.Production.json" \
    -w "${WFS_SERVERS}" 

# Build from source with debug symbols for code coverage
# UsePackageReferences=false builds GeoBlazor from source instead of NuGet
# DebugSymbols=true and DebugType=portable ensure PDB files are generated
RUN --mount=type=cache,id=nuget-cache,target=/root/.nuget/packages \
    --mount=type=cache,id=gbcore-objcache,sharing=locked,target=/work/obj-cache \
    rm -rf /root/.nuget/packages/dymaptic.geoblazor.core /root/.nuget/packages/dymaptic.geoblazor.pro; \
    GBObjCacheRoot=/work/obj-cache dotnet publish ./test/dymaptic.GeoBlazor.Core.Test.WebApp/dymaptic.GeoBlazor.Core.Test.WebApp/dymaptic.GeoBlazor.Core.Test.WebApp.csproj \
    -c Release \
    /p:UsePackageReferences=true \
    /p:DebugSymbols=true \
    /p:DebugType=portable \
    /p:GeneratePackage=false \
    /p:GenerateDocs=false \
    /p:GenerateXmlComments=false \
    /p:ShowScriptDialogs=false \
    -o /app/publish -bl

RUN cp ./msbuild.binlog /app/publish/msbuild.binlog 2>/dev/null || true

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS coverage-tools
RUN mkdir -p /tools \
    && dotnet tool install --tool-path /tools dotnet-coverage \
    && chmod -R 755 /tools

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

# dotnet-coverage is installed in a dedicated stage and copied in.
COPY --from=coverage-tools /tools /tools
ENV PATH="/tools:$PATH"

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
ENV SESSION_ID=WEB_APP

# Copy entrypoint script
COPY ./test/dymaptic.GeoBlazor.Core.Test.Automation/docker-entrypoint.sh /docker-entrypoint.sh
RUN chmod +x /docker-entrypoint.sh

USER info
EXPOSE ${HTTP_PORT} ${HTTPS_PORT}
ENTRYPOINT ["/docker-entrypoint.sh"]
CMD ["dotnet", "dymaptic.GeoBlazor.Core.Test.WebApp.dll"]