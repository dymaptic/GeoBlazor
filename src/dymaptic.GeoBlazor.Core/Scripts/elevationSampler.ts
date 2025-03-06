// override generated code in this file
import ElevationSamplerGenerated from './elevationSampler.gb';
import ElevationSampler from '@arcgis/core/layers/support/ElevationSampler';

export default class ElevationSamplerWrapper extends ElevationSamplerGenerated {

    constructor(component: ElevationSampler) {
        super(component);
    }

}

export async function buildJsElevationSampler(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsElevationSamplerGenerated} = await import('./elevationSampler.gb');
    return await buildJsElevationSamplerGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetElevationSampler(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildDotNetElevationSamplerGenerated} = await import('./elevationSampler.gb');
    return await buildDotNetElevationSamplerGenerated(jsObject, layerId, viewId);
}
