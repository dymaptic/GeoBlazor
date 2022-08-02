import * as geometryEngine from "./geometryEngine.js";
import * as projection from "./projection.js";

export let view;
export let dotNetRef = null;
export let graphicsLayers = [];
export let CreateGraphic = null;
export let activeWidgets = [];
export let basemapLayers = [];
export let mapLayers = [];
export let queryLayer = null;
let viewRoute = null;
let viewRouteParameters = null;
let viewFeatureSet = null;
let viewServiceArea = null;
let viewServiceAreaParameters = null;


export function buildMapView(dotNetReference, long, lat, rotation, mapObject, zoom, scale, apiKey, mapType, widgets,
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
                    setWaitCursor();
                    dotNetRef = dotNetReference;
                    esriConfig.apiKey = apiKey;
                    geometryEngine.initialize(dotNetReference);
                    projection.initialize(dotNetReference);
                    activeWidgets.forEach(w => w?.destroy());
                    activeWidgets = [];
                    basemapLayers.forEach(l => l?.destroy());
                    basemapLayers = [];
                    mapLayers.forEach(ml => ml?.destroy());
                    mapLayers = [];
                    queryLayer?.destroy();
                    queryLayer = null;
                    graphicsLayers?.forEach(gl => gl.destroy());
                    graphicsLayers = [];
                    view?.graphics?.forEach(g => g.destroy());
                    view?.map?.destroy();
                    view?.destroy();
                    view = null;
                    viewRoute = route;
                    viewRouteParameters = RouteParameters;
                    viewFeatureSet = FeatureSet;
                    viewServiceArea = serviceArea;
                    viewServiceAreaParameters = ServiceAreaParameters;
                    CreateGraphic = Graphic;

                    let basemap = null;
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
                                        addLayer(layerObject, true);
                                    }
                                }
                                basemap = new Basemap({
                                    baseLayers: basemapLayers
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
                                container: "map-container",
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
                                container: "map-container",
                                map: webScene
                            });
                            break;
                        case 'scene':
                            const scene = new Map({
                                basemap: basemap,
                                ground: mapObject.ground
                            });
                            view = new SceneView({
                                container: "map-container",
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
                                resetCenterToSpatialReference(center, spatialRef);
                            } else {
                                center = [long, lat];
                            }
                            view = new MapView({
                                map: map,
                                center: center,
                                container: "map-container",
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

                    if (mapObject.layers !== undefined && mapObject.layers !== null) {
                        mapObject.layers.forEach(layerObject => {
                            addLayer(layerObject);
                        });
                    }

                    widgets.forEach(widget => {
                        addWidget(widget);
                    });

                    graphics.forEach(graphicObject => {
                        addGraphic(graphicObject);
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
                    unsetWaitCursor();
                } catch (error) {
                    logError(error);
                }
            });
    } catch (error) {
        logError(error);
    }
}

export function updateWidgets(newWidgets) {
    try {
        setWaitCursor();
        let oldWidgets = [];
        activeWidgets.forEach(aw => {
            if (newWidgets.find(nw => nw.type === aw.type) === undefined) {
                oldWidgets.push(aw);
            }
        });
        oldWidgets.forEach(ow => {
            view.ui.remove(ow);
            activeWidgets.splice(activeWidgets.indexOf(ow), 1);
            ow?.destroy();
        });

        if (newWidgets !== null) {
            newWidgets.forEach(widget => {
                addWidget(widget);
            });
        }
        unsetWaitCursor();
    } catch (error) {
        logError(error);
    }
}

export function updateView(property, value) {
    try {
        setWaitCursor();
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
        unsetWaitCursor();
    } catch (error) {
        logError(error);
    }
}


export function queryFeatureLayer(queryObject, layerObject, symbol, popupTemplateObject) {
    try {
        setWaitCursor();
        let query = {
            where: queryObject.where,
            outFields: queryObject.outFields,
            returnGeometry: queryObject.returnGeometry,
            spatialRelationship: queryObject.spatialRelationship,
        };
        if (queryObject.useViewExtent) {
            query.geometry = view.extent;
        } else if (queryObject.geometry !== undefined && queryObject.geometry !== null) {
            query.geometry = queryObject.geometry;
        }
        let popupTemplate = buildPopupTemplate(popupTemplateObject);
        addLayer(layerObject, false, true, () => {
            displayQueryResults(query, symbol, popupTemplate);
        });
        unsetWaitCursor();
    } catch (error) {
        logError(error);
    }
}


export function updateGraphicsLayer(layerObject) {
    try {
        setWaitCursor();
        console.log('update graphics layer');
        removeGraphicsLayer();
        addLayer(layerObject);
        unsetWaitCursor();
    } catch (error) {
        logError(error);
    }
}

export function removeGraphicsLayer() {
    try {
        setWaitCursor();
        console.log('remove graphics layer');
        view.map.remove(graphicsLayers[0]);
        let layer = graphicsLayers.shift();
        layer?.destroy();
        unsetWaitCursor();
    } catch (error) {
        logError(error);
    }
}

export function updateGraphic(graphicObject, layerIndex) {
    try {
        setWaitCursor();
        console.log(`updating graphic ${graphicObject?.geometry?.type}, UID: ${graphicObject?.uid}`);
        const newGraphic = createGraphic(CreateGraphic, graphicObject);
        let oldGraphic = null;
        if (layerIndex === undefined || layerIndex === null) {
            if (graphicObject.uid !== undefined && graphicObject.uid !== null) {
                oldGraphic = view.graphics.find(g => g.uid === graphicObject.uid);
            }
            if (oldGraphic !== undefine && oldGraphic !== null) {
                view.graphics.remove(oldGraphic);
            } else {
                view.graphics.removeAt(graphicObject.graphicIndex);
            }
            view.graphics.add(newGraphic);
        } else {
            const gLayer = graphicsLayers[layerIndex];
            if (graphicObject.uid !== undefined && graphicObject.uid !== null) {
                oldGraphic = gLayer.graphics.find(g => g.uid === graphicObject.uid);
            }
            if (oldGraphic !== null) {
                gLayer.graphics.remove(oldGraphic);
            } else {
                gLayer.graphics.removeAt(graphicObject.graphicIndex);
            }
            gLayer.graphics.add(newGraphic);
        }
        unsetWaitCursor();
        return newGraphic.uid;
    } catch (error) {
        logError(error);
    }
}

export function removeGraphicAtIndex(index, layerIndex) {
    removeGraphic({graphicIndex: index}, layerIndex);
}


export function removeGraphic(graphicObject, layerIndex) {
    try {
        setWaitCursor();
        console.log(`removing graphic ${graphicObject?.geometry?.type}, UID ${graphicObject.uid} from layer ${layerIndex}`);
        let oldGraphic = null;
        if (layerIndex === undefined || layerIndex === null) {
            if (graphicObject.uid !== undefined && graphicObject.uid !== null) {
                oldGraphic = view.graphics.find(g => g.uid === graphicObject.uid);
                view.graphics.remove(oldGraphic);
            } else {
                view.graphics.removeAt(graphicObject.graphicIndex);
            }
        } else {
            let gLayer = graphicsLayers[layerIndex];
            if (graphicObject.uid !== undefined && graphicObject.uid !== null) {
                oldGraphic = gLayer.graphics?.find(g => g.uid === graphicObject.uid);
                gLayer.graphics.remove(oldGraphic);
            } else {
                graphicsLayers[layerIndex]?.graphics?.removeAt(graphicObject.graphicIndex);
            }
        }
        unsetWaitCursor();
    } catch (error) {
        logError(error);
    }
}

export function updateFeatureLayer(layerObject) {
    try {
        setWaitCursor();
        removeFeatureLayer(layerObject);
        addLayer(layerObject);
        unsetWaitCursor();
    } catch (error) {
        logError(error);
    }
}

export function removeFeatureLayer(layerObject) {
    try {
        setWaitCursor();
        let featureLayer = mapLayers.find(l => layerObject.url.includes(l.url));
        view.map.remove(featureLayer);
        mapLayers.splice(mapLayers.indexOf(featureLayer), 1);
        featureLayer?.destroy();
        unsetWaitCursor();
    } catch (error) {
        logError(error);
    }
}

export function findPlaces(addressQueryParams, symbol, popupTemplateObject) {
    require(["esri/rest/locator"], function (locator) {
        try {
            setWaitCursor();
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
                    unsetWaitCursor();
                }).catch((error) => {
                logError(error)
            });
        } catch (error) {
            logError(error);
        }
    });
}


export async function showPopup(popupTemplateObject, location) {
    try {
        setWaitCursor();
        var popupTemplate = buildPopupTemplate(popupTemplateObject);
        view.popup.open({
            title: popupTemplate.title,
            content: popupTemplate.content,
            location: location
        });
        unsetWaitCursor();
    } catch (error) {
        logError(error);
    }
}


export async function showPopupWithGraphic(graphicObject, options) {
    try {
        setWaitCursor();
        let graphicId = addGraphic(graphicObject);
        let graphic = view.graphics.find(g => g.uid === graphicId);
        view.popup.dockOptions = options.dockOptions;
        view.popup.visibleElements = options.visibleElements;
        view.popup.open({
            features: [graphic]
        });
        unsetWaitCursor();
    } catch (error) {
        logError(error);
    }
}


export function addGraphic(graphicObject, graphicsLayer) {
    try {
        setWaitCursor();
        let graphic = createGraphic(CreateGraphic, graphicObject);
        console.log(`adding graphic ${graphicObject?.geometry?.type}, UID: ${graphic.uid} to layer ${graphicsLayer}`);
        if (graphicsLayer === undefined || graphicsLayer === null) {
            view.graphics.add(graphic);
        } else if (typeof (graphicsLayer) === 'object') {
            graphicsLayer.add(graphic);
        } else {
            graphicsLayers[graphicsLayer].add(graphic);
        }
        unsetWaitCursor();
        return graphic.uid;
    } catch (error) {
        logError(error);
    }
}


export function clearViewGraphics() {
    try {
        setWaitCursor();
        view.graphics.removeAll();
        unsetWaitCursor();
    } catch (error) {
        logError(error);
    }
}


export async function drawRouteAndGetDirections(routeUrl, routeSymbol) {
    try {
        setWaitCursor();
        const routeParams = new viewRouteParameters({
            stops: new viewFeatureSet({
                features: view.graphics.toArray()
            }),
            returnDirections: true
        });

        var data = await viewRoute.solve(routeUrl, routeParams);
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
        unsetWaitCursor();
        return directions;
    } catch (error) {
        logError(error);
    }
}

export function solveServiceArea(url, driveTimeCutoffs, serviceAreaSymbol) {
    try {
        setWaitCursor();
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
                unsetWaitCursor();
            }, function (error) {
                logError(error);
            });
    } catch (error) {
        logError(error);
    }
}


export function getAllGraphics(layerIndex) {
    try {
        let dotNetGraphics = [];
        graphicsLayers[layerIndex].graphics.forEach(g => {
            let dotNetGraphic = buildDotNetGraphic(g);
            dotNetGraphics.push(dotNetGraphic);
        });
        return dotNetGraphics;
    } catch (error) {
        logError(error);
    }
}

export function getCenter() {
    return buildDotNetPoint(view.center);
}


export function drawWithGeodesicBufferOnPointer(cursorSymbol, bufferSymbol, geodesicBufferDistance, geodesicBufferUnit) {
    require(["esri/geometry/SpatialReference"], (SpatialReference) => {
        let cursorGraphicId;
        let bufferGraphicId;
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
                        view.graphics.removeMany([
                            view.graphics.find(g => g.uid === cursorGraphicId),
                            view.graphics.find(g => g.uid === bufferGraphicId)
                        ]);
                    } catch {
                        // ignore if they weren't created yet
                    }
                    cursorGraphicId = addGraphic({
                        geometry: cursorPoint,
                        symbol: cursorSymbol
                    });
                    bufferGraphicId = addGraphic({
                        geometry: buffer,
                        symbol: bufferSymbol
                    });
                }
            }
        })
    });
}


export function displayQueryResults(query, symbol, popupTemplate) {
    setWaitCursor();
    queryLayer.queryFeatures(query)
        .then((results) => {
            results.features.map((feature) => {
                feature.symbol = symbol;
                feature.popupTemplate = popupTemplate;
                return feature;
            });

            view.popup.close();
            view.graphics.removeAll();
            view.graphics.addMany(results.features);
            unsetWaitCursor();
        }).catch((error) => {
        logError(error);
    });
}

export function addWidget(widget) {
    return require(["esri/widgets/Locate",
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
                switch (widget.type) {
                    case 'locate':
                        if (activeWidgets.some(w => w.declaredClass === 'esri.widgets.Locate')) {
                            console.log("Locate widget already added!");
                            return;
                        }
                        const locate = new Locate({
                            view: view,
                            useHeadingEnabled: widget.useHeadingEnabled,
                            goToOverride: function (view, options) {
                                options.target.scale = widget.zoomTo;
                                return view.goTo(options.target);
                            }
                        });
                        view.ui.add(locate, widget.position);
                        activeWidgets.push(locate);
                        break;
                    case 'search':
                        if (activeWidgets.some(w => w.declaredClass === 'esri.widgets.Search')) {
                            console.log("Search widget already added!");
                            return;
                        }
                        const search = new Search({
                            view: view
                        });
                        view.ui.add(search, widget.position);
                        activeWidgets.push(search);
                        search.on('select-result', (evt) => {
                            widget.searchWidgetObjectReference.invokeMethodAsync('OnSearchSelectResult', {
                                extent: buildDotNetExtent(evt.result.extent),
                                feature: buildDotNetFeature(evt.result.feature),
                                name: evt.result.name
                            });
                        });
                        break;
                    case 'basemapToggle':
                        if (activeWidgets.some(w => w.declaredClass === 'esri.widgets.BasemapToggle')) {
                            console.log("Basemap Toggle widget already added!");
                            return;
                        }
                        const basemapToggle = new BasemapToggle({
                            view: view,
                            nextBasemap: widget.nextBasemap
                        });
                        view.ui.add(basemapToggle, widget.position);
                        activeWidgets.push(basemapToggle);
                        break;
                    case 'basemapGallery':
                        if (activeWidgets.some(w => w.declaredClass === 'esri.widgets.BasemapGallery')) {
                            console.log("Basemap Gallery widget already added!");
                            return;
                        }
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
                        activeWidgets.push(basemapGallery);
                        break;
                    case 'scaleBar':
                        if (activeWidgets.some(w => w.declaredClass === 'esri.widgets.ScaleBar')) {
                            console.log("Scale Bar widget already added!");
                            return;
                        }
                        const scaleBar = new ScaleBar({
                            view: view
                        });
                        if (widget.unit !== undefined && widget.unit !== null) {
                            scaleBar.unit = widget.unit;
                        }
                        view.ui.add(scaleBar, widget.position);
                        activeWidgets.push(scaleBar);
                        break;
                    case 'legend':
                        if (activeWidgets.some(w => w.declaredClass === 'esri.widgets.Legend')) {
                            console.log("Legend widget already added!");
                            return;
                        }
                        const legend = new Legend({
                            view: view
                        });
                        view.ui.add(legend, widget.position);
                        activeWidgets.push(legend);
                        break;
                }
            } catch (error) {
                logError(error);
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
    return graphic;
}

export function addLayer(layerObject, isBasemapLayer, isQueryLayer, callback) {
    return require(["esri/layers/GraphicsLayer",
            "esri/layers/VectorTileLayer",
            "esri/layers/TileLayer",
            "esri/layers/FeatureLayer",
            "esri/layers/GeoJSONLayer"],
        function (GraphicsLayer, VectorTileLayer, TileLayer, FeatureLayer, GeoJSONLayer) {
            let newLayer;
            try {
                switch (layerObject.type) {
                    case 'graphics':
                        newLayer = new GraphicsLayer();
                        graphicsLayers.push(newLayer);
                        layerObject.graphics?.forEach(graphicObject => {
                            addGraphic(graphicObject, newLayer);
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
                    basemapLayers.push(newLayer);
                } else if (isQueryLayer) {
                    queryLayer = newLayer;
                    callback();
                } else {
                    mapLayers.push(newLayer);
                    view.map.add(newLayer);
                }
            } catch (error) {
                logError(error);
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

async function resetCenterToSpatialReference(center, spatialReference) {
    center = await projection.project(center, spatialReference);
    view.center = center;
}


function logError(error) {
    if (error.stack !== undefined && error.stack !== null) {
        console.log(error.stack);
        dotNetRef.invokeMethodAsync('OnJavascriptError', error.stack);
    } else {
        console.log(error.message);
        dotNetRef.invokeMethodAsync('OnJavascriptError', error.message);
    }
    unsetWaitCursor();
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

function setWaitCursor() {
    document.getElementById('map-container').style.cursor = 'wait';
}

function unsetWaitCursor() {
    document.getElementById('map-container').style.cursor = 'unset';
}