// override generated code in this file
import IdentifyServiceGenerated from './identifyService.gb';
import identify = __esri.identify;

export default class IdentifyServiceWrapper extends IdentifyServiceGenerated {

    constructor(component: identify) {
        super(component);
    }
    
}

export async function buildJsIdentifyService(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsIdentifyServiceGenerated } = await import('./identifyService.gb');
    return await buildJsIdentifyServiceGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetIdentifyService(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetIdentifyServiceGenerated } = await import('./identifyService.gb');
    return await buildDotNetIdentifyServiceGenerated(jsObject, layerId, viewId);
}
