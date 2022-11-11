import SpatialReference from "@arcgis/core/geometry/SpatialReference";
import Extent from "@arcgis/core/geometry/Extent";
import Graphic from "@arcgis/core/Graphic";
import PopupTemplate from "@arcgis/core/PopupTemplate";
import {arcGisObjectRefs} from "./arcGisJsInterop";
import Geometry from "@arcgis/core/geometry/Geometry";
import Point from "@arcgis/core/geometry/Point";
import Polyline from "@arcgis/core/geometry/Polyline";
import Polygon from "@arcgis/core/geometry/Polygon";
import TextSymbol from "@arcgis/core/symbols/TextSymbol";
import SimpleRenderer from "@arcgis/core/renderers/SimpleRenderer";
import Renderer from "@arcgis/core/renderers/Renderer";
import Field from "@arcgis/core/layers/support/Field";
import Font from "@arcgis/core/symbols/Font";
import {
    DotNetExtent,
    DotNetGeometry,
    DotNetPoint,
    DotNetPolygon,
    DotNetPolyline,
    DotNetSpatialReference
} from "./definitions";

export function buildJsSpatialReference(dotNetSpatialReference: DotNetSpatialReference): SpatialReference {
    if (dotNetSpatialReference === undefined || dotNetSpatialReference === null) {
        return new SpatialReference({wkid: 4326});
    }
    let jsSpatialRef = new SpatialReference();
    if (dotNetSpatialReference.wkid !== null) {
        jsSpatialRef.wkid = dotNetSpatialReference.wkid;
    } else if (dotNetSpatialReference.wkt !== null) {
        jsSpatialRef.wkt = dotNetSpatialReference.wkt;
    } else {
        jsSpatialRef.wkid = 4326;
    }

    return jsSpatialRef;
}

export function buildJsExtent(dotNetExtent: DotNetExtent): Extent {
    let extent = new Extent();
    if (dotNetExtent.xmax !== undefined && dotNetExtent.xmax !== null) {
        extent.xmax = dotNetExtent.xmax;
    }
    if (dotNetExtent.xmin !== undefined && dotNetExtent.xmin !== null) {
        extent.xmin = dotNetExtent.xmin;
    }
    if (dotNetExtent.ymax !== undefined && dotNetExtent.ymax !== null) {
        extent.ymax = dotNetExtent.ymax;
    }
    if (dotNetExtent.ymin !== undefined && dotNetExtent.ymin !== null) {
        extent.ymin = dotNetExtent.ymin;
    }
    if (dotNetExtent.zmax !== undefined && dotNetExtent.zmax !== null) {
        extent.zmax = dotNetExtent.zmax;
    }
    if (dotNetExtent.zmin !== undefined && dotNetExtent.zmin !== null) {
        extent.zmin = dotNetExtent.zmin;
    }
    if (dotNetExtent.mmax !== undefined && dotNetExtent.mmax !== null) {
        extent.mmax = dotNetExtent.mmax;
    }
    if (dotNetExtent.mmin !== undefined && dotNetExtent.mmin !== null) {
        extent.mmin = dotNetExtent.mmin;
    }
    if (dotNetExtent.spatialReference !== undefined && dotNetExtent.spatialReference !== null) {
        extent.spatialReference = buildJsSpatialReference(dotNetExtent.spatialReference)
    } else {
        extent.spatialReference = new SpatialReference({wkid: 4326});
    }
    
    return extent;
}

export function buildJsGraphic(graphicObject: any): Graphic | null {
    let popupTemplate: PopupTemplate | undefined = undefined;
    if (graphicObject.popupTemplate !== undefined && graphicObject.popupTemplate !== null) {
        popupTemplate = buildJsPopupTemplate(graphicObject.popupTemplate);
    }

    const graphic = new Graphic({
        geometry: buildJsGeometry(graphicObject.geometry) as Geometry,
        symbol: graphicObject.symbol,
        attributes: graphicObject.attributes,
        popupTemplate: popupTemplate
    });

    arcGisObjectRefs[graphicObject.id] = graphic;
    return graphic;
}

export function buildJsPopupTemplate(popupTemplateObject: any): PopupTemplate {
    let content;
    if (popupTemplateObject.stringContent !== undefined && popupTemplateObject.stringContent !== null) {
        content = popupTemplateObject.stringContent;
    } else {
        content = popupTemplateObject.content;
    }
    return new PopupTemplate({
        title: popupTemplateObject.title,
        content: content
    });
}

export function buildJsGeometry(geometry: DotNetGeometry): Geometry | null {
    if (geometry === undefined || geometry?.type === undefined || geometry?.type === null) return null;
    switch (geometry.type) {
        case "point":
            return buildJsPoint(geometry as DotNetPoint);
        case "polyline":
            return buildJsPolyline(geometry as DotNetPolyline);
        case "polygon":
            return buildJsPolygon(geometry as DotNetPolygon);
        case "extent":
            return buildJsExtent(geometry as DotNetExtent);
    }

    return geometry as any;
}

export function buildJsPoint(dnPoint: DotNetPoint): Point | null {
    if (dnPoint === undefined || dnPoint === null) return null;
    let point = new Point();
    if (dnPoint.latitude !== undefined && dnPoint.latitude !== null) {
        point.latitude = dnPoint.latitude;
    }
    if (dnPoint.longitude !== undefined && dnPoint.longitude !== null) {
        point.longitude = dnPoint.longitude;
    }
    if (dnPoint.x !== undefined && dnPoint.x !== null) {
        point.x = dnPoint.x;
    }
    if (dnPoint.y !== undefined && dnPoint.y !== null) {
        point.y = dnPoint.y;
    }
    if (dnPoint.spatialReference !== undefined && dnPoint.spatialReference !== null) {
        point.spatialReference = buildJsSpatialReference(dnPoint.spatialReference);
    } else {
        point.spatialReference = new SpatialReference({wkid: 4326});
    }
    
    return point;
}

export function buildJsPolyline(dnPolyline: DotNetPolyline): Polyline | null {
    if (dnPolyline === undefined || dnPolyline === null) return null;
    let polyline = new Polyline();
    if (dnPolyline.paths !== undefined && dnPolyline.paths !== null) {
        polyline.paths = dnPolyline.paths;
    }
    if (dnPolyline.spatialReference !== undefined && dnPolyline.spatialReference !== null) {
        polyline.spatialReference = buildJsSpatialReference(dnPolyline.spatialReference);
    } else {
        polyline.spatialReference = new SpatialReference({wkid: 4326});
    }
    return polyline;
}

export function buildJsPolygon(dnPolygon: DotNetPolygon): Polygon | null {
    if (dnPolygon === undefined || dnPolygon === null) return null;
    let polygon = new Polygon();
    if (dnPolygon.rings !== undefined && dnPolygon.rings !== null) {
        polygon.rings = dnPolygon.rings;
    }
    if (dnPolygon.spatialReference !== undefined && dnPolygon.spatialReference !== null) {
        polygon.spatialReference = buildJsSpatialReference(dnPolygon.spatialReference);
    } else {
        polygon.spatialReference = new SpatialReference({wkid: 4326});
    }
    return polygon;
}


export function buildJsRenderer(dotNetRenderer: any): Renderer | null {
    if (dotNetRenderer === undefined || dotNetRenderer?.symbol === undefined ||
        dotNetRenderer?.symbol === null) return null;
    let dotNetSymbol = dotNetRenderer.symbol;
    switch (dotNetRenderer.type) {
        case 'simple':
            let renderer = new SimpleRenderer();
            switch (dotNetSymbol.type) {
                case 'text':
                    let symbol = buildJsTextSymbol(dotNetSymbol);
                    renderer.symbol = symbol;
                    return renderer;
            }
    }

    return dotNetRenderer
}


export function buildJsFields(dotNetFields: any): Array<Field> {
    let fields : Array<Field> = [];
    dotNetFields.forEach(dnField => {
        let field = new Field();
        for (const prop in dnField) {
            if (Object.prototype.hasOwnProperty.call(dnField, prop) && prop !== 'id') {
                field[prop] = dnField[prop];
            }
        }
        fields.push(field);
    });
    
    return fields;
}

export function buildJsTextSymbol(dotNetTextSymbol: any): TextSymbol {
    let symbol = new TextSymbol();
    if (dotNetTextSymbol.color !== undefined && dotNetTextSymbol.color !== null) {
        symbol.color = dotNetTextSymbol.color;
    }
    if (dotNetTextSymbol.haloColor !== undefined && dotNetTextSymbol.haloColor !== null) {
        symbol.haloColor = dotNetTextSymbol.haloColor;
    }
    if (dotNetTextSymbol.haloSize !== undefined && dotNetTextSymbol.haloSize !== null) {
        symbol.haloSize = dotNetTextSymbol.haloSize;
    }
    if (dotNetTextSymbol.text !== undefined && dotNetTextSymbol.text !== null) {
        symbol.text = dotNetTextSymbol.text;
    }
    if (dotNetTextSymbol.font !== undefined && dotNetTextSymbol.font !== null) {
        symbol.font = buildJsFont(dotNetTextSymbol.font);
    }
    
    return symbol;
}

function buildJsFont(dotNetFont: any) : Font {
    let font = new Font();
    font.size = dotNetFont.size;
    font.family = dotNetFont.family;
    font.style = dotNetFont.style;
    font.weight = dotNetFont.weight;
    
    return font;
}