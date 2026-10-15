// override generated code in this file
import UniqueValueRendererGeneratorGenerated from './uniqueValueRendererGenerator.gb';
import uniqueValue = __esri.uniqueValue;

export default class UniqueValueRendererGeneratorWrapper extends UniqueValueRendererGeneratorGenerated {

    constructor(component: uniqueValue) {
        super(component);
    }
    
}

export async function buildJsUniqueValueRendererGenerator(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsUniqueValueRendererGeneratorGenerated } = await import('./uniqueValueRendererGenerator.gb');
    return await buildJsUniqueValueRendererGeneratorGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetUniqueValueRendererGenerator(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetUniqueValueRendererGeneratorGenerated } = await import('./uniqueValueRendererGenerator.gb');
    return await buildDotNetUniqueValueRendererGeneratorGenerated(jsObject, layerId, viewId);
}
