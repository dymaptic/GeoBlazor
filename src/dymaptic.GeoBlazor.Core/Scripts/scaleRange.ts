// override generated code in this file
import ScaleRangeGenerated from './scaleRange.gb';
import scaleRange from '@arcgis/core/smartMapping/heuristics/scaleRange';

export default class ScaleRangeWrapper extends ScaleRangeGenerated {

    constructor(component: scaleRange) {
        super(component);
    }
    
}

export async function buildJsScaleRange(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsScaleRangeGenerated } = await import('./scaleRange.gb');
    return await buildJsScaleRangeGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetScaleRange(jsObject: any): Promise<any> {
    let { buildDotNetScaleRangeGenerated } = await import('./scaleRange.gb');
    return await buildDotNetScaleRangeGenerated(jsObject);
}
