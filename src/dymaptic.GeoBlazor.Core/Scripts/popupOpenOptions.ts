import Widget from '@arcgis/core/widgets/Widget';
import { hasValue } from './arcGisJsInterop';
import { buildJsWidget } from './widget';

export async function buildJsPopupOpenOptions(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsPopupOpenOptionsGenerated} = await import('./popupOpenOptions.gb');
    let jsPopupOptions = await buildJsPopupOpenOptionsGenerated(dotNetObject, layerId, viewId);

    if (hasValue(dotNetObject.widgetContent)) {
        const widgetContent = await buildJsWidget(dotNetObject.widgetContent, dotNetObject.widgetContent.layerId, viewId);
        if (hasValue(widgetContent)) {
            jsPopupOptions.content = widgetContent as Widget;
        }
    }
    
    if (hasValue(dotNetObject.htmlContent)) {
        jsPopupOptions.content = dotNetObject.htmlContent;
    }
    
    if (hasValue(dotNetObject.stringContent)) {
        jsPopupOptions.content = dotNetObject.stringContent;
    }

    return jsPopupOptions;
}

export async function buildDotNetPopupOpenOptions(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildDotNetPopupOpenOptionsGenerated} = await import('./popupOpenOptions.gb');
    return await buildDotNetPopupOpenOptionsGenerated(jsObject, layerId, viewId);
}
