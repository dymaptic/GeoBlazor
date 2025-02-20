// override generated code in this file
import WatchHandleGenerated from './watchHandle.gb';
import WatchHandle = __esri.WatchHandle;

export default class WatchHandleWrapper extends WatchHandleGenerated {

    constructor(component: WatchHandle) {
        super(component);
    }

}

export async function buildJsWatchHandle(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsWatchHandleGenerated} = await import('./watchHandle.gb');
    return await buildJsWatchHandleGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetWatchHandle(jsObject: any): Promise<any> {
    let {buildDotNetWatchHandleGenerated} = await import('./watchHandle.gb');
    return await buildDotNetWatchHandleGenerated(jsObject);
}
