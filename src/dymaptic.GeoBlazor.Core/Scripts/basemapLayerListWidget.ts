// override generated code in this file
import BasemapLayerListWidgetGenerated from './basemapLayerListWidget.gb';
import BasemapLayerList from '@arcgis/core/widgets/BasemapLayerList';
import {DotNetListItem} from "./definitions";
import {hasValue} from "./arcGisJsInterop";

export default class BasemapLayerListWidgetWrapper extends BasemapLayerListWidgetGenerated {

    constructor(widget: BasemapLayerList) {
        super(widget);
    }

}

export async function buildJsBasemapLayerListWidget(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsBasemapLayerListWidgetGenerated} = await import('./basemapLayerListWidget.gb');
    let widget = await buildJsBasemapLayerListWidgetGenerated(dotNetObject, layerId, viewId);
    if (hasValue(dotNetObject.hasCustomBaseListHandler) && dotNetObject.hasCustomBaseListHandler) {
        let {buildDotNetListItem} = await import('./listItem');
        widget.baseListItemCreatedFunction = async (evt) => {
            const dotNetBaseListItem = await buildDotNetListItem(evt.item, viewId);
            const returnItem = await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnBaseListItemCreated', dotNetBaseListItem) as DotNetListItem;
            if (hasValue(returnItem) && hasValue(evt.item)) {
                let {updateListItem} = await import('./listItem');
                await updateListItem(evt.item, returnItem, dotNetBaseListItem?.layerId, viewId);
            }
        };
    }
    if (hasValue(dotNetObject.hasCustomReferenceListHandler) && dotNetObject.hasCustomReferenceListHandler) {
        let {buildDotNetListItem} = await import('./listItem');
        widget.referenceListItemCreatedFunction = async (evt) => {
            const dotNetReferenceListItem = await buildDotNetListItem(evt.item, viewId);
            const returnItem = await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnReferenceListItemCreated', dotNetReferenceListItem) as DotNetListItem;
            if (hasValue(returnItem) && hasValue(evt.item)) {
                let {updateListItem} = await import('./listItem');
                await updateListItem(evt.item, returnItem, dotNetReferenceListItem?.layerId, viewId);
            }
        };
    }
    
    return widget;
}

export async function buildDotNetBasemapLayerListWidget(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildDotNetBasemapLayerListWidgetGenerated} = await import('./basemapLayerListWidget.gb');
    return await buildDotNetBasemapLayerListWidgetGenerated(jsObject, layerId, viewId);
}
