// override generated code in this file
import SymbologyPredominanceGenerated from './symbologyPredominance.gb';
import symbologyPredominance = __esri.symbologyPredominance;

export default class SymbologyPredominanceWrapper extends SymbologyPredominanceGenerated {

    constructor(component: symbologyPredominance) {
        super(component);
    }
    
}

export async function buildJsSymbologyPredominance(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsSymbologyPredominanceGenerated } = await import('./symbologyPredominance.gb');
    return await buildJsSymbologyPredominanceGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetSymbologyPredominance(jsObject: any): Promise<any> {
    let { buildDotNetSymbologyPredominanceGenerated } = await import('./symbologyPredominance.gb');
    return await buildDotNetSymbologyPredominanceGenerated(jsObject);
}
