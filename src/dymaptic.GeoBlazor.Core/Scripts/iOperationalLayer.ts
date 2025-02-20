// override generated code in this file
import IOperationalLayerGenerated from './iOperationalLayer.gb';
import OperationalLayer = __esri.OperationalLayer;

export default class IOperationalLayerWrapper extends IOperationalLayerGenerated {

    constructor(layer: OperationalLayer) {
        super(layer);
    }

}

export async function buildJsIOperationalLayer(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsIOperationalLayerGenerated} = await import('./iOperationalLayer.gb');
    return await buildJsIOperationalLayerGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetIOperationalLayer(jsObject: any): Promise<any> {
    let {buildDotNetIOperationalLayerGenerated} = await import('./iOperationalLayer.gb');
    return await buildDotNetIOperationalLayerGenerated(jsObject);
}
