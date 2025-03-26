import LocatorSearchSource from "@arcgis/core/widgets/Search/LocatorSearchSource";
import {arcGisObjectRefs, hasValue, lookupGeoBlazorId} from "./arcGisJsInterop";
import {buildDotNetPoint} from "./point";
import {buildDotNetSpatialReference} from "./spatialReference";
import {buildJsExtent} from "./extent";
import {buildJsGraphic} from "./graphic";

export async function buildDotNetSearchSource(jsSource: any): Promise<any> {
    if (jsSource instanceof LocatorSearchSource) {
        let {buildDotNetLocatorSearchSource} = await import('./locatorSearchSource');
        return await buildDotNetLocatorSearchSource(jsSource);
    }

    let {buildDotNetLayerSearchSource} = await import('./layerSearchSource');
    return await buildDotNetLayerSearchSource(jsSource);
}

export async function buildJsSearchSource(dotNetSource: any, viewId: string | null): Promise<any> {
    let jsSource: any;

    if (hasValue(dotNetSource.url)) {
        let {buildJsLocatorSearchSource} = await import('./locatorSearchSource');
        jsSource = await buildJsLocatorSearchSource(dotNetSource, null, viewId);
    } else {
        let {buildJsLayerSearchSource} = await import('./layerSearchSource');
        let layerId = dotNetSource.layerId ?? dotNetSource.layer?.id;
        jsSource = await buildJsLayerSearchSource(dotNetSource, layerId, viewId);
    }

    return jsSource;
}
