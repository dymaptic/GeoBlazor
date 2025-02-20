import BuildingGroupSublayer from '@arcgis/core/layers/buildingSublayers/BuildingGroupSublayer';
import BuildingGroupSublayerGenerated from './buildingGroupSublayer.gb';

export default class BuildingGroupSublayerWrapper extends BuildingGroupSublayerGenerated {

    constructor(component: BuildingGroupSublayer) {
        super(component);
    }

}

export async function buildJsBuildingGroupSublayer(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsBuildingGroupSublayerGenerated} = await import('./buildingGroupSublayer.gb');
    return await buildJsBuildingGroupSublayerGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetBuildingGroupSublayer(jsObject: any): Promise<any> {
    let {buildDotNetBuildingGroupSublayerGenerated} = await import('./buildingGroupSublayer.gb');
    return await buildDotNetBuildingGroupSublayerGenerated(jsObject);
}
