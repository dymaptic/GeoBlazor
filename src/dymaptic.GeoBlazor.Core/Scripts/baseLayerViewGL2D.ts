// override generated code in this file
import BaseLayerViewGL2DGenerated from './baseLayerViewGL2D.gb';
import BaseLayerViewGL2D from '@arcgis/core/views/2d/layers/BaseLayerViewGL2D';

export default class BaseLayerViewGL2DWrapper extends BaseLayerViewGL2DGenerated {

    constructor(component: BaseLayerViewGL2D) {
        super(component);
    }

}

export async function buildJsBaseLayerViewGL2D(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsBaseLayerViewGL2DGenerated} = await import('./baseLayerViewGL2D.gb');
    return await buildJsBaseLayerViewGL2DGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetBaseLayerViewGL2D(jsObject: any): Promise<any> {
    let {buildDotNetBaseLayerViewGL2DGenerated} = await import('./baseLayerViewGL2D.gb');
    return await buildDotNetBaseLayerViewGL2DGenerated(jsObject);
}
