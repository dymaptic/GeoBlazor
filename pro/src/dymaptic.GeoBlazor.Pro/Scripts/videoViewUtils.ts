// override generated code in this file
import VideoViewUtilsGenerated from './videoViewUtils.gb';
import videoViewUtils = __esri.videoViewUtils;

export default class VideoViewUtilsWrapper extends VideoViewUtilsGenerated {

    constructor(component: videoViewUtils) {
        super(component);
    }
    
}

export async function buildJsVideoViewUtils(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsVideoViewUtilsGenerated } = await import('./videoViewUtils.gb');
    return await buildJsVideoViewUtilsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetVideoViewUtils(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetVideoViewUtilsGenerated } = await import('./videoViewUtils.gb');
    return await buildDotNetVideoViewUtilsGenerated(jsObject, layerId, viewId);
}
