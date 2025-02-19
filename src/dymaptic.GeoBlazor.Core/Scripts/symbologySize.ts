import symbologySize = __esri.symbologySize;
import SymbologySizeGenerated from './symbologySize.gb';

export default class SymbologySizeWrapper extends SymbologySizeGenerated {

    constructor(component: symbologySize) {
        super(component);
    }
    
}

export async function buildJsSymbologySize(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsSymbologySizeGenerated } = await import('./symbologySize.gb');
    return await buildJsSymbologySizeGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetSymbologySize(jsObject: any): Promise<any> {
    let { buildDotNetSymbologySizeGenerated } = await import('./symbologySize.gb');
    return await buildDotNetSymbologySizeGenerated(jsObject);
}
