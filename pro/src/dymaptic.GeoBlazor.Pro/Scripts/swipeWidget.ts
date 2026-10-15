// override generated code in this file
import SwipeWidgetGenerated from './swipeWidget.gb';
import Swipe from "@arcgis/core/widgets/Swipe";
import {hasValue} from './geoBlazorCore';

export default class SwipeWidgetWrapper extends SwipeWidgetGenerated {

    constructor(widget: Swipe) {
        super(widget);
    }
    
}

export async function buildJsSwipeWidget(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsSwipeWidgetGenerated } = await import('./swipeWidget.gb');
    let jsObject = await buildJsSwipeWidgetGenerated(dotNetObject, layerId, viewId);

    if (hasValue(dotNetObject.leadingLayers) && dotNetObject.leadingLayers.length > 0) {
        let { buildJsLayer } = await import('./layer');
        jsObject.leadingLayers = await Promise.all(dotNetObject.leadingLayers.map(async i => await buildJsLayer(i, i.id, viewId))) as any;
    }
    if (hasValue(dotNetObject.trailingLayers) && dotNetObject.trailingLayers.length > 0) {
        let { buildJsLayer } = await import('./layer');
        jsObject.trailingLayers = await Promise.all(dotNetObject.trailingLayers.map(async i => await buildJsLayer(i, i.Id, viewId))) as any;
    }
    
    return jsObject;
}     

export async function buildDotNetSwipeWidget(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetSwipeWidgetGenerated } = await import('./swipeWidget.gb');
    return await buildDotNetSwipeWidgetGenerated(jsObject, layerId, viewId);
}
