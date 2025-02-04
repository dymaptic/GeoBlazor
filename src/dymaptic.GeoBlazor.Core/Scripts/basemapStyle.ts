// override generated code in this file
import BasemapStyleGenerated from './basemapStyle.gb';
import BasemapStyle from '@arcgis/core/support/BasemapStyle';

export default class BasemapStyleWrapper extends BasemapStyleGenerated {

    constructor(component: BasemapStyle) {
        super(component);
    }
    
}              
export async function buildJsBasemapStyle(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsBasemapStyleGenerated } = await import('./basemapStyle.gb');
    return await buildJsBasemapStyleGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetBasemapStyle(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetBasemapStyleGenerated } = await import('./basemapStyle.gb');
    return await buildDotNetBasemapStyleGenerated(jsObject, layerId, viewId);
}
