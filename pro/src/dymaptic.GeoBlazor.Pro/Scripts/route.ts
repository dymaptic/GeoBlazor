import * as route from "@arcgis/core/rest/route";
import {copyValuesIfExists, getProtobufGraphicStream, hasValue} from './geoBlazorCore';
import PolylineBarrier from "@arcgis/core/rest/support/PolylineBarrier";
import PolygonBarrier from "@arcgis/core/rest/support/PolygonBarrier";
import PointBarrier from "@arcgis/core/rest/support/PointBarrier";
import RouteParameters from "@arcgis/core/rest/support/RouteParameters";
import RouteSolveResult from "@arcgis/core/rest/support/RouteSolveResult";
import { buildJsSpatialReference } from "./spatialReference";
import { buildJsPoint } from "./point";
import { buildJsPolygon } from "./polygon";
import { buildJsPolyline } from "./polyline";

export default class RouteWrapper {
    private dotNetRef: any;
    
    constructor(dotNetRef) {
        this.dotNetRef = dotNetRef;
    }

    async solve(url: string, params: any, requestOptions: any) {
        let { buildDotNetGraphic } = await import('./graphic');
        try {
            let jsParams = new RouteParameters();
            if (hasValue(params.outSpatialReference)) {
                jsParams.outSpatialReference = buildJsSpatialReference(params.outSpatialReference) as any;
            }
            if (hasValue(params.pointBarriers)) {
                jsParams.pointBarriers = params.pointBarriers.map((pointBarrier) => {
                    let jsPointBarrier = new PointBarrier();
                    
                    if (hasValue(pointBarrier.geometry)) {
                        jsPointBarrier.geometry = buildJsPoint(pointBarrier.geometry) as any;
                    }
                    
                    copyValuesIfExists(pointBarrier, jsPointBarrier, 'barrierType', 'curbApproach', 'fullEdge',
                        'name');
                    
                    return jsPointBarrier;
                });
            }
            if (hasValue(params.polygonBarriers)) {
                jsParams.polygonBarriers = params.polygonBarriers.map((polygonBarrier) => {
                    let jsPolygonBarrier = new PolygonBarrier();
                    
                    if (hasValue(polygonBarrier.geometry)) {
                        jsPolygonBarrier.geometry = buildJsPolygon(polygonBarrier.geometry) as any;
                    }
                    
                    copyValuesIfExists(polygonBarrier, jsPolygonBarrier, 'barrierType', 'name');
                    
                    return jsPolygonBarrier;
                });
            }
            if (hasValue(params.polylineBarriers)) {
                jsParams.polylineBarriers = params.polylineBarriers.map((polylineBarrier) => {
                    let jsPolylineBarrier = new PolylineBarrier();
                    
                    if (hasValue(polylineBarrier.geometry)) {
                        jsPolylineBarrier.geometry = buildJsPolyline(polylineBarrier.geometry) as any;
                    }
                    
                    copyValuesIfExists(polylineBarrier, jsPolylineBarrier, 'barrierType', 'name');
                    
                    return jsPolylineBarrier;
                });
            }
            if (hasValue(params.featureSetStops)) {
                let { buildJsFeatureSet } = await import('./featureSet');
                jsParams.stops = buildJsFeatureSet(params.featureSetStops);
            }
            if (hasValue(params.travelMode)) {
                jsParams.travelMode = params.travelMode;
            }
            copyValuesIfExists(params, jsParams, 'accumulateAttributes', 'apiKey', 'attributeParameterValues',
                'directionsLanguage', 'directionsLengthUnits', 'directionsOutputType', 'directionsStyleName',
                'directionsTimeAttribute', 'findBestSequence', 'geometryPrecision', 'geometryPrecisionM',
                'geometryPrecisionZ', 'ignoreInvalidLocations', 'impedanceAttribute', 'outputGeometryPrecision',
                'outputGeometryPrecisionUnits', 'outputLines', 'preserveFirstStop', 'preserveLastStop',
                'preserveObjectID', 'restrictionAttributes', 'restrictUTurns', 'returnBarriers', 'returnDirections',
                'returnPolygonBarriers', 'returnPolylineBarriers', 'returnRoutes', 'returnStops', 
                'returnTraversedEdges', 'returnTraversedJunctions', 'returnTraversedTurns', 'returnZ',
                'timeWindowsAreUTC', 'useHierarchy', 'useTimeWindows');
            let result: RouteSolveResult;
            if (requestOptions !== null) {
                result = await route.solve(url, jsParams, requestOptions);
            } else {
                result = await route.solve(url, jsParams);
            }
            let routeResults: any[] = [];
            for (let i = 0; i < result.routeResults.length; i++) {
                let routeResult = result.routeResults[i];
                let directionLines: any = null;
                let { buildDotNetFeatureSet } = await import('./featureSet');
                if (hasValue(routeResult.directionLines)) {
                    directionLines = await buildDotNetFeatureSet(routeResult.directionLines, null, null);
                    let directionLinesGraphics = getProtobufGraphicStream(directionLines.features, null);
                    await this.dotNetRef.invokeMethodAsync('JsGraphicsStreamCallback', directionLinesGraphics, 'directionLines', i);
                    directionLines.features = [];
                }
                let directionPoints: any = null;
                if (hasValue(routeResult.directionPoints)) {
                    directionPoints = await buildDotNetFeatureSet(routeResult.directionPoints, null, null);
                    let directionPointsGraphics = getProtobufGraphicStream(directionPoints.features, null);
                    await this.dotNetRef.invokeMethodAsync('JsGraphicsStreamCallback', directionPointsGraphics, 'directionPoints', i);
                    directionPoints.features = [];
                }
                let directions: any = null;
                if (hasValue(routeResult.directions)) {
                    let { buildDotNetDirectionsFeatureSet } = await import('./directionsFeatureSet');
                    directions = await buildDotNetDirectionsFeatureSet(routeResult.directions, null, null);
                    let directionsGraphics = getProtobufGraphicStream(directions.features, null);
                    await this.dotNetRef.invokeMethodAsync('JsGraphicsStreamCallback', directionsGraphics, 'directions', i);
                    directions.features = [];
                    let mergedGeometries = getProtobufGraphicStream([{geometry: directions.mergedGeometry} as any], null);
                    await this.dotNetRef.invokeMethodAsync('JsGraphicsStreamCallback', mergedGeometries, 'mergedGeometry', i);
                    directions.mergedGeometry = null;
                }
                let traversedEdges: any = null;
                if (hasValue(routeResult.traversedEdges)) {
                    traversedEdges = await buildDotNetFeatureSet(routeResult.traversedEdges, null, null);
                    let traversedEdgesGraphics = getProtobufGraphicStream(traversedEdges.features, null);
                    await this.dotNetRef.invokeMethodAsync('JsGraphicsStreamCallback', traversedEdgesGraphics, 'traversedEdges', i);
                    traversedEdges.features = [];
                }
                let traversedJunctions: any = null;
                if (hasValue(routeResult.traversedJunctions)) {
                    traversedJunctions = await buildDotNetFeatureSet(routeResult.traversedJunctions, null, null);
                    let traversedJunctionsGraphics = getProtobufGraphicStream(traversedJunctions.features, null);
                    await this.dotNetRef.invokeMethodAsync('JsGraphicsStreamCallback', traversedJunctionsGraphics, 'traversedJunctions', i);
                    traversedJunctions.features = [];
                }
                let traversedTurns: any = null;
                if (hasValue(routeResult.traversedTurns)) {
                    traversedTurns = await buildDotNetFeatureSet(routeResult.traversedTurns, null, null);
                    let traversedTurnsGraphics = getProtobufGraphicStream(traversedTurns.features, null);
                    await this.dotNetRef.invokeMethodAsync('JsGraphicsStreamCallback', traversedTurnsGraphics, 'traversedTurns', i);
                    traversedTurns.features = [];
                }
                let route: any = null;
                if (hasValue(routeResult.route)) {
                    route = buildDotNetGraphic(routeResult.route, null, null);
                    let routeGraphics = getProtobufGraphicStream([route], null);
                    await this.dotNetRef.invokeMethodAsync('JsGraphicsStreamCallback', routeGraphics, 'route', i);
                }
                
                if (hasValue(routeResult.stops)) {
                    let graphics = await Promise.all(routeResult.stops.map(async s => await buildDotNetGraphic(s, null, null))) as any;
                    let stopsGraphics = getProtobufGraphicStream(graphics, null);
                    await this.dotNetRef.invokeMethodAsync('JsGraphicsStreamCallback', stopsGraphics, 'stops', i);
                }
                
                routeResults.push({
                    directionLines: directionLines,
                    directionPoints: directionPoints,
                    directions: directions,
                    routeName: routeResult.routeName,
                    traversedEdges: traversedEdges,
                    traversedJunctions: traversedJunctions,
                    traversedTurns: traversedTurns,
                    index: i
                });
            }
            
            if (result.pointBarriers.length > 0) {
                let graphics = result.pointBarriers.map(pb => buildDotNetGraphic(pb, null, null));
                let pointBarriersGraphics = getProtobufGraphicStream(graphics, null);
                await this.dotNetRef.invokeMethodAsync('JsGraphicsStreamCallback', pointBarriersGraphics, 'pointBarriers', null);
            }
            if (result.polygonBarriers.length > 0) {
                let graphics = result.polygonBarriers.map(pb => buildDotNetGraphic(pb, null, null)) as any;
                let polygonBarriersGraphics = getProtobufGraphicStream(graphics, null);
                await this.dotNetRef.invokeMethodAsync('JsGraphicsStreamCallback', polygonBarriersGraphics, 'polygonBarriers', null);
            }
            if (result.polylineBarriers.length > 0) {
                let graphics = result.polylineBarriers.map(pb => buildDotNetGraphic(pb, null, null)) as any;
                let polylineBarriersGraphics = getProtobufGraphicStream(graphics, null);
                await this.dotNetRef.invokeMethodAsync('JsGraphicsStreamCallback', polylineBarriersGraphics, 'polylineBarriers', null);
            }
            
            let messages = result.messages.map(message => {
                return {
                    description: message.description,
                    type: message.type
                }
            });
            return {
                messages: messages,
                routeResults: routeResults
            };
        } catch (error) {
            console.debug(error);
            throw error;
        }
    }
}
