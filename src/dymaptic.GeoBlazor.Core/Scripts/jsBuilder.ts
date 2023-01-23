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
    DotNetAttachmentsPopupContent,
    DotNetBarChartMediaInfo,
    DotNetChartMediaInfoValue,
    DotNetColumnChartMediaInfo, DotNetElementExpressionInfo, DotNetExpressionInfo, DotNetExpressionPopupContent,
    DotNetExtent,
    DotNetFieldInfo,
    DotNetFieldInfoFormat,
    DotNetFieldsPopupContent,
    DotNetGeometry,
    DotNetImageMediaInfo,
    DotNetImageMediaInfoValue,
    DotNetLineChartMediaInfo,
    DotNetMediaInfo,
    DotNetMediaPopupContent, DotNetPictureMarkerSymbol, DotNetPieChartMediaInfo,
    DotNetPoint,
    DotNetPolygon,
    DotNetPolyline,
    DotNetPopupContent,
    DotNetPopupTemplate,
    DotNetQuery, DotNetRelationshipQuery, DotNetSimpleFillSymbol, DotNetSimpleLineSymbol, DotNetSimpleMarkerSymbol,
    DotNetSpatialReference, DotNetSymbol,
    DotNetTextPopupContent, DotNetTopFeaturesQuery
} from "./definitions";
import ViewClickEvent = __esri.ViewClickEvent;
import PictureMarkerSymbol from "@arcgis/core/symbols/PictureMarkerSymbol";
import Popup from "@arcgis/core/widgets/Popup";
import PopupOpenOptions = __esri.PopupOpenOptions;
import PopupDockOptions = __esri.PopupDockOptions;
import Query from "@arcgis/core/rest/support/Query";
import ContentProperties = __esri.ContentProperties;
import FieldsContent from "@arcgis/core/popup/content/FieldsContent";
import TextContent from "@arcgis/core/popup/content/TextContent";
import FieldInfo from "@arcgis/core/popup/FieldInfo";
import FieldInfoFormat from "@arcgis/core/popup/support/FieldInfoFormat";
import MediaContent from "@arcgis/core/popup/content/MediaContent";
import BarChartMediaInfo from "@arcgis/core/popup/content/BarChartMediaInfo";
import ColumnChartMediaInfo from "@arcgis/core/popup/content/ColumnChartMediaInfo";
import ChartMediaInfoValue from "@arcgis/core/popup/content/support/ChartMediaInfoValue";
import ImageMediaInfoValue from "@arcgis/core/popup/content/support/ImageMediaInfoValue";
import ImageMediaInfo from "@arcgis/core/popup/content/ImageMediaInfo";
import LineChartMediaInfo from "@arcgis/core/popup/content/LineChartMediaInfo";
import PieChartMediaInfo from "@arcgis/core/popup/content/PieChartMediaInfo";
import AttachmentsContent from "@arcgis/core/popup/content/AttachmentsContent";
import ExpressionContent from "@arcgis/core/popup/content/ExpressionContent";
import ElementExpressionInfoProperties = __esri.ElementExpressionInfoProperties;
import Layer from "@arcgis/core/layers/Layer";
import RelationshipQuery from "@arcgis/core/rest/support/RelationshipQuery";
import TopFeaturesQuery from "@arcgis/core/rest/support/TopFeaturesQuery";
import popupExpressionInfo from "@arcgis/core/popup/ExpressionInfo";
import GraphicWrapper from "./graphic";
import SimpleMarkerSymbol from "@arcgis/core/symbols/SimpleMarkerSymbol";
import Symbol from "@arcgis/core/symbols/Symbol";
import SimpleFillSymbol from "@arcgis/core/symbols/SimpleFillSymbol";
import SimpleLineSymbol from "@arcgis/core/symbols/SimpleLineSymbol";
import ElementExpressionInfo from "@arcgis/core/popup/ElementExpressionInfo";
import ChartMediaInfoValueSeries from "@arcgis/core/popup/content/support/ChartMediaInfoValueSeries";

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

export async function buildJsGraphic(graphicObject: any): Promise<Graphic | null> {
    const graphic = new Graphic({
        geometry: buildJsGeometry(graphicObject.geometry) as Geometry
    });
    
    if (graphicObject.symbol !== undefined && graphicObject.symbol !== null) {
        graphic.symbol = buildJsSymbol(graphicObject.symbol) as Symbol;
    }
    
    if (graphicObject.attributes !== undefined && graphicObject.attributes !== null &&
        Object.keys(graphicObject.attributes).length > 0) {
        graphic.attributes = graphicObject.attributes;
    }

    if (graphicObject.popupTemplate !== undefined && graphicObject.popupTemplate !== null) {
        graphic.popupTemplate = buildJsPopupTemplate(graphicObject.popupTemplate);
    }
    
    if (graphicObject.layerId !== undefined && graphicObject.layerId !== null) {
        let layer = arcGisObjectRefs[graphicObject.layerId] as Layer;
        graphic.layer = layer;
    }

    let wrapper = new GraphicWrapper(graphic);
    // @ts-ignore
    let objectRef = DotNet.createJSObjectReference(wrapper);
    await graphicObject.dotNetGraphicReference.invokeMethodAsync("OnGraphicCreated", objectRef);
    arcGisObjectRefs[graphicObject.id] = graphic;
    return graphic;
}

export function buildJsPopupTemplate(popupTemplateObject: DotNetPopupTemplate): PopupTemplate {
    let content;
    if (popupTemplateObject.stringContent !== undefined && popupTemplateObject.stringContent !== null) {
        content = popupTemplateObject.stringContent;
    } else {
        content = popupTemplateObject.content?.map(c => buildJsPopupContent(c));
    }
    let template = new PopupTemplate();
    
    if (popupTemplateObject.title !== undefined && popupTemplateObject.title !== null) {
        template.title = popupTemplateObject.title;
    }
    
    if (content !== undefined && content !== null) {
        template.content = content;
    }
    
    if (popupTemplateObject.outFields !== undefined && popupTemplateObject.outFields !== null) {
        template.outFields = popupTemplateObject.outFields;
    }
    
    if (popupTemplateObject.overwriteActions !== undefined && popupTemplateObject.overwriteActions !== null) {
        template.overwriteActions = popupTemplateObject.overwriteActions;
    }
    
    if (popupTemplateObject.returnGeometry !== undefined && popupTemplateObject.returnGeometry !== null) {
        template.returnGeometry = popupTemplateObject.returnGeometry;
    }
    
    if (popupTemplateObject.fieldInfos !== undefined && popupTemplateObject.fieldInfos !== null) {
        template.fieldInfos = popupTemplateObject.fieldInfos.map(f => buildJsFieldInfo(f));
    }
    
    if (popupTemplateObject.expressionInfos !== undefined && popupTemplateObject.expressionInfos !== null) {
        template.expressionInfos = popupTemplateObject.expressionInfos.map(e => buildJsExpressionInfo(e));
    }
    
    return template;
}

export function buildJsPopupContent(popupContentObject: DotNetPopupContent): ContentProperties | null {
    switch (popupContentObject?.type) {
        case "fields":
            let dnFieldsContent = popupContentObject as DotNetFieldsPopupContent;
            let fieldsContent = new FieldsContent();
            if (dnFieldsContent.fieldInfos !== undefined && dnFieldsContent.fieldInfos !== null &&
                dnFieldsContent.fieldInfos.length > 0) {
                fieldsContent.fieldInfos = dnFieldsContent.fieldInfos.map(f => buildJsFieldInfo(f));
            }
            if (dnFieldsContent.description !== undefined && dnFieldsContent.description !== null) {
                fieldsContent.description = dnFieldsContent.description;
            }
            if (dnFieldsContent.title !== undefined && dnFieldsContent.title !== null) {
                fieldsContent.title = dnFieldsContent.title;
            }
            return fieldsContent;
        case "text":
            let dnTextContent = popupContentObject as DotNetTextPopupContent;
            let textContent = new TextContent();
            if (dnTextContent.text !== undefined && dnTextContent.text !== null) {
                textContent.text = dnTextContent.text;
            }
            return textContent;
        case "media":
            let dnMediaContent = popupContentObject as DotNetMediaPopupContent;
            let mediaContent = new MediaContent();
            if (dnMediaContent.mediaInfos !== undefined && dnMediaContent.mediaInfos !== null &&
                dnMediaContent.mediaInfos.length > 0) {
                mediaContent.mediaInfos = dnMediaContent.mediaInfos.map(m => buildJsMediaInfo(m));
            }
            return mediaContent;
        case "attachments":
            let dnAttachmentsContent = popupContentObject as DotNetAttachmentsPopupContent;
            let attachmentsContent = new AttachmentsContent();
            if (dnAttachmentsContent.description !== undefined && dnAttachmentsContent.description !== null) {
                attachmentsContent.description = dnAttachmentsContent.description;
            }
            if (dnAttachmentsContent.title !== undefined && dnAttachmentsContent.title !== null) {
                attachmentsContent.title = dnAttachmentsContent.title;
            }
            if (dnAttachmentsContent.displayType !== undefined && dnAttachmentsContent.displayType !== null) {
                attachmentsContent.displayType = dnAttachmentsContent.displayType as any;
            }
            return attachmentsContent;
        case "expression":
            let dnExpressionContent = popupContentObject as DotNetExpressionPopupContent;
            let expressionContent = new ExpressionContent({
                expressionInfo: buildJsElementExpressionInfo(dnExpressionContent.expressionInfo)
            });
            if (dnExpressionContent.expressionInfo !== undefined && dnExpressionContent.expressionInfo !== null) {
                expressionContent.expressionInfo = buildJsElementExpressionInfo(dnExpressionContent.expressionInfo);
            }
    }
    return null;
}

export function buildJsFieldInfo(fieldInfoObject: DotNetFieldInfo): FieldInfo {
    let fieldInfo = new FieldInfo();
    
    if (fieldInfoObject.fieldName !== undefined && fieldInfoObject.fieldName !== null) {
        fieldInfo.fieldName = fieldInfoObject.fieldName;
    }
    
    if (fieldInfoObject.label !== undefined && fieldInfoObject.label !== null) {
        fieldInfo.label = fieldInfoObject.label;
    }
    
    if (fieldInfoObject.tooltip !== undefined && fieldInfoObject.tooltip !== null) {
        fieldInfo.tooltip = fieldInfoObject.tooltip;
    }
    
    if (fieldInfoObject.stringFieldOption !== undefined && fieldInfoObject.stringFieldOption !== null) {
        fieldInfo.stringFieldOption = fieldInfoObject.stringFieldOption as any;
    }
    
    if (fieldInfoObject.visible !== undefined && fieldInfoObject.visible !== null) {
        fieldInfo.visible = fieldInfoObject.visible;
    }
    
    if (fieldInfoObject.isEditable !== undefined && fieldInfoObject.isEditable !== null) {
        fieldInfo.isEditable = fieldInfoObject.isEditable;
    }
    
    if (fieldInfoObject.format !== undefined && fieldInfoObject.format !== null) {
        fieldInfo.format = buildJsFieldInfoFormat(fieldInfoObject.format);
    }
    
    return fieldInfo;
}

export function buildJsFieldInfoFormat(formatObject: DotNetFieldInfoFormat): FieldInfoFormat {
    return new FieldInfoFormat({
        dateFormat: formatObject.dateFormat as any ?? undefined,
        places: formatObject.places ?? undefined,
        digitSeparator: formatObject.digitSeparator ?? undefined
    });
}

export function buildJsExpressionInfo(expressionInfoObject: DotNetExpressionInfo): popupExpressionInfo {
    return {
        name: expressionInfoObject.name ?? undefined,
        title: expressionInfoObject.title ?? undefined,
        expression: expressionInfoObject.expression ?? undefined,
        returnType: expressionInfoObject.returnType as any ?? undefined
    } as popupExpressionInfo;
}

export function buildJsSymbol(symbol: DotNetSymbol | null): Symbol | null {
    if (symbol === null) {
        return null;
    }
    switch (symbol.type) {
        case "simple-marker":
            let dnSimpleMarkerSymbol = symbol as DotNetSimpleMarkerSymbol;
            let jsSimpleMarkerSymbol = new SimpleMarkerSymbol();
            if (dnSimpleMarkerSymbol.color !== undefined && dnSimpleMarkerSymbol.color !== null) {
                jsSimpleMarkerSymbol.color = dnSimpleMarkerSymbol.color as any;
            }
            
            if (dnSimpleMarkerSymbol.path !== undefined && dnSimpleMarkerSymbol.path !== null) {
                jsSimpleMarkerSymbol.path = dnSimpleMarkerSymbol.path;
            }
            
            if (dnSimpleMarkerSymbol.size !== undefined && dnSimpleMarkerSymbol.size !== null) {
                jsSimpleMarkerSymbol.size = dnSimpleMarkerSymbol.size;
            }
            
            if (dnSimpleMarkerSymbol.style !== undefined && dnSimpleMarkerSymbol.style !== null) {
                jsSimpleMarkerSymbol.style = dnSimpleMarkerSymbol.style as any;
            }
            
            if (dnSimpleMarkerSymbol.xoffset !== undefined && dnSimpleMarkerSymbol.xoffset !== null) {
                jsSimpleMarkerSymbol.xoffset = dnSimpleMarkerSymbol.xoffset;
            }
            
            if (dnSimpleMarkerSymbol.yoffset !== undefined && dnSimpleMarkerSymbol.yoffset !== null) {
                jsSimpleMarkerSymbol.yoffset = dnSimpleMarkerSymbol.yoffset;
            }
            
            if (dnSimpleMarkerSymbol.outline !== undefined && dnSimpleMarkerSymbol.outline !== null) {
                jsSimpleMarkerSymbol.outline = buildJsSymbol(dnSimpleMarkerSymbol.outline) as any;
            }
            return jsSimpleMarkerSymbol;
        case "simple-line":
            let dnSimpleLineSymbol = symbol as DotNetSimpleLineSymbol;
            let jsSimpleLineSymbol = new SimpleLineSymbol();
            
            if (dnSimpleLineSymbol.color !== undefined && dnSimpleLineSymbol.color !== null) {
                jsSimpleLineSymbol.color = dnSimpleLineSymbol.color as any;
            }
            
            if (dnSimpleLineSymbol.cap !== undefined && dnSimpleLineSymbol.cap !== null) {
                jsSimpleLineSymbol.cap = dnSimpleLineSymbol.cap as any;
            }
            
            if (dnSimpleLineSymbol.join !== undefined && dnSimpleLineSymbol.join !== null) {
                jsSimpleLineSymbol.join = dnSimpleLineSymbol.join as any;
            }
            
            if (dnSimpleLineSymbol.marker !== undefined && dnSimpleLineSymbol.marker !== null) {
                jsSimpleLineSymbol.marker = dnSimpleLineSymbol.marker as any;
            }
            
            if (dnSimpleLineSymbol.miterLimit !== undefined && dnSimpleLineSymbol.miterLimit !== null) {
                jsSimpleLineSymbol.miterLimit = dnSimpleLineSymbol.miterLimit;
            }
            
            if (dnSimpleLineSymbol.style !== undefined && dnSimpleLineSymbol.style !== null) {
                jsSimpleLineSymbol.style = dnSimpleLineSymbol.style as any;
            }
            
            if (dnSimpleLineSymbol.width !== undefined && dnSimpleLineSymbol.width !== null) {
                jsSimpleLineSymbol.width = dnSimpleLineSymbol.width;
            }
            
            return jsSimpleLineSymbol;
        case "picture-marker":
            let dnPictureMarkerSymbol = symbol as DotNetPictureMarkerSymbol;
            let jsPictureMarkerSymbol = new PictureMarkerSymbol();
            
            if (dnPictureMarkerSymbol.color !== undefined && dnPictureMarkerSymbol.color !== null) {
                jsPictureMarkerSymbol.color = dnPictureMarkerSymbol.color as any;
            }
            if (dnPictureMarkerSymbol.angle !== undefined && dnPictureMarkerSymbol.angle !== null) {
                jsPictureMarkerSymbol.angle = dnPictureMarkerSymbol.angle;
            }
            if (dnPictureMarkerSymbol.xoffset !== undefined && dnPictureMarkerSymbol.xoffset !== null) {
                jsPictureMarkerSymbol.xoffset = dnPictureMarkerSymbol.xoffset;
            }
            if (dnPictureMarkerSymbol.yoffset !== undefined && dnPictureMarkerSymbol.yoffset !== null) {
                jsPictureMarkerSymbol.yoffset = dnPictureMarkerSymbol.yoffset;
            }
            
            return jsPictureMarkerSymbol;
            
        case "simple-fill":
            let dnSimpleFillSymbol = symbol as DotNetSimpleFillSymbol;
            let jsSimpleFillSymbol = new SimpleFillSymbol();
            if (dnSimpleFillSymbol.color !== undefined && dnSimpleFillSymbol.color !== null) {
                jsSimpleFillSymbol.color = dnSimpleFillSymbol.color as any;
            }
            
            if (dnSimpleFillSymbol.style !== undefined && dnSimpleFillSymbol.style !== null) {
                jsSimpleFillSymbol.style = dnSimpleFillSymbol.style as any;
            }
            
            if (dnSimpleFillSymbol.outline !== undefined && dnSimpleFillSymbol.outline !== null) {
                jsSimpleFillSymbol.outline = buildJsSymbol(dnSimpleFillSymbol.outline) as any;
            }
            return jsSimpleFillSymbol;
    }
    
    delete symbol["id"];
    return symbol as any;
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
            renderer.visualVariables = dotNetRenderer.visualVariables;
            switch (dotNetSymbol.type) {
                case 'text':
                    let symbol = buildJsTextSymbol(dotNetSymbol);
                    renderer.symbol = symbol;
                    return renderer;
                case 'picture-marker':
                    let marker = buildJsPictureMarker(dotNetSymbol);
                    renderer.symbol = marker;
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

export function buildJsPictureMarker(dotNetPictureMarker: any): PictureMarkerSymbol {
    let symbol = new PictureMarkerSymbol();
    if (dotNetPictureMarker.color !== undefined && dotNetPictureMarker.color !== null) {
        symbol.color = dotNetPictureMarker.color;
    }

    if (dotNetPictureMarker.angle !== undefined && dotNetPictureMarker.angle !== null) {
        symbol.angle = dotNetPictureMarker.angle;
    }

    if (dotNetPictureMarker.height !== undefined && dotNetPictureMarker.height !== null) {
        symbol.height = dotNetPictureMarker.height;
    }

    if (dotNetPictureMarker.width !== undefined && dotNetPictureMarker.width !== null) {
        symbol.width = dotNetPictureMarker.width;
    }

    if (dotNetPictureMarker.url !== undefined && dotNetPictureMarker.url !== null) {
        symbol.url = dotNetPictureMarker.url;
    }

    if (dotNetPictureMarker.xoffset !== undefined && dotNetPictureMarker.xoffset !== null) {
        symbol.xoffset = dotNetPictureMarker.xoffset;
    }

    if (dotNetPictureMarker.yoffset !== undefined && dotNetPictureMarker.yoffset !== null) {
        symbol.yoffset = dotNetPictureMarker.yoffset;
    }
    
    return symbol;
}

export function buildJsViewClickEvent(dotNetClickEvent: any): ViewClickEvent {
    return {
        type: dotNetClickEvent.type,
        mapPoint: buildJsPoint(dotNetClickEvent.mapPoint) as Point,
        x: dotNetClickEvent.x,
        y: dotNetClickEvent.y,
        button: dotNetClickEvent.button ?? undefined,
        buttons: dotNetClickEvent.buttons ?? undefined,
        timestamp: dotNetClickEvent.timestamp ?? undefined
    } as ViewClickEvent
}

export async function buildJsPopup(dotNetPopup: any) : Promise<Popup> {
    let popup = new Popup();
    
    if (dotNetPopup.stringContent !== undefined && dotNetPopup.stringContent !== null) {
        popup.content = dotNetPopup.stringContent;
    }
    
    if (dotNetPopup.actions !== undefined && dotNetPopup.actions !== null) {
        popup.actions = dotNetPopup.actions;
    }
    
    if (dotNetPopup.title !== undefined && dotNetPopup.title !== null) {
        popup.title = dotNetPopup.title;
    }
    
    if (dotNetPopup.location !== undefined && dotNetPopup.location !== null) {
        popup.location = buildJsPoint(dotNetPopup.location) as Point;
    }
    
    if (dotNetPopup.visible !== undefined && dotNetPopup.visible !== null) {
        popup.visible = dotNetPopup.visible;
    }
    
    if (dotNetPopup.dockEnabled !== undefined && dotNetPopup.dockEnabled !== null) {
        popup.dockEnabled = dotNetPopup.dockEnabled;
    }
    
    if (dotNetPopup.dockOptions !== undefined && dotNetPopup.dockOptions !== null) {
        popup.dockOptions = buildJsDockOptions(dotNetPopup.dockOptions);
    }
    
    if (dotNetPopup.features !== undefined && dotNetPopup.features !== null) {
        let features: Graphic[] = [];
        for (const f of dotNetPopup.features) {
            features.push(await buildJsGraphic(f) as Graphic);
        }
        popup.features = features;
    }
    
    if (dotNetPopup.alignment !== undefined && dotNetPopup.alignment !== null) {
        popup.alignment = dotNetPopup.alignment;
    }
    
    if (dotNetPopup.autoCloseEnabled !== undefined && dotNetPopup.autoCloseEnabled !== null) {
        popup.autoCloseEnabled = dotNetPopup.autoCloseEnabled;
    }
    
    if (dotNetPopup.autoOpenEnabled !== undefined && dotNetPopup.autoOpenEnabled !== null) {
        popup.autoOpenEnabled = dotNetPopup.autoOpenEnabled;
    }
    
    if (dotNetPopup.collapseEnabled !== undefined && dotNetPopup.collapseEnabled !== null) {
        popup.collapseEnabled = dotNetPopup.collapseEnabled;
    }
    
    if (dotNetPopup.collapsed !== undefined && dotNetPopup.collapsed !== null) {
        popup.collapsed = dotNetPopup.collapsed;
    }
    
    if (dotNetPopup.defaultPopupTemplateEnabled !== undefined && dotNetPopup.defaultPopupTemplateEnabled !== null) {
        popup.defaultPopupTemplateEnabled = dotNetPopup.defaultPopupTemplateEnabled;
    }
    
    if (dotNetPopup.dockEnabled !== undefined && dotNetPopup.dockEnabled !== null) {
        popup.dockEnabled = dotNetPopup.dockEnabled;
    }
    
    if (dotNetPopup.headingLevel !== undefined && dotNetPopup.headingLevel !== null) {
        popup.headingLevel = dotNetPopup.headingLevel;
    }
    
    if (dotNetPopup.highlightEnabled !== undefined && dotNetPopup.highlightEnabled !== null) {
        popup.highlightEnabled = dotNetPopup.highlightEnabled;
    }
    
    if (dotNetPopup.label !== undefined && dotNetPopup.label !== null) {
        popup.label = dotNetPopup.label;
    }
    
    if (dotNetPopup.spinnerEnabled !== undefined && dotNetPopup.spinnerEnabled !== null) {
        popup.spinnerEnabled = dotNetPopup.spinnerEnabled;
    }
    
    if (dotNetPopup.visibleElements !== undefined && dotNetPopup.visibleElements !== null) {
        popup.visibleElements = dotNetPopup.visibleElements;
    }
    
    return popup;
}

function buildJsDockOptions(dotNetDockOptions: any) : PopupDockOptions {
    let dockOptions: PopupDockOptions = {};
    
    if (dotNetDockOptions.buttonEnabled !== undefined && dotNetDockOptions.buttonEnabled !== null) {
        dockOptions.buttonEnabled = dotNetDockOptions.buttonEnabled;
    }
    
    if (dotNetDockOptions.position !== undefined && dotNetDockOptions.position !== null) {
        dockOptions.position = dotNetDockOptions.position;
    }
    
    if (dotNetDockOptions.breakPoint !== undefined && dotNetDockOptions.breakPoint !== null) {
        dockOptions.breakpoint = dotNetDockOptions.breakPoint;
    }
    
    return dockOptions as PopupDockOptions;
}

export async function buildJsPopupOptions(dotNetPopupOptions: any) : Promise<PopupOpenOptions> {
    let options: PopupOpenOptions = {};
    
    if (dotNetPopupOptions.title !== undefined && dotNetPopupOptions.title !== null) {
        options.title = dotNetPopupOptions.title;
    }
    
    if (dotNetPopupOptions.stringContent !== undefined && dotNetPopupOptions.stringContent !== null) {
        options.content = dotNetPopupOptions.stringContent;
    }
    
    if (dotNetPopupOptions.location !== undefined && dotNetPopupOptions.location !== null) {
        options.location = buildJsPoint(dotNetPopupOptions.location) as Point;
    }
    
    if (dotNetPopupOptions.fetchFeatures !== undefined && dotNetPopupOptions.fetchFeatures !== null) {
        options.fetchFeatures = dotNetPopupOptions.fetchFeatures;
    }
    
    if (dotNetPopupOptions.features !== undefined && dotNetPopupOptions.features !== null) {
        let features: Graphic[] = [];
        for (const f of dotNetPopupOptions.features) {
            features.push(await buildJsGraphic(f) as Graphic);
        }
        options.features = features;
    }
    
    if (dotNetPopupOptions.featureMenuOpen !== undefined && dotNetPopupOptions.featureMenuOpen !== null) {
        options.featureMenuOpen = dotNetPopupOptions.featureMenuOpen;
    }
    
    if (dotNetPopupOptions.updateLocationEnabled !== undefined && dotNetPopupOptions.updateLocationEnabled !== null) {
        options.updateLocationEnabled = dotNetPopupOptions.updateLocationEnabled;
    }
    
    if (dotNetPopupOptions.collapsed !== undefined && dotNetPopupOptions.collapsed !== null) {
        options.collapsed = dotNetPopupOptions.collapsed;
    }
    
    if (dotNetPopupOptions.shouldFocus !== undefined && dotNetPopupOptions.shouldFocus !== null) {
        options.shouldFocus = dotNetPopupOptions.shouldFocus;
    }
    
    return options;
}

function buildJsFont(dotNetFont: any) : Font {
    let font = new Font();
    font.size = dotNetFont.size;
    font.family = dotNetFont.family;
    font.style = dotNetFont.style;
    font.weight = dotNetFont.weight;
    
    return font;
}

export function buildJsQuery(dotNetQuery: DotNetQuery): Query {
    let query: any = {};
    
    if (dotNetQuery.where !== undefined && dotNetQuery.where !== null) {
        query.where = dotNetQuery.where;
    }
    
    if (dotNetQuery.geometry !== undefined && dotNetQuery.geometry !== null) {
        query.geometry = buildJsGeometry(dotNetQuery.geometry) as Geometry;
    }
    
    if (dotNetQuery.spatialRelationship !== undefined && dotNetQuery.spatialRelationship !== null) {
        query.spatialRelationship = dotNetQuery.spatialRelationship as any;
    }
    
    if (dotNetQuery.distance !== undefined && dotNetQuery.distance !== null) {
        query.distance = dotNetQuery.distance;
    }
    
    if (dotNetQuery.units !== undefined && dotNetQuery.units !== null) {
        query.units = dotNetQuery.units as any;
    }
    
    if (dotNetQuery.returnGeometry !== undefined && dotNetQuery.returnGeometry !== null) {
        query.returnGeometry = dotNetQuery.returnGeometry;
    }
    
    if (dotNetQuery.outFields !== undefined && dotNetQuery.outFields !== null) {
        query.outFields = dotNetQuery.outFields;
    }
    
    if (dotNetQuery.orderByFields !== undefined && dotNetQuery.orderByFields !== null) {
        query.orderByFields = dotNetQuery.orderByFields;
    }
    
    if (dotNetQuery.groupByFieldsForStatistics !== undefined && dotNetQuery.groupByFieldsForStatistics !== null) {
        query.groupByFieldsForStatistics = dotNetQuery.groupByFieldsForStatistics;
    }
    
    if (dotNetQuery.outStatistics !== undefined && dotNetQuery.outStatistics !== null) {
        query.outStatistics = dotNetQuery.outStatistics;
    }
    
    if (dotNetQuery.returnDistinctValues !== undefined && dotNetQuery.returnDistinctValues !== null) {
        query.returnDistinctValues = dotNetQuery.returnDistinctValues;
    }
    
    if (dotNetQuery.returnZ !== undefined && dotNetQuery.returnZ !== null) {
        query.returnZ = dotNetQuery.returnZ;
    }
    
    if (dotNetQuery.returnExceededLimitFeatures !== undefined && dotNetQuery.returnExceededLimitFeatures !== null) {
        query.returnExceededLimitFeatures = dotNetQuery.returnExceededLimitFeatures;
    }
    
    if (dotNetQuery.num !== undefined && dotNetQuery.num !== null) {
        query.num = dotNetQuery.num;
    }
    
    if (dotNetQuery.objectIds !== undefined && dotNetQuery.objectIds !== null) {
        query.objectIds = dotNetQuery.objectIds;
    }
    
    if (dotNetQuery.timeExtent !== undefined && dotNetQuery.timeExtent !== null) {
        query.timeExtent = dotNetQuery.timeExtent;
    }
    
    if (dotNetQuery.maxAllowableOffset !== undefined && dotNetQuery.maxAllowableOffset !== null) {
        query.maxAllowableOffset = dotNetQuery.maxAllowableOffset;
    }
    
    if (dotNetQuery.geometryPrecision !== undefined && dotNetQuery.geometryPrecision !== null) {
        query.geometryPrecision = dotNetQuery.geometryPrecision;
    }
    
    if (dotNetQuery.aggregateIds !== undefined && dotNetQuery.aggregateIds !== null) {
        query.aggregateIds = dotNetQuery.aggregateIds;
    }
    
    if (dotNetQuery.cacheHint !== undefined && dotNetQuery.cacheHint !== null) {
        query.cacheHint = dotNetQuery.cacheHint;
    }
    
    if (dotNetQuery.datumTransformation !== undefined && dotNetQuery.datumTransformation !== null) {
        query.datumTransformation = dotNetQuery.datumTransformation;
    }
    
    if (dotNetQuery.gdbVersion !== undefined && dotNetQuery.gdbVersion !== null) {
        query.gdbVersion = dotNetQuery.gdbVersion;
    }
    
    if (dotNetQuery.having !== undefined && dotNetQuery.having !== null) {
        query.having = dotNetQuery.having;
    }
    
    if (dotNetQuery.historicMoment !== undefined && dotNetQuery.historicMoment !== null) {
        query.historicMoment = dotNetQuery.historicMoment;
    }
    
    if (dotNetQuery.maxRecordCountFactor !== undefined && dotNetQuery.maxRecordCountFactor !== null) {
        query.maxRecordCountFactor = dotNetQuery.maxRecordCountFactor;
    }
    
    if (dotNetQuery.outSpatialReference !== undefined && dotNetQuery.outSpatialReference !== null) {
        query.outSpatialReference = buildJsSpatialReference(dotNetQuery.outSpatialReference);
    }
    
    if (dotNetQuery.text !== undefined && dotNetQuery.text !== null) {
        query.text = dotNetQuery.text;
    }
    
    if (dotNetQuery.parameterValues !== undefined && dotNetQuery.parameterValues !== null) {
        query.parameterValues = dotNetQuery.parameterValues;
    }
    
    if (dotNetQuery.quantizationParameters !== undefined && dotNetQuery.quantizationParameters !== null) {
        query.quantizationParameters = dotNetQuery.quantizationParameters;
    }
    
    if (dotNetQuery.rangeValues !== undefined && dotNetQuery.rangeValues !== null) {
        query.rangeValues = dotNetQuery.rangeValues;
    }
    
    if (dotNetQuery.relationParameter !== undefined && dotNetQuery.relationParameter !== null) {
        query.relationParameter = dotNetQuery.relationParameter;
    }
    
    if (dotNetQuery.returnCentroid !== undefined && dotNetQuery.returnCentroid !== null) {
        query.returnCentroid = dotNetQuery.returnCentroid;
    }
    
    if (dotNetQuery.returnM !== undefined && dotNetQuery.returnM !== null) {
        query.returnM = dotNetQuery.returnM;
    }
    
    if (dotNetQuery.returnQueryGeometry !== undefined && dotNetQuery.returnQueryGeometry !== null) {
        query.returnQueryGeometry = dotNetQuery.returnQueryGeometry;
    }
    
    if (dotNetQuery.sqlFormat !== undefined && dotNetQuery.sqlFormat !== null) {
        query.sqlFormat = dotNetQuery.sqlFormat as any;
    }
    
    if (dotNetQuery.start !== undefined && dotNetQuery.start !== null) {
        query.start = dotNetQuery.start;
    }
    
    return query as Query;
}

export function buildJsRelationshipQuery(dotNetRelationshipQuery: DotNetRelationshipQuery): RelationshipQuery
{
    // copy all values from the dotnet object to the js object
    let relationshipQuery = new RelationshipQuery();
    
    if (dotNetRelationshipQuery.cacheHint !== undefined && dotNetRelationshipQuery.cacheHint !== null) {
        relationshipQuery.cacheHint = dotNetRelationshipQuery.cacheHint;
    }
    
    if (dotNetRelationshipQuery.gdbVersion !== undefined && dotNetRelationshipQuery.gdbVersion !== null) {
        relationshipQuery.gdbVersion = dotNetRelationshipQuery.gdbVersion;
    }
    
    if (dotNetRelationshipQuery.geometryPrecision !== undefined && dotNetRelationshipQuery.geometryPrecision !== null) {
        relationshipQuery.geometryPrecision = dotNetRelationshipQuery.geometryPrecision;
    }

    if (dotNetRelationshipQuery.historicMoment !== undefined && dotNetRelationshipQuery.historicMoment !== null) {
        relationshipQuery.historicMoment = dotNetRelationshipQuery.historicMoment;
    }
    
    if (dotNetRelationshipQuery.maxAllowableOffset !== undefined && dotNetRelationshipQuery.maxAllowableOffset !== null) {
        relationshipQuery.maxAllowableOffset = dotNetRelationshipQuery.maxAllowableOffset;
    }
    
    if (dotNetRelationshipQuery.num !== undefined && dotNetRelationshipQuery.num !== null) {
        relationshipQuery.num = dotNetRelationshipQuery.num;
    }
    
    if (dotNetRelationshipQuery.objectIds !== undefined && dotNetRelationshipQuery.objectIds !== null) {
        relationshipQuery.objectIds = dotNetRelationshipQuery.objectIds;
    }
    
    if (dotNetRelationshipQuery.orderByFields !== undefined && dotNetRelationshipQuery.orderByFields !== null) {
        relationshipQuery.orderByFields = dotNetRelationshipQuery.orderByFields;
    }
    
    if (dotNetRelationshipQuery.outFields !== undefined && dotNetRelationshipQuery.outFields !== null) {
        relationshipQuery.outFields = dotNetRelationshipQuery.outFields;
    }
    
    if (dotNetRelationshipQuery.outSpatialReference !== undefined && dotNetRelationshipQuery.outSpatialReference !== null) {
        relationshipQuery.outSpatialReference = buildJsSpatialReference(dotNetRelationshipQuery.outSpatialReference);
    }   
    
    if (dotNetRelationshipQuery.returnGeometry !== undefined && dotNetRelationshipQuery.returnGeometry !== null) {
        relationshipQuery.returnGeometry = dotNetRelationshipQuery.returnGeometry;
    }
    
    if (dotNetRelationshipQuery.returnM !== undefined && dotNetRelationshipQuery.returnM !== null) {
        relationshipQuery.returnM = dotNetRelationshipQuery.returnM;
    }
    
    if (dotNetRelationshipQuery.returnZ !== undefined && dotNetRelationshipQuery.returnZ !== null) {
        relationshipQuery.returnZ = dotNetRelationshipQuery.returnZ;
    }
    
    if (dotNetRelationshipQuery.start !== undefined && dotNetRelationshipQuery.start !== null) {
        relationshipQuery.start = dotNetRelationshipQuery.start;
    }
    
    if (dotNetRelationshipQuery.where !== undefined && dotNetRelationshipQuery.where !== null) {
        relationshipQuery.where = dotNetRelationshipQuery.where;
    }
    
    return relationshipQuery as RelationshipQuery;
}

export function buildJsTopFeaturesQuery(dnQuery: DotNetTopFeaturesQuery): TopFeaturesQuery {
    let query = new TopFeaturesQuery();
    if (dnQuery.cacheHint !== undefined && dnQuery.cacheHint !== null) {
        query.cacheHint = dnQuery.cacheHint;
    }
    
    if (dnQuery.distance !== undefined && dnQuery.distance !== null) {
        query.distance = dnQuery.distance;
    }
    
    if (dnQuery.geometry !== undefined && dnQuery.geometry !== null) {
        query.geometry = buildJsGeometry(dnQuery.geometry) as Geometry;
    }
    
    if (dnQuery.geometryPrecision !== undefined && dnQuery.geometryPrecision !== null) {
        query.geometryPrecision = dnQuery.geometryPrecision;
    }
    
    if (dnQuery.maxAllowableOffset !== undefined && dnQuery.maxAllowableOffset !== null) {
        query.maxAllowableOffset = dnQuery.maxAllowableOffset;
    }
    
    if (dnQuery.num !== undefined && dnQuery.num !== null) {
        query.num = dnQuery.num;
    }
    
    if (dnQuery.objectIds !== undefined && dnQuery.objectIds !== null) {
        query.objectIds = dnQuery.objectIds;
    }
    
    if (dnQuery.orderByFields !== undefined && dnQuery.orderByFields !== null) {
        query.orderByFields = dnQuery.orderByFields;
    }
    
    if (dnQuery.outFields !== undefined && dnQuery.outFields !== null) {
        query.outFields = dnQuery.outFields;
    }
    
    if (dnQuery.outSpatialReference !== undefined && dnQuery.outSpatialReference !== null) {
        query.outSpatialReference = buildJsSpatialReference(dnQuery.outSpatialReference);
    }
    
    if (dnQuery.returnGeometry !== undefined && dnQuery.returnGeometry !== null) {
        query.returnGeometry = dnQuery.returnGeometry;
    }
    
    if (dnQuery.returnM !== undefined && dnQuery.returnM !== null) {
        query.returnM = dnQuery.returnM;
    }
    
    if (dnQuery.returnZ !== undefined && dnQuery.returnZ !== null) {
        query.returnZ = dnQuery.returnZ;
    }
    
    if (dnQuery.spatialRelationship !== undefined && dnQuery.spatialRelationship !== null) {
        query.spatialRelationship = dnQuery.spatialRelationship as any;
    }
    
    if (dnQuery.start !== undefined && dnQuery.start !== null) {
        query.start = dnQuery.start;
    }
    
    if (dnQuery.timeExtent !== undefined && dnQuery.timeExtent !== null) {
        query.timeExtent = dnQuery.timeExtent;
    }
    
    if (dnQuery.topFilter !== undefined && dnQuery.topFilter !== null) {
        query.topFilter = dnQuery.topFilter;
    }
    
    if (dnQuery.units !== undefined && dnQuery.units !== null) {
        query.units = dnQuery.units as any;
    }
    
    if (dnQuery.where !== undefined && dnQuery.where !== null) {
        query.where = dnQuery.where;
    }
    
    return query as TopFeaturesQuery;
}

export function buildJsMediaInfo(dotNetMediaInfo: DotNetMediaInfo): any {
    switch (dotNetMediaInfo?.type){
        case "bar-chart":
            let dotNetBarChartMediaInfo = dotNetMediaInfo as DotNetBarChartMediaInfo;
            return {
                type: "bar-chart",
                altText: dotNetBarChartMediaInfo.altText ?? undefined,
                caption: dotNetBarChartMediaInfo.caption ?? undefined,
                value: buildJsChartMediaInfoValue(dotNetBarChartMediaInfo.value)
            } as BarChartMediaInfo;
        case "column-chart":
            let dotNetColumnChartMediaInfo = dotNetMediaInfo as DotNetColumnChartMediaInfo;
            return {
                type: "column-chart",
                altText: dotNetColumnChartMediaInfo.altText ?? undefined,
                caption: dotNetColumnChartMediaInfo.caption ?? undefined,
                title: dotNetColumnChartMediaInfo.title ?? undefined,
                value: buildJsChartMediaInfoValue(dotNetColumnChartMediaInfo.value)
            } as ColumnChartMediaInfo;
        case "image":
            let dotNetImageMediaInfo = dotNetMediaInfo as DotNetImageMediaInfo;
            return {
                type: "image",
                altText: dotNetImageMediaInfo.altText ?? undefined,
                caption: dotNetImageMediaInfo.caption ?? undefined,
                title: dotNetImageMediaInfo.title ?? undefined,
                refreshInterval: dotNetImageMediaInfo.refreshInterval ?? undefined,
                value: buildJsImageMediaInfoValue(dotNetImageMediaInfo.value)
            } as ImageMediaInfo;
        case "line-chart":
            let dotNetLineChartMediaInfo = dotNetMediaInfo as DotNetLineChartMediaInfo;
            return {
                type: "line-chart",
                altText: dotNetLineChartMediaInfo.altText ?? undefined,
                caption: dotNetLineChartMediaInfo.caption ?? undefined,
                title: dotNetLineChartMediaInfo.title ?? undefined,
                value: buildJsChartMediaInfoValue(dotNetLineChartMediaInfo.value)
            } as LineChartMediaInfo;
        case "pie-chart":
            let dotNetPieChartMediaInfo = dotNetMediaInfo as DotNetPieChartMediaInfo;
            return {
                type: "pie-chart",
                altText: dotNetPieChartMediaInfo.altText ?? undefined,
                caption: dotNetPieChartMediaInfo.caption ?? undefined,
                title: dotNetPieChartMediaInfo.title ?? undefined,
                value: buildJsChartMediaInfoValue(dotNetPieChartMediaInfo.value)
            } as PieChartMediaInfo;
    }
}

export function buildJsChartMediaInfoValue(dotNetChartMediaInfoValue: DotNetChartMediaInfoValue): ChartMediaInfoValue {
    let value = {} as ChartMediaInfoValue;
    if (dotNetChartMediaInfoValue.fields !== undefined && dotNetChartMediaInfoValue.fields !== null) {
        value.fields = dotNetChartMediaInfoValue.fields;
    }
    if (dotNetChartMediaInfoValue.normalizeField !== undefined && dotNetChartMediaInfoValue.normalizeField !== null) {
        value.normalizeField = dotNetChartMediaInfoValue.normalizeField;
    }
    if (dotNetChartMediaInfoValue.tooltipField !== undefined && dotNetChartMediaInfoValue.tooltipField !== null) {
        value.tooltipField = dotNetChartMediaInfoValue.tooltipField;
    }
    if (dotNetChartMediaInfoValue.series !== undefined && dotNetChartMediaInfoValue.series !== null) {
        value.series = dotNetChartMediaInfoValue.series.map(s => {
            let series = new ChartMediaInfoValueSeries({
                tooltip: s.tooltip ?? undefined,
                value: s.value ?? undefined,
                fieldName: s.fieldName ?? undefined
            });
            return series;
        });
    }
    return value;
}

export function buildJsImageMediaInfoValue(dotNetImageMediaInfoValue: DotNetImageMediaInfoValue): ImageMediaInfoValue {
    return {
        sourceURL: dotNetImageMediaInfoValue.sourceURL ?? undefined,
        linkURL: dotNetImageMediaInfoValue.linkURL ?? undefined
    } as ImageMediaInfoValue;
}

export function buildJsElementExpressionInfo(dotNetExpressionInfo: DotNetElementExpressionInfo): ElementExpressionInfo {
    let info = {} as ElementExpressionInfo;
    if (dotNetExpressionInfo.expression !== undefined && dotNetExpressionInfo.expression !== null) {
        info.expression = dotNetExpressionInfo.expression;
    }
    if (dotNetExpressionInfo.returnType !== undefined && dotNetExpressionInfo.returnType !== null) {
        info.returnType = dotNetExpressionInfo.returnType as any;
    }
    if (dotNetExpressionInfo.title !== undefined && dotNetExpressionInfo.title !== null) {
        info.title = dotNetExpressionInfo.title;
    }
    return info;
}