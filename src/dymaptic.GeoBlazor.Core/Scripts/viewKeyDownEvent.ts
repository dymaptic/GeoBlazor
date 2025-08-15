// override generated code in this file
import ViewKeyDownEventGenerated from './viewKeyDownEvent.gb';
import ViewKeyDownEvent = __esri.ViewKeyDownEvent;

export default class ViewKeyDownEventWrapper extends ViewKeyDownEventGenerated {

    constructor(component: ViewKeyDownEvent) {
        super(component);
    }
    
}

export async function buildJsViewKeyDownEvent(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsViewKeyDownEventGenerated } = await import('./viewKeyDownEvent.gb');
    return await buildJsViewKeyDownEventGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetViewKeyDownEvent(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetViewKeyDownEventGenerated } = await import('./viewKeyDownEvent.gb');
    return await buildDotNetViewKeyDownEventGenerated(jsObject, viewId);
}
