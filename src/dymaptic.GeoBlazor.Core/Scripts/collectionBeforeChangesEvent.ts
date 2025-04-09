// override generated code in this file
import CollectionBeforeChangesEventGenerated from './collectionBeforeChangesEvent.gb';
import CollectionBeforeChangesEvent = __esri.CollectionBeforeChangesEvent;

export default class CollectionBeforeChangesEventWrapper extends CollectionBeforeChangesEventGenerated {

    constructor(component: CollectionBeforeChangesEvent) {
        super(component);
    }
    
}

export async function buildJsCollectionBeforeChangesEvent(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsCollectionBeforeChangesEventGenerated } = await import('./collectionBeforeChangesEvent.gb');
    return await buildJsCollectionBeforeChangesEventGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetCollectionBeforeChangesEvent(jsObject: any): Promise<any> {
    let { buildDotNetCollectionBeforeChangesEventGenerated } = await import('./collectionBeforeChangesEvent.gb');
    return await buildDotNetCollectionBeforeChangesEventGenerated(jsObject);
}
