# syntax=docker/dockerfile:1.7.0
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
ARG ARCGIS_API_KEY
ARG GEOBLAZOR_LICENSE_KEY
ARG WFS_SERVERS
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
COPY ./src/dymaptic.GeoBlazor.Core/package.json ./package.json
RUN --mount=type=cache,target=/root/.npm npm install

WORKDIR /work

# Update GeoBlazor Build Scripts
COPY ./build-scripts ./build-scripts
RUN --mount=type=cache,target=/root/.nuget/packages \
    dotnet run ./build-scripts/ScriptBuilder.cs 

# Restore NuGet Packages for Core Libraries
COPY ./*.ps1 ./
COPY ./Directory.Build.* ./
COPY ./.gitignore ./.gitignore
COPY ./nuget.config ./nuget.config
COPY ./src/dymaptic.GeoBlazor.Core/dymaptic.GeoBlazor.Core.csproj ./src/dymaptic.GeoBlazor.Core/dymaptic.GeoBlazor.Core.csproj
COPY ./src/dymaptic.GeoBlazor.Core.ESBuild/dymaptic.GeoBlazor.Core.ESBuild.csproj ./src/dymaptic.GeoBlazor.Core.ESBuild/dymaptic.GeoBlazor.Core.ESBuild.csproj
COPY ./src/dymaptic.GeoBlazor.Core.Analyzers/dymaptic.GeoBlazor.Core.Analyzers.csproj ./src/dymaptic.GeoBlazor.Core.Analyzers/dymaptic.GeoBlazor.Core.Analyzers.csproj
COPY ./src/dymaptic.GeoBlazor.Core.SourceGenerator/dymaptic.GeoBlazor.Core.SourceGenerator.csproj ./src/dymaptic.GeoBlazor.Core.SourceGenerator/dymaptic.GeoBlazor.Core.SourceGenerator.csproj
COPY ./src/dymaptic.GeoBlazor.Core.SourceGenerator.Shared/dymaptic.GeoBlazor.Core.SourceGenerator.Shared.csproj ./src/dymaptic.GeoBlazor.Core.SourceGenerator.Shared/dymaptic.GeoBlazor.Core.SourceGenerator.Shared.csproj
COPY ./test/dymaptic.GeoBlazor.Core.Test.Blazor.Shared/dymaptic.GeoBlazor.Core.Test.Blazor.Shared.csproj ./test/dymaptic.GeoBlazor.Core.Test.Blazor.Shared/dymaptic.GeoBlazor.Core.Test.Blazor.Shared.csproj
RUN --mount=type=cache,target=/root/.nuget/packages \
    dotnet restore ./src/dymaptic.GeoBlazor.Core/dymaptic.GeoBlazor.Core.csproj /p:UsePackageReference=false 

# Copy Source Files
COPY ./src/ ./src/

# Build Core Libraries
# This is necessary so the JS files are in place before building the test apps
RUN --mount=type=cache,target=/root/.nuget/packages \
    dotnet build ./src/dymaptic.GeoBlazor.Core/dymaptic.GeoBlazor.Core.csproj  \
    -c Release \
    /p:UsePackageReference=false \
    /p:DebugSymbols=true \
    /p:DebugType=portable \
    /p:GeneratePackage=false \
    /p:ShowSourceGenDialogs=false 

# Restore Shared Test Library
COPY ./test/dymaptic.GeoBlazor.Core.Test.Blazor.Shared/dymaptic.GeoBlazor.Core.Test.Blazor.Shared.csproj ./test/dymaptic.GeoBlazor.Core.Test.Blazor.Shared/dymaptic.GeoBlazor.Core.Test.Blazor.Shared.csproj
RUN --mount=type=cache,target=/root/.nuget/packages \
    dotnet restore ./test/dymaptic.GeoBlazor.Core.Test.Blazor.Shared/dymaptic.GeoBlazor.Core.Test.Blazor.Shared.csproj /p:UsePackageReference=false 

# Copy Shared Library Files
COPY ./test/dymaptic.GeoBlazor.Core.Test.Blazor.Shared ./test/dymaptic.GeoBlazor.Core.Test.Blazor.Shared

# Build Shared Test Library
RUN --mount=type=cache,target=/root/.nuget/packages \
    dotnet build ./test/dymaptic.GeoBlazor.Core.Test.Blazor.Shared/dymaptic.GeoBlazor.Core.Test.Blazor.Shared.csproj  \
    -c Release \
    /p:UsePackageReference=false \
    /p:DebugSymbols=true \
    /p:DebugType=portable \
    /p:GeneratePackage=false \
    /p:ShowSourceGenDialogs=false 

# Restore Test App
COPY ./test/dymaptic.GeoBlazor.Core.Test.WebApp/dymaptic.GeoBlazor.Core.Test.WebApp/dymaptic.GeoBlazor.Core.Test.WebApp.csproj ./test/dymaptic.GeoBlazor.Core.Test.WebApp/dymaptic.GeoBlazor.Core.Test.WebApp/dymaptic.GeoBlazor.Core.Test.WebApp.csproj
COPY ./test/dymaptic.GeoBlazor.Core.Test.WebApp/dymaptic.GeoBlazor.Core.Test.WebApp.Client/dymaptic.GeoBlazor.Core.Test.WebApp.Client.csproj ./test/dymaptic.GeoBlazor.Core.Test.WebApp/dymaptic.GeoBlazor.Core.Test.WebApp.Client/dymaptic.GeoBlazor.Core.Test.WebApp.Client.csproj
RUN --mount=type=cache,target=/root/.nuget/packages \
    dotnet restore ./test/dymaptic.GeoBlazor.Core.Test.WebApp/dymaptic.GeoBlazor.Core.Test.WebApp/dymaptic.GeoBlazor.Core.Test.WebApp.csproj /p:UsePackageReference=false

# Copy Test App Files
COPY ./test/dymaptic.GeoBlazor.Core.Test.WebApp ./test/dymaptic.GeoBlazor.Core.Test.WebApp

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
# UsePackageReference=false builds GeoBlazor from source instead of NuGet
# DebugSymbols=true and DebugType=portable ensure PDB files are generated
RUN --mount=type=cache,target=/root/.nuget/packages \
    dotnet publish ./test/dymaptic.GeoBlazor.Core.Test.WebApp/dymaptic.GeoBlazor.Core.Test.WebApp/dymaptic.GeoBlazor.Core.Test.WebApp.csproj \
    -c Release \
    /p:UsePackageReference=false \
    /p:DebugSymbols=true \
    /p:DebugType=portable \
    /p:GeneratePackage=false \
    /p:ShowSourceGenDialogs=false \
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
ENV SESSION_ID=WEB_APP

# Copy entrypoint script
COPY ./test/dymaptic.GeoBlazor.Core.Test.Automation/docker-entrypoint.sh /docker-entrypoint.sh
RUN chmod +x /docker-entrypoint.sh

USER info
EXPOSE ${HTTP_PORT} ${HTTPS_PORT}
ENTRYPOINT ["/docker-entrypoint.sh"]
CMD ["dotnet", "dymaptic.GeoBlazor.Core.Test.WebApp.dll"]