// override generated code in this file
import DimensionLayerViewGenerated from './dimensionLayerView.gb';
import DimensionLayerView from '@arcgis/core/views/layers/DimensionLayerView';

export default class DimensionLayerViewWrapper extends DimensionLayerViewGenerated {

    constructor(component: DimensionLayerView) {
        super(component);
    }

}

export async function buildJsDimensionLayerView(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsDimensionLayerViewGenerated} = await import('./dimensionLayerView.gb');
    return await buildJsDimensionLayerViewGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetDimensionLayerView(jsObject: any): Promise<any> {
    let {buildDotNetDimensionLayerViewGenerated} = await import('./dimensionLayerView.gb');
    return await buildDotNetDimensionLayerViewGenerated(jsObject);
}
