// override generated code in this file
import StopGenerated from './stop.gb';
import Stop from '@arcgis/core/rest/support/Stop';

export default class StopWrapper extends StopGenerated {

    constructor(component: Stop) {
        super(component);
    }
    
}

export async function buildJsStop(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsStopGenerated } = await import('./stop.gb');
    return await buildJsStopGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetStop(jsObject: any): Promise<any> {
    let { buildDotNetStopGenerated } = await import('./stop.gb');
    return await buildDotNetStopGenerated(jsObject);
}
