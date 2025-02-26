// override generated code in this file
import SymbologyLocationGenerated from './symbologyLocation.gb';
import symbologyLocation = __esri.symbologyLocation;

export default class SymbologyLocationWrapper extends SymbologyLocationGenerated {

    constructor(component: symbologyLocation) {
        super(component);
    }
    
}

export async function buildJsSymbologyLocation(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsSymbologyLocationGenerated } = await import('./symbologyLocation.gb');
    return await buildJsSymbologyLocationGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetSymbologyLocation(jsObject: any): Promise<any> {
    let { buildDotNetSymbologyLocationGenerated } = await import('./symbologyLocation.gb');
    return await buildDotNetSymbologyLocationGenerated(jsObject);
}
