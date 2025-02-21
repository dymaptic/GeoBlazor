// override generated code in this file
import ShadedReliefRendererGeneratorGenerated from './shadedReliefRendererGenerator.gb';
import shadedRelief = __esri.shadedRelief;

export default class ShadedReliefRendererGeneratorWrapper extends ShadedReliefRendererGeneratorGenerated {

    constructor(component: shadedRelief) {
        super(component);
    }
    
}

export async function buildJsShadedReliefRendererGenerator(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsShadedReliefRendererGeneratorGenerated } = await import('./shadedReliefRendererGenerator.gb');
    return await buildJsShadedReliefRendererGeneratorGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetShadedReliefRendererGenerator(jsObject: any): Promise<any> {
    let { buildDotNetShadedReliefRendererGeneratorGenerated } = await import('./shadedReliefRendererGenerator.gb');
    return await buildDotNetShadedReliefRendererGeneratorGenerated(jsObject);
}
