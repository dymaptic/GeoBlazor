// override generated code in this file
import PredominanceGenerated from './predominance.gb';
import predominance = __esri.predominance;

export default class PredominanceWrapper extends PredominanceGenerated {

    constructor(component: predominance) {
        super(component);
    }

}

export async function buildJsPredominance(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsPredominanceGenerated} = await import('./predominance.gb');
    return await buildJsPredominanceGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetPredominance(jsObject: any): Promise<any> {
    let {buildDotNetPredominanceGenerated} = await import('./predominance.gb');
    return await buildDotNetPredominanceGenerated(jsObject);
}
