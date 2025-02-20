// override generated code in this file
import ListItemPanelWidgetGenerated from './listItemPanelWidget.gb';
import ListItemPanel from '@arcgis/core/widgets/LayerList/ListItemPanel';

export default class ListItemPanelWidgetWrapper extends ListItemPanelWidgetGenerated {

    constructor(widget: ListItemPanel) {
        super(widget);
    }

}

export async function buildJsListItemPanelWidget(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsListItemPanelWidgetGenerated} = await import('./listItemPanelWidget.gb');
    return await buildJsListItemPanelWidgetGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetListItemPanelWidget(jsObject: any): Promise<any> {
    let {buildDotNetListItemPanelWidgetGenerated} = await import('./listItemPanelWidget.gb');
    return await buildDotNetListItemPanelWidgetGenerated(jsObject);
}
