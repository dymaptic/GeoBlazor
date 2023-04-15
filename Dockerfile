FROM mcr.microsoft.com/dotnet/sdk:7.0-alpine AS build-env
WORKDIR /App

# Add NPM
RUN apk add --update npm

# Copy everything
COPY . ./

# Restore as distinct layers
RUN dotnet restore samples/dymaptic.GeoBlazor.Core.Sample.Wasm/dymaptic.GeoBlazor.Core.Sample.Wasm.csproj

# Build and publish a release
RUN dotnet publish samples/dymaptic.GeoBlazor.Core.Sample.Wasm/dymaptic.GeoBlazor.Core.Sample.Wasm.csproj -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:7.0.3-alpine3.17
EXPOSE 5000
WORKDIR /App
COPY --from=build-env /App/out .
RUN ls -la

# Add Dumb-init
RUN apk upgrade -U -a \
    && apk add dumb-init \
    && rm -rf /var/cache/* \
    && mkdir /var/cache/apk \
    && mkdir /temp

# set up user
RUN addgroup -S geoblazor && adduser -S geoblazor -G geoblazor
RUN chmod -R 777 /temp
USER geoblazor

ENTRYPOINT ["dumb-init", "dotnet", "dymaptic.GeoBlazor.Core.Sample.Wasm.dll", "urls=http://0.0.0.0:5000/"]