// override generated code in this file
import SubtypeSublayerGenerated from './subtypeSublayer.gb';
import SubtypeSublayer from '@arcgis/core/layers/support/SubtypeSublayer';

export default class SubtypeSublayerWrapper extends SubtypeSublayerGenerated {

    constructor(component: SubtypeSublayer) {
        super(component);
    }
    
}

export async function buildJsSubtypeSublayer(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsSubtypeSublayerGenerated } = await import('./subtypeSublayer.gb');
    return await buildJsSubtypeSublayerGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetSubtypeSublayer(jsObject: any): Promise<any> {
    let { buildDotNetSubtypeSublayerGenerated } = await import('./subtypeSublayer.gb');
    return await buildDotNetSubtypeSublayerGenerated(jsObject);
}
