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
    let content: any = null;
    let expandWidgetDiv =
        document.getElementById(`widget-container-${dotNetObject.id}`) as HTMLElement;
    if (expandWidgetDiv === null) {
        return null;
    }

    // remove comment nodes
    for (let i = 0; i < expandWidgetDiv.childNodes.length; i++) {
        let childNode = expandWidgetDiv.childNodes[i];
        if (childNode.nodeType === 8) {
            expandWidgetDiv.removeChild(childNode);
            i --;
        }
    }
    expandWidgetDiv.hidden = false;
    if (hasValue(dotNetObject.htmlContent)) {
        let templatedContent = document.createElement('template');
        templatedContent.innerHTML = dotNetObject.htmlContent;
        expandWidgetDiv.appendChild(templatedContent.content.firstChild!);
    }

    if (hasValue(dotNetObject.widgetContent)) {
        await buildJsWidget(dotNetObject.widgetContent, layerId, viewId);
    }
    
    let view = arcGisObjectRefs[viewId!];
    view.ui.remove(content);
    jsExpand.widget.content = expandWidgetDiv;
    
    return jsExpand;
}

export async function buildDotNetExpandWidget(jsObject: any): Promise<any> {
    let {buildDotNetExpandWidgetGenerated} = await import('./expandWidget.gb');
    return await buildDotNetExpandWidgetGenerated(jsObject);
}
