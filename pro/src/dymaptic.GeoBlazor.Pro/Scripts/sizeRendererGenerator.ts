// override generated code in this file
import SizeRendererGeneratorGenerated from './sizeRendererGenerator.gb';
import size = __esri.size;

export default class SizeRendererGeneratorWrapper extends SizeRendererGeneratorGenerated {

    constructor(component: size) {
        super(component);
    }
    
}

export async function buildJsSizeRendererGenerator(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsSizeRendererGeneratorGenerated } = await import('./sizeRendererGenerator.gb');
    return await buildJsSizeRendererGeneratorGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetSizeRendererGenerator(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetSizeRendererGeneratorGenerated } = await import('./sizeRendererGenerator.gb');
    return await buildDotNetSizeRendererGeneratorGenerated(jsObject, layerId, viewId);
}
