import color = __esri.color;
import ColorRendererGeneratorGenerated from './colorRendererGenerator.gb';

export default class ColorRendererGeneratorWrapper extends ColorRendererGeneratorGenerated {

    constructor(component: color) {
        super(component);
    }

}

export async function buildJsColorRendererGenerator(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsColorRendererGeneratorGenerated} = await import('./colorRendererGenerator.gb');
    return await buildJsColorRendererGeneratorGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetColorRendererGenerator(jsObject: any): Promise<any> {
    let {buildDotNetColorRendererGeneratorGenerated} = await import('./colorRendererGenerator.gb');
    return await buildDotNetColorRendererGeneratorGenerated(jsObject);
}
