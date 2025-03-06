// override generated code in this file
import SizeVariableGenerated from './sizeVariable.gb';
import SizeVariable from '@arcgis/core/renderers/visualVariables/SizeVariable';

export default class SizeVariableWrapper extends SizeVariableGenerated {

    constructor(component: SizeVariable) {
        super(component);
    }

}

export async function buildJsSizeVariable(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsSizeVariableGenerated} = await import('./sizeVariable.gb');
    return await buildJsSizeVariableGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetSizeVariable(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildDotNetSizeVariableGenerated} = await import('./sizeVariable.gb');
    return await buildDotNetSizeVariableGenerated(jsObject, layerId, viewId);
}
