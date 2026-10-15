// override generated code in this file
import SearchResultRendererWidgetGenerated from './searchResultRendererWidget.gb';
import SearchResultRenderer from '@arcgis/core/widgets/Search/SearchResultRenderer';

export default class SearchResultRendererWidgetWrapper extends SearchResultRendererWidgetGenerated {

    constructor(widget: SearchResultRenderer) {
        super(widget);
    }
    
}

export async function buildJsSearchResultRendererWidget(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsSearchResultRendererWidgetGenerated } = await import('./searchResultRendererWidget.gb');
    return await buildJsSearchResultRendererWidgetGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetSearchResultRendererWidget(jsObject: any): Promise<any> {
    let { buildDotNetSearchResultRendererWidgetGenerated } = await import('./searchResultRendererWidget.gb');
    return await buildDotNetSearchResultRendererWidgetGenerated(jsObject);
}
