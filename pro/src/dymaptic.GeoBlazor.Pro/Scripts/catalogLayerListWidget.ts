import CatalogLayerList from '@arcgis/core/widgets/CatalogLayerList';
// override generated code in this file
import CatalogLayerListWidgetGenerated from './catalogLayerListWidget.gb';

export default class CatalogLayerListWidgetWrapper extends CatalogLayerListWidgetGenerated {

    constructor(widget: CatalogLayerList) {
        super(widget);
    }
    
}

export async function buildJsCatalogLayerListWidget(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsCatalogLayerListWidgetGenerated } = await import('./catalogLayerListWidget.gb');
    return await buildJsCatalogLayerListWidgetGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetCatalogLayerListWidget(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetCatalogLayerListWidgetGenerated } = await import('./catalogLayerListWidget.gb');
    return await buildDotNetCatalogLayerListWidgetGenerated(jsObject, layerId, viewId);
}
