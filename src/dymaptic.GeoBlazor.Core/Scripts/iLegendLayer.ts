// override generated code in this file
import ILegendLayerGenerated from './iLegendLayer.gb';
import LegendLayer from '@arcgis/core/rest/support/LegendLayer';

export default class ILegendLayerWrapper extends ILegendLayerGenerated {

    constructor(layer: LegendLayer) {
        super(layer);
    }

}

export async function buildJsILegendLayer(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsILegendLayerGenerated} = await import('./iLegendLayer.gb');
    return await buildJsILegendLayerGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetILegendLayer(jsObject: any): Promise<any> {
    let {buildDotNetILegendLayerGenerated} = await import('./iLegendLayer.gb');
    return await buildDotNetILegendLayerGenerated(jsObject);
}
