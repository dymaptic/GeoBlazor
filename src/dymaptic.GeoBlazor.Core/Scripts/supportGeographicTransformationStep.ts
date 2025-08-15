// override generated code in this file
import SupportGeographicTransformationStepGenerated from './supportGeographicTransformationStep.gb';
import supportGeographicTransformationStep from '@arcgis/core/geometry/support/GeographicTransformationStep';

export default class SupportGeographicTransformationStepWrapper extends SupportGeographicTransformationStepGenerated {

    constructor(component: supportGeographicTransformationStep) {
        super(component);
    }
    
}

export async function buildJsSupportGeographicTransformationStep(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsSupportGeographicTransformationStepGenerated } = await import('./supportGeographicTransformationStep.gb');
    return await buildJsSupportGeographicTransformationStepGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetSupportGeographicTransformationStep(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetSupportGeographicTransformationStepGenerated } = await import('./supportGeographicTransformationStep.gb');
    return await buildDotNetSupportGeographicTransformationStepGenerated(jsObject, viewId);
}
