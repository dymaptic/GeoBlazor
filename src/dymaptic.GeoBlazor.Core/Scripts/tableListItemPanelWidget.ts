// override generated code in this file
import TableListItemPanelWidgetGenerated from './tableListItemPanelWidget.gb';
import TableListListItemPanel from '@arcgis/core/widgets/TableList/ListItemPanel';

export default class TableListItemPanelWidgetWrapper extends TableListItemPanelWidgetGenerated {

    constructor(widget: TableListListItemPanel) {
        super(widget);
    }
    
}

export async function buildJsTableListItemPanelWidget(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsTableListItemPanelWidgetGenerated } = await import('./tableListItemPanelWidget.gb');
    return await buildJsTableListItemPanelWidgetGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetTableListItemPanelWidget(jsObject: any): Promise<any> {
    let { buildDotNetTableListItemPanelWidgetGenerated } = await import('./tableListItemPanelWidget.gb');
    return await buildDotNetTableListItemPanelWidgetGenerated(jsObject);
}
