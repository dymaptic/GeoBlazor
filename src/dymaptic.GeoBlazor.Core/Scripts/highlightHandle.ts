import HighlightHandle = __esri.Handle;
// override generated code in this file
import HighlightHandleGenerated from './highlightHandle.gb';

export default class HighlightHandleWrapper extends HighlightHandleGenerated {

    constructor(component: HighlightHandle) {
        super(component);
    }

}

export async function buildJsHighlightHandle(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsHighlightHandleGenerated} = await import('./highlightHandle.gb');
    return await buildJsHighlightHandleGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetHighlightHandle(jsObject: any): Promise<any> {
    let {buildDotNetHighlightHandleGenerated} = await import('./highlightHandle.gb');
    return await buildDotNetHighlightHandleGenerated(jsObject);
}
