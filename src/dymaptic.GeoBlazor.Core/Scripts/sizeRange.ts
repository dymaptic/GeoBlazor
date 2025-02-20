// override generated code in this file
import SizeRangeGenerated from './sizeRange.gb';
import sizeRange from '@arcgis/core/smartMapping/heuristics/sizeRange';

export default class SizeRangeWrapper extends SizeRangeGenerated {

    constructor(component: sizeRange) {
        super(component);
    }

}

export async function buildJsSizeRange(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsSizeRangeGenerated} = await import('./sizeRange.gb');
    return await buildJsSizeRangeGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetSizeRange(jsObject: any): Promise<any> {
    let {buildDotNetSizeRangeGenerated} = await import('./sizeRange.gb');
    return await buildDotNetSizeRangeGenerated(jsObject);
}
