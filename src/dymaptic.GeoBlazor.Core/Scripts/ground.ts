// override generated code in this file
import GroundGenerated from './ground.gb';
import Ground from '@arcgis/core/Ground';

export default class GroundWrapper extends GroundGenerated {

    constructor(component: Ground) {
        super(component);
    }
    
}

export async function buildJsGround(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsGroundGenerated } = await import('./ground.gb');
    return await buildJsGroundGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetGround(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetGroundGenerated } = await import('./ground.gb');
    return await buildDotNetGroundGenerated(jsObject, layerId, viewId);
}
