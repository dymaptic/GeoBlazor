import externalRenderers = __esri.externalRenderers;
import ExternalRenderersGenerated from './externalRenderers.gb';

export default class ExternalRenderersWrapper extends ExternalRenderersGenerated {

    constructor(component: externalRenderers) {
        super(component);
    }
    
}

export async function buildJsExternalRenderers(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsExternalRenderersGenerated } = await import('./externalRenderers.gb');
    return await buildJsExternalRenderersGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetExternalRenderers(jsObject: any): Promise<any> {
    let { buildDotNetExternalRenderersGenerated } = await import('./externalRenderers.gb');
    return await buildDotNetExternalRenderersGenerated(jsObject);
}
