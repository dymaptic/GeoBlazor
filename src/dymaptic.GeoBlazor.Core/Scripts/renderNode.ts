// override generated code in this file
import RenderNodeGenerated from './renderNode.gb';
import RenderNode from '@arcgis/core/views/3d/webgl/RenderNode';

export default class RenderNodeWrapper extends RenderNodeGenerated {

    constructor(component: RenderNode) {
        super(component);
    }
    
}

export async function buildJsRenderNode(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsRenderNodeGenerated } = await import('./renderNode.gb');
    return await buildJsRenderNodeGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetRenderNode(jsObject: any): Promise<any> {
    let { buildDotNetRenderNodeGenerated } = await import('./renderNode.gb');
    return await buildDotNetRenderNodeGenerated(jsObject);
}
