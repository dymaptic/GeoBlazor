// override generated code in this file
import ShadedReliefGenerated from './shadedRelief.gb';
import shadedRelief = __esri.shadedRelief;

export default class ShadedReliefWrapper extends ShadedReliefGenerated {

    constructor(component: shadedRelief) {
        super(component);
    }
    
}

export async function buildJsShadedRelief(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsShadedReliefGenerated } = await import('./shadedRelief.gb');
    return await buildJsShadedReliefGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetShadedRelief(jsObject: any): Promise<any> {
    let { buildDotNetShadedReliefGenerated } = await import('./shadedRelief.gb');
    return await buildDotNetShadedReliefGenerated(jsObject);
}
