// override generated code in this file
import CollectionBeforeAddEventGenerated from './collectionBeforeAddEvent.gb';
import CollectionBeforeAddEvent = __esri.CollectionBeforeAddEvent;

export default class CollectionBeforeAddEventWrapper extends CollectionBeforeAddEventGenerated {

    constructor(component: CollectionBeforeAddEvent) {
        super(component);
    }
    
}

export async function buildJsCollectionBeforeAddEvent(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsCollectionBeforeAddEventGenerated } = await import('./collectionBeforeAddEvent.gb');
    return await buildJsCollectionBeforeAddEventGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetCollectionBeforeAddEvent(jsObject: any): Promise<any> {
    let { buildDotNetCollectionBeforeAddEventGenerated } = await import('./collectionBeforeAddEvent.gb');
    return await buildDotNetCollectionBeforeAddEventGenerated(jsObject);
}
