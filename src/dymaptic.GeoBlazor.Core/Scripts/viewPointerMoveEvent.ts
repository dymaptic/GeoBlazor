// override generated code in this file
import ViewPointerMoveEventGenerated from './viewPointerMoveEvent.gb';
import ViewPointerMoveEvent = __esri.ViewPointerMoveEvent;

export default class ViewPointerMoveEventWrapper extends ViewPointerMoveEventGenerated {

    constructor(component: ViewPointerMoveEvent) {
        super(component);
    }
    
}

export async function buildJsViewPointerMoveEvent(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsViewPointerMoveEventGenerated } = await import('./viewPointerMoveEvent.gb');
    return await buildJsViewPointerMoveEventGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetViewPointerMoveEvent(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetViewPointerMoveEventGenerated } = await import('./viewPointerMoveEvent.gb');
    return await buildDotNetViewPointerMoveEventGenerated(jsObject, viewId);
}
