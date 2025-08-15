// override generated code in this file
import ViewPointerUpEventGenerated from './viewPointerUpEvent.gb';
import ViewPointerUpEvent = __esri.ViewPointerUpEvent;

export default class ViewPointerUpEventWrapper extends ViewPointerUpEventGenerated {

    constructor(component: ViewPointerUpEvent) {
        super(component);
    }
    
}

export async function buildJsViewPointerUpEvent(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsViewPointerUpEventGenerated } = await import('./viewPointerUpEvent.gb');
    return await buildJsViewPointerUpEventGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetViewPointerUpEvent(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetViewPointerUpEventGenerated } = await import('./viewPointerUpEvent.gb');
    return await buildDotNetViewPointerUpEventGenerated(jsObject, viewId);
}
