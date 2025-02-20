import PopupViewModel from '@arcgis/core/widgets/Popup/PopupViewModel';
import PopupViewModelGenerated from './popupViewModel.gb';

export default class PopupViewModelWrapper extends PopupViewModelGenerated {

    constructor(component: PopupViewModel) {
        super(component);
    }

}

export async function buildJsPopupViewModel(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsPopupViewModelGenerated} = await import('./popupViewModel.gb');
    return await buildJsPopupViewModelGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetPopupViewModel(jsObject: any): Promise<any> {
    let {buildDotNetPopupViewModelGenerated} = await import('./popupViewModel.gb');
    return await buildDotNetPopupViewModelGenerated(jsObject);
}
