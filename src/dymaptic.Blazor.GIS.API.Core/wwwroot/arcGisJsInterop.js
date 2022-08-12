// noinspection JSUnresolvedFunction

import * as geometryEngine from "./geometryEngine.js";
import * as projection from "./projection.js";

export let arcGisObjectRefs = {};
export let dotNetRefs = {};
export let CreateGraphic = null;
export let queryLayer = null;
let viewRoute = null;
let viewRouteParameters = null;
let viewFeatureSet = null;
let viewServiceArea = null;
let viewServiceAreaParameters = null;


export function buildMapView(id, dotNetReference, long, lat, rotation, mapObject, zoom, scale, apiKey, mapType, widgets,
                             graphics, spatialReference, zIndex, tilt) {
    console.log("render map");
    try {
        return require(["esri/Basemap",
                "esri/config",
                "esri/Map",
                "esri/views/SceneView",
                "esri/views/MapView",
                "esri/WebMap",
                "esri/WebScene",
                "esri/rest/route",
                "esri/rest/support/RouteParameters",
                "esri/rest/support/FeatureSet",
                "esri/rest/support/ServiceAreaParameters",
                "esri/rest/serviceArea",
                "esri/Graphic",
                "esri/geometry/Point",
                "esri/geometry/SpatialReference"
            ],
            function (Basemap, esriConfig, Map, SceneView, MapView, WebMap, WebScene,
                      route, RouteParameters, FeatureSet, ServiceAreaParameters, serviceArea, Graphic,
                      Point, SpatialReference) {
                try {
                    setWaitCursor(id);
                    let dotNetRef = dotNetReference;
                    dotNetRefs[id] = dotNetRef;
                    esriConfig.apiKey = apiKey;
                    geometryEngine.initialize(dotNetReference);
                    projection.initialize(dotNetReference);
                    disposeView(id);
                    let view = null;
                    viewRoute = route;
                    viewRouteParameters = RouteParameters;
                    viewFeatureSet = FeatureSet;
                    viewServiceArea = serviceArea;
                    viewServiceAreaParameters = ServiceAreaParameters;
                    CreateGraphic = Graphic;

                    let basemap = null;
                    let basemapLayers = [];
                    if (!mapType.startsWith('web')) {
                        if (mapObject.arcGISDefaultBasemap !== undefined) {
                            basemap = mapObject.arcGISDefaultBasemap;
                        }
                        if (basemap == null) {
                            if (mapObject.basemap?.portalItem?.id !== undefined &&
                                mapObject.basemap?.portalItem?.id !== null) {
                                basemap = {
                                    portalItem: {
                                        id: mapObject.basemap.portalItem.id
                                    }
                                };
                            } else {
                                if (mapObject.basemap?.layers.length > 0) {
                                    for (let i = 0; i < mapObject.basemap.layers.length; i++) {
                                        const layerObject = mapObject.basemap.layers[i];
                                        basemapLayers.push(layerObject);
                                    }
                                }
                                basemap = new Basemap({
                                    baseLayers: []
                                });
                            }
                        }
                    }

                    switch (mapType) {
                        case 'webmap':
                            const webMap = new WebMap({
                                portalItem: {
                                    id: mapObject.portalItem.id
                                }
                            });
                            view = new MapView({
                                container: `map-container-${id}`,
                                map: webMap
                            });
                            break;
                        case 'webscene':
                            const webScene = new WebScene({
                                portalItem: {
                                    id: mapObject.portalItem.id
                                }
                            });
                            view = new SceneView({
                                container: `map-container-${id}`,
                                map: webScene
                            });
                            break;
                        case 'scene':
                            const scene = new Map({
                                basemap: basemap,
                                ground: mapObject.ground
                            });
                            view = new SceneView({
                                container: `map-container-${id}`,
                                map: scene,
                                camera: {
                                    position: {
                                        x: long, //Longitude
                                        y: lat, //Latitude
                                        z: zIndex //Meters
                                    },
                                    tilt: tilt
                                }
                            });
                            break;
                        default:
                            const map = new Map({
                                basemap: basemap,
                                ground: mapObject.ground
                            });
                            let center;
                            let spatialRef;
                            if (spatialReference !== undefined && spatialReference !== null) {
                                spatialRef = new SpatialReference({
                                    wkid: spatialReference.wkid
                                });
                                center = new Point({
                                    latitude: lat,
                                    longitude: long,
                                    spatialReference: spatialRef
                                });
                                resetCenterToSpatialReference(center, spatialRef, id);
                            } else {
                                center = [long, lat];
                            }
                            view = new MapView({
                                map: map,
                                center: center,
                                container: `map-container-${id}`,
                                rotation: rotation
                            });
                            if (scale !== undefined && scale !== null) {
                                view.scale = scale;
                            } else {
                                view.zoom = zoom;
                            }

                            if (spatialRef !== undefined && spatialRef !== null) {
                                view.spatialReference = spatialRef;
                            }
                            break;
                    }
                    
                    arcGisObjectRefs[id] = view;

                    if (mapObject.layers !== undefined && mapObject.layers !== null) {
                        mapObject.layers.forEach(layerObject => {
                            addLayer(layerObject, id);
                        });
                    }
                    
                    basemapLayers.forEach(l => addLayer(l, id, true));

                    widgets.forEach(widget => {
                        addWidget(widget, id);
                    });

                    graphics.forEach(graphicObject => {
                        addGraphic(graphicObject, id);
                    })

                    view.on('click', (evt) => {
                        dotNetRef.invokeMethodAsync('OnJavascriptClick', buildDotNetPoint(evt.mapPoint));
                    });

                    view.on('pointer-move', (evt) => {
                        let point = view.toMap({
                            x: evt.x,
                            y: evt.y
                        });
                        dotNetRef.invokeMethodAsync('OnJavascriptPointerMove', buildDotNetPoint(point));
                    });
                    
                    view.watch('spatialReference', () => {
                        dotNetRef.invokeMethodAsync('OnSpatialReferenceChanged', view.spatialReference);
                    });

                    dotNetReference.invokeMethodAsync('OnViewRendered');
                    unsetWaitCursor(id);
                } catch (error) {
                    logError(error, id);
                }
            });
    } catch (error) {
        logError(error, id);
    }
}

export function disposeView(viewId) {
    try {
        Object.values(arcGisObjectRefs).forEach(o => o?.destroy());

        arcGisObjectRefs = {};
    } catch (error) {
        logError(error, viewId);
    }
}

export function disposeMapComponent(componentId, viewId) {
    try {
        let component = arcGisObjectRefs[componentId];
        switch (component?.declaredClass) {
            case 'esri.Graphic':
                component.layer.graphics.remove(component);
                break;
        }
        component?.destroy();
        delete arcGisObjectRefs[componentId];
        let view = arcGisObjectRefs[viewId];
        view?.ui?.remove(component);
    } catch (error) {
        logError(error, viewId);
    }
}

export function updateView(property, value, viewId) {
    try {
        setWaitCursor(viewId);
        let view = arcGisObjectRefs[viewId];
        switch (property) {
            case 'Longitude':
                view.center = [value, view.center.latitude];
                break;
            case 'Latitude':
                view.center = [view.center.longitude, value];
                break;
            case 'Zoom':
                view.zoom = value;
                break;
            case 'Rotation':
                view.rotation = value;
        }
        unsetWaitCursor(viewId);
    } catch (error) {
        logError(error, viewId);
    }
}


export function queryFeatureLayer(queryObject, layerObject, symbol, popupTemplateObject, viewId) {
    try {
        setWaitCursor(viewId);
        let query = {
            where: queryObject.where,
            outFields: queryObject.outFields,
            returnGeometry: queryObject.returnGeometry,
            spatialRelationship: queryObject.spatialRelationship,
        };
        if (queryObject.useViewExtent) {
            query.geometry = arcGisObjectRefs[viewId].extent;
        } else if (queryObject.geometry !== undefined && queryObject.geometry !== null) {
            query.geometry = queryObject.geometry;
        }
        let popupTemplate = buildPopupTemplate(popupTemplateObject);
        addLayer(layerObject, viewId, false, true, () => {
            displayQueryResults(query, symbol, popupTemplate, viewId);
        });
        unsetWaitCursor(viewId);
    } catch (error) {
        logError(error, viewId);
    }
}


export function updateGraphicsLayer(layerObject, layerId, viewId) {
    try {
        setWaitCursor(viewId);
        console.log('update graphics layer');
        removeGraphicsLayer(layerId);
        addLayer(layerObject, viewId);
        unsetWaitCursor(viewId);
    } catch (error) {
        logError(error, viewId);
    }
}

export function removeGraphicsLayer(viewId, layerId) {
    try {
        setWaitCursor(viewId);
        console.log('remove graphics layer');
        let view = arcGisObjectRefs[viewId];
        let layer = arcGisObjectRefs[layerId];
        view?.map?.remove(layer);
        layer?.destroy();
        unsetWaitCursor(viewId);
    } catch (error) {
        logError(error, viewId);
    }
}

export function updateGraphic(graphicObject, layerIndex, viewId) {
    try {
        setWaitCursor(viewId);
        let oldGraphic = arcGisObjectRefs[graphicObject.id];
        let gLayer = null;
        let view = arcGisObjectRefs[viewId];
        if (layerIndex === undefined || layerIndex === null) {
            if (oldGraphic !== undefined && oldGraphic !== null) {
                view.graphics.remove(oldGraphic);
            } else {
                view.graphics.removeAt(graphicObject.graphicIndex);
            }
        } else {
            gLayer = view.map.layers._items.filter(l => l.type === "graphics")[layerIndex];
            if (oldGraphic !== null) {
                gLayer.graphics.remove(oldGraphic);
            } else {
                gLayer.graphics.removeAt(graphicObject.graphicIndex);
            }
        }
        addGraphic(graphicObject, viewId, gLayer);
        unsetWaitCursor(viewId);
    } catch (error) {
        logError(error, viewId);
    }
}

export function removeGraphicAtIndex(index, layerIndex, viewId) {
    try {
        setWaitCursor(viewId);
        let view = arcGisObjectRefs[viewId];
        if (layerIndex === undefined || layerIndex === null) {
            view.graphics.removeAt(index);
        } else {
            let gLayer = view?.map?.layers._items.filter(l => l.type === "graphics")[layerIndex];
            gLayer?.graphics?.removeAt(index);
        }
        unsetWaitCursor(viewId);
    } catch (error) {
        logError(error, viewId);
    }
}

export function updateFeatureLayer(layerObject, viewId) {
    try {
        setWaitCursor(viewId);
        removeFeatureLayer(layerObject, viewId);
        addLayer(layerObject, viewId);
        unsetWaitCursor(viewId);
    } catch (error) {
        logError(error, viewId);
    }
}

export function removeFeatureLayer(layerObject, viewId) {
    try {
        setWaitCursor(viewId);
        let featureLayer = arcGisObjectRefs[layerObject.id];
        let view = arcGisObjectRefs[viewId];
        view?.map?.remove(featureLayer);
        featureLayer?.destroy();
        unsetWaitCursor(viewId);
    } catch (error) {
        logError(error, viewId);
    }
}

export function findPlaces(addressQueryParams, symbol, popupTemplateObject, viewId) {
    require(["esri/rest/locator"], function (locator) {
        try {
            setWaitCursor(viewId);
            let view = arcGisObjectRefs[viewId];
            locator.addressToLocations(addressQueryParams.locatorUrl, {
                location: view.center,
                categories: addressQueryParams.categories,
                maxLocations: addressQueryParams.maxLocations,
                outFields: addressQueryParams.outFields
            })
                .then(function (results) {
                    view.popup.close();
                    view.graphics.removeAll();
                    let popupTemplate = buildPopupTemplate(popupTemplateObject);
                    results.forEach(function (result) {
                        view.graphics.add(new CreateGraphic({
                            attributes: result.attributes,
                            geometry: result.location,
                            symbol: symbol,
                            popupTemplate: popupTemplate
                        }))
                    });
                    unsetWaitCursor(viewId);
                }).catch((error) => {
                logError(error, viewId)
            });
        } catch (error) {
            logError(error, viewId);
        }
    });
}


export async function showPopup(popupTemplateObject, location, viewId) {
    try {
        setWaitCursor(viewId);
        let popupTemplate = buildPopupTemplate(popupTemplateObject);
        arcGisObjectRefs[viewId].popup.open({
            title: popupTemplate.title,
            content: popupTemplate.content,
            location: location
        });
        unsetWaitCursor(viewId);
    } catch (error) {
        logError(error, viewId);
    }
}


export async function showPopupWithGraphic(graphicObject, options, viewId) {
    try {
        setWaitCursor(viewId);
        addGraphic(graphicObject, viewId);
        let view = arcGisObjectRefs[viewId];
        let graphic = arcGisObjectRefs[graphicObject.id];
        view.popup.dockOptions = options.dockOptions;
        view.popup.visibleElements = options.visibleElements;
        view.popup.open({
            features: [graphic]
        });
        unsetWaitCursor(viewId);
    } catch (error) {
        logError(error, viewId);
    }
}


export function addGraphic(graphicObject, viewId, graphicsLayer) {
    try {
        setWaitCursor(viewId);
        let graphic = createGraphic(CreateGraphic, graphicObject);
        let view = arcGisObjectRefs[viewId];
        if (graphicsLayer === undefined || graphicsLayer === null) {
            view.graphics.add(graphic);
        } else if (typeof (graphicsLayer) === 'object') {
            graphicsLayer.add(graphic);
        } else {
            view.map.layers._items.filter(l => l.type === "graphics")[graphicsLayer].add(graphic);
        }
        unsetWaitCursor(viewId);
    } catch (error) {
        logError(error, viewId);
    }
}


export function clearViewGraphics(viewId) {
    try {
        setWaitCursor(viewId);
        arcGisObjectRefs[viewId].graphics.removeAll();
        unsetWaitCursor(viewId);
    } catch (error) {
        logError(error, viewId);
    }
}


export async function drawRouteAndGetDirections(routeUrl, routeSymbol, viewId) {
    try {
        setWaitCursor(viewId);
        let view = arcGisObjectRefs[viewId];
        const routeParams = new viewRouteParameters({
            stops: new viewFeatureSet({
                features: view.graphics.toArray()
            }),
            returnDirections: true
        });

        let data = await viewRoute.solve(routeUrl, routeParams);
        data.routeResults.forEach(function (result) {
            result.route.symbol = routeSymbol
            view.graphics.add(result.route);
        });
        const directions = [];
        if (data.routeResults.length > 0) {
            data.routeResults[0].directions?.features.forEach(function (result, i) {
                let direction = {
                    text: result.attributes.text,
                    length: result.attributes.length,
                    time: result.attributes.time,
                    ETA: result.attributes.ETA,
                    maneuverType: result.attributes.maneuverType
                };
                directions.push(direction);
            });
        }
        unsetWaitCursor(viewId);
        return directions;
    } catch (error) {
        logError(error, viewId);
    }
}

export function solveServiceArea(url, driveTimeCutoffs, serviceAreaSymbol, viewId) {
    try {
        setWaitCursor(viewId);
        let view = arcGisObjectRefs[viewId];
        const featureSet = new viewFeatureSet({
            features: [view.graphics.items[0]]
        });
        const taskParameters = new viewServiceAreaParameters({
            facilities: featureSet,
            defaultBreaks: driveTimeCutoffs,
            trimOuterPolygon: true,
            outSpatialReference: view.spatialRelationship
        });
        
        return viewServiceArea.solve(url, taskParameters)
            .then(function (result) {
                if (result.serviceAreaPolygons.length) {
                    result.serviceAreaPolygons.forEach(function (graphic) {
                        graphic.symbol = serviceAreaSymbol;
                        view.graphics.add(graphic, 0);
                    })
                }
                unsetWaitCursor(viewId);
            }, function (error) {
                logError(error, viewId);
            });
    } catch (error) {
        logError(error, viewId);
    }
}


export function getAllGraphics(layerIndex, viewId) {
    try {
        let dotNetGraphics = [];
        let view = arcGisObjectRefs[viewId];
        view.map.layers._items.filter(l => l.type === "graphics")[layerIndex].graphics?._items.forEach(g => {
            let dotNetGraphic = buildDotNetGraphic(g);
            dotNetGraphics.push(dotNetGraphic);
        });
        return dotNetGraphics;
    } catch (error) {
        logError(error, viewId);
    }
}

export function getCenter(viewId) {
    return buildDotNetPoint(arcGisObjectRefs[viewId].center);
}


export function drawWithGeodesicBufferOnPointer(cursorSymbol, bufferSymbol, geodesicBufferDistance, geodesicBufferUnit, viewId) {
    require(["esri/geometry/SpatialReference"], (SpatialReference) => {
        let cursorGraphicId = cursorSymbol.id;
        let bufferGraphicId = bufferSymbol.id;
        let view = arcGisObjectRefs[viewId];
        view.on('pointer-move', async (evt) => {
            let cursorPoint = view.toMap({
                x: evt.x,
                y: evt.y,
            });
            if (cursorPoint) {
                if (cursorPoint.spatialReference.wkid !== 3857 &&
                    cursorPoint.spatialReference.wkid !== 4326) {
                    cursorPoint = await projection.project(cursorPoint, new SpatialReference({
                        wkid: 4326
                    }));
                }
                if (!cursorPoint) return;

                const buffer = await geometryEngine.geodesicBuffer(cursorPoint, geodesicBufferDistance, geodesicBufferUnit);

                if (buffer) {
                    try {
                        let cursorSymbolGraphic = arcGisObjectRefs[cursorGraphicId];
                        if (cursorSymbolGraphic !== undefined && cursorSymbolGraphic !== null) {
                            view.graphics.remove(cursorSymbolGraphic);
                            cursorSymbolGraphic.destroy();
                            delete arcGisObjectRefs[cursorGraphicId];
                        }
                        let bufferSymbolGraphic = arcGisObjectRefs[bufferGraphicId];
                        if (bufferSymbolGraphic !== undefined && bufferSymbolGraphic !== null) {
                            view.graphics.remove(bufferSymbolGraphic);
                            bufferSymbolGraphic.destroy();
                            delete arcGisObjectRefs[bufferGraphicId];
                        }
                    } catch {
                        // ignore if they weren't created yet
                    }
                    if (cursorGraphicId === undefined) {
                        
                    }
                    addGraphic({
                        geometry: cursorPoint,
                        symbol: cursorSymbol,
                        id: cursorGraphicId
                    }, viewId);
                    addGraphic({
                        geometry: buffer,
                        symbol: bufferSymbol,
                        id: bufferGraphicId
                    }, viewId);
                }
            }
        })
    });
}


export function displayQueryResults(query, symbol, popupTemplate, viewId) {
    setWaitCursor(viewId);
    queryLayer.queryFeatures(query)
        .then((results) => {
            results.features.map((feature) => {
                feature.symbol = symbol;
                feature.popupTemplate = popupTemplate;
                return feature;
            });
            let view = arcGisObjectRefs[viewId];

            view.popup.close();
            view.graphics.removeAll();
            view.graphics.addMany(results.features);
            unsetWaitCursor(viewId);
        }).catch((error) => {
        logError(error, viewId);
    });
}

export async function addWidget(widget, viewId) {
    return await require(["esri/widgets/Locate",
            "esri/widgets/Search",
            "esri/widgets/BasemapToggle",
            "esri/widgets/BasemapGallery",
            "esri/widgets/ScaleBar",
            "esri/widgets/Legend",
            "esri/widgets/BasemapGallery/support/PortalBasemapsSource",
            "esri/portal/Portal"
        ],
        function (Locate, Search, BasemapToggle, BasemapGallery, ScaleBar, Legend, 
                  PortalBasemapsSource, Portal) {
            try {
                let view = arcGisObjectRefs[viewId];
                switch (widget.type) {
                    case 'locate':
                        const locate = new Locate({
                            view: view,
                            useHeadingEnabled: widget.useHeadingEnabled,
                            goToOverride: function (view, options) {
                                options.target.scale = widget.zoomTo;
                                return view.goTo(options.target);
                            }
                        });
                        view.ui.add(locate, widget.position);
                        arcGisObjectRefs[widget.id] = locate;
                        break;
                    case 'search':
                        const search = new Search({
                            view: view
                        });
                        view.ui.add(search, widget.position);
                        arcGisObjectRefs[widget.id] = search;
                        search.on('select-result', (evt) => {
                            widget.searchWidgetObjectReference.invokeMethodAsync('OnSearchSelectResult', {
                                extent: buildDotNetExtent(evt.result.extent),
                                feature: buildDotNetFeature(evt.result.feature),
                                name: evt.result.name
                            });
                        });
                        break;
                    case 'basemapToggle':
                        const basemapToggle = new BasemapToggle({
                            view: view,
                            nextBasemap: widget.nextBasemap
                        });
                        view.ui.add(basemapToggle, widget.position);
                        arcGisObjectRefs[widget.id] = basemapToggle;
                        break;
                    case 'basemapGallery':
                        let source = {};
                        if (widget.portalBasemapsSource !== undefined && widget.portalBasemapsSource !== null) {
                            const portal = new Portal();
                            if (widget.portalBasemapsSource.portal?.url !== undefined && 
                                widget.portalBasemapsSource.portal?.url !== null) {
                                portal.url = widget.portalBasemapsSource.portal.url;
                            }
                            source = new PortalBasemapsSource({
                                portal
                            });
                            if (widget.portalBasemapsSource.queryParams !== undefined &&
                                widget.portalBasemapsSource.queryParams !== null) {
                                source.query = widget.portalBasemapsSource.queryParams;
                            } else if (widget.portalBasemapsSource.queryString !== undefined &&
                                widget.portalBasemapsSource.queryString !== null) {
                                source.query = widget.portalBasemapsSource.queryString;
                            }
                        } else if (widget.title !== undefined && widget.title !== null) {
                            source.query = {
                                title: widget.title
                            };
                        }
                        const basemapGallery = new BasemapGallery({
                            view: view,
                            source: source
                        });
                        view.ui.add(basemapGallery, widget.position);
                        arcGisObjectRefs[widget.id] = basemapGallery;
                        break;
                    case 'scaleBar':
                        const scaleBar = new ScaleBar({
                            view: view
                        });
                        if (widget.unit !== undefined && widget.unit !== null) {
                            scaleBar.unit = widget.unit;
                        }
                        view.ui.add(scaleBar, widget.position);
                        arcGisObjectRefs[widget.id] = scaleBar;
                        break;
                    case 'legend':
                        const legend = new Legend({
                            view: view
                        });
                        view.ui.add(legend, widget.position);
                        arcGisObjectRefs[widget.id] = legend;
                        break;
                }
            } catch (error) {
                logError(error, viewId);
            }
        });
}

export function createGraphic(Graphic, graphicObject) {
    let popupTemplate = null;
    if (graphicObject.popupTemplate !== undefined && graphicObject.popupTemplate !== null) {
        popupTemplate = buildPopupTemplate(graphicObject.popupTemplate);
    }

    const graphic = new Graphic({
        geometry: graphicObject.geometry,
        symbol: graphicObject.symbol,
        attributes: graphicObject.attributes,
        popupTemplate: popupTemplate
    });
    
    arcGisObjectRefs[graphicObject.id] = graphic;
    return graphic;
}

export function addLayer(layerObject, viewId, isBasemapLayer, isQueryLayer, callback) {
    return require(["esri/layers/GraphicsLayer",
            "esri/layers/VectorTileLayer",
            "esri/layers/TileLayer",
            "esri/layers/FeatureLayer",
            "esri/layers/GeoJSONLayer"],
        function (GraphicsLayer, VectorTileLayer, TileLayer, FeatureLayer, GeoJSONLayer) {
            let newLayer;
            try {
                let view = arcGisObjectRefs[viewId];
                switch (layerObject.type) {
                    case 'graphics':
                        newLayer = new GraphicsLayer();
                        layerObject.graphics?.forEach(graphicObject => {
                            addGraphic(graphicObject, viewId, newLayer);
                        });
                        break;
                    case 'feature':
                        newLayer = new FeatureLayer({
                            url: layerObject.url,
                            opacity: layerObject.opacity,
                            definitionExpression: layerObject.definitionExpression
                        });
                        if (layerObject.opacity !== undefined && layerObject.opacity !== null) {
                            newLayer.opacity = layerObject.opacity;
                        }
                        if (layerObject.definitionExpression !== undefined && layerObject.definitionExpression !== null) {
                            newLayer.definitionExpression = layerObject.definitionExpression;
                        }
                        if (layerObject.renderer !== undefined && layerObject.renderer !== null) {
                            newLayer.renderer = layerObject.renderer;
                        }

                        if (layerObject.labelingInfo !== undefined && layerObject.labelingInfo?.length > 0) {
                            newLayer.labelingInfo = layerObject.labelingInfo;
                        }

                        if (layerObject.outFields !== undefined && layerObject.outFields?.length > 0) {
                            newLayer.outFields = layerObject.outFields;
                        }

                        if (layerObject.popupTemplate !== undefined && layerObject.popupTemplate !== null) {
                            newLayer.popupTemplate = buildPopupTemplate(layerObject.popupTemplate);
                        }
                        break;
                    case 'vectorTile':
                        if (layerObject.portalItem !== undefined && layerObject.portalItem !== null) {
                            newLayer = new VectorTileLayer({
                                portalItem: layerObject.portalItem
                            });
                        } else {
                            newLayer = new VectorTileLayer({
                                url: layerObject.url
                            });
                        }
                        if (layerObject.opacity !== undefined && layerObject.opacity !== null) {
                            newLayer.opacity = layerObject.opacity;
                        }
                        break;
                    case 'tile':
                        newLayer = new TileLayer({
                            portalItem: {
                                id: layerObject.portalItem.id
                            }
                        });
                        break;
                    case 'geo-json':
                        newLayer = new GeoJSONLayer({
                            url: layerObject.url,
                            copyright: layerObject.copyright
                        });
                        if (layerObject.renderer !== undefined && layerObject.renderer !== null) {
                            newLayer.renderer = layerObject.renderer;
                        }
                        if (layerObject.spatialReference !== undefined && layerObject.spatialReference !== null) {
                            newLayer.spatialReference = {
                                wkid: layerObject.spatialReference.wkid
                            };
                        }
                }

                if (isBasemapLayer) {
                    view.map.basemap.baseLayers.push(newLayer);
                } else if (isQueryLayer) {
                    queryLayer = newLayer;
                    callback();
                } else {
                    view.map.add(newLayer);
                }
                arcGisObjectRefs[layerObject.id] = newLayer;
            } catch (error) {
                logError(error, viewId);
            }
        });
}


export function buildPopupTemplate(popupTemplateObject) {
    let content;
    if (popupTemplateObject.stringContent !== undefined && popupTemplateObject.stringContent !== null) {
        content = popupTemplateObject.stringContent;
    } else {
        content = popupTemplateObject.content;
    }
    return {
        title: popupTemplateObject.title,
        content: content
    };
}

async function resetCenterToSpatialReference(center, spatialReference, viewId) {
    center = await projection.project(center, spatialReference);
    arcGisObjectRefs[viewId].center = center;
}


function logError(error, viewId) {
    if (error.stack !== undefined && error.stack !== null) {
        console.log(error.stack);
        dotNetRefs[viewId].invokeMethodAsync('OnJavascriptError', error.stack);
    } else {
        console.log(error.message);
        dotNetRefs[viewId].invokeMethodAsync('OnJavascriptError', error.message);
    }
    unsetWaitCursor(viewId);
}


export function buildDotNetGraphic(graphic) {
    let dotNetGraphic = {};
    dotNetGraphic.uid = graphic.uid;

    switch (graphic.geometry?.type) {
        case 'point':
            dotNetGraphic.geometry = buildDotNetPoint(graphic.geometry);
            break;
        case 'polyline':
            dotNetGraphic.geometry = buildDotNetPolyline(graphic.geometry);
            break;
        case 'polygon':
            dotNetGraphic.geometry = buildDotNetPolygon(graphic.geometry);
            break;
        case 'extent':
            dotNetGraphic.geometry = buildDotNetExtent(graphic.geometry);
            break;
    }
    return dotNetGraphic;
}


function buildDotNetFeature(feature) {
    let dotNetFeature = {
        attributes: feature.attributes
    };
    dotNetFeature.uid = feature.uid;

    switch (feature.geometry?.type) {
        case 'point':
            dotNetFeature.geometry = buildDotNetPoint(feature.geometry);
            break;
        case 'polyline':
            dotNetFeature.geometry = buildDotNetPolyline(feature.geometry);
            break;
        case 'polygon':
            dotNetFeature.geometry = buildDotNetPolygon(feature.geometry);
            break;
        case 'extent':
            dotNetFeature.geometry = buildDotNetExtent(feature.geometry);
            break;
    }
    return dotNetFeature;
}


export function buildDotNetPoint(point) {
    return {
        type: 'point',
        latitude: point.latitude,
        longitude: point.longitude,
        hasM: point.hasM,
        hasZ: point.hasZ,
        extent: buildDotNetExtent(point.extent),
        x: point.x,
        y: point.y,
        spatialReference: point.spatialReference
    }
}

export function buildDotNetPolyline(polyline) {
    return {
        type: 'polyline',
        paths: polyline.paths,
        hasM: polyline.hasM,
        hasZ: polyline.hasZ,
        extent: buildDotNetExtent(polyline.extent),
        spatialReference: polyline.spatialReference
    }
}

export function buildDotNetPolygon(polygon) {
    return {
        type: 'polygon',
        rings: polygon.rings,
        hasM: polygon.hasM,
        hasZ: polygon.hasZ,
        extent: buildDotNetExtent(polygon.extent),
        spatialReference: polygon.spatialReference
    }
}

export function buildDotNetExtent(extent) {
    if (extent === undefined || extent === null) return null;
    return {
        type: 'extent',
        xmin: extent.xmin,
        ymin: extent.ymin,
        xmax: extent.xmax,
        ymax: extent.ymax,
        zmin: extent.zmin,
        zmax: extent.zmax,
        mmin: extent.mmin,
        mmax: extent.mmax,
        hasM: extent.hasM,
        hasZ: extent.hasZ,
        spatialReference: extent.spatialReference
    }
}

function setWaitCursor(viewId) {
    let viewContainer = document.getElementById(`map-container-${viewId}`);
    if (viewContainer !== null) {
        viewContainer.style.cursor = 'wait';
    }
}

function unsetWaitCursor(viewId) {
    let viewContainer = document.getElementById(`map-container-${viewId}`);
    if (viewContainer !== null) {
        viewContainer.style.cursor = 'unset';
    }
}


export function getActiveWidgetsForView(viewId) {
    let realWidgets = arcGisObjectRefs[viewId]?.ui?._components.filter(c => c?.widget !== undefined).map(c => c.widget);
    let registeredWidgets = Object.values(arcGisObjectRefs).filter(o => o?.declaredClass.includes('esri.widgets'));
    return realWidgets?.filter(wc => registeredWidgets.find(r => r === wc));
}