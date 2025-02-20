// override generated code in this file
import IPopupViewGenerated from './iPopupView.gb';
import PopupView = __esri.PopupView;

export default class IPopupViewWrapper extends IPopupViewGenerated {

    constructor(component: PopupView) {
        super(component);
    }

}

export async function buildJsIPopupView(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsIPopupViewGenerated} = await import('./iPopupView.gb');
    return await buildJsIPopupViewGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetIPopupView(jsObject: any): Promise<any> {
    let {buildDotNetIPopupViewGenerated} = await import('./iPopupView.gb');
    return await buildDotNetIPopupViewGenerated(jsObject);
}
