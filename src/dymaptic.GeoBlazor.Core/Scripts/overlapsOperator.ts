// override generated code in this file
import OverlapsOperatorGenerated from './overlapsOperator.gb';
import overlapsOperator = __esri.overlapsOperator;

export default class OverlapsOperatorWrapper extends OverlapsOperatorGenerated {

    constructor(component: overlapsOperator) {
        super(component);
    }
    
}

export async function buildJsOverlapsOperator(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsOverlapsOperatorGenerated } = await import('./overlapsOperator.gb');
    return await buildJsOverlapsOperatorGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetOverlapsOperator(jsObject: any): Promise<any> {
    let { buildDotNetOverlapsOperatorGenerated } = await import('./overlapsOperator.gb');
    return await buildDotNetOverlapsOperatorGenerated(jsObject);
}
