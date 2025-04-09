// override generated code in this file
import GeodesicBufferOperatorGenerated from './geodesicBufferOperator.gb';
import geodesicBufferOperator = __esri.geodesicBufferOperator;

export default class GeodesicBufferOperatorWrapper extends GeodesicBufferOperatorGenerated {

    constructor(component: geodesicBufferOperator) {
        super(component);
    }
    
}

export async function buildJsGeodesicBufferOperator(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsGeodesicBufferOperatorGenerated } = await import('./geodesicBufferOperator.gb');
    return await buildJsGeodesicBufferOperatorGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetGeodesicBufferOperator(jsObject: any): Promise<any> {
    let { buildDotNetGeodesicBufferOperatorGenerated } = await import('./geodesicBufferOperator.gb');
    return await buildDotNetGeodesicBufferOperatorGenerated(jsObject);
}
