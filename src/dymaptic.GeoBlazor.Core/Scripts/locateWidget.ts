// override generated code in this file
import LocateWidgetGenerated from './locateWidget.gb';
import Locate from '@arcgis/core/widgets/Locate';
import {hasValue, lookupGeoBlazorId} from "./arcGisJsInterop";

export default class LocateWidgetWrapper extends LocateWidgetGenerated {

    constructor(widget: Locate) {
        super(widget);
    }

}

export async function buildJsLocateWidget(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsLocateWidgetGenerated} = await import('./locateWidget.gb');
    return await buildJsLocateWidgetGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetLocateWidget(jsObject: any): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }

    let dotNetLocateWidget: any = {};

    if (hasValue(jsObject.goToOverride)) {
        let { buildDotNetGoToOverride } = await import('./goToOverride');
        dotNetLocateWidget.goToOverride = await buildDotNetGoToOverride(jsObject.goToOverride);
    }

    if (hasValue(jsObject.graphic)) {
        let { buildDotNetGraphic } = await import('./graphic');
        dotNetLocateWidget.graphic = buildDotNetGraphic(jsObject.graphic, null, null);
    }

    if (hasValue(jsObject.viewModel)) {
        let { buildDotNetLocateViewModel } = await import('./locateViewModel');
        dotNetLocateWidget.viewModel = await buildDotNetLocateViewModel(jsObject.viewModel);
    }

    if (hasValue(jsObject.geolocationOptions)) {
        dotNetLocateWidget.geolocationOptions = jsObject.geolocationOptions;
    }

    if (hasValue(jsObject.goToLocationEnabled)) {
        dotNetLocateWidget.goToLocationEnabled = jsObject.goToLocationEnabled;
    }

    if (hasValue(jsObject.icon)) {
        dotNetLocateWidget.icon = jsObject.icon;
    }

    if (hasValue(jsObject.label)) {
        dotNetLocateWidget.label = jsObject.label;
    }

    if (hasValue(jsObject.popupEnabled)) {
        dotNetLocateWidget.popupEnabled = jsObject.popupEnabled;
    }

    if (hasValue(jsObject.scale)) {
        dotNetLocateWidget.scale = jsObject.scale;
    }

    if (hasValue(jsObject.type)) {
        dotNetLocateWidget.type = jsObject.type;
    }

    if (hasValue(jsObject.visible)) {
        dotNetLocateWidget.visible = jsObject.visible;
    }

    if (hasValue(jsObject.id)) {
        dotNetLocateWidget.widgetId = jsObject.id;
    }


    let geoBlazorId = lookupGeoBlazorId(jsObject);
    if (hasValue(geoBlazorId)) {
        dotNetLocateWidget.id = geoBlazorId;
    }

    return dotNetLocateWidget;
}
