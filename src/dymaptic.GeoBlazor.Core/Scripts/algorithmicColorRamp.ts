// override generated code in this file
import AlgorithmicColorRampGenerated from './algorithmicColorRamp.gb';
import AlgorithmicColorRamp from '@arcgis/core/rest/support/AlgorithmicColorRamp';

export default class AlgorithmicColorRampWrapper extends AlgorithmicColorRampGenerated {

    constructor(component: AlgorithmicColorRamp) {
        super(component);
    }
    
}              
export async function buildJsAlgorithmicColorRamp(dotNetObject: any): Promise<any> {
    let { buildJsAlgorithmicColorRampGenerated } = await import('./algorithmicColorRamp.gb');
    return await buildJsAlgorithmicColorRampGenerated(dotNetObject);
}
export async function buildDotNetAlgorithmicColorRamp(jsObject: any): Promise<any> {
    let { buildDotNetAlgorithmicColorRampGenerated } = await import('./algorithmicColorRamp.gb');
    return await buildDotNetAlgorithmicColorRampGenerated(jsObject);
}
