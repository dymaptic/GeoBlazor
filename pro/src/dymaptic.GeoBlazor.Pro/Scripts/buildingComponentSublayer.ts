// override generated code in this file
import BuildingComponentSublayerGenerated from './buildingComponentSublayer.gb';
import BuildingComponentSublayer from '@arcgis/core/layers/buildingSublayers/BuildingComponentSublayer';

export default class BuildingComponentSublayerWrapper extends BuildingComponentSublayerGenerated {

    constructor(component: BuildingComponentSublayer) {
        super(component);
    }
    
}

export async function buildJsBuildingComponentSublayer(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsBuildingComponentSublayerGenerated } = await import('./buildingComponentSublayer.gb');
    return await buildJsBuildingComponentSublayerGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetBuildingComponentSublayer(jsObject: any): Promise<any> {
    let { buildDotNetBuildingComponentSublayerGenerated } = await import('./buildingComponentSublayer.gb');
    return await buildDotNetBuildingComponentSublayerGenerated(jsObject);
}
