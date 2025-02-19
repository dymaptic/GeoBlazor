// override generated code in this file
import BinsGenerated from './bins.gb';
import bins = __esri.bins;

export default class BinsWrapper extends BinsGenerated {

    constructor(component: bins) {
        super(component);
    }
    
}

export async function buildJsBins(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsBinsGenerated } = await import('./bins.gb');
    return await buildJsBinsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetBins(jsObject: any): Promise<any> {
    let { buildDotNetBinsGenerated } = await import('./bins.gb');
    return await buildDotNetBinsGenerated(jsObject);
}
