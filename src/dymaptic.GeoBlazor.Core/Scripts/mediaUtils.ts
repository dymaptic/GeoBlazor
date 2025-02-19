// override generated code in this file
import MediaUtilsGenerated from './mediaUtils.gb';
import mediaUtils = __esri.mediaUtils;

export default class MediaUtilsWrapper extends MediaUtilsGenerated {

    constructor(component: mediaUtils) {
        super(component);
    }
    
}

export async function buildJsMediaUtils(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsMediaUtilsGenerated } = await import('./mediaUtils.gb');
    return await buildJsMediaUtilsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetMediaUtils(jsObject: any): Promise<any> {
    let { buildDotNetMediaUtilsGenerated } = await import('./mediaUtils.gb');
    return await buildDotNetMediaUtilsGenerated(jsObject);
}
