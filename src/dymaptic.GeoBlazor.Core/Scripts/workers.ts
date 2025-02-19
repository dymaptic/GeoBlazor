// override generated code in this file
import WorkersGenerated from './workers.gb';
import workers = __esri.workers;

export default class WorkersWrapper extends WorkersGenerated {

    constructor(component: workers) {
        super(component);
    }
    
}

export async function buildJsWorkers(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsWorkersGenerated } = await import('./workers.gb');
    return await buildJsWorkersGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetWorkers(jsObject: any): Promise<any> {
    let { buildDotNetWorkersGenerated } = await import('./workers.gb');
    return await buildDotNetWorkersGenerated(jsObject);
}
