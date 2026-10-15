// override generated code in this file
import {buildEncodedJson, hasValue} from './geoBlazorCore';
import GroupLayerGenerated from './groupLayer.gb';
import GroupLayer from '@arcgis/core/layers/GroupLayer';

export default class GroupLayerWrapper extends GroupLayerGenerated {

    constructor(layer: GroupLayer) {
        super(layer);
    }

    async load(options: any): Promise<any> {
        let result = await this.layer.load(options);
        let dotNetLayer = await buildDotNetGroupLayer(result, this.layerId, this.viewId);
        return buildEncodedJson(dotNetLayer);
    }
}

export async function buildJsGroupLayer(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsGroupLayerGenerated } = await import('./groupLayer.gb');
    return await buildJsGroupLayerGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetGroupLayer(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetGroupLayerGenerated } = await import('./groupLayer.gb');
    let dnGroupLayer = await buildDotNetGroupLayerGenerated(jsObject, layerId, viewId);
    if (hasValue(jsObject.layers)) {
        let { buildDotNetLayer } = await import('./layer');
        dnGroupLayer.layers = await Promise.all(jsObject.layers.map(async (layer: any) => await buildDotNetLayer(layer, layerId, viewId)));
    }
    
    return dnGroupLayer;
}
