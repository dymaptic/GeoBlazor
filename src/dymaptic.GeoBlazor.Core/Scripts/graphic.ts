import Graphic from "@arcgis/core/Graphic";
import {
    arcGisObjectRefs,
    copyValuesIfExists, getArcGisObjectById,
    graphicsRefs,
    hasValue,
    jsObjectRefs, lookupGeoBlazorGraphicId, lookupGeoBlazorId,
    lookupJsGraphicById, updateGraphicForProtobuf, UseStreams
} from './geoBlazorCore';
import Geometry from "@arcgis/core/geometry/Geometry";
import PopupTemplate from "@arcgis/core/PopupTemplate";
import {buildDotNetGeometry, buildJsGeometry} from './geometry';
import {buildJsPopupTemplate} from './popupTemplate';
import {buildDotNetSymbol, buildJsSymbol} from './symbol';
import {buildJsAttributes} from './attributes';

export function buildJsGraphic(graphicObject: any): any {
    let graphic: Graphic | null = lookupJsGraphicById(graphicObject.id, graphicObject.layerId, graphicObject.viewId);
    if (graphic !== null) {
        graphic.geometry = buildJsGeometry(graphicObject.geometry) as Geometry ?? graphic.geometry;
        graphic.symbol = buildJsSymbol(graphicObject.symbol, graphicObject.layerId, graphicObject.viewId) as any ?? graphic.symbol;
    } else {
        graphic = new Graphic({
            geometry: buildJsGeometry(graphicObject.geometry) as Geometry ?? null,
            symbol: buildJsSymbol(graphicObject.symbol, graphicObject.layerId, graphicObject.viewId) as any ?? null,
        });
    }

    if (hasValue(graphicObject.attributes)) {
        graphic.attributes = buildJsAttributes(graphicObject.attributes);
    }

    if (hasValue(graphicObject.popupTemplate)) {
        graphic.popupTemplate = buildJsPopupTemplate(graphicObject.popupTemplate, graphicObject.layerId, graphicObject.viewId) as PopupTemplate;
    }

    if (hasValue(graphicObject.origin)) {
        let layer: any | undefined = undefined;
        if (arcGisObjectRefs.hasOwnProperty(graphicObject.origin.layerId)) {
            layer = arcGisObjectRefs[graphicObject.origin.layerId] as any;
        }
        graphic.origin = {
            type: 'vector-tile',
            layer: layer,
            layerId: graphicObject.origin.arcGISLayerId,
            layerIndex: graphicObject.origin.layerIndex
        }
    }
    
    if (hasValue(graphicObject.layerId) && arcGisObjectRefs.hasOwnProperty(graphicObject.layerId)) {
        graphic.layer = arcGisObjectRefs[graphicObject.layerId] as any;
    }
    
    if (hasValue(graphicObject.aggregateGeometries)) {
        graphic.aggregateGeometries = JSON.parse(graphicObject.aggregateGeometries);
    }

    copyValuesIfExists(graphicObject, graphic, 'visible');

    let groupId = graphicObject.layerId 
        ?? graphicObject.layer?.id 
        ?? graphicObject.viewId;
    if (hasValue(groupId)) {
        if (!graphicsRefs.hasOwnProperty(groupId!)) {
            graphicsRefs[groupId!] = {};
        }
        graphicsRefs[groupId!][graphicObject.id] = graphic;
    }

    let jsObjectRef = DotNet.createJSObjectReference(graphic);
    jsObjectRefs[graphicObject.id] = jsObjectRef;
    arcGisObjectRefs[graphicObject.id] = graphic;

    return graphic;
}

export function buildDotNetGraphic(graphic: Graphic, layerId: string | null, viewId: string | null): any {
    if (graphic === undefined || graphic === null) return null;
    let dotNetGraphic: any = {};
    
    if (layerId === null && hasValue(graphic.layer)) {
        layerId = lookupGeoBlazorId(graphic.layer);
    }

    let groupId = layerId ?? viewId;
    dotNetGraphic.id = lookupGeoBlazorGraphicId(graphic);

    copyValuesIfExists(graphic, dotNetGraphic, 'visible', 'aggregateGeometries', 'uid');

    dotNetGraphic.attributes = graphic.attributes ?? {};
    dotNetGraphic.layerId = layerId;
    dotNetGraphic.viewId = viewId;

    if (hasValue(graphic.symbol)) {
        dotNetGraphic.symbol = buildDotNetSymbol(graphic.symbol, viewId);
    }

    if (hasValue(graphic.geometry)) {
        dotNetGraphic.geometry = buildDotNetGeometry(graphic.geometry);
    }

    if (hasValue(groupId)) {
        if (!graphicsRefs.hasOwnProperty(groupId!)) {
            graphicsRefs[groupId!] = {};
        }
        
        if (!hasValue(dotNetGraphic.id)) {
            dotNetGraphic.id = crypto.randomUUID();
            graphicsRefs[groupId!][dotNetGraphic.id] = graphic;
        }
    } else if (!hasValue(dotNetGraphic.id)) {
        dotNetGraphic.id = crypto.randomUUID();
    }

    if (UseStreams) {
        updateGraphicForProtobuf(dotNetGraphic, graphic.layer as any);
    }
    
    return dotNetGraphic;
}
