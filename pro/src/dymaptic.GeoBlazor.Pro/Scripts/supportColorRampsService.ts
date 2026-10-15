// override generated code in this file
import SupportColorRampsServiceGenerated from './supportColorRampsService.gb';
import supportColorRamps = __esri.supportColorRamps;

export default class SupportColorRampsServiceWrapper extends SupportColorRampsServiceGenerated {

    constructor(component: supportColorRamps) {
        super(component);
    }
    
}

export async function buildJsSupportColorRampsService(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsSupportColorRampsServiceGenerated } = await import('./supportColorRampsService.gb');
    return await buildJsSupportColorRampsServiceGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetSupportColorRampsService(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetSupportColorRampsServiceGenerated } = await import('./supportColorRampsService.gb');
    return await buildDotNetSupportColorRampsServiceGenerated(jsObject, layerId, viewId);
}
