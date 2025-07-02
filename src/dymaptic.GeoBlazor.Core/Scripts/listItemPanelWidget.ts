// override generated code in this file
import {arcGisObjectRefs, hasValue, jsObjectRefs} from "./arcGisJsInterop";
import { buildJsWidget } from "./widget";

export async function buildJsListItemPanelWidget(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
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
    } else if (hasValue(dotNetObject.showLegendContent)) {
        properties.content = 'legend';
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

export async function buildDotNetListItemPanelWidget(jsObject: any): Promise<any> {
    let {buildDotNetListItemPanelWidgetGenerated} = await import('./listItemPanelWidget.gb');
    return await buildDotNetListItemPanelWidgetGenerated(jsObject);
}
