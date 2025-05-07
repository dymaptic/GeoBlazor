// override generated code in this file
import MultipointDrawActionDrawCompleteEventGenerated from './multipointDrawActionDrawCompleteEvent.gb';
import MultipointDrawActionDrawCompleteEvent = __esri.MultipointDrawActionDrawCompleteEvent;

export default class MultipointDrawActionDrawCompleteEventWrapper extends MultipointDrawActionDrawCompleteEventGenerated {

    constructor(component: MultipointDrawActionDrawCompleteEvent) {
        super(component);
    }
    
}

export async function buildJsMultipointDrawActionDrawCompleteEvent(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsMultipointDrawActionDrawCompleteEventGenerated } = await import('./multipointDrawActionDrawCompleteEvent.gb');
    return await buildJsMultipointDrawActionDrawCompleteEventGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetMultipointDrawActionDrawCompleteEvent(jsObject: any): Promise<any> {
    let { buildDotNetMultipointDrawActionDrawCompleteEventGenerated } = await import('./multipointDrawActionDrawCompleteEvent.gb');
    return await buildDotNetMultipointDrawActionDrawCompleteEventGenerated(jsObject);
}
