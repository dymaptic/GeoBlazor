import GeographicTransformationStep from '@arcgis/core/geometry/support/GeographicTransformationStep';
import GeographicTransformationStepGenerated from './geographicTransformationStep.gb';

export default class GeographicTransformationStepWrapper extends GeographicTransformationStepGenerated {

    constructor(component: GeographicTransformationStep) {
        super(component);
    }

}

export async function buildJsGeographicTransformationStep(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsGeographicTransformationStepGenerated} = await import('./geographicTransformationStep.gb');
    return await buildJsGeographicTransformationStepGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetGeographicTransformationStep(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildDotNetGeographicTransformationStepGenerated} = await import('./geographicTransformationStep.gb');
    return await buildDotNetGeographicTransformationStepGenerated(jsObject, layerId, viewId);
}
