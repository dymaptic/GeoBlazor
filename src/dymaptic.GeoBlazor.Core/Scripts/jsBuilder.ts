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
    DotNetMediaPopupContent, DotNetPieChartMediaInfo,
    DotNetPoint,
    DotNetPolygon,
    DotNetPolyline,
    DotNetPopupContent,
    DotNetPopupTemplate,
    DotNetQuery,
    DotNetSpatialReference,
    DotNetTextPopupContent
} from "./definitions";
import ViewClickEvent = __esri.ViewClickEvent;
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
import popupExpressionInfoProperties = __esri.popupExpressionInfoProperties;
import Layer from "@arcgis/core/layers/Layer";

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
    const graphic = new Graphic({
        geometry: buildJsGeometry(graphicObject.geometry) as Geometry,
        symbol: graphicObject.symbol,
        attributes: graphicObject.attributes
    });

    if (graphicObject.popupTemplate !== undefined && graphicObject.popupTemplate !== null) {
        graphic.popupTemplate = buildJsPopupTemplate(graphicObject.popupTemplate);
    }
    
    if (graphicObject.layerId !== undefined && graphicObject.layerId !== null) {
        let layer = arcGisObjectRefs[graphicObject.layerId] as Layer;
        graphic.layer = layer;
    }

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
    return new PopupTemplate({
        title: popupTemplateObject.title,
        content: content,
        outFields: popupTemplateObject.outFields,
        overwriteActions: popupTemplateObject.overwriteActions,
        returnGeometry: popupTemplateObject.returnGeometry,
        fieldInfos: popupTemplateObject.fieldInfos?.map(f => buildJsFieldInfo(f)),
        expressionInfos: popupTemplateObject.expressionInfos?.map(e => buildJsExpressionInfo(e)),
    });
}

export function buildJsPopupContent(popupContentObject: DotNetPopupContent): ContentProperties | null {
    switch (popupContentObject?.type) {
        case "fields":
            let dnFieldsContent = popupContentObject as DotNetFieldsPopupContent;
            return new FieldsContent({
                fieldInfos: dnFieldsContent.fieldInfos?.map(f => buildJsFieldInfo(f)),
                description: dnFieldsContent.description,
                title: dnFieldsContent.title
            });
        case "text":
            return new TextContent({
                text: (popupContentObject as DotNetTextPopupContent).text
            });
        case "media":
            return new MediaContent({
                mediaInfos: (popupContentObject as DotNetMediaPopupContent).mediaInfos?.map(m => buildJsMediaInfo(m))
            });
        case "attachments":
            let dnAttachmentsContent = popupContentObject as DotNetAttachmentsPopupContent;
            return new AttachmentsContent({
                description: dnAttachmentsContent.description,
                title: dnAttachmentsContent.title,
                displayType: dnAttachmentsContent.displayType as any
            });
        case "expression":
            let dnExpressionContent = popupContentObject as DotNetExpressionPopupContent;
            return new ExpressionContent({
                expressionInfo: buildJsElementExpressionInfo(dnExpressionContent.expressionInfo)
            });
    }
    return null;
}

export function buildJsFieldInfo(fieldInfoObject: DotNetFieldInfo): FieldInfo {
    let fieldInfo = new FieldInfo({
        fieldName: fieldInfoObject.fieldName,
        label: fieldInfoObject.label,
        tooltip: fieldInfoObject.tooltip,
        stringFieldOption: fieldInfoObject.stringFieldOption as any,
        visible: fieldInfoObject.visible,
        isEditable: fieldInfoObject.isEditable
    });
    if (fieldInfoObject.format !== undefined && fieldInfoObject.format !== null) {
        fieldInfo.format = buildJsFieldInfoFormat(fieldInfoObject.format);
    }
    
    return fieldInfo;
}

export function buildJsFieldInfoFormat(formatObject: DotNetFieldInfoFormat): FieldInfoFormat {
    return new FieldInfoFormat({
        dateFormat: formatObject.dateFormat as any,
        places: formatObject.places,
        digitSeparator: formatObject.digitSeparator
    });
}

export function buildJsExpressionInfo(expressionInfoObject: DotNetExpressionInfo): popupExpressionInfoProperties {
    return {
        name: expressionInfoObject.name,
        title: expressionInfoObject.title,
        expression: expressionInfoObject.expression,
        returnType: expressionInfoObject.returnType as any
    };
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

export function buildJsViewClickEvent(dotNetClickEvent: any): ViewClickEvent {
    return {
        type: dotNetClickEvent.type,
        mapPoint: buildJsPoint(dotNetClickEvent.mapPoint) as Point,
        x: dotNetClickEvent.x,
        y: dotNetClickEvent.y,
        button: dotNetClickEvent.button,
        buttons: dotNetClickEvent.buttons,
        timestamp: dotNetClickEvent.timestamp
    } as ViewClickEvent
}

export function buildJsPopup(dotNetPopup: any) : Popup {
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
        popup.features = dotNetPopup.features.forEach(f => buildJsGraphic(f));
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

export function buildJsPopupOptions(dotNetPopupOptions: any) : PopupOpenOptions {
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
        options.features = dotNetPopupOptions.features.map(f => buildJsGraphic(f));
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

export function buildJsMediaInfo(dotNetMediaInfo: DotNetMediaInfo): any {
    switch (dotNetMediaInfo?.type){
        case "bar-chart":
            let dotNetBarChartMediaInfo = dotNetMediaInfo as DotNetBarChartMediaInfo;
            return {
                type: "bar-chart",
                altText: dotNetBarChartMediaInfo.altText,
                caption: dotNetBarChartMediaInfo.caption,
                value: buildJsChartMediaInfoValue(dotNetBarChartMediaInfo.value)
            } as BarChartMediaInfo;
        case "column-chart":
            let dotNetColumnChartMediaInfo = dotNetMediaInfo as DotNetColumnChartMediaInfo;
            return {
                type: "column-chart",
                altText: dotNetColumnChartMediaInfo.altText,
                caption: dotNetColumnChartMediaInfo.caption,
                title: dotNetColumnChartMediaInfo.title,
                value: buildJsChartMediaInfoValue(dotNetColumnChartMediaInfo.value)
            } as ColumnChartMediaInfo;
        case "image":
            let dotNetImageMediaInfo = dotNetMediaInfo as DotNetImageMediaInfo;
            return {
                type: "image",
                altText: dotNetImageMediaInfo.altText,
                caption: dotNetImageMediaInfo.caption,
                title: dotNetImageMediaInfo.title,
                refreshInterval: dotNetImageMediaInfo.refreshInterval,
                value: buildJsImageMediaInfoValue(dotNetImageMediaInfo.value)
            } as ImageMediaInfo;
        case "line-chart":
            let dotNetLineChartMediaInfo = dotNetMediaInfo as DotNetLineChartMediaInfo;
            return {
                type: "line-chart",
                altText: dotNetLineChartMediaInfo.altText,
                caption: dotNetLineChartMediaInfo.caption,
                title: dotNetLineChartMediaInfo.title,
                value: buildJsChartMediaInfoValue(dotNetLineChartMediaInfo.value)
            } as LineChartMediaInfo;
        case "pie-chart":
            let dotNetPieChartMediaInfo = dotNetMediaInfo as DotNetPieChartMediaInfo;
            return {
                type: "pie-chart",
                altText: dotNetPieChartMediaInfo.altText,
                caption: dotNetPieChartMediaInfo.caption,
                title: dotNetPieChartMediaInfo.title,
                value: buildJsChartMediaInfoValue(dotNetPieChartMediaInfo.value)
            } as PieChartMediaInfo;
    }
}

export function buildJsChartMediaInfoValue(dotNetChartMediaInfoValue: DotNetChartMediaInfoValue): ChartMediaInfoValue {
    return {
        fields: dotNetChartMediaInfoValue.fields,
        normalizeField: dotNetChartMediaInfoValue.normalizeField,
        tooltipField: dotNetChartMediaInfoValue.tooltipField,
        series: dotNetChartMediaInfoValue.series,
    } as ChartMediaInfoValue;
}

export function buildJsImageMediaInfoValue(dotNetImageMediaInfoValue: DotNetImageMediaInfoValue): ImageMediaInfoValue {
    return {
        sourceURL: dotNetImageMediaInfoValue.sourceURL,
        linkURL: dotNetImageMediaInfoValue.linkURL
    } as ImageMediaInfoValue;
}

export function buildJsElementExpressionInfo(dotNetExpressionInfo: DotNetElementExpressionInfo): ElementExpressionInfoProperties {
    return {
        expression: dotNetExpressionInfo.expression,
        returnType: dotNetExpressionInfo.returnType as any,
        title: dotNetExpressionInfo.title
    } as ElementExpressionInfoProperties;
}