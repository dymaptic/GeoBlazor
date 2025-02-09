// override generated code in this file
import LayerFloorInfoGenerated from './layerFloorInfo.gb';
import LayerFloorInfo from '@arcgis/core/layers/support/LayerFloorInfo';

export default class LayerFloorInfoWrapper extends LayerFloorInfoGenerated {

    constructor(component: LayerFloorInfo) {
        super(component);
    }
    
}              
export async function buildJsLayerFloorInfo(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsLayerFloorInfoGenerated } = await import('./layerFloorInfo.gb');
    return await buildJsLayerFloorInfoGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetLayerFloorInfo(jsObject: any): Promise<any> {
    let { buildDotNetLayerFloorInfoGenerated } = await import('./layerFloorInfo.gb');
    return await buildDotNetLayerFloorInfoGenerated(jsObject);
}
