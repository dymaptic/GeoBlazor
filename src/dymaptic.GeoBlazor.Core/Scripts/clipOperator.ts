// override generated code in this file
import ClipOperatorGenerated from './clipOperator.gb';
import clipOperator = __esri.clipOperator;

export default class ClipOperatorWrapper extends ClipOperatorGenerated {

    constructor(component: clipOperator) {
        super(component);
    }
    
}

export async function buildJsClipOperator(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsClipOperatorGenerated } = await import('./clipOperator.gb');
    return await buildJsClipOperatorGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetClipOperator(jsObject: any): Promise<any> {
    let { buildDotNetClipOperatorGenerated } = await import('./clipOperator.gb');
    return await buildDotNetClipOperatorGenerated(jsObject);
}
