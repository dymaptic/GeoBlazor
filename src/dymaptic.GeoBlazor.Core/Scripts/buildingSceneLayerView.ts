import BuildingSceneLayerView from '@arcgis/core/views/layers/BuildingSceneLayerView';
import BuildingSceneLayerViewGenerated from './buildingSceneLayerView.gb';

export default class BuildingSceneLayerViewWrapper extends BuildingSceneLayerViewGenerated {

    constructor(component: BuildingSceneLayerView) {
        super(component);
    }

}

export async function buildJsBuildingSceneLayerView(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsBuildingSceneLayerViewGenerated} = await import('./buildingSceneLayerView.gb');
    return await buildJsBuildingSceneLayerViewGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetBuildingSceneLayerView(jsObject: any): Promise<any> {
    let {buildDotNetBuildingSceneLayerViewGenerated} = await import('./buildingSceneLayerView.gb');
    return await buildDotNetBuildingSceneLayerViewGenerated(jsObject);
}
