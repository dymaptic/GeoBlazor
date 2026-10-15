// override generated code in this file
import RenderContextGenerated from './renderContext.gb';
import RenderContext = __esri.RenderContext;

export default class RenderContextWrapper extends RenderContextGenerated {

    constructor(component: RenderContext) {
        super(component);
    }
    
}

export async function buildJsRenderContext(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsRenderContextGenerated } = await import('./renderContext.gb');
    return await buildJsRenderContextGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetRenderContext(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetRenderContextGenerated } = await import('./renderContext.gb');
    return await buildDotNetRenderContextGenerated(jsObject, layerId, viewId);
}
