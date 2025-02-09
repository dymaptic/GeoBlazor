// override generated code in this file
import ColorVariableGenerated from './colorVariable.gb';
import ColorVariable from '@arcgis/core/renderers/visualVariables/ColorVariable';

export default class ColorVariableWrapper extends ColorVariableGenerated {

    constructor(component: ColorVariable) {
        super(component);
    }
    
}              
export async function buildJsColorVariable(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsColorVariableGenerated } = await import('./colorVariable.gb');
    return await buildJsColorVariableGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetColorVariable(jsObject: any): Promise<any> {
    let { buildDotNetColorVariableGenerated } = await import('./colorVariable.gb');
    return await buildDotNetColorVariableGenerated(jsObject);
}
