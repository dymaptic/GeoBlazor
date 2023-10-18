import SpatialReference from "@arcgis/core/geometry/SpatialReference";
import Extent from "@arcgis/core/geometry/Extent";
import Graphic from "@arcgis/core/Graphic";
import PopupTemplate from "@arcgis/core/PopupTemplate";
import {arcGisObjectRefs, dotNetRefs, triggerActionHandler} from "./arcGisJsInterop";
import Geometry from "@arcgis/core/geometry/Geometry";
import Point from "@arcgis/core/geometry/Point";
import Polyline from "@arcgis/core/geometry/Polyline";
import Polygon from "@arcgis/core/geometry/Polygon";
import TextSymbol from "@arcgis/core/symbols/TextSymbol";
import SimpleRenderer from "@arcgis/core/renderers/SimpleRenderer";
import Renderer from "@arcgis/core/renderers/Renderer";
import Field from "@arcgis/core/layers/support/Field";
import Font from "@arcgis/core/symbols/Font";
import Bookmark from "@arcgis/core/webmap/Bookmark"
import Viewpoint from "@arcgis/core/Viewpoint";
import FeatureEffect from "@arcgis/core/layers/support/FeatureEffect";
import FeatureFilter from "@arcgis/core/layers/support/FeatureFilter";
import RasterStretchRenderer from "@arcgis/core/renderers/RasterStretchRenderer.js"
import ColorRamp from "@arcgis/core/rest/support/ColorRamp.js";
import DimensionalDefinition from "@arcgis/core/layers/support/DimensionalDefinition.js";
import MultipartColorRamp from "@arcgis/core/rest/support/MultipartColorRamp.js";
import AlgorithmicColorRamp from "@arcgis/core/rest/support/AlgorithmicColorRamp.js";
import RasterShadedReliefRenderer from "@arcgis/core/renderers/RasterShadedReliefRenderer.js";
import RasterColormapRenderer from "@arcgis/core/renderers/RasterColormapRenderer.js";
import VectorFieldRenderer from "@arcgis/core/renderers/VectorFieldRenderer.js";
import FlowRenderer from "@arcgis/core/renderers/FlowRenderer.js";
import ClassBreaksRenderer from "@arcgis/core/renderers/ClassBreaksRenderer.js";
import AuthoringInfo from "@arcgis/core/renderers/support/AuthoringInfo.js";
import ClassBreakInfo from "@arcgis/core/renderers/support/ClassBreakInfo.js";
import UniqueValueRenderer from "@arcgis/core/renderers/UniqueValueRenderer.js";
import ColormapInfo from "@arcgis/core/renderers/support/ColormapInfo.js";
import VisualVariable from "@arcgis/core/renderers/visualVariables/VisualVariable.js";
import MultidimensionalSubset from "@arcgis/core/layers/support/MultidimensionalSubset.js";
import PolygonSymbol3D from "@arcgis/core/symbols/PolygonSymbol3D.js";
import FieldsIndex from "@arcgis/core/layers/support/FieldsIndex.js";
import AuthoringInfoVisualVariable from "@arcgis/core/renderers/support/AuthoringInfoVisualVariable.js";
import UniqueValue from "@arcgis/core/renderers/support/UniqueValue.js";
import UniqueValueInfo from "@arcgis/core/renderers/support/UniqueValueInfo.js";
import UniqueValueClass from "@arcgis/core/renderers/support/UniqueValueClass.js";
import UniqueValueGroup from "@arcgis/core/renderers/support/UniqueValueGroup.js";
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
    DotNetTopFeaturesQuery,
    DotNetBookmark,
    DotNetViewpoint,
    DotNetFeatureEffect,
    DotNetFeatureFilter,
    DotNetRasterStretchRenderer,
    DotNetRasterColormapRenderer,
    DotNetVectorFieldRenderer,
    DotNetFlowRenderer,
    DotNetDimensionalDefinition,
    DotNetColorRamp,
    DotNetVisualVariable,
    DotNetColormapInfo,
    DotNetClassBreaksRenderer,
    DotNetClassBreaksInfo,
    DotNetMultidimensionalSubset,
    DotNetSubsetDimension,
    DotNetRasterFunction,
    DotNetRasterFunctionInfo,
    DotNetAuthoringInfo,
    DotNetFieldsIndex,
    DotNetUniqueValueRenderer
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
import { buildDotNetGraphic } from "./dotNetBuilder";
import ViewClickEvent = __esri.ViewClickEvent;
import PopupOpenOptions = __esri.PopupOpenOptions;
import PopupDockOptions = __esri.PopupDockOptions;
import ContentProperties = __esri.ContentProperties;
import PopupTriggerActionEvent = __esri.PopupTriggerActionEvent;
import FeatureLayerBaseApplyEditsEdits = __esri.FeatureLayerBaseApplyEditsEdits;
import AttachmentEdit = __esri.AttachmentEdit;
import FormTemplate from "@arcgis/core/form/FormTemplate";
import Element from "@arcgis/core/form/elements/Element";
import GroupElement from "@arcgis/core/form/elements/GroupElement";
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
import * as reactiveUtils from "@arcgis/core/core/reactiveUtils";


export function buildJsSpatialReference(dotNetSpatialReference: DotNetSpatialReference): SpatialReference {
    if (dotNetSpatialReference === undefined || dotNetSpatialReference === null) {
        return new SpatialReference({ wkid: 4326 });
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
                await lookupDotNetRefForPopupTemplate(popupTemplateObject, viewId as string);
                let results: DotNetPopupContent[] | null = await popupTemplateObject.dotNetPopupTemplateReference
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
            try {
                if (hasValue(triggerActionHandler)) {
                    triggerActionHandler.remove();
                }
                if (hasValue(templateTriggerActionHandler)) {
                    templateTriggerActionHandler.remove();
                }
                
                if (view.popup.on === undefined) {
                    // we need to wait for the popup to be initialized before we can add the trigger-action handler
                    reactiveUtils.once(() => view.popup.on !== undefined)
                        .then(() => {
                            templateTriggerActionHandler = view.popup.on("trigger-action", async (event: PopupTriggerActionEvent) => {
                                await lookupDotNetRefForPopupTemplate(popupTemplateObject, viewId as string);
                                await popupTemplateObject.dotNetPopupTemplateReference.invokeMethodAsync("OnTriggerAction", event.action.id);
                            });
                        })
                } else {
                    templateTriggerActionHandler = view.popup.on("trigger-action", async (event: PopupTriggerActionEvent) => {
                        await lookupDotNetRefForPopupTemplate(popupTemplateObject, viewId as string);
                        await popupTemplateObject.dotNetPopupTemplateReference.invokeMethodAsync("OnTriggerAction", event.action.id);
                    });
                }
            }
            catch (error) {
                console.debug(error);
            }
        }
    }

    return template;
}

async function lookupDotNetRefForPopupTemplate(popupTemplateObject: DotNetPopupTemplate, viewId: string) {
    if (!hasValue(popupTemplateObject.dotNetPopupTemplateReference)) {
        let viewRef = dotNetRefs[viewId];
        popupTemplateObject.dotNetPopupTemplateReference =
            await viewRef.invokeMethodAsync('GetDotNetPopupTemplateObjectReference', popupTemplateObject.id);
    }
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

export function buildJsBookmark(dnBookmark: DotNetBookmark): Bookmark | null {
    if (dnBookmark === undefined || dnBookmark === null) return null;
    let bookmark = new Bookmark();
    bookmark.name = dnBookmark.name ?? undefined;
    bookmark.timeExtent = dnBookmark.timeExtent ?? undefined;

    if (!(dnBookmark.thumbnail == null)) {
        //ESRI has this as an "object" with url property
        let thumbnail = { url: dnBookmark.thumbnail };
        bookmark.thumbnail = thumbnail;
    }

    if (hasValue(dnBookmark.viewpoint)) {
        bookmark.viewpoint = buildJsViewpoint(dnBookmark.viewpoint) as Viewpoint;
    }

    return bookmark as Bookmark;
}

export function buildJsViewpoint(dnViewpoint: DotNetViewpoint): Viewpoint | null {
    if (dnViewpoint === undefined || dnViewpoint === null) return null;
    let viewpoint = new Viewpoint();
    viewpoint.rotation = dnViewpoint.rotation ?? undefined;
    viewpoint.scale = dnViewpoint.scale ?? undefined;
    viewpoint.targetGeometry = buildJsGeometry(dnViewpoint.targetGeometry) as Geometry;
    return viewpoint as Viewpoint;
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
        point.spatialReference = new SpatialReference({ wkid: 4326 });
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
        polyline.spatialReference = new SpatialReference({ wkid: 4326 });
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
        polygon.spatialReference = new SpatialReference({ wkid: 4326 });
    }
    return polygon;
}

export function buildJsRenderer(dotNetRenderer: any): Renderer | null {
    if (dotNetRenderer === undefined) return null;
    let dotNetSymbol = dotNetRenderer.symbol;
    switch (dotNetRenderer.type) {
        case 'simple':
            let simpleRenderer = new SimpleRenderer();
            simpleRenderer.visualVariables = dotNetRenderer.visualVariables;
            simpleRenderer.symbol = buildJsSymbol(dotNetSymbol) as Symbol;
            simpleRenderer.authoringInfo = dotNetRenderer.authoringInfo;
            return simpleRenderer;
    }
    return dotNetRenderer;
}

export function buildJsRasterColormapRenderer(dotNetRasterColormapRenderer: DotNetRasterColormapRenderer): RasterColormapRenderer | null {
    if (dotNetRasterColormapRenderer === undefined) return null;
    let rasterColormapRender = new RasterColormapRenderer();

    if (hasValue(dotNetRasterColormapRenderer.colormapInfos)) {
        rasterColormapRender.colormapInfos = buildJsColormapInfo(dotNetRasterColormapRenderer.colormapInfos) as ColormapInfo;
    }
    return rasterColormapRender;
}

export function buildJsColormapInfo(dotNetColormapInfo: DotNetColormapInfo): ColormapInfo | null {
    if (dotNetColormapInfo === undefined) return null;
    let colormapInfo = new ColormapInfo();

    if (hasValue(dotNetColormapInfo.mapColor)) {
        colormapInfo.color = dotNetColormapInfo.color;
    }
    if (hasValue(dotNetColormapInfo.label)) {
        colormapInfo.label = dotNetColormapInfo.label;
    }
    if (hasValue(dotNetColormapInfo.value)) {
        colormapInfo.value = dotNetColormapInfo.value;
    }
    return colormapInfo;
}

export function buildJsRasterShadedReliefRenderer(dnRasterShadedReliefRenderer: DotNetRasterShadedReliefRenderer): RasterShadedReliefRenderer | null {
    if (dnRasterShadedReliefRenderer === undefined) return null;
    let rasterShadedReliefRenderer = new RasterShadedReliefRenderer();
    if (hasValue(dnRasterShadedReliefRenderer.altitude)) {
        rasterShadedReliefRenderer.altitude = dnRasterShadedReliefRenderer.altitude;
    }
    if (hasValue(dnRasterShadedReliefRenderer.azimuth)) {
        rasterShadedReliefRenderer.azimuth
    }
    return rasterShadedReliefRenderer;
}

export function buildJsSimpleFillSymbol(dnSimpleFillSymbol: DotNetSimpleFillSymbol): SimpleFillSymbol | null {

}

export function buildJsClassBreaksRenderer(dnClassBreaksRenderer: DotNetClassBreaksRenderer): ClassBreaksRenderer | null {
    if (dnClassBreaksRenderer === undefined) return null;
    let classBreaksRenderer = new ClassBreaksRenderer();
    //Implements only the simple fill symbol PolygonSymbol3d is another option but can be implemented later
    if (hasValue(dnClassBreaksRenderer.backgroundFillSymbol)) {
        classBreaksRenderer.backgroundFillSymbol = dnClassBreaksRenderer.backgroundFillSymbol as DotNetSimpleFillSymbol;
    }
    if (hasValue(dnClassBreaksRenderer.classBreakInfos)) {
        classBreaksRenderer.classBreakInfos = dnClassBreaksRenderer.classBreakInfos;
    }
    if (hasValue(dnClassBreaksRenderer.defaultLabel)) {
        classBreaksRenderer.defaultLabel = dnClassBreaksRenderer.defaultLabel;
    }
    if (hasValue(dnClassBreaksRenderer.defaultSymbol)) {
        classBreaksRenderer.defaultSymbol = dnClassBreaksRenderer.defaultSymbol;
    }
    if (hasValue(dnClassBreaksRenderer.field)) {
        classBreaksRenderer.field = dnClassBreaksRenderer.field;
    }
    if (hasValue(dnClassBreaksRenderer.legendOptions)) {
        classBreaksRenderer.legendOptions = dnClassBreaksRenderer.legendOptions;
    }
    if (hasValue(dnClassBreaksRenderer.normalizationField)) {
        classBreaksRenderer.normalizationField = dnClassBreaksRenderer.normalizationField;
    }
    if (hasValue(dnClassBreaksRenderer.normalizationTotal)) {
        classBreaksRenderer.normalizationTotal = dnClassBreaksRenderer.normalizationTotal;
    }
    if (hasValue(dnClassBreaksRenderer.normalizationType)) {
        classBreaksRenderer.normalizationType = dnClassBreaksRenderer.normalizationType;
    }
    if (hasValue(dnClassBreaksRenderer.type)) {
        classBreaksRenderer.type = dnClassBreaksRenderer.type;
    }
    if (hasValue(dnClassBreaksRenderer.valueExpression)) {
        classBreaksRenderer.valueExpression = dnClassBreaksRenderer.valueExpression;
    }
    if (hasValue(dnClassBreaksRenderer.valueExpressionTitle)) {
        classBreaksRenderer.valueExpressionTitle = dnClassBreaksRenderer.valueExpressionTitle;
    }
    if (hasValue(dnClassBreaksRenderer.visualVariables)) {
        classBreaksRenderer.visualVariables = dnClassBreaksRenderer.visualVariables;
    }
    return classBreaksRenderer;
}

export function buildJsVectorFieldRenderer(dotNetVectorFieldRenderer: DotNetVectorFieldRenderer): VectorFieldRenderer | null {
    if (dotNetVectorFieldRenderer === undefined) return null;
    let vectorFieldRenderer = new VectorFieldRenderer();

    if (hasValue(dotNetVectorFieldRenderer.attributeField)) {
        vectorFieldRenderer.attributeField = dotNetVectorFieldRenderer.attributeField;
    }
    if (hasValue(dotNetVectorFieldRenderer.flowRepresentation)) {
        vectorFieldRenderer.flowRepresentation = dotNetVectorFieldRenderer.flowRepresentation;
    }
    if (hasValue(dotNetVectorFieldRenderer.style)) {
        vectorFieldRenderer.style = dotNetVectorFieldRenderer.style;
    }
    if (hasValue(dotNetVectorFieldRenderer.symbolTileSize)) {
        vectorFieldRenderer.symbolTileSize = dotNetVectorFieldRenderer.symbolTileSize;
    }
    if (hasValue(dotNetVectorFieldRenderer.visualVariables)) {
        vectorFieldRenderer.visualVariables = dotNetVectorFieldRenderer.visualVariables;
    }
    return vectorFieldRenderer;
}

export function buildJsVisualVariable(dotNetVisualVariable: DotNetVisualVariable): VisualVariable | null {
    if (dotNetVisualVariable === undefined) return null;
    let visualVariable = new VisualVariable();

    if (hasValue(dotNetVisualVariable.type)) {
        dotNetVisualVariable.field = visualVariable.type;
    }
    if (hasValue(dotNetVisualVariable.field)) {
        dotNetVisualVariable.field = visualVariable.field;
    }
    if (hasValue(dotNetVisualVariable.legendOptions)) {
        dotNetVisualVariable.legendOptions = visualVariable.legendOptions;
    }
    if (hasValue(dotNetVisualVariable.valueExpression)) {
        dotNetVisualVariable.valueExpression = visualVariable.valueExpression;
    }
    if (hasValue(dotNetVisualVariable.valueExpressionTitle)) {
        dotNetVisualVariable.valueExpressionTitle = visualVariable.valueExpressionTitle;
    }
    return visualVariable;
}

export function buildJsFlowRenderer(dotNetFlowRenderer: DotNetFlowRenderer): FlowRenderer | null {
    if (dotNetFlowRenderer === undefined) return null;
    let flowRenderer = new FlowRenderer();

    if (hasValue(dotNetFlowRenderer.authoringInfo)) {
        dotNetFlowRenderer.authoringInfo = flowRenderer.authoringInfo;
    }
    if (hasValue(dotNetFlowRenderer.color)) {
        dotNetFlowRenderer.color = flowRenderer.color;
    }
    if (hasValue(dotNetFlowRenderer.density)) {
        dotNetFlowRenderer.density = flowRenderer.density;
    }
    if (hasValue(dotNetFlowRenderer.flowRepresentation)) {
        dotNetFlowRenderer.flowRepresentation = flowRenderer.flowRepresentation;
    }
    if (hasValue(dotNetFlowRenderer.flowSpeed)) {
        dotNetFlowRenderer.flowSpeed = flowRenderer.flowSpeed;
    }
    if (hasValue(dotNetFlowRenderer.legendOptions)) {
        dotNetFlowRenderer.legendOptions = flowRenderer.legendOptions;
    }
    if (hasValue(dotNetFlowRenderer.maxPathLength)) {
        dotNetFlowRenderer.maxPathLength = flowRenderer.maxPathLength;
    }
    if (hasValue(dotNetFlowRenderer.trailCap)) {
        dotNetFlowRenderer.trailCap = flowRenderer.trailCap;
    }
    if (hasValue(dotNetFlowRenderer.trailLength)) {
        dotNetFlowRenderer.trailLength = flowRenderer.trailLength;
    }
    if (hasValue(dotNetFlowRenderer.trailWidth)) {
        dotNetFlowRenderer.trailWidth = flowRenderer.trailWidth;
    }
    if (hasValue(dotNetFlowRenderer.visualVariables)) {
        dotNetFlowRenderer.visualVariables = flowRenderer.visualVariables;
    }
    return flowRenderer;
}

export function buildJsRasterStretchRenderer(dotNetRasterStretchRenderer: DotNetRasterStretchRenderer): RasterStretchRenderer | null {
    if (dotNetRasterStretchRenderer === undefined) return null;
    let rasterStretchRenderer = new RasterStretchRenderer();

    if (hasValue(dotNetRasterStretchRenderer.colorRamp)) {
        rasterStretchRenderer.colorRamp = buildJsColorRamp(dotNetRasterStretchRenderer.colorRamp) as ColorRamp;
    }
    if (hasValue(dotNetRasterStretchRenderer.computeGamma)) {
        rasterStretchRenderer.computeGamma = dotNetRasterStretchRenderer.computeGamma;
    }
    if (hasValue(dotNetRasterStretchRenderer.dynamicRangeAdjustment)) {
        rasterStretchRenderer.dynamicRangeAdjustment = dotNetRasterStretchRenderer.dynamicRangeAdjustment;
    }
    if (hasValue(dotNetRasterStretchRenderer.gamma)) {
        rasterStretchRenderer.gamma = dotNetRasterStretchRenderer.gamma;
    }
    if (hasValue(dotNetRasterStretchRenderer.useGamma)) {
        rasterStretchRenderer.useGamma = dotNetRasterStretchRenderer.useGamma;
    }
    if (hasValue(dotNetRasterStretchRenderer.outputMax)) {
        rasterStretchRenderer.outputMax = dotNetRasterStretchRenderer.outputMax;
    }
    if (hasValue(dotNetRasterStretchRenderer.outputMin)) {
        rasterStretchRenderer.outputMin = dotNetRasterStretchRenderer.outputMin;
    }
    if (hasValue(dotNetRasterStretchRenderer.stretchType)) {
        rasterStretchRenderer.stretchType = dotNetRasterStretchRenderer.stretchType;
    }
    if (hasValue(dotNetRasterStretchRenderer.statistics)) {
        rasterStretchRenderer.statistics = dotNetRasterStretchRenderer.statistics;
    }
    if (hasValue(dotNetRasterStretchRenderer.numberOfStandardDeviations)) {
        rasterStretchRenderer.numberOfStandardDeviations = dotNetRasterStretchRenderer.numberOfStandardDeviations;
    }
    return rasterStretchRenderer;
}

export function buildJsColorRamp(dotNetColorRamp: any): ColorRamp | null {
    if (dotNetColorRamp === undefined) return null;
    switch (dotNetColorRamp.type) {
        case 'multipart':
            return buildJsMultipartColorRamp(dotNetColorRamp);
        default:
            return buildJsAlgorithmicColorRamp(dotNetColorRamp);
    }
}

export function buildJsAlgorithmicColorRamp(dotNetAlgorithmicColorRamp: any): AlgorithmicColorRamp | null {
    if (dotNetAlgorithmicColorRamp === undefined) return null;
    let algorithmicColorRamp = new AlgorithmicColorRamp();
    algorithmicColorRamp.fromColor = dotNetAlgorithmicColorRamp.fromColor;
    algorithmicColorRamp.toColor = dotNetAlgorithmicColorRamp.toColor;
    return algorithmicColorRamp;
}

export function buildJsDimensionalDefinition(dotNetMultidimensionalDefinition: any): DimensionalDefinition | null {
    if (dotNetMultidimensionalDefinition == undefined) return null;
    let multidimensionalDefinition = new DimensionalDefinition();
    multidimensionalDefinition = dotNetMultidimensionalDefinition;
    return multidimensionalDefinition;
}

export function buildJsMultipartColorRamp(dotNetMultipartColorRamp: any): MultipartColorRamp | null {
    if (dotNetMultipartColorRamp === undefined) return null;
    let multipartColorRamp = new MultipartColorRamp();
    multipartColorRamp.colorRamps = dotNetMultipartColorRamp.colorRamps.map(buildJsAlgorithmicColorRamp);
    return multipartColorRamp;
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
    } as ViewClickEvent;
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
        units: dotNetQuery.units as any ?? undefined,
        returnGeometry: dotNetQuery.returnGeometry ?? false,
        outFields: dotNetQuery.outFields ?? undefined,
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
        text: dotNetQuery.text ?? undefined,
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

export function buildJsTimeSliderStops(dotNetStop: any): any | null {
    if (dotNetStop === null) return null;
    switch (dotNetStop.type) {
        case "stops-by-dates":
            return {
                dates: dotNetStop.dates,
            }
        case "stops-by-count":
            return {
                count: dotNetStop.count,
                timeExtent: dotNetStop.timeExtent ?? undefined,
            }
        case "stops-by-interval":
            return {
                interval: dotNetStop.interval,
                timeExtent: dotNetStop.timeExtent ?? undefined,
            }
    }
    return null;
}

function buildJsFormTemplateElement(dotNetFormTemplateElement: any): Element {
    switch (dotNetFormTemplateElement.type) {
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
    switch (dotNetDomain?.type) {
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

export function buildJsFeatureEffect(dnFeatureEffect: DotNetFeatureEffect): FeatureEffect | null {
    if (dnFeatureEffect === undefined || dnFeatureEffect === null) return null;
    let featureEffect = new FeatureEffect();

    //if there is a single effect, its a string, if there are effects based on scale its an array and has scale and value.
    if (dnFeatureEffect.excludedEffect != null) {
        if (dnFeatureEffect.excludedEffect.length === 1) {
            featureEffect.excludedEffect = buildJsEffect(dnFeatureEffect.excludedEffect[0]);
        } else {
            featureEffect.excludedEffect = dnFeatureEffect.excludedEffect.map(buildJsEffect);
        }
    }
    featureEffect.excludedLabelsVisible = dnFeatureEffect.excludedLabelsVisible ?? undefined;
    if (hasValue(dnFeatureEffect?.filter)) {
        featureEffect.filter = buildJsFeatureFilter(dnFeatureEffect.filter) as FeatureFilter;
    }

    if (dnFeatureEffect.includedEffect != null) {
        if (dnFeatureEffect.includedEffect.length === 1) {
            featureEffect.includedEffect = buildJsEffect(dnFeatureEffect.includedEffect[0]);
        } else {
            featureEffect.includedEffect = dnFeatureEffect.includedEffect.map(buildJsEffect);
        }
    }

    return featureEffect;
}

export function buildJsFeatureFilter(dnFeatureFilter: DotNetFeatureFilter): FeatureFilter | null {
    if (dnFeatureFilter === undefined || dnFeatureFilter === null) return null;

    let featureFilter = new FeatureFilter();
    featureFilter.distance = dnFeatureFilter.distance ?? undefined;
    if (hasValue(dnFeatureFilter.geometry)) {
        featureFilter.geometry = buildJsGeometry(dnFeatureFilter.geometry) as Geometry;
    }
    featureFilter.objectIds = dnFeatureFilter.objectIds ?? undefined;
    featureFilter.spatialRelationship = dnFeatureFilter.spatialRelationship ?? undefined;
    featureFilter.timeExtent = dnFeatureFilter.timeExtent ?? undefined;
    if (hasValue(dnFeatureFilter.where)) {
        featureFilter.units = dnFeatureFilter.units as any;
    }
    featureFilter.where = dnFeatureFilter.where ?? undefined;
    return featureFilter;
}

export function buildJsEffect(dnEffect: any): any {

    if (dnEffect.scale != null) {
        return {
            value: dnEffect.value,
            scale: dnEffect.scale
        };
    } else {
        return dnEffect.value;
    }
}

export function buildJsTickConfigs(dotNetTickConfig: any): any {
    if (dotNetTickConfig === undefined || dotNetTickConfig === null) return null;

    let tickCreatedFunction : Function | null = null;
    if (dotNetTickConfig.tickCreatedFunction != null) {
        tickCreatedFunction = new Function(dotNetTickConfig.tickCreatedFunction);
    }

    let labelFormatFunction : Function | null = null;
    if (dotNetTickConfig.labelFormatFunction != null) {
        labelFormatFunction = new Function(dotNetTickConfig.labelFormatFunction);
    }

    let tickConfig = {
        mode: dotNetTickConfig.mode ?? undefined,
        count: dotNetTickConfig.count ?? undefined,
        values: dotNetTickConfig.values ?? undefined,
        labelsVisible: dotNetTickConfig.labelsVisible ?? undefined,
        tickCreatedFunction: tickCreatedFunction ?? undefined,
        labelFormatFunction: labelFormatFunction ?? undefined
    }
    return tickConfig;
}