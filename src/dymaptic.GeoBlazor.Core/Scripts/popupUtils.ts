// override generated code in this file
import PopupUtilsGenerated from './popupUtils.gb';
import popupUtils = __esri.popupUtils;

export default class PopupUtilsWrapper extends PopupUtilsGenerated {

    constructor(component: popupUtils) {
        super(component);
    }

}

export async function buildJsPopupUtils(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsPopupUtilsGenerated} = await import('./popupUtils.gb');
    return await buildJsPopupUtilsGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetPopupUtils(jsObject: any): Promise<any> {
    let {buildDotNetPopupUtilsGenerated} = await import('./popupUtils.gb');
    return await buildDotNetPopupUtilsGenerated(jsObject);
}
