import identify = __esri.identify;
import IdentifyServiceGenerated from './identifyService.gb';

export default class IdentifyServiceWrapper extends IdentifyServiceGenerated {

    constructor(component: identify) {
        super(component);
    }
    
}

export async function buildJsIdentifyService(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsIdentifyServiceGenerated } = await import('./identifyService.gb');
    return await buildJsIdentifyServiceGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetIdentifyService(jsObject: any): Promise<any> {
    let { buildDotNetIdentifyServiceGenerated } = await import('./identifyService.gb');
    return await buildDotNetIdentifyServiceGenerated(jsObject);
}
