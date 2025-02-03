// override generated code in this file
import BasemapStyleGenerated from './basemapStyle.gb';
import BasemapStyle from '@arcgis/core/support/BasemapStyle';

export default class BasemapStyleWrapper extends BasemapStyleGenerated {

    constructor(component: BasemapStyle) {
        super(component);
    }
    
}              
export async function buildJsBasemapStyle(dotNetObject: any): Promise<any> {
    let { buildJsBasemapStyleGenerated } = await import('./basemapStyle.gb');
    return await buildJsBasemapStyleGenerated(dotNetObject);
}
export async function buildDotNetBasemapStyle(jsObject: any): Promise<any> {
    let { buildDotNetBasemapStyleGenerated } = await import('./basemapStyle.gb');
    return await buildDotNetBasemapStyleGenerated(jsObject);
}
