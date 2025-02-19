// override generated code in this file
import DecoratorsGenerated from './decorators.gb';
import decorators = __esri.decorators;

export default class DecoratorsWrapper extends DecoratorsGenerated {

    constructor(component: decorators) {
        super(component);
    }
    
}

export async function buildJsDecorators(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsDecoratorsGenerated } = await import('./decorators.gb');
    return await buildJsDecoratorsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetDecorators(jsObject: any): Promise<any> {
    let { buildDotNetDecoratorsGenerated } = await import('./decorators.gb');
    return await buildDotNetDecoratorsGenerated(jsObject);
}
