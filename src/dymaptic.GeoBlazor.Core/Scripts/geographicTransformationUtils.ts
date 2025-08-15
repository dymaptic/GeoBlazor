// override generated code in this file
import GeographicTransformationUtilsGenerated from './geographicTransformationUtils.gb';
import geographicTransformationUtils = __esri.geographicTransformationUtils;

export default class GeographicTransformationUtilsWrapper extends GeographicTransformationUtilsGenerated {

    constructor(component: geographicTransformationUtils) {
        super(component);
    }
    
}

export async function buildJsGeographicTransformationUtils(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsGeographicTransformationUtilsGenerated } = await import('./geographicTransformationUtils.gb');
    return await buildJsGeographicTransformationUtilsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetGeographicTransformationUtils(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetGeographicTransformationUtilsGenerated } = await import('./geographicTransformationUtils.gb');
    return await buildDotNetGeographicTransformationUtilsGenerated(jsObject, viewId);
}
