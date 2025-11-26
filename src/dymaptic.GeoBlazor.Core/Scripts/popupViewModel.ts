import PopupViewModel from '@arcgis/core/widgets/Popup/PopupViewModel';
import PopupViewModelGenerated from './popupViewModel.gb';
import {hasValue} from './geoBlazorCore';
import {buildJsWidget} from "./widget";
import Widget from "@arcgis/core/widgets/Widget";

export default class PopupViewModelWrapper extends PopupViewModelGenerated {

    constructor(component: PopupViewModel) {
        super(component);
    }

}

export async function buildJsPopupViewModel(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsPopupViewModelGenerated} = await import('./popupViewModel.gb');
    let jsViewModel = await buildJsPopupViewModelGenerated(dotNetObject, layerId, viewId);
    if (hasValue(dotNetObject.widgetContent)) {
        const widgetContent = await buildJsWidget(dotNetObject.widgetContent, dotNetObject.widgetContent.layerId, viewId);
        if (hasValue(widgetContent)) {
            jsViewModel.content = widgetContent as Widget;
        }
    }

    if (hasValue(dotNetObject.htmlContent)) {
        jsViewModel.content = dotNetObject.htmlContent;
    }

    if (hasValue(dotNetObject.stringContent)) {
        jsViewModel.content = dotNetObject.stringContent;
    }

    return jsViewModel;
}

export async function buildDotNetPopupViewModel(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildDotNetPopupViewModelGenerated} = await import('./popupViewModel.gb');
    return await buildDotNetPopupViewModelGenerated(jsObject, layerId, viewId);
}
