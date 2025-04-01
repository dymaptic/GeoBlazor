// override generated code in this file
import LayerListViewModelGenerated from './layerListViewModel.gb';
import LayerListViewModel from '@arcgis/core/widgets/LayerList/LayerListViewModel';
import {hasValue} from "./arcGisJsInterop";
import {DotNetListItem} from "./definitions";

export default class LayerListViewModelWrapper extends LayerListViewModelGenerated {

    constructor(component: LayerListViewModel) {
        super(component);
    }

}

export async function buildJsLayerListViewModel(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsLayerListViewModelGenerated} = await import('./layerListViewModel.gb');
    let jsViewModel = await buildJsLayerListViewModelGenerated(dotNetObject, layerId, viewId);
    if (hasValue(dotNetObject.hasCustomHandler) && dotNetObject.hasCustomHandler) {
        let {buildDotNetListItem} = await import('./listItem');
        jsViewModel.listItemCreatedFunction = async (evt) => {
            const dotNetListItem = await buildDotNetListItem(evt.item);
            const returnItem = await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnListItemCreated', dotNetListItem) as DotNetListItem;
            if (hasValue(returnItem) && hasValue(evt.item)) {
                let {updateListItem} = await import('./listItem');
                await updateListItem(evt.item, returnItem, dotNetListItem?.layerId, viewId);
            }
        };
    }
    
    return jsViewModel;
}

export async function buildDotNetLayerListViewModel(jsObject: any): Promise<any> {
    let {buildDotNetLayerListViewModelGenerated} = await import('./layerListViewModel.gb');
    return await buildDotNetLayerListViewModelGenerated(jsObject);
}
