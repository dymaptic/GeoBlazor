// override generated code in this file
import UniqueValueRendererLegendOptionsGenerated from './uniqueValueRendererLegendOptions.gb';
import UniqueValueRendererLegendOptions = __esri.UniqueValueRendererLegendOptions;

export default class UniqueValueRendererLegendOptionsWrapper extends UniqueValueRendererLegendOptionsGenerated {

    constructor(component: UniqueValueRendererLegendOptions) {
        super(component);
    }
    
}              
export async function buildJsUniqueValueRendererLegendOptions(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsUniqueValueRendererLegendOptionsGenerated } = await import('./uniqueValueRendererLegendOptions.gb');
    return await buildJsUniqueValueRendererLegendOptionsGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetUniqueValueRendererLegendOptions(jsObject: any): Promise<any> {
    let { buildDotNetUniqueValueRendererLegendOptionsGenerated } = await import('./uniqueValueRendererLegendOptions.gb');
    return await buildDotNetUniqueValueRendererLegendOptionsGenerated(jsObject);
}
