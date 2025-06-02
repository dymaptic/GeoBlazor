// override generated code in this file
import BasemapGenerated from './basemap.gb';
import Basemap from '@arcgis/core/Basemap';
import * as promiseUtils from '@arcgis/core/core/promiseUtils';
import {arcGisObjectRefs, hasValue, jsObjectRefs} from "./arcGisJsInterop";

export default class BasemapWrapper extends BasemapGenerated {

    constructor(component: Basemap) {
        super(component);
    }

    async setSpatialReference(spatialReference: any): Promise<void> {
        let {buildJsSpatialReference} = await import('./spatialReference');
        this.component.spatialReference = buildJsSpatialReference(spatialReference) as any;
    }
}

export async function buildJsBasemap(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    if (!hasValue(dotNetObject)) {
        return null;
    }

    let properties: any = {};
    if (hasValue(dotNetObject.baseLayers) && dotNetObject.baseLayers.length > 0) {
        let { buildJsLayer } = await import('./layer');
        properties.baseLayers = await Promise.all(dotNetObject.baseLayers.map(async i => await buildJsLayer(i, layerId, viewId))) as any;
    }
    if (hasValue(dotNetObject.portalItem)) {
        let { buildJsPortalItem } = await import('./portalItem');
        properties.portalItem = await buildJsPortalItem(dotNetObject.portalItem, layerId, viewId) as any;
    }
    if (hasValue(dotNetObject.referenceLayers) && dotNetObject.referenceLayers.length > 0) {
        let { buildJsLayer } = await import('./layer');
        properties.referenceLayers = await Promise.all(dotNetObject.referenceLayers.map(async i => await buildJsLayer(i, layerId, viewId))) as any;
    }
    if (hasValue(dotNetObject.spatialReference)) {
        let { buildJsSpatialReference } = await import('./spatialReference');
        properties.spatialReference = buildJsSpatialReference(dotNetObject.spatialReference) as any;
    }
    if (hasValue(dotNetObject.style)) {
        let { buildJsBasemapStyle } = await import('./basemapStyle');
        properties.style = await buildJsBasemapStyle(dotNetObject.style) as any;
    }

    if (hasValue(dotNetObject.basemapId)) {
        properties.id = dotNetObject.basemapId;
    }
    if (hasValue(dotNetObject.thumbnailUrl)) {
        properties.thumbnailUrl = dotNetObject.thumbnailUrl;
    }
    if (hasValue(dotNetObject.title)) {
        properties.title = dotNetObject.title;
    }
    let jsBasemap = new Basemap(properties);
    jsBasemap.when().catch((error: any) => !promiseUtils.isAbortError(error) && console.error( error));

    let basemapWrapper = new BasemapWrapper(jsBasemap);
    basemapWrapper.geoBlazorId = dotNetObject.id;
    basemapWrapper.viewId = viewId;
    basemapWrapper.layerId = layerId;

    jsObjectRefs[dotNetObject.id] = basemapWrapper;
    arcGisObjectRefs[dotNetObject.id] = jsBasemap;

    return jsBasemap;
}

export async function buildDotNetBasemap(jsObject: any): Promise<any> {
    let {buildDotNetBasemapGenerated} = await import('./basemap.gb');
    return await buildDotNetBasemapGenerated(jsObject);
}
