// override generated code in this file
import SchedulingServiceGenerated from './schedulingService.gb';
import scheduling = __esri.scheduling;

export default class SchedulingServiceWrapper extends SchedulingServiceGenerated {

    constructor(component: scheduling) {
        super(component);
    }
    
}

export async function buildJsSchedulingService(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsSchedulingServiceGenerated } = await import('./schedulingService.gb');
    return await buildJsSchedulingServiceGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetSchedulingService(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetSchedulingServiceGenerated } = await import('./schedulingService.gb');
    return await buildDotNetSchedulingServiceGenerated(jsObject, layerId, viewId);
}
