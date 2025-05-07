// override generated code in this file
import MultipointDrawActionVertexAddEventGenerated from './multipointDrawActionVertexAddEvent.gb';
import MultipointDrawActionVertexAddEvent = __esri.MultipointDrawActionVertexAddEvent;

export default class MultipointDrawActionVertexAddEventWrapper extends MultipointDrawActionVertexAddEventGenerated {

    constructor(component: MultipointDrawActionVertexAddEvent) {
        super(component);
    }
    
}

export async function buildJsMultipointDrawActionVertexAddEvent(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsMultipointDrawActionVertexAddEventGenerated } = await import('./multipointDrawActionVertexAddEvent.gb');
    return await buildJsMultipointDrawActionVertexAddEventGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetMultipointDrawActionVertexAddEvent(jsObject: any): Promise<any> {
    let { buildDotNetMultipointDrawActionVertexAddEventGenerated } = await import('./multipointDrawActionVertexAddEvent.gb');
    return await buildDotNetMultipointDrawActionVertexAddEventGenerated(jsObject);
}
