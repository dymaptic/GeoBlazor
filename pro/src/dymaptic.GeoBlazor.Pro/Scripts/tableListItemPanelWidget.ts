// override generated code in this file
import TableListItemPanelWidgetGenerated from './tableListItemPanelWidget.gb';
import TableListListItemPanel from '@arcgis/core/widgets/TableList/ListItemPanel';
import { hasValue } from './geoBlazorCore';
import { buildJsWidget } from './widget';

export default class TableListItemPanelWidgetWrapper extends TableListItemPanelWidgetGenerated {

    constructor(widget: TableListListItemPanel) {
        super(widget);
    }
    
}

export async function buildJsTableListItemPanelWidget(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    if (!hasValue(dotNetObject)) {
        return null;
    }

    let properties: any = {};

    if (hasValue(dotNetObject.className)) {
        properties.className = dotNetObject.className;
    }

    if (hasValue(dotNetObject.containerId)) {
        let contentDiv = document.getElementById(dotNetObject.containerId);
        properties.content = contentDiv;
    } else if (hasValue(dotNetObject.widgetContent)) {
        let contentWidget = await buildJsWidget(dotNetObject.widgetContent, layerId, viewId);
        properties.content = contentWidget;
    } else if (hasValue(dotNetObject.stringContent)) {
        properties.content = dotNetObject.stringContent;
    } else if (hasValue(dotNetObject.htmlElementContent)) {
        // direct HTML element reference
        properties.content = dotNetObject.htmlElementContent;
    }
    
    if (hasValue(dotNetObject.disabled)) {
        properties.disabled = dotNetObject.disabled;
    }
    if (hasValue(dotNetObject.flowEnabled)) {
        properties.flowEnabled = dotNetObject.flowEnabled;
    }
    if (hasValue(dotNetObject.icon)) {
        properties.icon = dotNetObject.icon;
    }
    if (hasValue(dotNetObject.image)) {
        properties.image = dotNetObject.image;
    }
    if (hasValue(dotNetObject.label)) {
        properties.label = dotNetObject.label;
    }
    if (hasValue(dotNetObject.open)) {
        properties.open = dotNetObject.open;
    }
    if (hasValue(dotNetObject.title)) {
        properties.title = dotNetObject.title;
    }
    if (hasValue(dotNetObject.visible)) {
        properties.visible = dotNetObject.visible;
    }
    if (hasValue(dotNetObject.widgetId)) {
        properties.id = dotNetObject.widgetId;
    }
    
    // instantiating the actual class here causes issues when updating ListItems,
    // so we will pass as properties and let ArcGIS cast it.
    return properties;
}     

export async function buildDotNetTableListItemPanelWidget(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetTableListItemPanelWidgetGenerated } = await import('./tableListItemPanelWidget.gb');
    return await buildDotNetTableListItemPanelWidgetGenerated(jsObject, layerId, viewId);
}
