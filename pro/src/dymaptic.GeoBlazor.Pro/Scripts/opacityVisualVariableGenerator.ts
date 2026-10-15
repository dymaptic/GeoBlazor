// override generated code in this file
import OpacityVisualVariableGeneratorGenerated from './opacityVisualVariableGenerator.gb';
import opacity = __esri.opacity;

export default class OpacityVisualVariableGeneratorWrapper extends OpacityVisualVariableGeneratorGenerated {

    constructor(component: opacity) {
        super(component);
    }
    
}

export async function buildJsOpacityVisualVariableGenerator(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsOpacityVisualVariableGeneratorGenerated } = await import('./opacityVisualVariableGenerator.gb');
    return await buildJsOpacityVisualVariableGeneratorGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetOpacityVisualVariableGenerator(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetOpacityVisualVariableGeneratorGenerated } = await import('./opacityVisualVariableGenerator.gb');
    return await buildDotNetOpacityVisualVariableGeneratorGenerated(jsObject, layerId, viewId);
}
