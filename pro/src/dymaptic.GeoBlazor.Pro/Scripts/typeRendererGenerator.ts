// override generated code in this file
import TypeRendererGeneratorGenerated from './typeRendererGenerator.gb';
import type = __esri.type;

export default class TypeRendererGeneratorWrapper extends TypeRendererGeneratorGenerated {

    constructor(component: type) {
        super(component);
    }
    
}

export async function buildJsTypeRendererGenerator(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsTypeRendererGeneratorGenerated } = await import('./typeRendererGenerator.gb');
    return await buildJsTypeRendererGeneratorGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetTypeRendererGenerator(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetTypeRendererGeneratorGenerated } = await import('./typeRendererGenerator.gb');
    return await buildDotNetTypeRendererGeneratorGenerated(jsObject, layerId, viewId);
}
