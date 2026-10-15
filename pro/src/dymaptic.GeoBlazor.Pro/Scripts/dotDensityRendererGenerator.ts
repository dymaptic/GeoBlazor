// override generated code in this file
import DotDensityRendererGeneratorGenerated from './dotDensityRendererGenerator.gb';
import dotDensity = __esri.dotDensity;

export default class DotDensityRendererGeneratorWrapper extends DotDensityRendererGeneratorGenerated {

    constructor(component: dotDensity) {
        super(component);
    }
    
}

export async function buildJsDotDensityRendererGenerator(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsDotDensityRendererGeneratorGenerated } = await import('./dotDensityRendererGenerator.gb');
    return await buildJsDotDensityRendererGeneratorGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetDotDensityRendererGenerator(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetDotDensityRendererGeneratorGenerated } = await import('./dotDensityRendererGenerator.gb');
    return await buildDotNetDotDensityRendererGeneratorGenerated(jsObject, layerId, viewId);
}
