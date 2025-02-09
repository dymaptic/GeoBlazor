// override generated code in this file
import RendererGenerated from './renderer.gb';
import Renderer from '@arcgis/core/renderers/Renderer';

export default class RendererWrapper extends RendererGenerated {

    constructor(component: Renderer) {
        super(component);
    }
    
}

export async function buildJsRenderer(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsRendererGenerated } = await import('./renderer.gb');
    return await buildJsRendererGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetRenderer(jsObject: any): Promise<any> {
    let { buildDotNetRendererGenerated } = await import('./renderer.gb');
    return await buildDotNetRendererGenerated(jsObject);
}
