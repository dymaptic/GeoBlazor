import LocateViewModel from '@arcgis/core/widgets/Locate/LocateViewModel';
import LocateViewModelGenerated from './locateViewModel.gb';
import {hasValue, lookupGeoBlazorId} from "./arcGisJsInterop";

export default class LocateViewModelWrapper extends LocateViewModelGenerated {

    constructor(component: LocateViewModel) {
        super(component);
    }

}

export async function buildJsLocateViewModel(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsLocateViewModelGenerated} = await import('./locateViewModel.gb');
    return await buildJsLocateViewModelGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetLocateViewModel(jsObject: any): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }

    let dotNetLocateViewModel: any = {};

    if (hasValue(jsObject.goToOverride)) {
        let { buildDotNetGoToOverride } = await import('./goToOverride');
        dotNetLocateViewModel.goToOverride = await buildDotNetGoToOverride(jsObject.goToOverride);
    }

    if (hasValue(jsObject.graphic)) {
        let { buildDotNetGraphic } = await import('./graphic');
        dotNetLocateViewModel.graphic = buildDotNetGraphic(jsObject.graphic, null, null);
    }

    if (hasValue(jsObject.error)) {
        dotNetLocateViewModel.error = jsObject.error;
    }

    if (hasValue(jsObject.geolocationOptions)) {
        dotNetLocateViewModel.geolocationOptions = jsObject.geolocationOptions;
    }

    if (hasValue(jsObject.goToLocationEnabled)) {
        dotNetLocateViewModel.goToLocationEnabled = jsObject.goToLocationEnabled;
    }

    if (hasValue(jsObject.popupEnabled)) {
        dotNetLocateViewModel.popupEnabled = jsObject.popupEnabled;
    }

    if (hasValue(jsObject.scale)) {
        dotNetLocateViewModel.scale = jsObject.scale;
    }

    if (hasValue(jsObject.state)) {
        dotNetLocateViewModel.state = jsObject.state;
    }


    let geoBlazorId = lookupGeoBlazorId(jsObject);
    if (hasValue(geoBlazorId)) {
        dotNetLocateViewModel.id = geoBlazorId;
    }

    return dotNetLocateViewModel;
}
