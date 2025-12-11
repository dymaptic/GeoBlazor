import WebSceneWidgetsGenerated from './webSceneWidgets.gb';
import WebSceneWidgets = __esri.WebSceneWidgets;

export async function buildJsWebSceneWidgets(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsWebSceneWidgetsGenerated } = await import('./webSceneWidgets.gb');
    return await buildJsWebSceneWidgetsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetWebSceneWidgets(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetWebSceneWidgetsGenerated } = await import('./webSceneWidgets.gb');
    return await buildDotNetWebSceneWidgetsGenerated(jsObject, viewId);
}

export default class WebSceneWidgetsWrapper extends WebSceneWidgetsGenerated {

    constructor(component: WebSceneWidgets) {
        super(component);
    }
    
}

