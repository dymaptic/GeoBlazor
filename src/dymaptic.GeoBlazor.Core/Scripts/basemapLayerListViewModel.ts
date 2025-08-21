// override generated code in this file
import BasemapLayerListViewModelGenerated from './basemapLayerListViewModel.gb';
import BasemapLayerListViewModel from '@arcgis/core/widgets/BasemapLayerList/BasemapLayerListViewModel';
import {hasValue} from "./arcGisJsInterop";
import {DotNetListItem} from "./definitions";

export default class BasemapLayerListViewModelWrapper extends BasemapLayerListViewModelGenerated {

    constructor(component: BasemapLayerListViewModel) {
        super(component);
    }

}

export async function buildJsBasemapLayerListViewModel(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsBasemapLayerListViewModelGenerated} = await import('./basemapLayerListViewModel.gb');
    let jsViewModel = await buildJsBasemapLayerListViewModelGenerated(dotNetObject, layerId, viewId);
    if (hasValue(dotNetObject.hasCustomBaseListHandler) && dotNetObject.hasCustomBaseListHandler) {
        let {buildDotNetListItem} = await import('./listItem');
        jsViewModel.baseListItemCreatedFunction = async (evt) => {
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
        jsViewModel.referenceListItemCreatedFunction = async (evt) => {
            const dotNetReferenceListItem = await buildDotNetListItem(evt.item, viewId);
            const returnItem = await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnReferenceListItemCreated', dotNetReferenceListItem) as DotNetListItem;
            if (hasValue(returnItem) && hasValue(evt.item)) {
                let {updateListItem} = await import('./listItem');
                await updateListItem(evt.item, returnItem, dotNetReferenceListItem?.layerId, viewId);
            }
        };
    }
    
    return jsViewModel;
}

export async function buildDotNetBasemapLayerListViewModel(jsObject: any, viewId: string | null): Promise<any> {
    let {buildDotNetBasemapLayerListViewModelGenerated} = await import('./basemapLayerListViewModel.gb');
    return await buildDotNetBasemapLayerListViewModelGenerated(jsObject, viewId);
}
