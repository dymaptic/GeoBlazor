// override generated code in this file
import AlgorithmicColorRampGenerated from './algorithmicColorRamp.gb';
import AlgorithmicColorRamp from '@arcgis/core/rest/support/AlgorithmicColorRamp';

export default class AlgorithmicColorRampWrapper extends AlgorithmicColorRampGenerated {

    constructor(component: AlgorithmicColorRamp) {
        super(component);
    }
    
}              
export async function buildJsAlgorithmicColorRamp(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsAlgorithmicColorRampGenerated } = await import('./algorithmicColorRamp.gb');
    return await buildJsAlgorithmicColorRampGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetAlgorithmicColorRamp(jsObject: any): Promise<any> {
    let { buildDotNetAlgorithmicColorRampGenerated } = await import('./algorithmicColorRamp.gb');
    return await buildDotNetAlgorithmicColorRampGenerated(jsObject);
}
