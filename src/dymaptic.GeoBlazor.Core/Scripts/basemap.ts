// override generated code in this file
import BasemapGenerated from './basemap.gb';
import Basemap from '@arcgis/core/Basemap';

export default class BasemapWrapper extends BasemapGenerated {

    constructor(component: Basemap) {
        super(component);
    }
    
}              
export async function buildJsBasemap(dotNetObject: any): Promise<any> {
    let { buildJsBasemapGenerated } = await import('./basemap.gb');
    return await buildJsBasemapGenerated(dotNetObject);
}
export async function buildDotNetBasemap(jsObject: any): Promise<any> {
    let { buildDotNetBasemapGenerated } = await import('./basemap.gb');
    return await buildDotNetBasemapGenerated(jsObject);
}
