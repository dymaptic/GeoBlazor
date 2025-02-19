// override generated code in this file
import BinLevelGenerated from './binLevel.gb';
import binLevel from '@arcgis/core/smartMapping/heuristics/binLevel';

export default class BinLevelWrapper extends BinLevelGenerated {

    constructor(component: binLevel) {
        super(component);
    }
    
}

export async function buildJsBinLevel(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsBinLevelGenerated } = await import('./binLevel.gb');
    return await buildJsBinLevelGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetBinLevel(jsObject: any): Promise<any> {
    let { buildDotNetBinLevelGenerated } = await import('./binLevel.gb');
    return await buildDotNetBinLevelGenerated(jsObject);
}
