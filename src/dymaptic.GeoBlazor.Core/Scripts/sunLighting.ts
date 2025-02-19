// override generated code in this file
import SunLightingGenerated from './sunLighting.gb';
import SunLighting from '@arcgis/core/views/3d/environment/SunLighting';

export default class SunLightingWrapper extends SunLightingGenerated {

    constructor(component: SunLighting) {
        super(component);
    }
    
}

export async function buildJsSunLighting(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsSunLightingGenerated } = await import('./sunLighting.gb');
    return await buildJsSunLightingGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetSunLighting(jsObject: any): Promise<any> {
    let { buildDotNetSunLightingGenerated } = await import('./sunLighting.gb');
    return await buildDotNetSunLightingGenerated(jsObject);
}
