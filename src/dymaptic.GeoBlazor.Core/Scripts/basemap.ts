// override generated code in this file
import BasemapGenerated from './basemap.gb';
import Basemap from '@arcgis/core/Basemap';

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
    let {buildJsBasemapGenerated} = await import('./basemap.gb');
    return await buildJsBasemapGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetBasemap(jsObject: any): Promise<any> {
    let {buildDotNetBasemapGenerated} = await import('./basemap.gb');
    return await buildDotNetBasemapGenerated(jsObject);
}
