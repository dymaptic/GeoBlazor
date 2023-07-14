import SpatialReference from "@arcgis/core/geometry/SpatialReference";
import Extent from "@arcgis/core/geometry/Extent";
import Graphic from "@arcgis/core/Graphic";
import PopupTemplate from "@arcgis/core/PopupTemplate";
import {arcGisObjectRefs, triggerActionHandler} from "./arcGisJsInterop";
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
    DotNetApplyEdits,
    DotNetAttachmentsEdit,
    DotNetAttachmentsPopupContent,
    DotNetBarChartMediaInfo,
    DotNetChartMediaInfoValue,
    DotNetColumnChartMediaInfo,
    DotNetElementExpressionInfo,
    DotNetExpressionInfo,
    DotNetExpressionPopupContent,
    DotNetExtent,
    DotNetFieldInfo,
    DotNetFieldInfoFormat,
    DotNetFieldsPopupContent,
    DotNetGeometry,
    DotNetImageMediaInfo,
    DotNetImageMediaInfoValue,
    DotNetLineChartMediaInfo,
    DotNetMediaInfo,
    DotNetMediaPopupContent,
    DotNetPictureMarkerSymbol,
    DotNetPieChartMediaInfo,
    DotNetPoint,
    DotNetPolygon,
    DotNetPolyline,
    DotNetPopupContent,
    DotNetPopupTemplate,
    DotNetQuery,
    DotNetRelationshipQuery,
    DotNetSimpleFillSymbol,
    DotNetSimpleLineSymbol,
    DotNetSimpleMarkerSymbol,
    DotNetSpatialReference,
    DotNetSymbol,
    DotNetTextPopupContent,
    DotNetTextSymbol,
    DotNetTopFeaturesQuery
} from "./definitions";
import PictureMarkerSymbol from "@arcgis/core/symbols/PictureMarkerSymbol";
import Popup from "@arcgis/core/widgets/Popup";
import Query from "@arcgis/core/rest/support/Query";
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
import Layer from "@arcgis/core/layers/Layer";
import RelationshipQuery from "@arcgis/core/rest/support/RelationshipQuery";
import TopFeaturesQuery from "@arcgis/core/rest/support/TopFeaturesQuery";
import popupExpressionInfo from "@arcgis/core/popup/ExpressionInfo";
import SimpleMarkerSymbol from "@arcgis/core/symbols/SimpleMarkerSymbol";
import Symbol from "@arcgis/core/symbols/Symbol";
import SimpleFillSymbol from "@arcgis/core/symbols/SimpleFillSymbol";
import SimpleLineSymbol from "@arcgis/core/symbols/SimpleLineSymbol";
import ElementExpressionInfo from "@arcgis/core/popup/ElementExpressionInfo";
import ChartMediaInfoValueSeries from "@arcgis/core/popup/content/support/ChartMediaInfoValueSeries";
import View from "@arcgis/core/views/View";
import {buildDotNetGraphic} from "./dotNetBuilder";
import ViewClickEvent = __esri.ViewClickEvent;
import PopupOpenOptions = __esri.PopupOpenOptions;
import PopupDockOptions = __esri.PopupDockOptions;
import ContentProperties = __esri.ContentProperties;
import PopupTriggerActionEvent = __esri.PopupTriggerActionEvent;
import FeatureLayerBaseApplyEditsEdits = __esri.FeatureLayerBaseApplyEditsEdits;
import AttachmentEdit = __esri.AttachmentEdit;
import FormTemplate from "@arcgis/core/form/FormTemplate";
import ElementProperties = __esri.ElementProperties;
import Element from "@arcgis/core/form/elements/Element";
import GroupElement from "@arcgis/core/form/elements/GroupElement";
import FieldElement from "@arcgis/core/form/elements/FieldElement";
import CodedValueDomain from "@arcgis/core/layers/support/CodedValueDomain";
import RangeDomain from "@arcgis/core/layers/support/RangeDomain";
import CodedValue = __esri.CodedValue;
import TextBoxInput from "@arcgis/core/form/elements/inputs/TextBoxInput";
import TextAreaInput from "@arcgis/core/form/elements/inputs/TextAreaInput";
import DateTimePickerInput from "@arcgis/core/form/elements/inputs/DateTimePickerInput";
import BarcodeScannerInput from "@arcgis/core/form/elements/inputs/BarcodeScannerInput";
import ComboBoxInput from "@arcgis/core/form/elements/inputs/ComboBoxInput";
import RadioButtonsInput from "@arcgis/core/form/elements/inputs/RadioButtonsInput";
import SwitchInput from "@arcgis/core/form/elements/inputs/SwitchInput";
import Domain from "@arcgis/core/layers/support/Domain";


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

export function buildJsExtent(dotNetExtent: DotNetExtent, currentSpatialReference: SpatialReference | null): Extent {
    let extent = new Extent();
    if (hasValue(dotNetExtent.xmax)) {
        extent.xmax = dotNetExtent.xmax;
    }
    if (hasValue(dotNetExtent.xmin)) {
        extent.xmin = dotNetExtent.xmin;
    }
    if (hasValue(dotNetExtent.ymax)) {
        extent.ymax = dotNetExtent.ymax;
    }
    if (hasValue(dotNetExtent.ymin)) {
        extent.ymin = dotNetExtent.ymin;
    }
    if (hasValue(dotNetExtent.zmax)) {
        extent.zmax = dotNetExtent.zmax;
    }
    if (hasValue(dotNetExtent.zmin)) {
        extent.zmin = dotNetExtent.zmin;
    }
    if (hasValue(dotNetExtent.mmax)) {
        extent.mmax = dotNetExtent.mmax;
    }
    if (hasValue(dotNetExtent.mmin)) {
        extent.mmin = dotNetExtent.mmin;
    }
    if (hasValue(dotNetExtent.spatialReference)) {
        extent.spatialReference = buildJsSpatialReference(dotNetExtent.spatialReference)
    } else if (currentSpatialReference !== null) {
        extent.spatialReference = currentSpatialReference;
    }

    return extent;
}

export function buildJsGraphic(graphicObject: any, viewId: string | null)
    : Graphic | null {
    const graphic = new Graphic({
        geometry: buildJsGeometry(graphicObject.geometry) as Geometry ?? null,
        symbol: buildJsSymbol(graphicObject.symbol) as Symbol ?? null,
    });

    graphic.attributes = buildJsAttributes(graphicObject.attributes);

    if (hasValue(graphicObject.popupTemplate)) {
        graphic.popupTemplate = buildJsPopupTemplate(graphicObject.popupTemplate, viewId);
    }

    return graphic;
}

export function buildJsAttributes(attributes: any): any {
    if (hasValue(attributes)) {
        if (attributes instanceof Array) {
            let graphicAttributes = {};
            attributes.forEach((attr: any) => {
                switch (attr.valueType.toLowerCase().replace('system.', '')) {
                    case "number":
                    case "int32":
                    case "int64":
                        graphicAttributes[attr.key] = Number(attr.value);
                        break;
                    case "boolean":
                        graphicAttributes[attr.key] = attr.value.toLowerCase() === "true";
                        break;
                    case "date":
                    case "datetime":
                    case "dateonly":
                        graphicAttributes[attr.key] = new Date(attr.value);
                        break;
                    case "object":
                        graphicAttributes[attr.key] = JSON.stringify(attr.value, null, 2);
                        break;
                    default:
                        graphicAttributes[attr.key] = attr.value;
                }
            });
            return graphicAttributes;
        } else {
            return attributes;
        }
    }
}

export function buildJsPopupTemplate(popupTemplateObject: DotNetPopupTemplate, viewId: string | null): PopupTemplate {
    let content;
    if (hasValue(popupTemplateObject.stringContent)) {
        content = popupTemplateObject.stringContent;
    } else if (hasValue(popupTemplateObject.content) && popupTemplateObject.content.length > 0) {
        content = popupTemplateObject.content?.map(c => buildJsPopupContent(c));
    } else {
        content = async (featureSelection) => {
            try {
                let results : DotNetPopupContent[] | null = await popupTemplateObject.dotNetPopupTemplateReference
                    .invokeMethodAsync("OnContentFunction", buildDotNetGraphic(featureSelection.graphic));
                return results?.map(r => buildJsPopupContent(r));
            } catch (error) {
                console.error(error);
                return null;
            }
        }
    }
    let template = new PopupTemplate({
        title: popupTemplateObject.title ?? undefined,
        content: content ?? undefined,
        outFields: popupTemplateObject.outFields ?? undefined,
        overwriteActions: popupTemplateObject.overwriteActions ?? false,
        returnGeometry: popupTemplateObject.returnGeometry ?? false
    });

    if (hasValue(popupTemplateObject.fieldInfos)) {
        template.fieldInfos = popupTemplateObject.fieldInfos.map(f => buildJsFieldInfo(f));
    }

    if (hasValue(popupTemplateObject.expressionInfos)) {
        template.expressionInfos = popupTemplateObject.expressionInfos.map(e => buildJsExpressionInfo(e));
    }

    if (hasValue(popupTemplateObject.actions)) {
        template.actions = popupTemplateObject.actions as any;
    }

    if (viewId !== null) {
        let view = arcGisObjectRefs[viewId] as View;
        if (hasValue(view)) {
            if (hasValue(triggerActionHandler)) {
                triggerActionHandler.remove();
            }
            if (hasValue(templateTriggerActionHandler)) {
                templateTriggerActionHandler.remove();
            }
            templateTriggerActionHandler = view.popup.on("trigger-action", async (event: PopupTriggerActionEvent) => {
                await popupTemplateObject.dotNetPopupTemplateReference.invokeMethodAsync("OnTriggerAction", event.action.id);
            });
        }
    }

    return template;
}

export let templateTriggerActionHandler: IHandle;

export function buildJsPopupContent(popupContentObject: DotNetPopupContent): ContentProperties | null {
    switch (popupContentObject?.type) {
        case "fields":
            let dnFieldsContent = popupContentObject as DotNetFieldsPopupContent;
            let fieldsContent = new FieldsContent({
                description: dnFieldsContent.description ?? '',
                title: dnFieldsContent.title ?? ''
            });
            if (dnFieldsContent.fieldInfos !== undefined && dnFieldsContent.fieldInfos !== null &&
                dnFieldsContent.fieldInfos.length > 0) {
                fieldsContent.fieldInfos = dnFieldsContent.fieldInfos.map(f => buildJsFieldInfo(f));
            }

            return fieldsContent;
        case "text":
            let dnTextContent = popupContentObject as DotNetTextPopupContent;
            let textContent = new TextContent({
                text: dnTextContent.text ?? null
            });

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
            let attachmentsContent = new AttachmentsContent({
                description: dnAttachmentsContent.description ?? '',
                title: dnAttachmentsContent.title ?? '',
                displayType: dnAttachmentsContent.displayType as any ?? "auto",
            });
            return attachmentsContent;
        case "expression":
            let dnExpressionContent = popupContentObject as DotNetExpressionPopupContent;
            let expressionContent = new ExpressionContent();
            if (hasValue(dnExpressionContent.expressionInfo)) {
                expressionContent.expressionInfo = buildJsElementExpressionInfo(dnExpressionContent.expressionInfo);
            }
            return expressionContent;
    }
    return null;
}

export function buildJsFieldInfo(fieldInfoObject: DotNetFieldInfo): FieldInfo {
    let fieldInfo = new FieldInfo({
        fieldName: fieldInfoObject.fieldName ?? '',
        label: fieldInfoObject.label ?? '',
        tooltip: fieldInfoObject.tooltip ?? '',
        stringFieldOption: fieldInfoObject.stringFieldOption as any ?? "text-box",
        visible: fieldInfoObject.visible ?? true,
        isEditable: fieldInfoObject.isEditable ?? false
    });

    if (hasValue(fieldInfoObject.format)) {
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
        expression: expressionInfoObject.expression ?? undefined
    } as popupExpressionInfo;
}

export function buildJsSymbol(symbol: DotNetSymbol | null): Symbol | null {
    if (symbol === null || symbol === undefined) {
        return null;
    }
    switch (symbol.type) {
        case "simple-marker":
            let dnSimpleMarkerSymbol = symbol as DotNetSimpleMarkerSymbol;
            let jsSimpleMarkerSymbol = new SimpleMarkerSymbol({
                color: buildJsColor(dnSimpleMarkerSymbol.color) ?? [255, 255, 255, 0.25],
                path: dnSimpleMarkerSymbol.path ?? undefined,
                size: dnSimpleMarkerSymbol.size ?? 12,
                style: dnSimpleMarkerSymbol.style as any ?? "circle",
                xoffset: dnSimpleMarkerSymbol.xOffset ?? 0,
                yoffset: dnSimpleMarkerSymbol.yOffset ?? 0
            });

            if (hasValue(dnSimpleMarkerSymbol.outline)) {
                jsSimpleMarkerSymbol.outline = buildJsSymbol(dnSimpleMarkerSymbol.outline) as any;
            }
            return jsSimpleMarkerSymbol;
        case "simple-line":
            let dnSimpleLineSymbol = symbol as DotNetSimpleLineSymbol;
            let jsSimpleLineSymbol = new SimpleLineSymbol({
                color: buildJsColor(dnSimpleLineSymbol.color) ?? "black",
                cap: dnSimpleLineSymbol.cap as any ?? "round",
                join: dnSimpleLineSymbol.join as any ?? "round",
                marker: dnSimpleLineSymbol.marker as any ?? null,
                miterLimit: dnSimpleLineSymbol.miterLimit ?? 2,
                style: dnSimpleLineSymbol.style as any ?? "solid",
                width: dnSimpleLineSymbol.width ?? 0.75
            });

            return jsSimpleLineSymbol;
        case "picture-marker":
            let dnPictureMarkerSymbol = symbol as DotNetPictureMarkerSymbol;
            let jsPictureMarkerSymbol = new PictureMarkerSymbol({
                angle: dnPictureMarkerSymbol.angle ?? 0,
                xoffset: dnPictureMarkerSymbol.xOffset ?? 0,
                yoffset: dnPictureMarkerSymbol.yOffset ?? 0,
                height: dnPictureMarkerSymbol.height ?? 12,
                width: dnPictureMarkerSymbol.width ?? 12,
                url: dnPictureMarkerSymbol.url
            });

            return jsPictureMarkerSymbol;

        case "simple-fill":
            let dnSimpleFillSymbol = symbol as DotNetSimpleFillSymbol;
            let jsSimpleFillSymbol = new SimpleFillSymbol({
                color: buildJsColor(dnSimpleFillSymbol.color) ?? [0, 0, 0, 0.25],
                style: dnSimpleFillSymbol.style as any ?? "solid"
            });

            if (hasValue(dnSimpleFillSymbol.outline)) {
                jsSimpleFillSymbol.outline = buildJsSymbol(dnSimpleFillSymbol.outline) as any;
            }
            return jsSimpleFillSymbol;
        case "text":
            let dotNetTextSymbol = symbol as DotNetTextSymbol;
            let jsTextSymbol = new TextSymbol({
                color: buildJsColor(dotNetTextSymbol.color) ?? "black",
                haloColor: buildJsColor(dotNetTextSymbol.haloColor) ?? undefined,
                haloSize: dotNetTextSymbol.haloSize ?? undefined,
                text: dotNetTextSymbol.text ?? undefined
            });
            if (hasValue(dotNetTextSymbol.font)) {
                jsTextSymbol.font = buildJsFont(dotNetTextSymbol.font);
            }

            return jsTextSymbol;
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
            return buildJsExtent(geometry as DotNetExtent, null);
    }

    return geometry as any;
}

export function buildJsPoint(dnPoint: DotNetPoint): Point | null {
    if (dnPoint === undefined || dnPoint === null) return null;
    let point = new Point({
        latitude: dnPoint.latitude ?? undefined,
        longitude: dnPoint.longitude ?? undefined,
        x: dnPoint.x ?? undefined,
        y: dnPoint.y ?? undefined
    });

    if (hasValue(dnPoint.spatialReference)) {
        point.spatialReference = buildJsSpatialReference(dnPoint.spatialReference);
    } else {
        point.spatialReference = new SpatialReference({wkid: 4326});
    }

    return point;
}

export function buildJsPolyline(dnPolyline: DotNetPolyline): Polyline | null {
    if (dnPolyline === undefined || dnPolyline === null) return null;
    let polyline = new Polyline({
        paths: buildJsPathsOrRings(dnPolyline.paths) ?? undefined
    });
    if (hasValue(dnPolyline.spatialReference)) {
        polyline.spatialReference = buildJsSpatialReference(dnPolyline.spatialReference);
    } else {
        polyline.spatialReference = new SpatialReference({wkid: 4326});
    }
    return polyline;
}

export function buildJsPolygon(dnPolygon: DotNetPolygon): Polygon | null {
    if (dnPolygon === undefined || dnPolygon === null) return null;
    let polygon = new Polygon({
        rings: buildJsPathsOrRings(dnPolygon.rings) ?? undefined
    });
    if (hasValue(dnPolygon.spatialReference)) {
        polygon.spatialReference = buildJsSpatialReference(dnPolygon.spatialReference);
    } else {
        polygon.spatialReference = new SpatialReference({wkid: 4326});
    }
    return polygon;
}


export function buildJsRenderer(dotNetRenderer: any): Renderer | null {
    if (dotNetRenderer === undefined) return null;
    let dotNetSymbol = dotNetRenderer.symbol;
    switch (dotNetRenderer.type) {
        case 'simple':
            let renderer = new SimpleRenderer();
            renderer.visualVariables = dotNetRenderer.visualVariables;
            renderer.symbol = buildJsSymbol(dotNetSymbol) as Symbol;
    }

    return dotNetRenderer
}


export function buildJsFields(dotNetFields: any): Array<Field> {
    let fields: Array<Field> = [];
    dotNetFields.forEach(dnField => {
        let field = buildJsField(dnField);
        fields.push(field);
    });

    return fields;
}

function buildJsField(dotNetField: any): Field {
    let field = new Field();
    if (hasValue(dotNetField.type)) {
        field.type = dotNetField.type;
    }
    if (hasValue(dotNetField.alias)) {
        field.alias = dotNetField.alias;
    }
    if (hasValue(dotNetField.name)) {
        field.name = dotNetField.name;
    }
    if (hasValue(dotNetField.length)) {
        field.length = dotNetField.length;
    }
    if (hasValue(dotNetField.nullable)) {
        field.nullable = dotNetField.nullable;
    }
    if (hasValue(dotNetField.domain)) {
        switch (dotNetField.domain.type) {
            case "coded-value":
                let codedValueDomain = new CodedValueDomain();
                codedValueDomain.name = dotNetField.domain.name;
                codedValueDomain.codedValues = dotNetField.domain.codedValues.map(cv => {
                    return {
                        name: cv.name,
                        code: cv.code
                    }
                });
                field.domain = codedValueDomain;
                break;
            case "range":
                let rangeDomain = new RangeDomain();
                rangeDomain.name = dotNetField.domain.name;
                rangeDomain.minValue = dotNetField.domain.minValue;
                rangeDomain.maxValue = dotNetField.domain.maxValue;
                field.domain = rangeDomain;
                break;
        }
    }
    if (hasValue(dotNetField.defaultValue)) {
        field.defaultValue = dotNetField.defaultValue;
    }
    if (hasValue(dotNetField.description)) {
        field.description = dotNetField.description;
    }
    if (hasValue(dotNetField.editable)) {
        field.editable = dotNetField.editable;
    }
    if (hasValue(dotNetField.valueType)) {
        field.valueType = dotNetField.valueType;
    }
    return field;
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

export async function buildJsPopup(dotNetPopup: any, viewId: string): Promise<Popup> {
    let popup = new Popup({
        actions: dotNetPopup.actions ?? [],
        alignment: dotNetPopup.alignment ?? "auto",
        content: dotNetPopup.content ?? null,
        title: dotNetPopup.title ?? null,
        visible: dotNetPopup.visible ?? false,
        dockEnabled: dotNetPopup.dockEnabled ?? false,
        autoCloseEnabled: dotNetPopup.autoCloseEnabled ?? false,
        autoOpenEnabled: dotNetPopup.autoOpenEnabled ?? true,
        collapseEnabled: dotNetPopup.collapseEnabled ?? true,
        //collapsed: dotNetPopup.collapsed ?? false,
        defaultPopupTemplateEnabled: dotNetPopup.defaultPopupTemplateEnabled ?? false,
        headingLevel: dotNetPopup.headingLevel ?? 2,
        highlightEnabled: dotNetPopup.highlightEnabled ?? true,
        label: dotNetPopup.label ?? '',
        spinnerEnabled: dotNetPopup.spinnerEnabled ?? true
    });

    if (hasValue(dotNetPopup.location)) {
        popup.location = buildJsPoint(dotNetPopup.location) as Point;
    }

    if (hasValue(dotNetPopup.dockOptions)) {
        popup.dockOptions = buildJsDockOptions(dotNetPopup.dockOptions);
    }

    if (hasValue(dotNetPopup.features)) {
        let features: Graphic[] = [];
        for (const f of dotNetPopup.features) {
            delete f.dotNetGraphicReference;
            let graphic = buildJsGraphic(f, viewId) as Graphic;
            features.push(graphic);
        }
        popup.features = features;
    }

    if (hasValue(dotNetPopup.visibleElements)) {
        popup.visibleElements = dotNetPopup.visibleElements;
    }

    return popup;
}

function buildJsDockOptions(dotNetDockOptions: any): PopupDockOptions {
    let dockOptions: PopupDockOptions = {
        buttonEnabled: dotNetDockOptions.buttonEnabled ?? undefined,
        position: dotNetDockOptions.position ?? undefined,
        breakpoint: dotNetDockOptions.breakPoint ?? true
    };

    return dockOptions as PopupDockOptions;
}

export async function buildJsPopupOptions(dotNetPopupOptions: any): Promise<PopupOpenOptions> {
    let options: PopupOpenOptions = {};

    if (hasValue(dotNetPopupOptions.title)) {
        options.title = dotNetPopupOptions.title;
    }
    if (hasValue(dotNetPopupOptions.stringContent)) {
        options.content = dotNetPopupOptions.content;
    }
    if (hasValue(dotNetPopupOptions.fetchFeatures)) {
        options.fetchFeatures = dotNetPopupOptions.fetchFeatures;
    }

    if (hasValue(dotNetPopupOptions.featureMenuOpen)) {
        options.featureMenuOpen = dotNetPopupOptions.featureMenuOpen;
    }

    if (hasValue(dotNetPopupOptions.updateLocationEnabled)) {
        options.updateLocationEnabled = dotNetPopupOptions.updateLocationEnabled;
    }

    if (hasValue(dotNetPopupOptions.collapsed)) {
        options.collapsed = dotNetPopupOptions.collapsed;
    }

    if (hasValue(dotNetPopupOptions.shouldFocus)) {
        options.shouldFocus = dotNetPopupOptions.shouldFocus;
    }

    if (hasValue(dotNetPopupOptions.location)) {
        options.location = buildJsPoint(dotNetPopupOptions.location) as Point;
    }

    if (hasValue(dotNetPopupOptions.features)) {
        let features: Graphic[] = [];
        for (const f of dotNetPopupOptions.features) {
            delete f.dotNetGraphicReference;
            let graphic = buildJsGraphic(f, null) as Graphic;
            graphic.layer = arcGisObjectRefs[f.layerId] as Layer;
            features.push(graphic);
        }
        options.features = features;
    }

    return options;
}

function buildJsFont(dotNetFont: any): Font {
    let font = new Font();
    font.size = dotNetFont.size ?? 9;
    font.family = dotNetFont.family ?? "sans-serif";
    font.style = dotNetFont.style ?? "normal";
    font.weight = dotNetFont.weight ?? "normal";

    return font;
}

export function buildJsQuery(dotNetQuery: DotNetQuery): Query {
    let query: any = new Query({
        where: dotNetQuery.where ?? "1=1",
        spatialRelationship: dotNetQuery.spatialRelationship as any ?? "intersects",
        distance: dotNetQuery.distance ?? undefined,
        units: dotNetQuery.units as any ?? null,
        returnGeometry: dotNetQuery.returnGeometry ?? false,
        outFields: dotNetQuery.outFields ?? null,
        orderByFields: dotNetQuery.orderByFields ?? undefined,
        outStatistics: dotNetQuery.outStatistics ?? undefined,
        groupByFieldsForStatistics: dotNetQuery.groupByFieldsForStatistics ?? undefined,
        returnDistinctValues: dotNetQuery.returnDistinctValues ?? false,
        returnZ: dotNetQuery.returnZ ?? undefined,
        returnExceededLimitFeatures: dotNetQuery.returnExceededLimitFeatures ?? true,
        num: dotNetQuery.num ?? undefined,
        objectIds: dotNetQuery.objectIds ?? undefined,
        timeExtent: dotNetQuery.timeExtent ?? undefined,
        maxAllowableOffset: dotNetQuery.maxAllowableOffset ?? undefined,
        geometryPrecision: dotNetQuery.geometryPrecision ?? undefined,
        aggregateIds: dotNetQuery.aggregateIds ?? undefined,
        cacheHint: dotNetQuery.cacheHint ?? undefined,
        datumTransformation: dotNetQuery.datumTransformation ?? undefined,
        gdbVersion: dotNetQuery.gdbVersion ?? undefined,
        having: dotNetQuery.having ?? undefined,
        historicMoment: dotNetQuery.historicMoment ?? undefined,
        maxRecordCountFactor: dotNetQuery.maxRecordCountFactor ?? 1,
        text: dotNetQuery.text ?? null,
        parameterValues: dotNetQuery.parameterValues ?? undefined,
        quantizationParameters: dotNetQuery.quantizationParameters ?? undefined,
        rangeValues: dotNetQuery.rangeValues ?? undefined,
        relationParameter: dotNetQuery.relationParameter ?? undefined,
        returnCentroid: dotNetQuery.returnCentroid ?? false,
        returnM: dotNetQuery.returnM ?? undefined,
        returnQueryGeometry: dotNetQuery.returnQueryGeometry ?? false,
        sqlFormat: dotNetQuery.sqlFormat as any ?? "none",
        start: dotNetQuery.start ?? undefined
    });

    if (hasValue(dotNetQuery.geometry)) {
        query.geometry = buildJsGeometry(dotNetQuery.geometry) as Geometry;
    }

    if (hasValue(dotNetQuery.outSpatialReference)) {
        query.outSpatialReference = buildJsSpatialReference(dotNetQuery.outSpatialReference);
    }

    return query as Query;
}

export function buildJsRelationshipQuery(dotNetRelationshipQuery: DotNetRelationshipQuery): RelationshipQuery {
    // copy all values from the dotnet object to the js object
    let relationshipQuery = new RelationshipQuery({
        cacheHint: dotNetRelationshipQuery.cacheHint ?? undefined,
        gdbVersion: dotNetRelationshipQuery.gdbVersion ?? undefined,
        geometryPrecision: dotNetRelationshipQuery.geometryPrecision ?? undefined,
        historicMoment: dotNetRelationshipQuery.historicMoment ?? undefined,
        maxAllowableOffset: dotNetRelationshipQuery.maxAllowableOffset ?? undefined,
        num: dotNetRelationshipQuery.num ?? undefined,
        objectIds: dotNetRelationshipQuery.objectIds ?? undefined,
        orderByFields: dotNetRelationshipQuery.orderByFields ?? undefined,
        outFields: dotNetRelationshipQuery.outFields ?? undefined,
        returnGeometry: dotNetRelationshipQuery.returnGeometry ?? undefined,
        returnM: dotNetRelationshipQuery.returnM ?? undefined,
        returnZ: dotNetRelationshipQuery.returnZ ?? undefined,
        start: dotNetRelationshipQuery.start ?? undefined,
        where: dotNetRelationshipQuery.where ?? undefined
    });

    if (hasValue(dotNetRelationshipQuery.outSpatialReference)) {
        relationshipQuery.outSpatialReference = buildJsSpatialReference(dotNetRelationshipQuery.outSpatialReference);
    }

    return relationshipQuery as RelationshipQuery;
}

export function buildJsTopFeaturesQuery(dnQuery: DotNetTopFeaturesQuery): TopFeaturesQuery {
    let query = new TopFeaturesQuery({
        cacheHint: dnQuery.cacheHint ?? undefined,
        distance: dnQuery.distance ?? undefined,
        geometryPrecision: dnQuery.geometryPrecision ?? undefined,
        maxAllowableOffset: dnQuery.maxAllowableOffset ?? undefined,
        num: dnQuery.num ?? undefined,
        objectIds: dnQuery.objectIds ?? undefined,
        orderByFields: dnQuery.orderByFields ?? undefined,
        outFields: dnQuery.outFields ?? null,
        returnGeometry: dnQuery.returnGeometry ?? false,
        returnM: dnQuery.returnM ?? undefined,
        returnZ: dnQuery.returnZ ?? undefined,
        spatialRelationship: dnQuery.spatialRelationship as any ?? "intersects",
        start: dnQuery.start ?? undefined,
        timeExtent: dnQuery.timeExtent ?? undefined,
        topFilter: dnQuery.topFilter as any ?? undefined,
        units: dnQuery.units as any ?? null
    });

    if (hasValue(dnQuery.where)) {
        query.where = dnQuery.where;
    }

    if (hasValue(dnQuery.geometry)) {
        query.geometry = buildJsGeometry(dnQuery.geometry) as Geometry;
    }

    if (hasValue(dnQuery.outSpatialReference)) {
        query.outSpatialReference = buildJsSpatialReference(dnQuery.outSpatialReference);
    }

    return query as TopFeaturesQuery;
}

export function buildJsMediaInfo(dotNetMediaInfo: DotNetMediaInfo): any {
    switch (dotNetMediaInfo?.type) {
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
    let value = new ChartMediaInfoValue({
        fields: dotNetChartMediaInfoValue?.fields ?? undefined,
        normalizeField: dotNetChartMediaInfoValue?.normalizeField ?? undefined,
        tooltipField: dotNetChartMediaInfoValue?.tooltipField ?? undefined
    });

    if (hasValue(dotNetChartMediaInfoValue?.series)) {
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
    let info = new ElementExpressionInfo({
        expression: dotNetExpressionInfo.expression ?? undefined,
        title: dotNetExpressionInfo.title ?? undefined
    });

    return info;
}

export function buildJsPortalItem(dotNetPortalItem: any): any {
    if (dotNetPortalItem?.Id === null) return null;
    let portalItem: any = {
        id: dotNetPortalItem.id
    };
    if (hasValue(dotNetPortalItem?.portal)) {
        portalItem.portal = {
            url: dotNetPortalItem.portal.url
        }
    }
    if (hasValue(dotNetPortalItem?.apiKey)) {
        portalItem.apiKey = dotNetPortalItem.apiKey;
    }

    return portalItem;
}

export function buildJsApplyEdits(dotNetApplyEdits: DotNetApplyEdits, viewId: string): FeatureLayerBaseApplyEditsEdits {
    let addFeatures = dotNetApplyEdits.addFeatures?.map(f => buildJsGraphic(f, viewId)!);
    let deleteFeatures = dotNetApplyEdits.deleteFeatures?.map(f => buildJsGraphic(f, viewId)!);
    let updateFeatures = dotNetApplyEdits.updateFeatures?.map(f => buildJsGraphic(f, viewId)!);
    let addAttachments = dotNetApplyEdits.addAttachments?.map(a => buildJsAttachmentEdit(a, viewId)!);
    let updateAttachments = dotNetApplyEdits.updateAttachments?.map(a => buildJsAttachmentEdit(a, viewId)!);

    return {
        addFeatures: addFeatures ?? undefined,
        deleteFeatures: deleteFeatures ?? undefined,
        updateFeatures: updateFeatures ?? undefined,
        addAttachments: addAttachments ?? undefined,
        updateAttachments: updateAttachments ?? undefined,
        deleteAttachments: dotNetApplyEdits.deleteAttachments ?? undefined
    };
}

export function buildJsFormTemplate(dotNetFormTemplate: any): FormTemplate {
    let formTemplate = new FormTemplate({
        title: dotNetFormTemplate.title ?? undefined,
        description: dotNetFormTemplate.description ?? undefined,
        preserveFieldValuesWhenHidden: dotNetFormTemplate.preserveFieldValuesWhenHidden ?? undefined
    });
    if (hasValue(dotNetFormTemplate?.elements)) {
        formTemplate.elements = dotNetFormTemplate.elements.map(e => buildJsFormTemplateElement(e));
    }
    if (hasValue(dotNetFormTemplate.expressionInfos)) {
        formTemplate.expressionInfos = dotNetFormTemplate.expressionInfos.map(e => buildJsExpressionInfo(e));
    }
    return formTemplate;
}

function buildJsFormTemplateElement(dotNetFormTemplateElement: any): Element {
    switch (dotNetFormTemplateElement.type){
        case 'group':
            return new GroupElement({
                label: dotNetFormTemplateElement.label ?? undefined,
                description: dotNetFormTemplateElement.description ?? undefined,
                elements: dotNetFormTemplateElement.elements?.map(e => buildJsFormTemplateElement(e)) ?? []
            });
    }
    let fieldElement: any = {
        type: 'field'
    };
    if (hasValue(dotNetFormTemplateElement.description)) {
        fieldElement.description = dotNetFormTemplateElement.description;
    }
    if (hasValue(dotNetFormTemplateElement.label)) {
        fieldElement.label = dotNetFormTemplateElement.label;
    }
    if (hasValue(dotNetFormTemplateElement.visibilityExpression)) {
        fieldElement.visibilityExpression = dotNetFormTemplateElement.visibilityExpression;
    }
    if (hasValue(dotNetFormTemplateElement.editableExpression)) {
        fieldElement.editableExpression = dotNetFormTemplateElement.editableExpression;
    }
    if (hasValue(dotNetFormTemplateElement.requiredExpression)) {
        fieldElement.requiredExpression = dotNetFormTemplateElement.requiredExpression;
    }
    if (hasValue(dotNetFormTemplateElement.fieldName)) {
        fieldElement.fieldName = dotNetFormTemplateElement.fieldName;
    }
    if (hasValue(dotNetFormTemplateElement.hint)) {
        fieldElement.hint = dotNetFormTemplateElement.hint;
    }
    if (hasValue(dotNetFormTemplateElement.valueExpression)) {
        fieldElement.valueExpression = dotNetFormTemplateElement.valueExpression;
    }
    if (hasValue(dotNetFormTemplateElement?.domain)) {
        fieldElement.domain = buildJsDomain(dotNetFormTemplateElement.domain);
    }
    if (hasValue(dotNetFormTemplateElement?.input)) {
        fieldElement.input = buildJsFormInput(dotNetFormTemplateElement.input);
    }
    return fieldElement;
}

function buildJsDomain(dotNetDomain: any): any {
    switch (dotNetDomain?.type){
        case 'coded-value':
            return new CodedValueDomain({
                name: dotNetDomain.name ?? undefined,
                codedValues: dotNetDomain.codedValues?.map(c => buildJsCodedValue(c)) ?? undefined
            });
        case 'range':
            return new RangeDomain({
                name: dotNetDomain.name ?? undefined,
                maxValue: dotNetDomain.maxValue ?? undefined,
                minValue: dotNetDomain.minValue ?? undefined
            });
    }
    
    return undefined;
}

function buildJsCodedValue(dotNetCodedValue: any): CodedValue {
    return {
        name: dotNetCodedValue.name ?? undefined,
        code: dotNetCodedValue.code ?? undefined
    };
}

function buildJsFormInput(dotNetFormInput: any): any {
    switch (dotNetFormInput?.type) {
        case 'text-box':
            return new TextBoxInput({
                maxLength: dotNetFormInput.maxLength ?? undefined,
                minLength: dotNetFormInput.minLength ?? undefined
            });
        case 'text-area':
            return new TextAreaInput({
                maxLength: dotNetFormInput.maxLength ?? undefined,
                minLength: dotNetFormInput.minLength ?? undefined
            });
        case 'datetime-picker':
            return new DateTimePickerInput({
                includeTime: dotNetFormInput.includeTime ?? undefined,
                max: dotNetFormInput.max ?? undefined,
                min: dotNetFormInput.min ?? undefined
            });
        case 'barcode-scanner':
            return new BarcodeScannerInput({
                maxLength: dotNetFormInput.maxLength ?? undefined,
                minLength: dotNetFormInput.minLength ?? undefined
            });
        case 'combo-box':
            return new ComboBoxInput({
                noValueOptionLabel: dotNetFormInput.noValueOptionLabel ?? undefined,
                showNoValueOption: dotNetFormInput.showNoValueOption ?? undefined
            });
        case 'radio-buttons':
            return new RadioButtonsInput({
                noValueOptionLabel: dotNetFormInput.noValueOptionLabel ?? undefined,
                showNoValueOption: dotNetFormInput.showNoValueOption ?? undefined
            });
        case 'switch':
            return new SwitchInput({
                offValue: dotNetFormInput.offValue ?? undefined,
                onValue: dotNetFormInput.onValue ?? undefined
            });
    }
    
    return undefined;
}

function buildJsAttachmentEdit(dotNetAttachmentEdit: DotNetAttachmentsEdit, viewId: string): AttachmentEdit {
    return {
        feature: buildJsGraphic(dotNetAttachmentEdit.feature, viewId)!,
        attachment: dotNetAttachmentEdit.attachment
    };
}

function buildJsColor(color: any) {
    if (!hasValue(color)) return null;
    // @ts-ignore
    if (typeof color === "string" || color instanceof Array<number>) return color;
    if (hasValue(color?.hexOrNameValue)) {
        return color.hexOrNameValue;
    }
    return color.values;
}

function buildJsPathsOrRings(pathsOrRings: any) {
    if (!hasValue(pathsOrRings)) return null;
    if (pathsOrRings[0].hasOwnProperty("points")) {
        let array: [][][] = [];
        for (let i = 0; i < pathsOrRings.length; i++) {
            let points = pathsOrRings[i].points;
            let pointsArray: [][] = [];
            for (let j = 0; j < points.length; j++) {
                pointsArray.push(points[j].coordinates);
            }
            array.push(pointsArray);
        }
        return array;
    }
    return pathsOrRings;
}

function hasValue(prop: any): boolean {
    return prop !== undefined && prop !== null;
}