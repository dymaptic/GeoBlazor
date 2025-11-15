// override generated code in this file
import BasemapGenerated from './basemap.gb';
import Basemap from '@arcgis/core/Basemap';
import {arcGisObjectRefs} from "./geoBlazorCore";
import MapView from "@arcgis/core/views/MapView";

export default class BasemapWrapper extends BasemapGenerated {

    constructor(component: Basemap) {
        super(component);
    }

    async setSpatialReference(spatialReference: any): Promise<void> {
        let {buildJsSpatialReference} = await import('./spatialReference');
        this.component.spatialReference = buildJsSpatialReference(spatialReference) as any;
    }

    async setStyle(value: any): Promise<void> {
        let { buildJsBasemapStyle } = await import('./basemapStyle');
        let style = await  buildJsBasemapStyle(value);
        
        // setting the style on an existing basemap doesn't work, so we have to replace it
        let newBasemap = new Basemap({ style: style });
        let view = arcGisObjectRefs[this.viewId!] as MapView;
        view.map!.basemap = newBasemap;
        this.component = newBasemap;
    }

    async setPortalItem(value: any): Promise<void> {
        let { buildJsPortalItem } = await import('./portalItem');
        let portalItem = await  buildJsPortalItem(value, this.layerId, this.viewId);
        
        // setting the portalItem on an existing basemap doesn't work, so we have to replace it
        let newBasemap = new Basemap({ portalItem: portalItem });
        let view = arcGisObjectRefs[this.viewId!] as MapView;
        view.map!.basemap = newBasemap;
        this.component = newBasemap;
    }
}

export async function buildJsBasemap(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsBasemapGenerated} = await import('./basemap.gb');
    return await buildJsBasemapGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetBasemap(jsObject: any, viewId: string | null): Promise<any> {
    let {buildDotNetBasemapGenerated} = await import('./basemap.gb');
    return await buildDotNetBasemapGenerated(jsObject, viewId);
}
