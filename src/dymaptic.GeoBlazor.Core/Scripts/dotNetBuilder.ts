import {
    DotNetAttachmentsPopupContent,
    DotNetBarChartMediaInfo,
    DotNetColumnChartMediaInfo,
    DotNetElementExpressionInfo,
    DotNetExpressionInfo,
    DotNetExpressionPopupContent,
    DotNetExtent,
    DotNetFeature,
    DotNetFeatureLayer,
    DotNetFieldInfo,
    DotNetFieldInfoFormat,
    DotNetFieldsPopupContent,
    DotNetGeographicTransformation,
    DotNetGeographicTransformationStep,
    DotNetGeometry,
    DotNetGraphic,
    DotNetGraphicHit,
    DotNetGraphicsLayer,
    DotNetHitTestResult,
    DotNetImageMediaInfo,
    DotNetImageMediaInfoValue,
    DotNetLayer,
    DotNetLayerView,
    DotNetLineChartMediaInfo,
    DotNetMediaInfo,
    DotNetMediaPopupContent,
    DotNetPictureMarkerSymbol,
    DotNetPoint,
    DotNetPolygon,
    DotNetPolyline,
    DotNetPopupContent,
    DotNetPopupTemplate,
    DotNetSimpleFillSymbol,
    DotNetSimpleLineSymbol,
    DotNetSimpleMarkerSymbol,
    DotNetSpatialReference,
    DotNetSymbol,
    DotNetTextPopupContent,
    DotNetTextSymbol,
    DotNetViewHit,
    MapCollection
} from "./definitions";
import Point from "@arcgis/core/geometry/Point";
import Polyline from "@arcgis/core/geometry/Polyline";
import Polygon from "@arcgis/core/geometry/Polygon";
import Extent from "@arcgis/core/geometry/Extent";
import Geometry from "@arcgis/core/geometry/Geometry";
import SpatialReference from "@arcgis/core/geometry/SpatialReference";
import GeographicTransformation from "@arcgis/core/geometry/support/GeographicTransformation";
import LayerView from "@arcgis/core/views/layers/LayerView";
import Layer from "@arcgis/core/layers/Layer";
import PopupTemplate from "@arcgis/core/PopupTemplate";
import Content from "@arcgis/core/popup/content/Content";
import FieldInfo from "@arcgis/core/popup/FieldInfo";
import FieldInfoFormat from "@arcgis/core/popup/support/FieldInfoFormat";
import FieldsContent from "@arcgis/core/popup/content/FieldsContent";
import TextContent from "@arcgis/core/popup/content/TextContent";
import MediaContent from "@arcgis/core/popup/content/MediaContent";
import MediaInfo from "@arcgis/core/popup/content/mixins/MediaInfo";
import BarChartMediaInfo from "@arcgis/core/popup/content/BarChartMediaInfo";
import ColumnChartMediaInfo from "@arcgis/core/popup/content/ColumnChartMediaInfo";
import ImageMediaInfo from "@arcgis/core/popup/content/ImageMediaInfo";
import ImageMediaInfoValue from "@arcgis/core/popup/content/support/ImageMediaInfoValue";
import LineChartMediaInfo from "@arcgis/core/popup/content/LineChartMediaInfo";
import AttachmentsContent from "@arcgis/core/popup/content/AttachmentsContent";
import ExpressionContent from "@arcgis/core/popup/content/ExpressionContent";
import ElementExpressionInfo from "@arcgis/core/popup/ElementExpressionInfo";
import FeatureLayer from "@arcgis/core/layers/FeatureLayer";
import GraphicsLayer from "@arcgis/core/layers/GraphicsLayer";
import {arcGisObjectRefs} from "./arcGisJsInterop";
import SimpleMarkerSymbol from "@arcgis/core/symbols/SimpleMarkerSymbol";
import Symbol from "@arcgis/core/symbols/Symbol";
import Graphic from "@arcgis/core/Graphic";
import SimpleLineSymbol from "@arcgis/core/symbols/SimpleLineSymbol";
import SimpleFillSymbol from "@arcgis/core/symbols/SimpleFillSymbol";
import PictureMarkerSymbol from "@arcgis/core/symbols/PictureMarkerSymbol";
import TextSymbol from "@arcgis/core/symbols/TextSymbol";
import View from "@arcgis/core/views/View";
import MapView from "@arcgis/core/views/MapView";
import SceneView from "@arcgis/core/views/SceneView";
import HitTestResult = __esri.HitTestResult;
import ViewHit = __esri.ViewHit;

export function buildDotNetGraphic(graphic: Graphic): DotNetGraphic {
    let dotNetGraphic = {} as DotNetGraphic;

    if (Object.values(arcGisObjectRefs).includes(graphic)) {
        for (const k of Object.keys(arcGisObjectRefs)) {
            if (arcGisObjectRefs[k] === graphic) {
                dotNetGraphic.id = k;
                break;
            }
        }
    }

    dotNetGraphic.uid = (graphic as any).uid;
    dotNetGraphic.attributes = graphic.attributes;
    if (graphic.symbol !== undefined && graphic.symbol !== null) {
        dotNetGraphic.symbol = buildDotNetSymbol(graphic.symbol);
    }

    switch (graphic.geometry?.type) {
        case 'point':
            dotNetGraphic.geometry = buildDotNetPoint(graphic.geometry as Point);
            break;
        case 'polyline':
            dotNetGraphic.geometry = buildDotNetPolyline(graphic.geometry as Polyline);
            break;
        case 'polygon':
            dotNetGraphic.geometry = buildDotNetPolygon(graphic.geometry as Polygon);
            break;
        case 'extent':
            dotNetGraphic.geometry = buildDotNetExtent(graphic.geometry as Extent);
            break;
    }
    return dotNetGraphic;
}

function buildDotNetSymbol(symbol: Symbol): DotNetSymbol {
    if (symbol instanceof SimpleMarkerSymbol) {
        let dnMarkerSymbol = {
            type: 'simple-marker',
            color: symbol.color?.toHex(),
            size: symbol.size,
            style: symbol.style,
            path: symbol.path,
            xoffset: symbol.xoffset,
            yoffset: symbol.yoffset,
        } as DotNetSimpleMarkerSymbol;
        if (symbol.outline !== undefined && symbol.outline !== null) {
            dnMarkerSymbol.outline = buildDotNetSymbol(symbol.outline) as DotNetSimpleLineSymbol;
        }
        return dnMarkerSymbol;
    }
    if (symbol instanceof SimpleLineSymbol) {
        return {
            type: 'simple-line',
            color: symbol.color?.toHex(),
            width: symbol.width,
            style: symbol.style,
            cap: symbol.cap,
            join: symbol.join,
            marker: symbol.marker,
            miterLimit: symbol.miterLimit
        } as DotNetSimpleLineSymbol;
    }
    if (symbol instanceof SimpleFillSymbol) {
        let dnSimpleFillSymbol = {
            type: 'simple-fill',
            color: symbol.color?.toHex(),
            style: symbol.style
        } as DotNetSimpleFillSymbol;
        if (symbol.outline !== undefined && symbol.outline !== null) {
            dnSimpleFillSymbol.outline = buildDotNetSymbol(symbol.outline) as DotNetSimpleLineSymbol;
        }
        return dnSimpleFillSymbol;
    }
    if (symbol instanceof PictureMarkerSymbol) {
        return {
            type: 'picture-marker',
            url: symbol.url,
            width: symbol.width,
            height: symbol.height,
            angle: symbol.angle,
            xoffset: symbol.xoffset,
            yoffset: symbol.yoffset
        } as DotNetPictureMarkerSymbol;
    }
    if (symbol instanceof TextSymbol) {
        return {
            type: 'text',
            color: symbol.color?.toHex(),
            haloColor: symbol.haloColor?.toHex(),
            haloSize: symbol.haloSize,
            horizontalAlignment: symbol.horizontalAlignment,
            kerning: symbol.kerning,
            rotated: symbol.rotated,
            text: symbol.text,
            xoffset: symbol.xoffset,
            yoffset: symbol.yoffset,
            font: {
                family: symbol.font.family,
                size: symbol.font.size,
                style: symbol.font.style,
                weight: symbol.font.weight
            },
            angle: symbol.angle,
            backgroundColor: symbol.backgroundColor?.toHex(),
            borderLineColor: symbol.borderLineColor?.toHex(),
            borderLineSize: symbol.borderLineSize,
            lineHeight: symbol.lineHeight,
            lineWidth: symbol.lineWidth,
            verticalAlignment: symbol.verticalAlignment
        } as DotNetTextSymbol;
    }

    return symbol as any as DotNetSymbol;
}

export function buildDotNetFeature(feature: any): DotNetFeature {
    let dotNetFeature = {
        attributes: feature.attributes
    } as DotNetFeature;
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

export function buildDotNetGeometry(geometry: Geometry): DotNetGeometry | null {
    switch (geometry.type) {
        case "point":
            return buildDotNetPoint(geometry as Point);
        case "polyline":
            return buildDotNetPolyline(geometry as Polyline);
        case "polygon":
            return buildDotNetPolygon(geometry as Polygon);
        case "extent":
            return buildDotNetExtent(geometry as Extent);
    }

    return geometry as any;
}

export function buildDotNetPoint(point: Point | null | undefined): DotNetPoint | null {
    if (point === undefined || point === null) return null;
    return {
        type: 'point',
        latitude: point.latitude,
        longitude: point.longitude,
        hasM: point.hasM,
        hasZ: point.hasZ,
        extent: buildDotNetExtent(point.extent),
        x: point.x,
        y: point.y,
        z: point.z,
        m: point.m,
        spatialReference: buildDotNetSpatialReference(point.spatialReference)
    } as DotNetPoint
}

export function buildDotNetPolyline(polyline: Polyline): DotNetPolyline | null {
    return {
        type: 'polyline',
        paths: polyline.paths,
        hasM: polyline.hasM,
        hasZ: polyline.hasZ,
        extent: buildDotNetExtent(polyline.extent),
        spatialReference: buildDotNetSpatialReference(polyline.spatialReference)
    } as DotNetPolyline
}

export function buildDotNetPolygon(polygon: Polygon): DotNetPolygon | null {
    if (polygon === undefined || polygon === null) return null;
    return {
        type: 'polygon',
        rings: polygon.rings,
        hasM: polygon.hasM,
        hasZ: polygon.hasZ,
        extent: buildDotNetExtent(polygon.extent),
        spatialReference: buildDotNetSpatialReference(polygon.spatialReference)
    } as DotNetPolygon
}

export function buildDotNetExtent(extent: Extent): DotNetExtent | null {
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
        spatialReference: buildDotNetSpatialReference(extent.spatialReference)
    } as DotNetExtent;
}

export function buildDotNetSpatialReference(spatialReference: SpatialReference): DotNetSpatialReference | null {
    if (spatialReference === undefined || spatialReference === null) return null;

    return {
        isGeographic: spatialReference.isGeographic,
        isWebMercator: spatialReference.isWebMercator,
        isWgs84: spatialReference.isWGS84,
        isWrappable: spatialReference.isWrappable,
        wkid: spatialReference.wkid,
        wkt: spatialReference.wkt,
        imageCoordinateSystem: spatialReference.imageCoordinateSystem
    } as DotNetSpatialReference;
}


export function buildDotNetGeographicTransformation(geographicTransformation: GeographicTransformation):
    DotNetGeographicTransformation | null {
    if (geographicTransformation === undefined || geographicTransformation === null) return null;
    let steps: Array<DotNetGeographicTransformationStep> = [];
    geographicTransformation.steps.forEach(s => {
        steps.push({
            isInverse: s.isInverse,
            wkid: s.wkid,
            wkt: s.wkt
        } as DotNetGeographicTransformationStep)
    });
    return {
        steps: steps
    } as DotNetGeographicTransformation;
}

export function buildDotNetLayerView(layerView: LayerView): DotNetLayerView {
    return {
        spatialReferenceSupported: layerView.spatialReferenceSupported,
        suspended: layerView.suspended,
        updating: layerView.updating,
        visible: layerView.visible
    }
}

export function buildDotNetLayer(layer: Layer): DotNetLayer {
    switch (layer.type) {
        case 'feature':
            return buildDotNetFeatureLayer(layer as FeatureLayer);
        case 'graphics':
            return buildDotNetGraphicsLayer(layer as GraphicsLayer);
        default:

            let dotNetLayer = {
                title: layer.title,
                type: layer.type,
                listMode: layer.listMode,
                visible: layer.visible,
                opacity: layer.opacity
            } as DotNetLayer;

            if (layer.fullExtent !== undefined && layer.fullExtent !== null) {
                dotNetLayer.fullExtent = buildDotNetExtent(layer.fullExtent) as DotNetExtent;
            }

            if (Object.values(arcGisObjectRefs).includes(layer)) {
                for (const k of Object.keys(arcGisObjectRefs)) {
                    if (arcGisObjectRefs[k] === layer) {
                        dotNetLayer.id = k;
                        break;
                    }
                }
            }
            return dotNetLayer;
    }
}

export function buildDotNetFeatureLayer(layer: FeatureLayer): DotNetFeatureLayer {

    let dotNetLayer = {
        title: layer.title,
        type: layer.type,
        listMode: layer.listMode,
        visible: layer.visible,
        opacity: layer.opacity,
        url: layer.url,
        definitionExpression: layer.definitionExpression,
        outFields: layer.outFields,
        minScale: layer.minScale,
        maxScale: layer.maxScale,
        objectIdField: layer.objectIdField,
        geometryType: layer.geometryType,
        orderBy: layer.orderBy,
        labelingInfo: layer.labelingInfo,
        renderer: layer.renderer,
        portalItem: layer.portalItem,
        fields: layer.fields,
        relationships: layer.relationships
    } as DotNetFeatureLayer;

    if (layer.fullExtent !== undefined && layer.fullExtent !== null) {
        dotNetLayer.fullExtent = buildDotNetExtent(layer.fullExtent) as DotNetExtent;
    }

    if (layer.popupTemplate !== undefined && layer.popupTemplate !== null) {
        dotNetLayer.popupTemplate = buildDotNetPopupTemplate(layer.popupTemplate);
    }

    if (layer.spatialReference !== undefined && layer.spatialReference !== null) {
        dotNetLayer.spatialReference = buildDotNetSpatialReference(layer.spatialReference) as DotNetSpatialReference;
    }

    if (Object.values(arcGisObjectRefs).includes(layer)) {
        for (const k of Object.keys(arcGisObjectRefs)) {
            if (arcGisObjectRefs[k] === layer) {
                dotNetLayer.id = k;
                break;
            }
        }
    }

    return dotNetLayer;
}

export function buildDotNetGraphicsLayer(layer: GraphicsLayer): DotNetGraphicsLayer {
    let dotNetLayer = {
        title: layer.title,
        type: layer.type,
        listMode: layer.listMode,
        visible: layer.visible,
        opacity: layer.opacity
    } as DotNetGraphicsLayer;

    if (layer.fullExtent !== undefined && layer.fullExtent !== null) {
        dotNetLayer.fullExtent = buildDotNetExtent(layer.fullExtent) as DotNetExtent;
    }

    if (layer.graphics !== undefined && layer.graphics !== null) {
        dotNetLayer.graphics = (layer.graphics as MapCollection).items.map(g => buildDotNetGraphic(g));
    }

    if (Object.values(arcGisObjectRefs).includes(layer)) {
        for (const k of Object.keys(arcGisObjectRefs)) {
            if (arcGisObjectRefs[k] === layer) {
                dotNetLayer.id = k;
                break;
            }
        }
    }

    return dotNetLayer;
}

export function buildDotNetHitTestResult(hitTestResult: HitTestResult): DotNetHitTestResult {
    let results = hitTestResult.results.map(r => buildDotNetViewHit(r))
        .filter(r => r !== null) as Array<DotNetViewHit>;
    return {
        results: results,
        screenPoint: hitTestResult.screenPoint
    }
}

function buildDotNetViewHit(viewHit: ViewHit): DotNetViewHit | null {
    switch (viewHit.type) {
        case "graphic":
            return {
                type: "graphic",
                graphic: buildDotNetGraphic(viewHit.graphic),
                layer: buildDotNetLayer(viewHit.layer),
                mapPoint: buildDotNetPoint(viewHit.mapPoint)
            } as DotNetGraphicHit;
            break;
    }

    return null;
}

export function buildDotNetPopupTemplate(popupTemplate: PopupTemplate): DotNetPopupTemplate {
    let template = {
        title: popupTemplate.title as string
    } as DotNetPopupTemplate;

    if (typeof popupTemplate.content === "string") {
        template.stringContent = popupTemplate.content as string;
    } else {
        template.content = (popupTemplate.content as any[])?.map(c => buildDotNetPopupContent(c));
    }

    template.fieldInfos = popupTemplate.fieldInfos?.map(f => buildDotNetFieldInfo(f));
    template.expressionInfos = popupTemplate.expressionInfos?.map(e => buildDotNetExpressionInfo(e));

    return template;
}

export function buildDotNetPopupContent(popupContent: Content): DotNetPopupContent {
    let content = {
        type: popupContent.type
    } as DotNetPopupContent;

    switch (popupContent.type) {
        case "fields":
            let fieldsContent = content as DotNetFieldsPopupContent;
            let jsFieldsContent = popupContent as FieldsContent;
            fieldsContent.fieldInfos = jsFieldsContent.fieldInfos?.map(f => buildDotNetFieldInfo(f));
            fieldsContent.title = (popupContent as FieldsContent).title;
            fieldsContent.description = (popupContent as FieldsContent).description;
            break;
        case "text":
            (content as DotNetTextPopupContent).text = (popupContent as TextContent).text;
            break;
        case "media":
            let mediaContent = content as DotNetMediaPopupContent;
            let jsMediaContent = popupContent as MediaContent;
            if (mediaContent.mediaInfos instanceof MediaInfo) {
                mediaContent.mediaInfos = [buildDotNetMediaInfo(jsMediaContent.mediaInfos as any)];
            } else {
                mediaContent.mediaInfos = (jsMediaContent.mediaInfos as MediaInfo[])?.map(m => buildDotNetMediaInfo(m));
            }
            break;
        case "attachments":
            let attachmentsContent = content as DotNetAttachmentsPopupContent;
            let jsAttachmentsContent = popupContent as AttachmentsContent;
            attachmentsContent.description = jsAttachmentsContent.description;
            attachmentsContent.title = jsAttachmentsContent.title;
            attachmentsContent.displayType = jsAttachmentsContent.displayType;
            break;
        case "expression":
            let expressionContent = content as DotNetExpressionPopupContent;
            let jsExpressionContent = popupContent as ExpressionContent;
            expressionContent.expressionInfo = buildDotNetElementExpressionInfo(jsExpressionContent.expressionInfo);
            break;
    }

    return content;
}

export function buildDotNetFieldInfo(fieldInfo: FieldInfo): DotNetFieldInfo {
    return {
        fieldName: fieldInfo.fieldName,
        format: buildDotNetFieldInfoFormat(fieldInfo.format),
        label: fieldInfo.label,
        stringFieldOption: fieldInfo.stringFieldOption,
        tooltip: fieldInfo.tooltip,
        visible: fieldInfo.visible
    } as DotNetFieldInfo;
}

export function buildDotNetExpressionInfo(expressionInfo: any): DotNetExpressionInfo {
    return {
        name: expressionInfo.name,
        expression: expressionInfo.expression,
        title: expressionInfo.title,
        returnType: expressionInfo.returnType
    } as DotNetExpressionInfo;
}

export function buildDotNetFieldInfoFormat(format: FieldInfoFormat | null): DotNetFieldInfoFormat | null {
    if (format === null) return null;
    return {
        dateFormat: format.dateFormat,
        digitSeparator: format.digitSeparator,
        places: format.places
    } as DotNetFieldInfoFormat;
}

export function buildDotNetMediaInfo(mediaInfo: MediaInfo): DotNetMediaInfo {
    if (mediaInfo instanceof BarChartMediaInfo) {
        return {
            type: "bar-chart",
            altText: mediaInfo.altText,
            caption: mediaInfo.caption,
            title: mediaInfo.title,
        } as DotNetBarChartMediaInfo;
    }

    if (mediaInfo instanceof ColumnChartMediaInfo) {
        return {
            type: "column-chart",
            altText: mediaInfo.altText,
            caption: mediaInfo.caption,
            title: mediaInfo.title,
        } as DotNetColumnChartMediaInfo;
    }

    if (mediaInfo instanceof ImageMediaInfo) {
        return {
            type: "image-media",
            altText: mediaInfo.altText,
            caption: mediaInfo.caption,
            title: mediaInfo.title,
            value: buildDotNetImageMediaInfoValue(mediaInfo.value)
        } as DotNetImageMediaInfo;
    }

    if (mediaInfo instanceof LineChartMediaInfo) {
        return {
            type: "line-chart",
            altText: mediaInfo.altText,
            caption: mediaInfo.caption,
            title: mediaInfo.title,
        } as DotNetLineChartMediaInfo;
    }

    throw new Error("Unknown media info type");
}

export function buildDotNetImageMediaInfoValue(value: ImageMediaInfoValue): DotNetImageMediaInfoValue {
    return {
        sourceURL: value.sourceURL,
        linkURL: value.linkURL
    } as DotNetImageMediaInfoValue;
}

export function buildDotNetElementExpressionInfo(expressionInfo: ElementExpressionInfo): DotNetElementExpressionInfo {
    return {
        expression: expressionInfo.expression,
        title: expressionInfo.title,
        returnType: expressionInfo.returnType
    } as DotNetElementExpressionInfo;
}

export function buildViewExtentUpdate(view: View): any {
    if (view instanceof MapView) {
        return {
            extent: buildDotNetExtent(view.extent),
            center: view.center !== null ? buildDotNetPoint(view.center) : null,
            scale: view.scale,
            zoom: view.zoom,
            rotation: view.rotation
        }
    } else if (view instanceof SceneView) {
        return {
            extent: buildDotNetExtent(view.extent),
            center: view.center !== null ? buildDotNetPoint(view.center) : null,
            scale: view.scale,
            zoom: view.zoom,
            tilt: view.camera?.tilt
        }
    }
}