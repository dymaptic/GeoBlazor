// override generated code in this file
import LayerListWidgetGenerated from './layerListWidget.gb';
import LayerList from '@arcgis/core/widgets/LayerList';
import {DotNetListItem} from "./definitions";
import {hasValue} from './geoBlazorCore';

export default class LayerListWidgetWrapper extends LayerListWidgetGenerated {

    constructor(widget: LayerList) {
        super(widget);
    }

}

export async function buildJsLayerListWidget(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsLayerListWidgetGenerated} = await import('./layerListWidget.gb');
    let widget = await buildJsLayerListWidgetGenerated(dotNetObject, layerId, viewId);
    if (hasValue(dotNetObject.hasCustomHandler) && dotNetObject.hasCustomHandler) {
        let {buildDotNetListItem} = await import('./listItem');
        widget.listItemCreatedFunction = async (evt) => {
            const dotNetListItem = await buildDotNetListItem(evt.item, layerId, viewId);
            const returnItem = await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnListItemCreated', dotNetListItem) as DotNetListItem;
            if (hasValue(returnItem) && hasValue(evt.item)) {
                let {updateListItem} = await import('./listItem');
                await updateListItem(evt.item, returnItem, dotNetListItem?.layerId, viewId);
            }
        };
    }
    
    return widget;
}

export async function buildDotNetLayerListWidget(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildDotNetLayerListWidgetGenerated} = await import('./layerListWidget.gb');
    return await buildDotNetLayerListWidgetGenerated(jsObject, layerId, viewId);
}
