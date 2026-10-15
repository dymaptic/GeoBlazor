// override generated code in this file
import SizeRangeServiceGenerated from './sizeRangeService.gb';
import sizeRange from '@arcgis/core/smartMapping/heuristics/sizeRange';

export default class SizeRangeServiceWrapper extends SizeRangeServiceGenerated {

    constructor(component: sizeRange) {
        super(component);
    }
    
}

export async function buildJsSizeRangeService(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsSizeRangeServiceGenerated } = await import('./sizeRangeService.gb');
    return await buildJsSizeRangeServiceGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetSizeRangeService(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetSizeRangeServiceGenerated } = await import('./sizeRangeService.gb');
    return await buildDotNetSizeRangeServiceGenerated(jsObject, layerId, viewId);
}
