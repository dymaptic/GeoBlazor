// override generated code in this file
import SupportGeographicTransformationGenerated from './supportGeographicTransformation.gb';
import supportGeographicTransformation from '@arcgis/core/geometry/support/GeographicTransformation';

export default class SupportGeographicTransformationWrapper extends SupportGeographicTransformationGenerated {

    constructor(component: supportGeographicTransformation) {
        super(component);
    }
    
}

export async function buildJsSupportGeographicTransformation(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsSupportGeographicTransformationGenerated } = await import('./supportGeographicTransformation.gb');
    return await buildJsSupportGeographicTransformationGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetSupportGeographicTransformation(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetSupportGeographicTransformationGenerated } = await import('./supportGeographicTransformation.gb');
    return await buildDotNetSupportGeographicTransformationGenerated(jsObject, viewId);
}
