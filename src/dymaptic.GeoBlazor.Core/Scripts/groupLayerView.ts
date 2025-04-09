// override generated code in this file
import GroupLayerViewGenerated from './groupLayerView.gb';
import GroupLayerView from '@arcgis/core/views/layers/GroupLayerView';

export default class GroupLayerViewWrapper extends GroupLayerViewGenerated {

    constructor(component: GroupLayerView) {
        super(component);
    }
    
}

export async function buildJsGroupLayerView(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsGroupLayerViewGenerated } = await import('./groupLayerView.gb');
    return await buildJsGroupLayerViewGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetGroupLayerView(jsObject: any): Promise<any> {
    let { buildDotNetGroupLayerViewGenerated } = await import('./groupLayerView.gb');
    return await buildDotNetGroupLayerViewGenerated(jsObject);
}
