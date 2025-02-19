// override generated code in this file
import SymbologyDotDensityGenerated from './symbologyDotDensity.gb';
import symbologyDotDensity = __esri.symbologyDotDensity;

export default class SymbologyDotDensityWrapper extends SymbologyDotDensityGenerated {

    constructor(component: symbologyDotDensity) {
        super(component);
    }
    
}

export async function buildJsSymbologyDotDensity(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsSymbologyDotDensityGenerated } = await import('./symbologyDotDensity.gb');
    return await buildJsSymbologyDotDensityGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetSymbologyDotDensity(jsObject: any): Promise<any> {
    let { buildDotNetSymbologyDotDensityGenerated } = await import('./symbologyDotDensity.gb');
    return await buildDotNetSymbologyDotDensityGenerated(jsObject);
}
