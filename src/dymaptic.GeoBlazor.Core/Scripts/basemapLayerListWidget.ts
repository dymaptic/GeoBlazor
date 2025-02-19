// override generated code in this file
import BasemapLayerListWidgetGenerated from './basemapLayerListWidget.gb';
import BasemapLayerList from '@arcgis/core/widgets/BasemapLayerList';

export default class BasemapLayerListWidgetWrapper extends BasemapLayerListWidgetGenerated {

    constructor(widget: BasemapLayerList) {
        super(widget);
    }
    
}

export async function buildJsBasemapLayerListWidget(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsBasemapLayerListWidgetGenerated } = await import('./basemapLayerListWidget.gb');
    return await buildJsBasemapLayerListWidgetGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetBasemapLayerListWidget(jsObject: any): Promise<any> {
    let { buildDotNetBasemapLayerListWidgetGenerated } = await import('./basemapLayerListWidget.gb');
    return await buildDotNetBasemapLayerListWidgetGenerated(jsObject);
}
