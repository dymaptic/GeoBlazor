// override generated code in this file
import RotationVariableGenerated from './rotationVariable.gb';
import RotationVariable from '@arcgis/core/renderers/visualVariables/RotationVariable';

export default class RotationVariableWrapper extends RotationVariableGenerated {

    constructor(component: RotationVariable) {
        super(component);
    }
    
}

export async function buildJsRotationVariable(dotNetObject: any): Promise<any> {
    let { buildJsRotationVariableGenerated } = await import('./rotationVariable.gb');
    return await buildJsRotationVariableGenerated(dotNetObject);
}     

export async function buildDotNetRotationVariable(jsObject: any): Promise<any> {
    let { buildDotNetRotationVariableGenerated } = await import('./rotationVariable.gb');
    return await buildDotNetRotationVariableGenerated(jsObject);
}
