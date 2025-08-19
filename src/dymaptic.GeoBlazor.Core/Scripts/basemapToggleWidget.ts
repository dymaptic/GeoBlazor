import BasemapToggle from '@arcgis/core/widgets/BasemapToggle';
import BasemapToggleWidgetGenerated from './basemapToggleWidget.gb';
import {hasValue} from "./arcGisJsInterop";
import BasemapStyle from "@arcgis/core/support/BasemapStyle";
import Basemap from "@arcgis/core/Basemap";

export default class BasemapToggleWidgetWrapper extends BasemapToggleWidgetGenerated {

    constructor(widget: BasemapToggle) {
        super(widget);
    }

}

export async function buildJsBasemapToggleWidget(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsBasemapToggleWidgetGenerated} = await import('./basemapToggleWidget.gb');
    let jsObject = await buildJsBasemapToggleWidgetGenerated(dotNetObject, layerId, viewId);
    
    if (hasValue(dotNetObject.nextBasemapStyle)) {
        jsObject.nextBasemap = new Basemap({
            style: {
                id: dotNetObject.nextBasemapStyle
            }
        })
    } else if (hasValue(dotNetObject.nextBasemapName)) {
        jsObject.nextBasemap = dotNetObject.nextBasemapName;
    }
    
    return await jsObject;
}

export async function buildDotNetBasemapToggleWidget(jsObject: any, viewId: string | null): Promise<any> {
    let {buildDotNetBasemapToggleWidgetGenerated} = await import('./basemapToggleWidget.gb');
    return await buildDotNetBasemapToggleWidgetGenerated(jsObject, viewId);
}
