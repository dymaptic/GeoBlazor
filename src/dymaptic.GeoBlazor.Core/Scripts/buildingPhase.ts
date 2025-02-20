// override generated code in this file
import BuildingPhaseGenerated from './buildingPhase.gb';
import BuildingPhase from '@arcgis/core/widgets/BuildingExplorer/BuildingPhase';

export default class BuildingPhaseWrapper extends BuildingPhaseGenerated {

    constructor(component: BuildingPhase) {
        super(component);
    }

}

export async function buildJsBuildingPhase(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsBuildingPhaseGenerated} = await import('./buildingPhase.gb');
    return await buildJsBuildingPhaseGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetBuildingPhase(jsObject: any): Promise<any> {
    let {buildDotNetBuildingPhaseGenerated} = await import('./buildingPhase.gb');
    return await buildDotNetBuildingPhaseGenerated(jsObject);
}
