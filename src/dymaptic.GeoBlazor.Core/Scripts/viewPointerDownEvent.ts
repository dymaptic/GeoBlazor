// override generated code in this file
import ViewPointerDownEventGenerated from './viewPointerDownEvent.gb';
import ViewPointerDownEvent = __esri.ViewPointerDownEvent;

export default class ViewPointerDownEventWrapper extends ViewPointerDownEventGenerated {

    constructor(component: ViewPointerDownEvent) {
        super(component);
    }
    
}

export async function buildJsViewPointerDownEvent(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsViewPointerDownEventGenerated } = await import('./viewPointerDownEvent.gb');
    return await buildJsViewPointerDownEventGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetViewPointerDownEvent(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetViewPointerDownEventGenerated } = await import('./viewPointerDownEvent.gb');
    return await buildDotNetViewPointerDownEventGenerated(jsObject, viewId);
}
