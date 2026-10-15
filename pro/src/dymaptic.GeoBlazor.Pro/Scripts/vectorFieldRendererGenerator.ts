// override generated code in this file
import VectorFieldRendererGeneratorGenerated from './vectorFieldRendererGenerator.gb';
import vectorField = __esri.vectorField;

export default class VectorFieldRendererGeneratorWrapper extends VectorFieldRendererGeneratorGenerated {

    constructor(component: vectorField) {
        super(component);
    }
    
}

export async function buildJsVectorFieldRendererGenerator(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsVectorFieldRendererGeneratorGenerated } = await import('./vectorFieldRendererGenerator.gb');
    return await buildJsVectorFieldRendererGeneratorGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetVectorFieldRendererGenerator(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetVectorFieldRendererGeneratorGenerated } = await import('./vectorFieldRendererGenerator.gb');
    return await buildDotNetVectorFieldRendererGeneratorGenerated(jsObject, layerId, viewId);
}
