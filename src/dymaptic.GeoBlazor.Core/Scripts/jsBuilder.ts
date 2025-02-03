import SpatialReference from "@arcgis/core/geometry/SpatialReference";
import Extent from "@arcgis/core/geometry/Extent";
import Graphic from "@arcgis/core/Graphic";
import PopupTemplate from "@arcgis/core/PopupTemplate";
import {
    arcGisObjectRefs,
    createLayer,
    copyValuesIfExists, popupTemplateRefs, dotNetRefs, lookupGraphicById
} from "./arcGisJsInterop";
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
import UniqueValueRenderer from "@arcgis/core/renderers/UniqueValueRenderer.js";
import ColormapInfo from "@arcgis/core/renderers/support/ColormapInfo.js";
import MultidimensionalSubset from "@arcgis/core/layers/support/MultidimensionalSubset.js";
import UniqueValueInfo from "@arcgis/core/renderers/support/UniqueValueInfo.js";
import {
    DotNetAttachmentsPopupContent,
    DotNetBarChartMediaInfo,
    DotNetBookmark,
    DotNetChartMediaInfoValue,
    DotNetClassBreaksRenderer,
    DotNetColormapInfo,
    DotNetColumnChartMediaInfo,
    DotNetElementExpressionInfo,
    DotNetExpressionInfo,
    DotNetExpressionPopupContent,
    DotNetExtent,
    DotNetFeatureEffect,
    DotNetFeatureFilter,
    DotNetFeatureTemplate,
    DotNetFieldInfo,
    DotNetFieldInfoFormat,
    DotNetFieldsPopupContent,
    DotNetFlowRenderer,
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
    DotNetRasterColormapRenderer,
    DotNetRasterShadedReliefRenderer,
    DotNetRasterStretchRenderer,
    DotNetRelationshipQuery,
    DotNetSimpleFillSymbol,
    DotNetSimpleLineSymbol,
    DotNetSimpleMarkerSymbol,
    DotNetSpatialReference,
    DotNetSymbol,
    DotNetTextPopupContent,
    DotNetTextSymbol,
    DotNetTopFeaturesQuery,
    DotNetUniqueValueRenderer,
    DotNetVectorFieldRenderer,
    DotNetViewpoint,
    DotNetVisualVariable, DotNetFeatureSet, DotNetPictureFillSymbol,
} from "./definitions";
import PictureMarkerSymbol from "@arcgis/core/symbols/PictureMarkerSymbol";
import PictureFillSymbol from "@arcgis/core/symbols/PictureFillSymbol";
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
import { buildDotNetGraphic, buildDotNetPoint, buildDotNetSpatialReference } from "./dotNetBuilder";
import FormTemplate from "@arcgis/core/form/FormTemplate";
import Element from "@arcgis/core/form/elements/Element";
import GroupElement from "@arcgis/core/form/elements/GroupElement";
import CodedValueDomain from "@arcgis/core/layers/support/CodedValueDomain";
import RangeDomain from "@arcgis/core/layers/support/RangeDomain";
import TextBoxInput from "@arcgis/core/form/elements/inputs/TextBoxInput";
import TextAreaInput from "@arcgis/core/form/elements/inputs/TextAreaInput";
import DateTimePickerInput from "@arcgis/core/form/elements/inputs/DateTimePickerInput";
import BarcodeScannerInput from "@arcgis/core/form/elements/inputs/BarcodeScannerInput";
import ComboBoxInput from "@arcgis/core/form/elements/inputs/ComboBoxInput";
import RadioButtonsInput from "@arcgis/core/form/elements/inputs/RadioButtonsInput";
import SwitchInput from "@arcgis/core/form/elements/inputs/SwitchInput";
import SearchSource from "@arcgis/core/widgets/Search/SearchSource";
import FeatureTemplate from "@arcgis/core/layers/support/FeatureTemplate";
import ViewClickEvent = __esri.ViewClickEvent;
import PopupOpenOptions = __esri.PopupOpenOptions;
import PopupDockOptions = __esri.PopupDockOptions;
import ContentProperties = __esri.ContentProperties;


import CodedValue = __esri.CodedValue;
import SearchSourceFilter = __esri.SearchSourceFilter;
import SearchResult = __esri.SearchResult;
import SuggestResult = __esri.SuggestResult;
import LabelClass from "@arcgis/core/layers/support/LabelClass";
import VisualVariable from "@arcgis/core/renderers/visualVariables/VisualVariable";
import ColorVariable from "@arcgis/core/renderers/visualVariables/ColorVariable";
import RotationVariable from "@arcgis/core/renderers/visualVariables/RotationVariable";
import SizeVariable from "@arcgis/core/renderers/visualVariables/SizeVariable";
import OpacityVariable from "@arcgis/core/renderers/visualVariables/OpacityVariable";
import FeatureReductionCluster from "@arcgis/core/layers/support/FeatureReductionCluster";
import FeatureReductionBinning from "@arcgis/core/layers/support/FeatureReductionBinning";
import FeatureReductionSelection from "@arcgis/core/layers/support/FeatureReductionSelection";
import AggregateField from "@arcgis/core/layers/support/AggregateField";
import supportExpressionInfo from "@arcgis/core/layers/support/ExpressionInfo";
import PieChartRenderer from "@arcgis/core/renderers/PieChartRenderer";
import AttributeColorInfo from "@arcgis/core/renderers/support/AttributeColorInfo";
import AuthoringInfo from "@arcgis/core/renderers/support/AuthoringInfo";
import AuthoringInfoVisualVariable from "@arcgis/core/renderers/support/AuthoringInfoVisualVariable";
import ActionButton from "@arcgis/core/support/actions/ActionButton";
import ActionToggle from "@arcgis/core/support/actions/ActionToggle";
import FeatureSet from "@arcgis/core/rest/support/FeatureSet";
import Sublayer from "@arcgis/core/layers/support/Sublayer.js";
import DynamicMapLayer = __esri.DynamicMapLayer;
import DynamicDataLayer = __esri.DynamicDataLayer;
import TableDataSource = __esri.TableDataSource;
import QueryTableDataSource = __esri.QueryTableDataSource;
import RasterDataSource = __esri.RasterDataSource;
import JoinTableDataSource = __esri.JoinTableDataSource;
import DynamicDataLayerFields = __esri.DynamicDataLayerFields;
import TickConfig = __esri.TickConfig;
import MapView from "@arcgis/core/views/MapView";

export function buildJsSpatialReference(dotNetSpatialReference: DotNetSpatialReference): SpatialReference {
    if (dotNetSpatialReference === undefined || dotNetSpatialReference === null) {
        return new SpatialReference({ wkid: 4326 });
    }
    let jsSpatialRef = new SpatialReference();
    if (hasValue(dotNetSpatialReference.wkid)) {
        jsSpatialRef.wkid = dotNetSpatialReference.wkid;
    } else if (hasValue(dotNetSpatialReference.wkt)) {
        jsSpatialRef.wkt = dotNetSpatialReference.wkt
    } else if (hasValue(dotNetSpatialReference.wkt2)) {
        jsSpatialRef.wkt2 = dotNetSpatialReference.wkt2
    } else {
        jsSpatialRef.wkid = 4326;
    }

    return jsSpatialRef;
}

export function buildJsExtent(dotNetExtent: DotNetExtent, currentSpatialReference: SpatialReference | null): Extent {
    let extent = new Extent();
    copyValuesIfExists(dotNetExtent, extent, 'xmax', 'xmin', 'ymax', 'ymin', 'zmax', 'zmin', 'mmax', 'mmin');

    if (hasValue(dotNetExtent.spatialReference)) {
        extent.spatialReference = buildJsSpatialReference(dotNetExtent.spatialReference)
    } else if (currentSpatialReference !== null) {
        extent.spatialReference = currentSpatialReference;
    }

    return extent;
}

export function buildJsGraphic(graphicObject: any, layerId: string | null, viewId: string | null)
    : Graphic | null {
    let graphic: Graphic | null = lookupGraphicById(graphicObject.id, layerId, viewId);
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
        graphic.popupTemplate = buildJsPopupTemplate(graphicObject.popupTemplate, viewId) as PopupTemplate;
    }

    copyValuesIfExists(graphicObject, graphic, 'visible');

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
                    case "double":
                    case "single":
                    case "float":
                    case "int":
                        graphicAttributes[attr.key] = Number(attr.value);
                        break;
                    case "boolean":
                        graphicAttributes[attr.key] = attr.value.toLowerCase() === "true";
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

export function buildJsPopupTemplate(popupTemplateObject: DotNetPopupTemplate, viewId: string | null): PopupTemplate | null {
    if (!hasValue(popupTemplateObject)) return null;

    let content;
    if (hasValue(popupTemplateObject.stringContent)) {
        content = popupTemplateObject.stringContent;
    } else if (hasValue(popupTemplateObject.content) && popupTemplateObject.content.length > 0) {
        content = popupTemplateObject.content?.map(buildJsPopupContent);
    } else {
        content = async (featureSelection) => {
            try {
                if (viewId === null || !arcGisObjectRefs.hasOwnProperty(viewId)) {
                    return;
                }
                let viewRef = dotNetRefs[viewId];
                let popupRef = dotNetRefs[popupTemplateObject.id];
                if (!hasValue(popupRef)) {
                    popupRef = await viewRef.invokeMethodAsync('GetDotNetPopupTemplateObjectReference', popupTemplateObject.id);
                    if (hasValue(popupRef)) {
                        dotNetRefs[popupTemplateObject.id] = popupRef;
                    }
                }

                if (!hasValue(popupRef)) return null;
                let results: DotNetPopupContent[] | null = await popupRef
                    .invokeMethodAsync("OnContentFunction", buildDotNetGraphic(featureSelection.graphic));
                return results?.map(buildJsPopupContent);
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
        template.fieldInfos = popupTemplateObject.fieldInfos.map(buildJsFieldInfo);
    }

    if (hasValue(popupTemplateObject.expressionInfos)) {
        template.expressionInfos = popupTemplateObject.expressionInfos.map(buildJsExpressionInfo);
    }

    if (hasValue(popupTemplateObject.actions)) {
        template.actions = popupTemplateObject.actions.map(buildJsAction) as any;
    }

    popupTemplateRefs[popupTemplateObject.id] = template;

    return template;
}

export function buildJsAction(dnAction: any): ActionButton | ActionToggle {
    if (dnAction.type === "button") {
        let jsAction = new ActionButton();
        copyValuesIfExists(dnAction, jsAction, 'active', 'className', 'disabled', 'icon', 'id', 'image', 'title',
            'visible');
        return jsAction;
    }

    let jsAction = new ActionToggle();
    copyValuesIfExists(dnAction, jsAction, 'active', 'disabled', 'icon', 'id', 'title', 'value', 'visible');
    return jsAction;
}

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
            return new TextContent({
                text: dnTextContent.text ?? null
            });
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
            return new AttachmentsContent({
                description: dnAttachmentsContent.description ?? '',
                title: dnAttachmentsContent.title ?? '',
                displayType: dnAttachmentsContent.displayType as any ?? "auto",
            });
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
    let fieldInfo = new FieldInfo();
    copyValuesIfExists(fieldInfoObject, fieldInfo, 'fieldName', 'label', 'tooltip', 'stringFieldOption', 'visible', 'isEditable');

    if (hasValue(fieldInfoObject.format)) {
        fieldInfo.format = buildJsFieldInfoFormat(fieldInfoObject.format);
    }

    return fieldInfo;
}

export function buildJsFieldInfoFormat(formatObject: DotNetFieldInfoFormat): FieldInfoFormat {
    let format = new FieldInfoFormat();
    copyValuesIfExists(formatObject, format, 'dateFormat', 'places', 'digitSeparator');
    return format;
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
                size: dnSimpleMarkerSymbol.size ?? 12, // undefined breaks this
                style: dnSimpleMarkerSymbol.style as any ?? 'circle', // undefined breaks this
                xoffset: dnSimpleMarkerSymbol.xOffset ?? 0,
                yoffset: dnSimpleMarkerSymbol.yOffset ?? 0
            });

            if (hasValue(dnSimpleMarkerSymbol.outline)) {
                jsSimpleMarkerSymbol.outline = buildJsSymbol(dnSimpleMarkerSymbol.outline) as any;
            }
            return jsSimpleMarkerSymbol;
        case "simple-line":
            let dnSimpleLineSymbol = symbol as DotNetSimpleLineSymbol;
            return new SimpleLineSymbol({
                color: buildJsColor(dnSimpleLineSymbol.color) ?? "black",
                cap: dnSimpleLineSymbol.cap as any ?? "round",
                join: dnSimpleLineSymbol.join as any ?? "round",
                marker: dnSimpleLineSymbol.marker as any ?? null,
                miterLimit: dnSimpleLineSymbol.miterLimit ?? 2,
                style: dnSimpleLineSymbol.lineStyle as any ?? dnSimpleLineSymbol.style as any ?? "solid",
                width: dnSimpleLineSymbol.width ?? 0.75
            });
        case "picture-marker":
            let dnPictureMarkerSymbol = symbol as DotNetPictureMarkerSymbol;
            return new PictureMarkerSymbol({
                angle: dnPictureMarkerSymbol.angle ?? 0,
                xoffset: dnPictureMarkerSymbol.xOffset ?? 0,
                yoffset: dnPictureMarkerSymbol.yOffset ?? 0,
                height: dnPictureMarkerSymbol.height ?? 12,
                width: dnPictureMarkerSymbol.width ?? 12,
                url: dnPictureMarkerSymbol.url
            });

        case "picture-fill":
            let dnPictureFillSymbol = symbol as DotNetPictureFillSymbol;
            let jsFillSymbol = new PictureFillSymbol({
                url: dnPictureFillSymbol.url,
                width: dnPictureFillSymbol.width ?? 12,
                height: dnPictureFillSymbol.height ?? 12,
                xoffset: dnPictureFillSymbol.xOffset ?? 0,
                yoffset: dnPictureFillSymbol.yOffset ?? 0,
                xscale: dnPictureFillSymbol.xScale ?? 1,
                yscale: dnPictureFillSymbol.yScale ?? 1
            });
            if (hasValue(dnPictureFillSymbol.outline)) {
                jsFillSymbol.outline = buildJsSymbol(dnPictureFillSymbol.outline) as any;
            }

            return jsFillSymbol;

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
                text: dotNetTextSymbol.text ?? undefined
            });
            copyValuesIfExists(dotNetTextSymbol, jsTextSymbol, 'angle', 'borderLineSize', 'haloSize',
                'horizontalAlignment', 'kerning', 'lineHeight', 'lineWidth', 'rotated', 'text', 'verticalAlignment');

            if (hasValue(dotNetTextSymbol.backgroundColor)) {
                jsTextSymbol.backgroundColor = buildJsColor(dotNetTextSymbol.backgroundColor);
            }
            if (hasValue(dotNetTextSymbol.borderLineColor)) {
                jsTextSymbol.borderLineColor = buildJsColor(dotNetTextSymbol.borderLineColor);
            }
            if (hasValue(dotNetTextSymbol.color)) {
                jsTextSymbol.color = buildJsColor(dotNetTextSymbol.color);
            }
            if (hasValue(dotNetTextSymbol.font)) {
                jsTextSymbol.font = buildJsFont(dotNetTextSymbol.font);
            }
            if (hasValue(dotNetTextSymbol.haloColor)) {
                jsTextSymbol.haloColor = buildJsColor(dotNetTextSymbol.haloColor);
            }
            if (hasValue(dotNetTextSymbol.xOffset)) {
                jsTextSymbol.xoffset = dotNetTextSymbol.xOffset;
            }
            if (hasValue(dotNetTextSymbol.yOffset)) {
                jsTextSymbol.yoffset = dotNetTextSymbol.yOffset;
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
        bookmark.thumbnail = { url: dnBookmark.thumbnail };
    }

    if (hasValue(dnBookmark.viewpoint)) {
        bookmark.viewpoint = buildJsViewpoint(dnBookmark.viewpoint) as Viewpoint;
    }

    return bookmark as Bookmark;
}

export function buildJsViewpoint(dnViewpoint: DotNetViewpoint): Viewpoint | null {
    if (dnViewpoint === undefined || dnViewpoint === null) return null;
    let viewpoint = new Viewpoint();
    copyValuesIfExists(dnViewpoint, viewpoint, 'rotation', 'scale');
    viewpoint.targetGeometry = buildJsGeometry(dnViewpoint.targetGeometry) as Geometry;
    return viewpoint as Viewpoint;
}

export function buildJsPoint(dnPoint: DotNetPoint): Point | null {
    if (dnPoint === undefined || dnPoint === null) return null;
    let point = new Point();

    copyValuesIfExists(dnPoint, point, 'latitude', 'longitude', 'x', 'y', 'z', 'm');

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
    if (!hasValue(dotNetRenderer)) return null;
    let dotNetSymbol = dotNetRenderer.symbol;
    switch (dotNetRenderer.type) {
        case 'simple':
            let simpleRenderer = new SimpleRenderer();
            if (hasValue(dotNetRenderer.visualVariables) && dotNetRenderer.visualVariables.length > 0) {
                simpleRenderer.visualVariables = dotNetRenderer.visualVariables.map(buildVisualVariable);
            }
            if (hasValue(dotNetSymbol)) {
                simpleRenderer.symbol = buildJsSymbol(dotNetSymbol) as Symbol;
            }
            copyValuesIfExists(dotNetRenderer, simpleRenderer, 'label', 'authoringInfo');
            return simpleRenderer;
        case 'pie-chart':
            let pieChartRenderer = new PieChartRenderer();
            if (hasValue(dotNetRenderer.attributes) && dotNetRenderer.attributes.length > 0) {
                pieChartRenderer.attributes = dotNetRenderer.attributes.map(buildJsAttributeColorInfo);
            }
            if (hasValue(dotNetRenderer.authoringInfo)) {
                pieChartRenderer.authoringInfo = buildJsAuthoringInfo(dotNetRenderer.authoringInfo);
            }
            if (hasValue(dotNetRenderer.backgroundFillSymbol)) {
                pieChartRenderer.backgroundFillSymbol = buildJsSymbol(dotNetRenderer.backgroundFillSymbol) as SimpleFillSymbol;
            }
            if (hasValue(dotNetRenderer.defaultColor)) {
                pieChartRenderer.defaultColor = buildJsColor(dotNetRenderer.defaultColor);
            }
            if (hasValue(dotNetRenderer.legendOptions)) {
                pieChartRenderer.legendOptions = {
                    title: dotNetRenderer.legendOptions.title
                };
            }
            if (hasValue(dotNetRenderer.othersCategory)) {
                pieChartRenderer.othersCategory = {};
                if (hasValue(dotNetRenderer.othersCategory.color)) {
                    pieChartRenderer.othersCategory.color = buildJsColor(dotNetRenderer.othersCategory.color);
                }
                if (hasValue(dotNetRenderer.othersCategory.label)) {
                    pieChartRenderer.othersCategory.label = dotNetRenderer.othersCategory.label;
                }
                if (hasValue(dotNetRenderer.othersCategory.threshold)) {
                    pieChartRenderer.othersCategory.threshold = dotNetRenderer.othersCategory.threshold;
                }
            }
            if (hasValue(dotNetRenderer.outline)) {
                pieChartRenderer.outline = buildJsSymbol(dotNetRenderer.outline) as SimpleLineSymbol;
            }
            if (hasValue(dotNetRenderer.visualVariables) && dotNetRenderer.visualVariables.length > 0) {
                pieChartRenderer.visualVariables = dotNetRenderer.visualVariables.map(buildVisualVariable);
            }
            copyValuesIfExists(dotNetRenderer, pieChartRenderer, 'defaultLabel', 'holePercentage', 'size');

            return pieChartRenderer;
        case 'unique-value':
            return buildJsUniqueValueRenderer(dotNetRenderer);
    }
    return dotNetRenderer;
}

export function buildJsRasterColormapRenderer(dotNetRasterColormapRenderer: DotNetRasterColormapRenderer): RasterColormapRenderer | null {
    if (dotNetRasterColormapRenderer === undefined) return null;
    let rasterColormapRender = new RasterColormapRenderer();
    if (hasValue(dotNetRasterColormapRenderer.colormapInfos)) {
        rasterColormapRender.colormapInfos = dotNetRasterColormapRenderer.colormapInfos.map(buildJsColormapInfo) as ColormapInfo[];
    }
    return rasterColormapRender;
}

export function buildJsColormapInfo(dotNetColormapInfo: DotNetColormapInfo): ColormapInfo | null {
    if (dotNetColormapInfo === undefined) return null;
    let colormapInfo = new ColormapInfo();

    if (hasValue(dotNetColormapInfo.color)) {
        colormapInfo.color = buildJsColor(dotNetColormapInfo.color);
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
        rasterShadedReliefRenderer.azimuth = dnRasterShadedReliefRenderer.azimuth;
    }
    if (hasValue(dnRasterShadedReliefRenderer.colorRamp)) {
        rasterShadedReliefRenderer.colorRamp = buildJsColorRamp(dnRasterShadedReliefRenderer.colorRamp) as ColorRamp;
    }
    if (hasValue(dnRasterShadedReliefRenderer.hillshadeType)) {
        rasterShadedReliefRenderer.hillshadeType = dnRasterShadedReliefRenderer.hillshadeType as any;
    }
    if (hasValue(dnRasterShadedReliefRenderer.pixelSizeFactor)) {
        rasterShadedReliefRenderer.pixelSizeFactor = dnRasterShadedReliefRenderer.pixelSizeFactor;
    }
    if (hasValue(dnRasterShadedReliefRenderer.pixelSizePower)) {
        rasterShadedReliefRenderer.pixelSizePower = dnRasterShadedReliefRenderer.pixelSizePower;
    }
    if (hasValue(dnRasterShadedReliefRenderer.pixelSizePower)) {
        rasterShadedReliefRenderer.pixelSizePower = dnRasterShadedReliefRenderer.pixelSizePower;
    }
    if (hasValue(dnRasterShadedReliefRenderer.scalingType)) {
        rasterShadedReliefRenderer.scalingType = dnRasterShadedReliefRenderer.scalingType as any;
    }
    if (hasValue(dnRasterShadedReliefRenderer.zFactor)) {
        rasterShadedReliefRenderer.zFactor = dnRasterShadedReliefRenderer.zFactor;
    }
    return rasterShadedReliefRenderer;
}

export function buildJsImageryRenderer(dnRenderer: any) {
    switch (dnRenderer?.imageryRendererType) {
        case 'unique-value':
            return buildJsUniqueValueRenderer(dnRenderer);
        case 'raster-stretch':
            return buildJsRasterStretchRenderer(dnRenderer);
    }

    return null;
}

export function buildJsUniqueValueRenderer(dnUniqueValueRenderer: DotNetUniqueValueRenderer): UniqueValueRenderer | null {
    if (dnUniqueValueRenderer === undefined) return null;

    // Setting this by calling the class constructor breaks the Legend widget for some reason.
    let uniqueValueRenderer: any = {
        type: 'unique-value'
    };
    if (hasValue(dnUniqueValueRenderer.backgroundFillSymbol)) {
        if (dnUniqueValueRenderer.backgroundFillSymbol.type == "FillSymbol") {
            uniqueValueRenderer.backgroundFillSymbol = buildJsSymbol(dnUniqueValueRenderer.backgroundFillSymbol) as SimpleFillSymbol;
        }
        // Note: The PolygonSymbol3d is not currently supported
    }

    copyValuesIfExists(dnUniqueValueRenderer, uniqueValueRenderer, 'defaultLabel', 'field', 'field2', 'field3',
        'fieldDelimiter', 'orderByClassesEnabled', 'valueExpression', 'valueExpressionTitle');

    if (hasValue(dnUniqueValueRenderer.legendOptions)) {
        uniqueValueRenderer.legendOptions = {
            title: dnUniqueValueRenderer.legendOptions.title
        };
    }

    if (hasValue(dnUniqueValueRenderer.defaultSymbol?.symbol)) {
        uniqueValueRenderer.defaultSymbol = buildJsSymbol(dnUniqueValueRenderer.defaultSymbol.symbol) as Symbol;
    }

    if (hasValue(dnUniqueValueRenderer.uniqueValueInfos) && dnUniqueValueRenderer.uniqueValueInfos.length > 0) {
        uniqueValueRenderer.uniqueValueInfos = [];
        for (let i = 0; i < dnUniqueValueRenderer.uniqueValueInfos.length; i++) {
            let dnUniqueValueInfo = dnUniqueValueRenderer.uniqueValueInfos[i];
            let uniqueValueInfo = new UniqueValueInfo();
            copyValuesIfExists(dnUniqueValueInfo, uniqueValueInfo, 'label', 'value');
            if (hasValue(dnUniqueValueInfo.symbol)) {
                uniqueValueInfo.symbol = buildJsSymbol(dnUniqueValueInfo.symbol) as Symbol;
            }
            uniqueValueRenderer.uniqueValueInfos.push(uniqueValueInfo);
        }
    }

    if (hasValue(dnUniqueValueRenderer.visualVariables) && dnUniqueValueRenderer.visualVariables.length > 0) {
        uniqueValueRenderer.visualVariables = dnUniqueValueRenderer.visualVariables.map(buildJsVisualVariable) as VisualVariable[];
    }
    return uniqueValueRenderer;
}

export function buildJsClassBreaksRenderer(dnClassBreaksRenderer: DotNetClassBreaksRenderer): ClassBreaksRenderer | null {
    if (dnClassBreaksRenderer === undefined) return null;
    let classBreaksRenderer = new ClassBreaksRenderer();
    //Implements only the simple fill symbol PolygonSymbol3d is another option but can be implemented later
    if (hasValue(dnClassBreaksRenderer.defaultLabel)) {
        classBreaksRenderer.defaultLabel = dnClassBreaksRenderer.defaultLabel;
    }
    if (hasValue(dnClassBreaksRenderer.defaultSymbol)) {
        classBreaksRenderer.defaultSymbol = buildJsSymbol(dnClassBreaksRenderer.defaultSymbol) as Symbol;
    }
    if (hasValue(dnClassBreaksRenderer.field)) {
        classBreaksRenderer.field = dnClassBreaksRenderer.field;
    }
    if (hasValue(dnClassBreaksRenderer.normalizationField)) {
        classBreaksRenderer.normalizationField = dnClassBreaksRenderer.normalizationField;
    }
    if (hasValue(dnClassBreaksRenderer.normalizationTotal)) {
        classBreaksRenderer.normalizationTotal = dnClassBreaksRenderer.normalizationTotal;
    }
    if (hasValue(dnClassBreaksRenderer.normalizationType)) {
        classBreaksRenderer.normalizationType = dnClassBreaksRenderer.normalizationType as any;
    }
    if (hasValue(dnClassBreaksRenderer.valueExpression)) {
        classBreaksRenderer.valueExpression = dnClassBreaksRenderer.valueExpression;
    }
    if (hasValue(dnClassBreaksRenderer.valueExpressionTitle)) {
        classBreaksRenderer.valueExpressionTitle = dnClassBreaksRenderer.valueExpressionTitle;
    }
    if (hasValue(dnClassBreaksRenderer.visualVariables)) {
        classBreaksRenderer.visualVariables = dnClassBreaksRenderer.visualVariables.map(buildJsVisualVariable) as VisualVariable[];
    }
    return classBreaksRenderer;
}

export function buildJsVectorFieldRenderer(dotNetVectorFieldRenderer: DotNetVectorFieldRenderer): VectorFieldRenderer | null {
    if (dotNetVectorFieldRenderer === undefined) return null;
    let vectorFieldRenderer = new VectorFieldRenderer();

    if (hasValue(dotNetVectorFieldRenderer.flowRepresentation)) {
        vectorFieldRenderer.flowRepresentation = dotNetVectorFieldRenderer.flowRepresentation as any;
    }
    if (hasValue(dotNetVectorFieldRenderer.style)) {
        vectorFieldRenderer.style = dotNetVectorFieldRenderer.style as any;
    }
    if (hasValue(dotNetVectorFieldRenderer.symbolTileSize)) {
        vectorFieldRenderer.symbolTileSize = dotNetVectorFieldRenderer.symbolTileSize;
    }
    if (hasValue(dotNetVectorFieldRenderer.visualVariables)) {
        vectorFieldRenderer.visualVariables = dotNetVectorFieldRenderer.visualVariables.map(buildJsVisualVariable) as VisualVariable[];
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
        flowRenderer.authoringInfo = buildJsAuthoringInfo(dotNetFlowRenderer.authoringInfo);
    }
    if (hasValue(dotNetFlowRenderer.color)) {
        flowRenderer.color = buildJsColor(dotNetFlowRenderer.color);
    }
    if (hasValue(dotNetFlowRenderer.density)) {
        flowRenderer.density = dotNetFlowRenderer.density;
    }
    if (hasValue(dotNetFlowRenderer.flowRepresentation)) {
        flowRenderer.flowRepresentation = dotNetFlowRenderer.flowRepresentation as any;
    }
    if (hasValue(dotNetFlowRenderer.flowSpeed)) {
        flowRenderer.flowSpeed = dotNetFlowRenderer.flowSpeed;
    }
    if (hasValue(dotNetFlowRenderer.maxPathLength)) {
        flowRenderer.maxPathLength = dotNetFlowRenderer.maxPathLength;
    }
    if (hasValue(dotNetFlowRenderer.trailCap)) {
        flowRenderer.trailCap = dotNetFlowRenderer.trailCap as any;
    }
    if (hasValue(dotNetFlowRenderer.trailLength)) {
        flowRenderer.trailLength = dotNetFlowRenderer.trailLength;
    }
    if (hasValue(dotNetFlowRenderer.trailWidth)) {
        flowRenderer.trailWidth = dotNetFlowRenderer.trailWidth;
    }
    if (hasValue(dotNetFlowRenderer.visualVariables)) {
        flowRenderer.visualVariables = dotNetFlowRenderer.visualVariables.map(buildJsVisualVariable) as VisualVariable[];
    }
    return flowRenderer;
}

function buildJsAttributeColorInfo(dnColorInfo: any): AttributeColorInfo {

    let attributeColorInfo = new AttributeColorInfo();
    if (hasValue(dnColorInfo.color)) {
        attributeColorInfo.color = buildJsColor(dnColorInfo.color);
    }
    copyValuesIfExists(dnColorInfo, attributeColorInfo, 'field', 'label', 'valueExpression',
        'valueExpressionTitle');
    return attributeColorInfo;
}

function buildJsAuthoringInfo(dnAuthoringInfo: any): AuthoringInfo {
    let authoringInfo = new AuthoringInfo();
    copyValuesIfExists(dnAuthoringInfo, authoringInfo, 'classificationMethod', 'fadeRatio', 'fields',
        'flowTheme', 'focus', 'isAutoGenerated', 'lengthUnit', 'maxSliderValue', 'minSliderValue',
        'standardDeviationInterval', 'type', 'univariateSymbolStyle', 'univariateTheme');
    if (hasValue(dnAuthoringInfo.colorRamp)) {
        authoringInfo.colorRamp = buildJsColorRamp(dnAuthoringInfo.colorRamp) as ColorRamp;
    }
    if (hasValue(dnAuthoringInfo.field1)) {
        authoringInfo.field1 = {
            field: dnAuthoringInfo.field1.field,
            normalizationField: dnAuthoringInfo.field1.normalizationField,
            classBreakInfos: dnAuthoringInfo.field1.classBreakInfos.map((cbi: any) => {
                return {
                    maxValue: cbi.maxValue,
                    minValue: cbi.minValue
                }
            }),
            label: dnAuthoringInfo.field1.label
        }
    }
    if (hasValue(dnAuthoringInfo.field2)) {
        authoringInfo.field2 = {
            field: dnAuthoringInfo.field2.field,
            normalizationField: dnAuthoringInfo.field2.normalizationField,
            classBreakInfos: dnAuthoringInfo.field2.classBreakInfos.map((cbi: any) => {
                return {
                    maxValue: cbi.maxValue,
                    minValue: cbi.minValue
                }
            }),
            label: dnAuthoringInfo.field2.label
        }
    }

    if (hasValue(dnAuthoringInfo.statistics)) {
        authoringInfo.statistics = {
            max: dnAuthoringInfo.statistics.max,
            min: dnAuthoringInfo.statistics.min
        };
    }

    if (hasValue(dnAuthoringInfo.visualVariables)) {
        authoringInfo.visualVariables = dnAuthoringInfo.visualVariables.map(buildAuthoringVisualVariable);
    }

    return authoringInfo;
}

function buildAuthoringVisualVariable(dnVV: any): AuthoringInfoVisualVariable {
    let authVV = new AuthoringInfoVisualVariable();
    copyValuesIfExists(dnVV, authVV, 'endTime', 'field', 'maxSliderValue', 'minSliderValue', 'startTime',
        'style', 'theme', 'type', 'units');
    return authVV;
}

export function buildJsLabelClass(dotNetLabel: any): LabelClass | null {
    if (!hasValue(dotNetLabel)) return null;
    let labelClass = new LabelClass();
    copyValuesIfExists(dotNetLabel, labelClass, 'labelExpression', 'labelPlacement', 'labelPosition', 'maxScale',
        'minScale', 'repeatLabel', 'repeatLabelDistance', 'useCodedValues', 'where', 'deconflictionStrategy');
    if (hasValue(dotNetLabel.symbol)) {
        labelClass.symbol = buildJsSymbol(dotNetLabel.symbol) as any;
    }
    if (hasValue(dotNetLabel.labelExpressionInfo)) {
        labelClass.labelExpressionInfo = buildJsLabelExpressionInfo(dotNetLabel.labelExpressionInfo);
    }
    return labelClass;
}

export function buildJsLabelExpressionInfo(dotNetLabelExpressionInfo: any): any {
    if (!hasValue(dotNetLabelExpressionInfo)) return null;
    let jsLabelExpressionInfo = {};
    copyValuesIfExists(dotNetLabelExpressionInfo, jsLabelExpressionInfo, 'expression', 'title');
    return jsLabelExpressionInfo;
}

export function buildVisualVariable(dnVV: any): VisualVariable | null {
    if (!hasValue(dnVV)) return null;
    let variable = {
        type: dnVV.type
    } as VisualVariable;
    copyValuesIfExists(dnVV, variable, 'field', 'legendOptions', 'valueExpression', 'valueExpressionTitle');
    switch (dnVV.type) {
        case "color":
            let colorVariable = variable as ColorVariable;
            colorVariable.normalizationField = dnVV.normalizationField ?? undefined;
            if (hasValue(dnVV.stops) && dnVV.stops.length > 0) {
                colorVariable.stops = dnVV.stops.map((stop: any) => {
                    let dnStop: any = {};
                    copyValuesIfExists(stop, dnStop, 'label', 'value');
                    if (hasValue(stop.color)) {
                        dnStop.color = buildJsColor(stop.color);
                    }
                    return dnStop;
                });
            }

            return colorVariable;
        case "rotation":
            let rotationVariable = variable as RotationVariable;
            copyValuesIfExists(dnVV, rotationVariable, 'axis', 'rotationType');
            return rotationVariable;
        case "size":
            let sizeVariable = variable as SizeVariable;
            copyValuesIfExists(dnVV, sizeVariable, 'axis', 'maxDataValue', 'minDataValue', 'minSize', 'maxSize',
                'normalizationField', 'target', 'useSymbolValue', 'valueUnit');

            if (hasValue(dnVV.stops) && dnVV.stops.length > 0) {
                sizeVariable.stops = dnVV.stops.map((stop: any) => {
                    let dnStop = {};
                    copyValuesIfExists(stop, dnStop, 'label', 'size', 'value');
                    return dnStop;
                });
            }
            return sizeVariable;
        case "opacity":
            let opacityVariable = variable as OpacityVariable;
            if (hasValue(dnVV.stops) && dnVV.stops.length > 0) {
                opacityVariable.stops = dnVV.stops.map((stop: any) => {
                    let dnStop: any = {};
                    copyValuesIfExists(stop, dnStop, 'label', 'opacity', 'value');
                    return dnStop;
                });
            }
            if (hasValue(opacityVariable.normalizationField)) {
                opacityVariable.normalizationField = dnVV.normalizationField;
            }
            return opacityVariable;
    }

    return null;
}

export function buildJsRasterStretchRenderer(dotNetRasterStretchRenderer: DotNetRasterStretchRenderer): RasterStretchRenderer | null {
    if (dotNetRasterStretchRenderer === undefined) return null;
    let rasterStretchRenderer = new RasterStretchRenderer();

    if (hasValue(dotNetRasterStretchRenderer.colorRamp)) {
        rasterStretchRenderer.colorRamp = buildJsColorRamp(dotNetRasterStretchRenderer.colorRamp) as ColorRamp;
    }

    copyValuesIfExists(dotNetRasterStretchRenderer, rasterStretchRenderer, 'computeGamma',
        'dynamicRangeAdjustment', 'gamma', 'useGamma', 'outputMax', 'outputMin', 'stretchType',
        'statistics', 'numberOfStandardDeviations');

    arcGisObjectRefs[dotNetRasterStretchRenderer.id] = rasterStretchRenderer;

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
        alignment: dotNetPopup.alignment ?? "auto",
        content: dotNetPopup.content ?? null,
        title: dotNetPopup.title ?? null,
        visible: dotNetPopup.visible ?? false,
        dockEnabled: dotNetPopup.dockEnabled ?? false,
        autoCloseEnabled: dotNetPopup.autoCloseEnabled ?? false,
        collapseEnabled: dotNetPopup.collapseEnabled ?? true,
        defaultPopupTemplateEnabled: dotNetPopup.defaultPopupTemplateEnabled ?? false,
        headingLevel: dotNetPopup.headingLevel ?? 2,
        highlightEnabled: dotNetPopup.highlightEnabled ?? true,
        label: dotNetPopup.label ?? '',
        spinnerEnabled: dotNetPopup.spinnerEnabled ?? true
    });

    if (hasValue(dotNetPopup.autoOpenEnabled)) {
        let view = arcGisObjectRefs[viewId] as MapView;
        if (hasValue(view)) {
            view.popupEnabled = dotNetPopup.autoOpenEnabled;
        }
    }

    if (hasValue(dotNetPopup.actions)) {
        popup.actions = dotNetPopup.actions.map(buildJsAction) as any;
    }

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
            let graphic = buildJsGraphic(f, f.layerId, viewId) as Graphic;
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
            let graphic = buildJsGraphic(f, f.layerId, null) as Graphic;
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

export function buildJsFormTemplate(dotNetFormTemplate: any): FormTemplate {
    let formTemplate = new FormTemplate({
        title: dotNetFormTemplate.title ?? undefined,
        description: dotNetFormTemplate.description ?? undefined,
        preserveFieldValuesWhenHidden: dotNetFormTemplate.preserveFieldValuesWhenHidden ?? undefined
    });
    if (hasValue(dotNetFormTemplate?.elements)) {
        formTemplate.elements = dotNetFormTemplate.elements.map(buildJsFormTemplateElement);
    }
    if (hasValue(dotNetFormTemplate.expressionInfos)) {
        formTemplate.expressionInfos = dotNetFormTemplate.expressionInfos.map(buildJsExpressionInfo);
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

export function buildJsFeatureTemplate(dnFeatureTemplate: DotNetFeatureTemplate, viewId: string | null): FeatureTemplate {
    return {
        name: dnFeatureTemplate.name,
        description: dnFeatureTemplate.description,
        drawingTool: dnFeatureTemplate.drawingTool as any,
        thumbnail: dnFeatureTemplate.thumbnail as any,
        prototype: buildJsGraphic(dnFeatureTemplate.prototype, null, viewId)
    } as FeatureTemplate
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

    let tickCreatedFunction: Function | null = null;
    if (dotNetTickConfig.tickCreatedFunction != null) {
        tickCreatedFunction = new Function(dotNetTickConfig.tickCreatedFunction);
    }

    let labelFormatFunction: Function | null = null;
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

export async function buildJsSearchSource(dotNetSource: any, viewId: string): Promise<SearchSource> {
    let source: any = {
        autoNavigate: dotNetSource.autoNavigate ?? undefined,
        filter: buildJsSearchSourceFilter(dotNetSource.filter) ?? undefined,
        maxResults: dotNetSource.maxResults ?? undefined,
        minSuggestCharacters: dotNetSource.minSuggestCharacters ?? undefined,
        name: dotNetSource.name ?? undefined,
        outFields: dotNetSource.outFields ?? undefined,
        placeholder: dotNetSource.placeholder ?? undefined,
        popupEnabled: dotNetSource.popupEnabled ?? undefined,
        prefix: dotNetSource.prefix ?? undefined,
        resultGraphicEnabled: dotNetSource.resultGraphicEnabled ?? undefined,
        searchTemplate: dotNetSource.searchTemplate ?? undefined,
        suffix: dotNetSource.suffix ?? undefined,
        suggestionsEnabled: dotNetSource.suggestionsEnabled ?? undefined,
        zoomScale: dotNetSource.zoomScale ?? undefined
    };

    if (hasValue(dotNetSource.popupTemplate)) {
        source.popupTemplate = buildJsPopupTemplate(dotNetSource.popupTemplate, viewId);
    }

    if (hasValue(dotNetSource.resultSymbol)) {
        source.resultSymbol = buildJsSymbol(dotNetSource.resultSymbol);
    }

    if (dotNetSource.hasGetResultsHandler) {
        source.getResults = async (params: any) => {
            let viewId: string | null = null;

            for (let key in arcGisObjectRefs) {
                if (arcGisObjectRefs[key] === params.view) {
                    viewId = key;
                    break;
                }
            }

            let dnParams = {
                exactMatch: params.exactMatch,
                location: buildDotNetPoint(params.location),
                maxResults: params.maxResults,
                sourceIndex: params.sourceIndex,
                spatialReference: buildDotNetSpatialReference(params.spatialReference),
                suggestResult: {
                    key: params.suggestResult.key,
                    text: params.suggestResult.text,
                    sourceIndex: params.suggestResult.sourceIndex
                },
                viewId: viewId
            }
            let dnResults = await dotNetSource.searchSourceObjectReference.invokeMethodAsync('OnJavaScriptGetResults', dnParams);

            let results: SearchResult[] = [];

            for (let dnResult of dnResults) {
                let result: any = {
                    extent: buildJsExtent(dnResult.extent, null) ?? undefined,
                    name: dnResult.name ?? undefined,
                };
                if (hasValue(dnResult.feature)) {
                    result.feature = buildJsGraphic(dnResult.feature, dnResult.feature?.layerId, viewId) as Graphic;
                }
                results.push(result);
            }

            return results;
        }
    }

    if (dotNetSource.hasGetSuggestionsHandler) {
        source.getSuggestions = async (params: any) => {
            let viewId: string | null = null;

            for (let key in arcGisObjectRefs) {
                if (arcGisObjectRefs[key] === params.view) {
                    viewId = key;
                    break;
                }
            }

            let dnParams = {
                maxSuggestions: params.maxSuggestions,
                sourceIndex: params.sourceIndex,
                spatialReference: buildDotNetSpatialReference(params.spatialReference),
                suggestTerm: params.suggestTerm,
                viewId: viewId
            }
            let dnResults = await dotNetSource.searchSourceObjectReference.invokeMethodAsync('OnJavaScriptGetSuggestions', dnParams);

            let results: SuggestResult[] = [];

            for (let dnResult of dnResults) {
                results.push({
                    key: dnResult.key,
                    text: dnResult.text,
                    sourceIndex: dnResult.sourceIndex
                })
            }

            return results;
        }
    }

    switch (dotNetSource.type) {
        case "layer":
            let layer: Layer | null = null;
            if (hasValue(dotNetSource.layerId)) {
                layer = arcGisObjectRefs[dotNetSource.layerId] as Layer;
            }
            if (!hasValue(layer) && hasValue(dotNetSource.layer)) {
                layer = await createLayer(dotNetSource.layer, false, viewId);
            }
            source.layer = layer;
            source.displayField = dotNetSource.displayField ?? undefined;
            source.exactMatch = dotNetSource.exactMatch ?? undefined;
            source.orderByFields = dotNetSource.orderByFields ?? undefined;
            source.searchFields = dotNetSource.searchFields ?? undefined;
            source.suggestionTemplate = dotNetSource.suggestionTemplate ?? undefined;

            break;
        case "locator":
            source.apiKey = dotNetSource.apiKey ?? undefined;
            source.categories = dotNetSource.categories ?? undefined;
            source.countryCode = dotNetSource.countryCode ?? undefined;
            source.defaultZoomScale = dotNetSource.defaultZoomScale ?? undefined;
            source.localSearchDisabled = dotNetSource.localSearchDisabled ?? undefined;
            source.locationType = dotNetSource.locationType ?? undefined;
            source.singleLineFieldName = dotNetSource.singleLineFieldName ?? undefined;
            source.url = dotNetSource.url ?? undefined;

            break;
    }

    return source as SearchSource;
}

function buildJsSearchSourceFilter(dotNetFilter: any): SearchSourceFilter | null {
    if (!hasValue(dotNetFilter)) return null;

    let filter: SearchSourceFilter = {
        where: dotNetFilter.where ?? undefined,
        geometry: buildJsGeometry(dotNetFilter.geometry) ?? undefined
    };

    return filter;
}

export function buildJsFeatureReduction(dnFeatureReduction: any, viewId: string | null): any {
    if (!hasValue(dnFeatureReduction)) return null;
    switch (dnFeatureReduction.type) {
        case 'cluster':
            let cluster = new FeatureReductionCluster();
            if (hasValue(dnFeatureReduction.fields) && dnFeatureReduction.fields.length > 0) {
                cluster.fields = dnFeatureReduction.fields.map(buildJsAggregateField);
            }
            if (hasValue(dnFeatureReduction.labelingInfo) && dnFeatureReduction.labelingInfo.length > 0) {
                cluster.labelingInfo = dnFeatureReduction.labelingInfo.map(buildJsLabelClass);
            }
            if (hasValue(dnFeatureReduction.popupTemplate)) {
                cluster.popupTemplate = buildJsPopupTemplate(dnFeatureReduction.popupTemplate, viewId) as PopupTemplate;
            }
            if (hasValue(dnFeatureReduction.renderer)) {
                cluster.renderer = buildJsRenderer(dnFeatureReduction.renderer) as Renderer;
            }
            if (hasValue(dnFeatureReduction.symbol)) {
                cluster.symbol = buildJsSymbol(dnFeatureReduction.symbol) as any;
            }
            copyValuesIfExists(dnFeatureReduction, cluster, 'clusterMaxSize', 'clusterMinSize', 'clusterRadius',
                'labelsVisible', 'maxScale', 'popupEnabled');
            return cluster;
        case 'binning':
            return {
                type: 'binning',
                fields: dnFeatureReduction.fields?.map(buildJsAggregateField) ?? undefined,
                fixedBinLevel: dnFeatureReduction.fixedBinLevel ?? undefined,
                labelingInfo: dnFeatureReduction.labelingInfo?.map(buildJsLabelClass) ?? undefined,
                labelsVisible: dnFeatureReduction.labelsVisible ?? undefined,
                maxScale: dnFeatureReduction.maxScale ?? undefined,
                popupEnabled: dnFeatureReduction.popupEnabled ?? true,
                popupTemplate: buildJsPopupTemplate(dnFeatureReduction.popupTemplate, viewId) ?? undefined,
                renderer: buildJsRenderer(dnFeatureReduction.renderer) ?? undefined
            } as FeatureReductionBinning;
            let binning = new FeatureReductionBinning();
            if (hasValue(dnFeatureReduction.fields) && dnFeatureReduction.fields.length > 0) {
                binning.fields = dnFeatureReduction.fields.map(buildJsAggregateField);
            }
            if (hasValue(dnFeatureReduction.labelingInfo) && dnFeatureReduction.labelingInfo.length > 0) {
                binning.labelingInfo = dnFeatureReduction.labelingInfo.map(buildJsLabelClass);
            }
            if (hasValue(dnFeatureReduction.popupTemplate)) {
                binning.popupTemplate = buildJsPopupTemplate(dnFeatureReduction.popupTemplate, viewId) as PopupTemplate;
            }
            if (hasValue(dnFeatureReduction.renderer)) {
                binning.renderer = buildJsRenderer(dnFeatureReduction.renderer) as Renderer;
            }
        case 'selection':
            return new FeatureReductionSelection();
    }
}

function buildJsAggregateField(dnAggregateField: any): AggregateField {
    return new AggregateField({
        alias: dnAggregateField.alias ?? undefined,
        isAutoGenerated: dnAggregateField.isAutoGenerated ?? undefined,
        name: dnAggregateField.name ?? undefined,
        onStatisticExpression: buildJsSupportExpressionInfo(dnAggregateField.onStatisticExpression) ?? undefined,
        onStatisticField: dnAggregateField.onStatisticField ?? undefined,
        statisticType: dnAggregateField.statisticType ?? undefined
    });
}

function buildJsSupportExpressionInfo(dnEI: any): supportExpressionInfo | null {
    if (!hasValue(dnEI)) return null;
    return {
        expression: dnEI.expression ?? undefined,
        returnType: dnEI.returnType ?? undefined,
        title: dnEI.title ?? undefined
    } as supportExpressionInfo;
}

export function buildJsFeatureSet(dnFs: DotNetFeatureSet, viewId: string | null): FeatureSet {
    let jsFeatureSet = new FeatureSet();
    copyValuesIfExists(dnFs, jsFeatureSet, 'displayFieldName', 'exceededTransferLimit',
        'geometryType');
    if (hasValue(dnFs.features)) {
        jsFeatureSet.features = dnFs.features.map(f => buildJsGraphic(f, f.layerId, viewId) as Graphic);
    }
    if (hasValue(dnFs.fields)) {
        jsFeatureSet.fields = dnFs.fields.map(f => buildJsField(f));
    }
    if (hasValue(dnFs.queryGeometry)) {
        jsFeatureSet.queryGeometry = buildJsGeometry(dnFs.queryGeometry as DotNetGeometry) as Geometry;
    }
    if (hasValue(dnFs.spatialReference)) {
        jsFeatureSet.spatialReference = buildJsSpatialReference(dnFs.spatialReference as DotNetSpatialReference);
    }
    return jsFeatureSet;
}

export function buildJsSublayer(dotNetSublayer: any): Sublayer {
    let sublayer = new Sublayer({
        id: dotNetSublayer.sublayerId
    });

    copyValuesIfExists(dotNetSublayer, sublayer, 'maxScale', 'minScale', 'visible', 'labelsVisible',
        'legendEnabled', 'listMode', 'opacity', 'popupEnabled', 'title', 'definitionExpression', 'url');

    if (hasValue(dotNetSublayer.floorInfo)) {
        sublayer.floorInfo = {
            floorField: dotNetSublayer.floorInfo.floorField ?? undefined
        } as any;
    }

    if (hasValue(dotNetSublayer.labelingInfo) && dotNetSublayer.labelingInfo.length > 0) {
        sublayer.labelingInfo = dotNetSublayer.labelingInfo.map(buildJsLabelClass);
    }

    if (hasValue(dotNetSublayer.sublayers) && dotNetSublayer.sublayers.length > 0) {
        sublayer.sublayers = dotNetSublayer.sublayers.map(buildJsSublayer);
    }

    if (hasValue(dotNetSublayer.renderer)) {
        sublayer.renderer = buildJsRenderer(dotNetSublayer.renderer) as Renderer;
    }

    if (hasValue(dotNetSublayer.popupTemplate)) {
        sublayer.popupTemplate = buildJsPopupTemplate(dotNetSublayer.popupTemplate, null) as PopupTemplate;
    }

    if (hasValue(dotNetSublayer.source)) {
        sublayer.source = buildJsDynamicLayer(dotNetSublayer.source);
    }

    arcGisObjectRefs[dotNetSublayer.id] = sublayer;
    return sublayer;
}

function buildJsDynamicLayer(dotNetSource: any): DynamicMapLayer | DynamicDataLayer {
    switch (dotNetSource.type) {
        case 'map-layer':
            return {
                type: 'map-layer',
                mapLayerId: dotNetSource.mapLayerId,
                gdbVersion: dotNetSource.gdbVersion ?? undefined,
            } as DynamicMapLayer;
        default:
            let dataLayer = {
                type: 'data-layer'
            } as DynamicDataLayer;
            if (hasValue(dotNetSource?.dataSource)) {
                dataLayer.dataSource = buildJsDynamicDataSource(dotNetSource.dataSource);
            }

            if (hasValue(dotNetSource?.fields) && dotNetSource.fields.length > 0) {
                dataLayer.fields = dotNetSource.fields.map(buildJsDynamicDataLayerField);
            }

            return dataLayer;
    }
}

function buildJsDynamicDataSource(dotNetSource: any): any {
    switch (dotNetSource.type) {
        case 'table':
            return {
                type: 'table',
                workspaceId: dotNetSource.workspaceId,
                dataSourceName: dotNetSource.dataSourceName,
                gdbVersion: dotNetSource.gdbVersion ?? undefined
            } as TableDataSource;
        case 'query-table':
            let queryTable = {
                type: 'query-table',
                workspaceId: dotNetSource.workspaceId,
                query: dotNetSource.query,
                oidFields: dotNetSource.oidFields ?? undefined,
                geometryType: dotNetSource.geometryType ?? undefined
            } as QueryTableDataSource;
            if (hasValue(dotNetSource.spatialReference)) {
                queryTable.spatialReference = buildJsSpatialReference(dotNetSource.spatialReference);
            }
            return queryTable;
        case 'raster':
            return {
                type: 'raster',
                workspaceId: dotNetSource.workspaceId,
                dataSourceName: dotNetSource.dataSourceName
            } as RasterDataSource;
        default:
            let joinTable = {
                type: 'join-table',
                leftTableKey: dotNetSource.leftTableKey,
                rightTableKey: dotNetSource.rightTableKey,
                joinType: dotNetSource.joinType
            } as JoinTableDataSource;

            if (hasValue(dotNetSource?.leftTableSource)) {
                joinTable.leftTableSource = buildJsDynamicLayer(dotNetSource.leftTableSource);
            }
            if (hasValue(dotNetSource?.rightTableSource)) {
                joinTable.rightTableSource = buildJsDynamicLayer(dotNetSource.rightTableSource);
            }

            return joinTable;
    }
}

function buildJsDynamicDataLayerField(dotNetField: any): DynamicDataLayerFields {
    return {
        name: dotNetField.name,
        alias: dotNetField.alias ?? undefined
    } as DynamicDataLayerFields;
}

export function buildJsTickConfig(dnTickConfig: any): TickConfig {
    let tickConfig: TickConfig = {
        mode: dnTickConfig.mode ?? undefined,
        values: dnTickConfig.values ?? undefined
    };
    copyValuesIfExists(dnTickConfig, tickConfig, 'labelsVisible');
    if (hasValue(dnTickConfig.tickCreatedFunction)) {
        tickConfig.tickCreatedFunction = (value, tickElement, labelElement) => {
            return new Function('value', 'tickElement', 'labelElement', dnTickConfig.tickCreatedFunction)(value, tickElement, labelElement);
        };
    }
    if (hasValue(dnTickConfig.labelFormatFunction)) {
        tickConfig.labelFormatFunction = (value, type, index) => {
            return new Function('value', 'type', 'index', dnTickConfig.labelFormatFunction)(value, type, index);
        };
    }

    return tickConfig;
}

export function buildJsMultidimensionalSubset(dnSubSet: any): MultidimensionalSubset {
    let subset = new MultidimensionalSubset();
    if (hasValue(dnSubSet!.extentOfInterest)) {
        subset.areaOfInterest = buildJsExtent(dnSubSet.extentOfInterest, null);
    } else if (hasValue(dnSubSet.polygonOfInterest)) {
        subset.areaOfInterest = buildJsPolygon(dnSubSet.polygonOfInterest) as Polygon;
    }
    if (hasValue(dnSubSet.subsetDefinitions) && dnSubSet.subsetDefinitions.length > 0) {
        subset.subsetDefinitions = dnSubSet.subsetDefinitions.map(buildJsDimensionalDefinition);
    }
    return subset;
}