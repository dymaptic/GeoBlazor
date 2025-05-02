// override generated code in this file
import SunLightingGenerated from './sunLighting.gb';
import SunLighting from '@arcgis/core/views/3d/environment/SunLighting';

export async function buildJsSunLighting(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsSunLightingGenerated} = await import('./sunLighting.gb');
    return await buildJsSunLightingGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetSunLighting(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildDotNetSunLightingGenerated} = await import('./sunLighting.gb');
    return await buildDotNetSunLightingGenerated(jsObject, layerId, viewId);
}
