// override generated code in this file
import StretchRendererGeneratorGenerated from './stretchRendererGenerator.gb';
import stretch = __esri.stretch;

export default class StretchRendererGeneratorWrapper extends StretchRendererGeneratorGenerated {

    constructor(component: stretch) {
        super(component);
    }
    
}

export async function buildJsStretchRendererGenerator(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsStretchRendererGeneratorGenerated } = await import('./stretchRendererGenerator.gb');
    return await buildJsStretchRendererGeneratorGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetStretchRendererGenerator(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetStretchRendererGeneratorGenerated } = await import('./stretchRendererGenerator.gb');
    return await buildDotNetStretchRendererGeneratorGenerated(jsObject, layerId, viewId);
}
