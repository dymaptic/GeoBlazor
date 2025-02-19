// override generated code in this file
import OpacityGenerated from './opacity.gb';
import opacity = __esri.opacity;

export default class OpacityWrapper extends OpacityGenerated {

    constructor(component: opacity) {
        super(component);
    }
    
}

export async function buildJsOpacity(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsOpacityGenerated } = await import('./opacity.gb');
    return await buildJsOpacityGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetOpacity(jsObject: any): Promise<any> {
    let { buildDotNetOpacityGenerated } = await import('./opacity.gb');
    return await buildDotNetOpacityGenerated(jsObject);
}
