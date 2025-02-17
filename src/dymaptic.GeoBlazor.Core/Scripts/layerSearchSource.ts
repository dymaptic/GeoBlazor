// override generated code in this file
import LayerSearchSourceGenerated from './layerSearchSource.gb';
import LayerSearchSource from "@arcgis/core/widgets/Search/LayerSearchSource";

export default class LayerSearchSourceWrapper extends LayerSearchSourceGenerated {

    constructor(component: LayerSearchSource) {
        super(component);
    }

}

export async function buildJsLayerSearchSource(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsLayerSearchSourceGenerated } = await import('./layerSearchSource.gb');
    return await buildJsLayerSearchSourceGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetLayerSearchSource(jsObject: any): Promise<any> {
    let { buildDotNetLayerSearchSourceGenerated } = await import('./layerSearchSource.gb');
    return await buildDotNetLayerSearchSourceGenerated(jsObject);
}
