import Graphic from "@arcgis/core/Graphic";
import {
    arcGisObjectRefs,
    copyValuesIfExists,
    graphicsRefs,
    hasValue,
    jsObjectRefs,
    lookupJsGraphicById
} from "./arcGisJsInterop";
import Geometry from "@arcgis/core/geometry/Geometry";
import Symbol from "@arcgis/core/symbols/Symbol";
import PopupTemplate from "@arcgis/core/PopupTemplate";
import {buildDotNetGeometry, buildJsGeometry} from './geometry';
import {buildJsPopupTemplate} from './popupTemplate';
import {buildDotNetSymbol, buildJsSymbol} from './symbol';
import {buildJsAttributes} from './attributes';

export function buildJsGraphic(graphicObject: any)
    : Graphic | null {
    let graphic: Graphic | null = lookupJsGraphicById(graphicObject.id, graphicObject.layerId, graphicObject.viewId);
    if (graphic !== null) {
        graphic.geometry = buildJsGeometry(graphicObject.geometry) as Geometry ?? graphic.geometry;
        graphic.symbol = buildJsSymbol(graphicObject.symbol) as Symbol ?? graphic.symbol;
    } else {
        graphic = new Graphic({
            geometry: buildJsGeometry(graphicObject.geometry) as Geometry ?? null,
            symbol: buildJsSymbol(graphicObject.symbol) as Symbol ?? null,
        });
    }

    graphic.attributes = buildJsAttributes(graphicObject.attributes);

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

    copyValuesIfExists(graphicObject, graphic, 'visible', 'aggregateGeometries', '');

    let groupId = graphicObject.layerId ?? graphicObject.viewId;
    if (hasValue(groupId)) {
        if (!graphicsRefs.hasOwnProperty(groupId!)) {
            graphicsRefs[groupId!] = {};
        }
        graphicsRefs[groupId!][graphicObject.id] = graphic;
    }

    // @ts-ignore
    let jsObjectRef = DotNet.createJSObjectReference(graphic);
    jsObjectRefs[graphicObject.id] = jsObjectRef;

    return graphic;
}

export function buildDotNetGraphic(graphic: Graphic, layerId: string | null, viewId: string | null): any {
    if (graphic === undefined || graphic === null) return null;
    let dotNetGraphic: any = {};

    let groupId = layerId ?? viewId;
    if (groupId !== null && graphicsRefs.hasOwnProperty(groupId)) {
        let group = graphicsRefs[groupId];
        for (const k of Object.keys(group)) {
            if (group[k] === graphic) {
                dotNetGraphic.id = k;
                break;
            }
        }
    } else {
        for (const k of Object.keys(graphicsRefs)) {
            let group = graphicsRefs[k];
            for (const j of Object.keys(group)) {
                if (group[j] === graphic) {
                    dotNetGraphic.id = j;
                    break;
                }
            }
        }
    }

    copyValuesIfExists(graphic, dotNetGraphic, 'visible', 'aggregateGeometries', 'uid');

    dotNetGraphic.attributes = graphic.attributes ?? {};
    dotNetGraphic.layerId = layerId;
    dotNetGraphic.viewId = viewId;

    if (hasValue(graphic.symbol)) {
        dotNetGraphic.symbol = buildDotNetSymbol(graphic.symbol);
    }

    if (hasValue(graphic.geometry)) {
        dotNetGraphic.geometry = buildDotNetGeometry(graphic.geometry);
    }
    return dotNetGraphic;
}
