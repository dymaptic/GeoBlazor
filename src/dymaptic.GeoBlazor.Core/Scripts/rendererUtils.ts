// override generated code in this file
import RendererUtilsGenerated from './rendererUtils.gb';
import rendererUtils = __esri.rendererUtils;

export default class RendererUtilsWrapper extends RendererUtilsGenerated {

    constructor(component: rendererUtils) {
        super(component);
    }
    
}

export async function buildJsRendererUtils(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsRendererUtilsGenerated } = await import('./rendererUtils.gb');
    return await buildJsRendererUtilsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetRendererUtils(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetRendererUtilsGenerated } = await import('./rendererUtils.gb');
    return await buildDotNetRendererUtilsGenerated(jsObject, viewId);
}
