import RasterStretchRenderer from "@arcgis/core/renderers/RasterStretchRenderer";
import ColorRamp from "@arcgis/core/rest/support/ColorRamp";
import {arcGisObjectRefs, copyValuesIfExists, hasValue} from "./arcGisJsInterop";
import { buildJsColorRamp } from "./colorRamp";

export function buildJsRasterStretchRenderer(dotNetRasterStretchRenderer): RasterStretchRenderer | null {
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