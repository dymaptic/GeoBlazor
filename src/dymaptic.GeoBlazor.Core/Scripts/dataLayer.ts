// override generated code in this file
import DataLayerGenerated from './dataLayer.gb';
import DataLayer from '@arcgis/core/rest/support/DataLayer';

export default class DataLayerWrapper extends DataLayerGenerated {

    constructor(layer: DataLayer) {
        super(layer);
    }

}

export async function buildJsDataLayer(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsDataLayerGenerated} = await import('./dataLayer.gb');
    return await buildJsDataLayerGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetDataLayer(jsObject: any): Promise<any> {
    let {buildDotNetDataLayerGenerated} = await import('./dataLayer.gb');
    return await buildDotNetDataLayerGenerated(jsObject);
}
