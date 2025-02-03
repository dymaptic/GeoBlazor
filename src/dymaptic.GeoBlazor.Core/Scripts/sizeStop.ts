// override generated code in this file
import SizeStopGenerated from './sizeStop.gb';
import SizeStop from '@arcgis/core/renderers/visualVariables/support/SizeStop';

export default class SizeStopWrapper extends SizeStopGenerated {

    constructor(component: SizeStop) {
        super(component);
    }
    
}              
export async function buildJsSizeStop(dotNetObject: any): Promise<any> {
    let { buildJsSizeStopGenerated } = await import('./sizeStop.gb');
    return await buildJsSizeStopGenerated(dotNetObject);
}
export async function buildDotNetSizeStop(jsObject: any): Promise<any> {
    let { buildDotNetSizeStopGenerated } = await import('./sizeStop.gb');
    return await buildDotNetSizeStopGenerated(jsObject);
}
