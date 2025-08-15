// override generated code in this file
import MultipointDrawActionRedoEventGenerated from './multipointDrawActionRedoEvent.gb';
import MultipointDrawActionRedoEvent = __esri.MultipointDrawActionRedoEvent;

export default class MultipointDrawActionRedoEventWrapper extends MultipointDrawActionRedoEventGenerated {

    constructor(component: MultipointDrawActionRedoEvent) {
        super(component);
    }
    
}

export async function buildJsMultipointDrawActionRedoEvent(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsMultipointDrawActionRedoEventGenerated } = await import('./multipointDrawActionRedoEvent.gb');
    return await buildJsMultipointDrawActionRedoEventGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetMultipointDrawActionRedoEvent(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetMultipointDrawActionRedoEventGenerated } = await import('./multipointDrawActionRedoEvent.gb');
    return await buildDotNetMultipointDrawActionRedoEventGenerated(jsObject, viewId);
}
