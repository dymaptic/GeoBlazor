// override generated code in this file
import LayerListWidgetGenerated from './layerListWidget.gb';
import LayerList from '@arcgis/core/widgets/LayerList';

export default class LayerListWidgetWrapper extends LayerListWidgetGenerated {

    constructor(widget: LayerList) {
        super(widget);
    }

}

export async function buildJsLayerListWidget(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsLayerListWidgetGenerated} = await import('./layerListWidget.gb');
    return await buildJsLayerListWidgetGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetLayerListWidget(jsObject: any): Promise<any> {
    let {buildDotNetLayerListWidgetGenerated} = await import('./layerListWidget.gb');
    return await buildDotNetLayerListWidgetGenerated(jsObject);
}
