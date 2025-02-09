// override generated code in this file
import AuthoringInfoVisualVariableGenerated from './authoringInfoVisualVariable.gb';
import AuthoringInfoVisualVariable from '@arcgis/core/renderers/support/AuthoringInfoVisualVariable';

export default class AuthoringInfoVisualVariableWrapper extends AuthoringInfoVisualVariableGenerated {

    constructor(component: AuthoringInfoVisualVariable) {
        super(component);
    }
    
}              
export async function buildJsAuthoringInfoVisualVariable(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsAuthoringInfoVisualVariableGenerated } = await import('./authoringInfoVisualVariable.gb');
    return await buildJsAuthoringInfoVisualVariableGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetAuthoringInfoVisualVariable(jsObject: any): Promise<any> {
    let { buildDotNetAuthoringInfoVisualVariableGenerated } = await import('./authoringInfoVisualVariable.gb');
    return await buildDotNetAuthoringInfoVisualVariableGenerated(jsObject);
}
