// override generated code in this file
import ViewKeyUpEventGenerated from './viewKeyUpEvent.gb';
import ViewKeyUpEvent = __esri.ViewKeyUpEvent;

export default class ViewKeyUpEventWrapper extends ViewKeyUpEventGenerated {

    constructor(component: ViewKeyUpEvent) {
        super(component);
    }
    
}

export async function buildJsViewKeyUpEvent(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsViewKeyUpEventGenerated } = await import('./viewKeyUpEvent.gb');
    return await buildJsViewKeyUpEventGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetViewKeyUpEvent(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetViewKeyUpEventGenerated } = await import('./viewKeyUpEvent.gb');
    return await buildDotNetViewKeyUpEventGenerated(jsObject, viewId);
}
