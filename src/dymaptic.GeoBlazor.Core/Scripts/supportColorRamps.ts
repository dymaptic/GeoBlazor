import supportColorRamps = __esri.supportColorRamps;
import SupportColorRampsGenerated from './supportColorRamps.gb';

export default class SupportColorRampsWrapper extends SupportColorRampsGenerated {

    constructor(component: supportColorRamps) {
        super(component);
    }
    
}

export async function buildJsSupportColorRamps(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsSupportColorRampsGenerated } = await import('./supportColorRamps.gb');
    return await buildJsSupportColorRampsGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetSupportColorRamps(jsObject: any): Promise<any> {
    let { buildDotNetSupportColorRampsGenerated } = await import('./supportColorRamps.gb');
    return await buildDotNetSupportColorRampsGenerated(jsObject);
}
