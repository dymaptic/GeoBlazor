// override generated code in this file
import FrameTaskHandleGenerated from './frameTaskHandle.gb';
import FrameTaskHandle = __esri.FrameTaskHandle;

export default class FrameTaskHandleWrapper extends FrameTaskHandleGenerated {

    constructor(component: FrameTaskHandle) {
        super(component);
    }

}

export async function buildJsFrameTaskHandle(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsFrameTaskHandleGenerated} = await import('./frameTaskHandle.gb');
    return await buildJsFrameTaskHandleGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetFrameTaskHandle(jsObject: any): Promise<any> {
    let {buildDotNetFrameTaskHandleGenerated} = await import('./frameTaskHandle.gb');
    return await buildDotNetFrameTaskHandleGenerated(jsObject);
}
