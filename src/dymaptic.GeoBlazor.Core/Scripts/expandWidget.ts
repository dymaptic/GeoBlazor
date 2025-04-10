// override generated code in this file
import ExpandWidgetGenerated from './expandWidget.gb';
import Expand from '@arcgis/core/widgets/Expand';
import {arcGisObjectRefs, hasValue} from "./arcGisJsInterop";
import {buildJsWidget} from "./widget";

export default class ExpandWidgetWrapper extends ExpandWidgetGenerated {

    constructor(widget: Expand) {
        super(widget);
    }

}

export async function buildJsExpandWidget(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsExpandWidgetGenerated} = await import('./expandWidget.gb');
    let jsExpand = await buildJsExpandWidgetGenerated(dotNetObject, layerId, viewId);
    let expandWidgetDiv =
        document.getElementById(`widget-container-${dotNetObject.id}`) as HTMLElement;
    if (expandWidgetDiv === null) {
        return null;
    }

    // remove comment nodes
    expandWidgetDiv.innerHTML = '';
    
    expandWidgetDiv.hidden = false;
    if (hasValue(dotNetObject.htmlContent)) {
        let templatedContent = document.createElement('template');
        templatedContent.innerHTML = dotNetObject.htmlContent;
        expandWidgetDiv.appendChild(templatedContent.content.firstChild!);
    }

    if (hasValue(dotNetObject.widgetContent)) {
        let innerWidget = await buildJsWidget(dotNetObject.widgetContent, layerId, viewId);
        innerWidget.view = arcGisObjectRefs[viewId!];
        let innerWidgetDiv = document.createElement('div');
        innerWidget.container = innerWidgetDiv;
        expandWidgetDiv.appendChild(innerWidgetDiv);
    }

    jsExpand.content = expandWidgetDiv;
    
    return jsExpand;
}

export async function buildDotNetExpandWidget(jsObject: any): Promise<any> {
    let {buildDotNetExpandWidgetGenerated} = await import('./expandWidget.gb');
    return await buildDotNetExpandWidgetGenerated(jsObject);
}
