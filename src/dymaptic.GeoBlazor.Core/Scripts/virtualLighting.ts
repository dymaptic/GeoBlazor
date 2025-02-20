import VirtualLighting from '@arcgis/core/views/3d/environment/VirtualLighting';
import VirtualLightingGenerated from './virtualLighting.gb';

export default class VirtualLightingWrapper extends VirtualLightingGenerated {

    constructor(component: VirtualLighting) {
        super(component);
    }

}

export async function buildJsVirtualLighting(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsVirtualLightingGenerated} = await import('./virtualLighting.gb');
    return await buildJsVirtualLightingGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetVirtualLighting(jsObject: any): Promise<any> {
    let {buildDotNetVirtualLightingGenerated} = await import('./virtualLighting.gb');
    return await buildDotNetVirtualLightingGenerated(jsObject);
}
