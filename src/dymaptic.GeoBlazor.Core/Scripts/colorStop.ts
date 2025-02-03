// override generated code in this file
import ColorStopGenerated from './colorStop.gb';
import ColorStop from '@arcgis/core/renderers/visualVariables/support/ColorStop';

export default class ColorStopWrapper extends ColorStopGenerated {

    constructor(component: ColorStop) {
        super(component);
    }
    
}              
export async function buildJsColorStop(dotNetObject: any): Promise<any> {
    let { buildJsColorStopGenerated } = await import('./colorStop.gb');
    return await buildJsColorStopGenerated(dotNetObject);
}
export async function buildDotNetColorStop(jsObject: any): Promise<any> {
    let { buildDotNetColorStopGenerated } = await import('./colorStop.gb');
    return await buildDotNetColorStopGenerated(jsObject);
}
