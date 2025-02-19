import ClassBreaksRenderer from '@arcgis/core/renderers/ClassBreaksRenderer';
import ClassBreaksRendererGenerated from './classBreaksRenderer.gb';

export default class ClassBreaksRendererWrapper extends ClassBreaksRendererGenerated {

    constructor(component: ClassBreaksRenderer) {
        super(component);
    }
    
}

export async function buildJsClassBreaksRenderer(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsClassBreaksRendererGenerated } = await import('./classBreaksRenderer.gb');
    return await buildJsClassBreaksRendererGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetClassBreaksRenderer(jsObject: any): Promise<any> {
    let { buildDotNetClassBreaksRendererGenerated } = await import('./classBreaksRenderer.gb');
    return await buildDotNetClassBreaksRendererGenerated(jsObject);
}
