// override generated code in this file
import GeodesicProximityOperatorGenerated from './geodesicProximityOperator.gb';
import geodesicProximityOperator = __esri.geodesicProximityOperator;

export default class GeodesicProximityOperatorWrapper extends GeodesicProximityOperatorGenerated {

    constructor(component: geodesicProximityOperator) {
        super(component);
    }
    
}

export async function buildJsGeodesicProximityOperator(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsGeodesicProximityOperatorGenerated } = await import('./geodesicProximityOperator.gb');
    return await buildJsGeodesicProximityOperatorGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetGeodesicProximityOperator(jsObject: any): Promise<any> {
    let { buildDotNetGeodesicProximityOperatorGenerated } = await import('./geodesicProximityOperator.gb');
    return await buildDotNetGeodesicProximityOperatorGenerated(jsObject);
}
