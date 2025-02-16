// override generated code in this file
import ColorRampGenerated from './colorRamp.gb';
import ColorRamp from '@arcgis/core/rest/support/ColorRamp';

export default class ColorRampWrapper extends ColorRampGenerated {

    constructor(component: ColorRamp) {
        super(component);
    }
    
}

export async function buildJsColorRamp(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    switch (dotNetObject?.type) {
        case 'multipart':
            let {buildJsMultipartColorRamp} = await import('./multipartColorRamp');
            return await buildJsMultipartColorRamp(dotNetObject, layerId, viewId);
        case 'algorithmic':
            let {buildJsAlgorithmicColorRamp} = await import('./algorithmicColorRamp');
            return await buildJsAlgorithmicColorRamp(dotNetObject, layerId, viewId);
        default:
            throw new Error(`Unsupported color ramp type: ${dotNetObject?.type}`);
    }
}     

export async function buildDotNetColorRamp(jsObject: any): Promise<any> {
    switch (jsObject?.type) {
        case 'multipart':
            let {buildDotNetMultipartColorRamp} = await import('./multipartColorRamp');
            return await buildDotNetMultipartColorRamp(jsObject);
        case 'algorithmic':
            let {buildDotNetAlgorithmicColorRamp} = await import('./algorithmicColorRamp');
            return await buildDotNetAlgorithmicColorRamp(jsObject);
        default:
            throw new Error(`Unsupported color ramp type: ${jsObject?.type}`);
    }
}
