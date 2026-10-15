// override generated code in this file
import PredominanceRendererGeneratorGenerated from './predominanceRendererGenerator.gb';
import predominance = __esri.predominance;

export default class PredominanceRendererGeneratorWrapper extends PredominanceRendererGeneratorGenerated {

    constructor(component: predominance) {
        super(component);
    }
    
}

export async function buildJsPredominanceRendererGenerator(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsPredominanceRendererGeneratorGenerated } = await import('./predominanceRendererGenerator.gb');
    return await buildJsPredominanceRendererGeneratorGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetPredominanceRendererGenerator(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetPredominanceRendererGeneratorGenerated } = await import('./predominanceRendererGenerator.gb');
    return await buildDotNetPredominanceRendererGeneratorGenerated(jsObject, layerId, viewId);
}
