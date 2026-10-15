// override generated code in this file
import ClassBreaksRendererGeneratorGenerated from './classBreaksRendererGenerator.gb';
import classBreaks = __esri.classBreaks;

export default class ClassBreaksRendererGeneratorWrapper extends ClassBreaksRendererGeneratorGenerated {

    constructor(component: classBreaks) {
        super(component);
    }
    
}

export async function buildJsClassBreaksRendererGenerator(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsClassBreaksRendererGeneratorGenerated } = await import('./classBreaksRendererGenerator.gb');
    return await buildJsClassBreaksRendererGeneratorGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetClassBreaksRendererGenerator(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetClassBreaksRendererGeneratorGenerated } = await import('./classBreaksRendererGenerator.gb');
    return await buildDotNetClassBreaksRendererGeneratorGenerated(jsObject, layerId, viewId);
}
