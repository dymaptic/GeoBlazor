// override generated code in this file
import OpacityVariableGenerated from './opacityVariable.gb';
import OpacityVariable from '@arcgis/core/renderers/visualVariables/OpacityVariable';

export default class OpacityVariableWrapper extends OpacityVariableGenerated {

    constructor(component: OpacityVariable) {
        super(component);
    }
    
}

export async function buildJsOpacityVariable(dotNetObject: any): Promise<any> {
    let { buildJsOpacityVariableGenerated } = await import('./opacityVariable.gb');
    return await buildJsOpacityVariableGenerated(dotNetObject);
}     

export async function buildDotNetOpacityVariable(jsObject: any): Promise<any> {
    let { buildDotNetOpacityVariableGenerated } = await import('./opacityVariable.gb');
    return await buildDotNetOpacityVariableGenerated(jsObject);
}
