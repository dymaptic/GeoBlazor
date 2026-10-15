// override generated code in this file
import UnivariateColorSizeRendererGeneratorGenerated from './univariateColorSizeRendererGenerator.gb';
import univariateColorSize = __esri.univariateColorSize;

export default class UnivariateColorSizeRendererGeneratorWrapper extends UnivariateColorSizeRendererGeneratorGenerated {

    constructor(component: univariateColorSize) {
        super(component);
    }
    
}

export async function buildJsUnivariateColorSizeRendererGenerator(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsUnivariateColorSizeRendererGeneratorGenerated } = await import('./univariateColorSizeRendererGenerator.gb');
    return await buildJsUnivariateColorSizeRendererGeneratorGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetUnivariateColorSizeRendererGenerator(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetUnivariateColorSizeRendererGeneratorGenerated } = await import('./univariateColorSizeRendererGenerator.gb');
    return await buildDotNetUnivariateColorSizeRendererGeneratorGenerated(jsObject, layerId, viewId);
}
