// override generated code in this file
import MeasureFromImageParametersGenerated from './measureFromImageParameters.gb';
import MeasureFromImageParameters from '@arcgis/core/rest/support/MeasureFromImageParameters';

export default class MeasureFromImageParametersWrapper extends MeasureFromImageParametersGenerated {

    constructor(component: MeasureFromImageParameters) {
        super(component);
    }
    
}              
export async function buildJsMeasureFromImageParameters(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsMeasureFromImageParametersGenerated } = await import('./measureFromImageParameters.gb');
    return await buildJsMeasureFromImageParametersGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetMeasureFromImageParameters(jsObject: any): Promise<any> {
    let { buildDotNetMeasureFromImageParametersGenerated } = await import('./measureFromImageParameters.gb');
    return await buildDotNetMeasureFromImageParametersGenerated(jsObject);
}
