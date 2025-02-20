import BuildingLevel from '@arcgis/core/widgets/BuildingExplorer/BuildingLevel';
import BuildingLevelGenerated from './buildingLevel.gb';

export default class BuildingLevelWrapper extends BuildingLevelGenerated {

    constructor(component: BuildingLevel) {
        super(component);
    }

}

export async function buildJsBuildingLevel(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsBuildingLevelGenerated} = await import('./buildingLevel.gb');
    return await buildJsBuildingLevelGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetBuildingLevel(jsObject: any): Promise<any> {
    let {buildDotNetBuildingLevelGenerated} = await import('./buildingLevel.gb');
    return await buildDotNetBuildingLevelGenerated(jsObject);
}
