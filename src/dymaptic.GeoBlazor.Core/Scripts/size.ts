// override generated code in this file
import SizeGenerated from './size.gb';
import size = __esri.size;

export default class SizeWrapper extends SizeGenerated {

    constructor(component: size) {
        super(component);
    }
    
}

export async function buildJsSize(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsSizeGenerated } = await import('./size.gb');
    return await buildJsSizeGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetSize(jsObject: any): Promise<any> {
    let { buildDotNetSizeGenerated } = await import('./size.gb');
    return await buildDotNetSizeGenerated(jsObject);
}
