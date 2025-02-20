// override generated code in this file
import BuildingComponentSublayerViewGenerated from './buildingComponentSublayerView.gb';
import BuildingComponentSublayerView from '@arcgis/core/views/layers/BuildingComponentSublayerView';

export default class BuildingComponentSublayerViewWrapper extends BuildingComponentSublayerViewGenerated {

    constructor(component: BuildingComponentSublayerView) {
        super(component);
    }

}

export async function buildJsBuildingComponentSublayerView(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsBuildingComponentSublayerViewGenerated} = await import('./buildingComponentSublayerView.gb');
    return await buildJsBuildingComponentSublayerViewGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetBuildingComponentSublayerView(jsObject: any): Promise<any> {
    let {buildDotNetBuildingComponentSublayerViewGenerated} = await import('./buildingComponentSublayerView.gb');
    return await buildDotNetBuildingComponentSublayerViewGenerated(jsObject);
}
