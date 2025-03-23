import KMLLayerViewGenerated from './kMLLayerView.gb';
import KMLLayerView from "@arcgis/core/views/layers/KMLLayerView";
export async function buildJsKMLLayerView(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsKMLLayerViewGenerated} = await import('./kMLLayerView.gb');
    return await buildJsKMLLayerViewGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetKMLLayerView(jsObject: any): Promise<any> {
    let {buildDotNetKMLLayerViewGenerated} = await import('./kMLLayerView.gb');
    return await buildDotNetKMLLayerViewGenerated(jsObject);
}

export default class KMLLayerViewWrapper extends KMLLayerViewGenerated {

    constructor(component: KMLLayerView) {
        super(component);
    }

}

