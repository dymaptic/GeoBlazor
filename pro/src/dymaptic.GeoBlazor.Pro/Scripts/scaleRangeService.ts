// override generated code in this file
import ScaleRangeServiceGenerated from './scaleRangeService.gb';
import scaleRange from '@arcgis/core/smartMapping/heuristics/scaleRange';

export default class ScaleRangeServiceWrapper extends ScaleRangeServiceGenerated {

    constructor(component: scaleRange) {
        super(component);
    }
    
}

export async function buildJsScaleRangeService(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsScaleRangeServiceGenerated } = await import('./scaleRangeService.gb');
    return await buildJsScaleRangeServiceGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetScaleRangeService(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetScaleRangeServiceGenerated } = await import('./scaleRangeService.gb');
    return await buildDotNetScaleRangeServiceGenerated(jsObject, layerId, viewId);
}
