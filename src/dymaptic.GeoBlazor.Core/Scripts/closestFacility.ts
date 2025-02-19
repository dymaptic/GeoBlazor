import closestFacility = __esri.closestFacility;
import ClosestFacilityGenerated from './closestFacility.gb';

export default class ClosestFacilityWrapper extends ClosestFacilityGenerated {

    constructor(component: closestFacility) {
        super(component);
    }
    
}

export async function buildJsClosestFacility(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsClosestFacilityGenerated } = await import('./closestFacility.gb');
    return await buildJsClosestFacilityGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetClosestFacility(jsObject: any): Promise<any> {
    let { buildDotNetClosestFacilityGenerated } = await import('./closestFacility.gb');
    return await buildDotNetClosestFacilityGenerated(jsObject);
}
