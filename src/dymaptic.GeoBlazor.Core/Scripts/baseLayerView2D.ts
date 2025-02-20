import BaseLayerView2D from '@arcgis/core/views/2d/layers/BaseLayerView2D';
import BaseLayerView2DGenerated from './baseLayerView2D.gb';

export default class BaseLayerView2DWrapper extends BaseLayerView2DGenerated {

    constructor(component: BaseLayerView2D) {
        super(component);
    }

}

export async function buildJsBaseLayerView2D(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsBaseLayerView2DGenerated} = await import('./baseLayerView2D.gb');
    return await buildJsBaseLayerView2DGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetBaseLayerView2D(jsObject: any): Promise<any> {
    let {buildDotNetBaseLayerView2DGenerated} = await import('./baseLayerView2D.gb');
    return await buildDotNetBaseLayerView2DGenerated(jsObject);
}
