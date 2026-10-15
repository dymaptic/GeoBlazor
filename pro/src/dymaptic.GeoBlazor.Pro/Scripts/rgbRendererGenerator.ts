// override generated code in this file
import RgbRendererGeneratorGenerated from './rgbRendererGenerator.gb';
import rgb = __esri.rgb;

export default class RgbRendererGeneratorWrapper extends RgbRendererGeneratorGenerated {

    constructor(component: rgb) {
        super(component);
    }
    
}

export async function buildJsRgbRendererGenerator(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsRgbRendererGeneratorGenerated } = await import('./rgbRendererGenerator.gb');
    return await buildJsRgbRendererGeneratorGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetRgbRendererGenerator(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetRgbRendererGeneratorGenerated } = await import('./rgbRendererGenerator.gb');
    return await buildDotNetRgbRendererGeneratorGenerated(jsObject, layerId, viewId);
}
