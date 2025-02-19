// override generated code in this file
import DotDensityGenerated from './dotDensity.gb';
import dotDensity = __esri.dotDensity;

export default class DotDensityWrapper extends DotDensityGenerated {

    constructor(component: dotDensity) {
        super(component);
    }
    
}

export async function buildJsDotDensity(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsDotDensityGenerated } = await import('./dotDensity.gb');
    return await buildJsDotDensityGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetDotDensity(jsObject: any): Promise<any> {
    let { buildDotNetDotDensityGenerated } = await import('./dotDensity.gb');
    return await buildDotNetDotDensityGenerated(jsObject);
}
