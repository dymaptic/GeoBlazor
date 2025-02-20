// override generated code in this file
import ISearchLayerGenerated from './iSearchLayer.gb';
import SearchLayer from '@arcgis/core/webdoc/applicationProperties/SearchLayer';

export default class ISearchLayerWrapper extends ISearchLayerGenerated {

    constructor(layer: SearchLayer) {
        super(layer);
    }

}

export async function buildJsISearchLayer(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsISearchLayerGenerated} = await import('./iSearchLayer.gb');
    return await buildJsISearchLayerGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetISearchLayer(jsObject: any): Promise<any> {
    let {buildDotNetISearchLayerGenerated} = await import('./iSearchLayer.gb');
    return await buildDotNetISearchLayerGenerated(jsObject);
}
