// override generated code in this file
import SymbologyTypeGenerated from './symbologyType.gb';
import symbologyType = __esri.symbologyType;

export default class SymbologyTypeWrapper extends SymbologyTypeGenerated {

    constructor(component: symbologyType) {
        super(component);
    }

}

export async function buildJsSymbologyType(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsSymbologyTypeGenerated} = await import('./symbologyType.gb');
    return await buildJsSymbologyTypeGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetSymbologyType(jsObject: any): Promise<any> {
    let {buildDotNetSymbologyTypeGenerated} = await import('./symbologyType.gb');
    return await buildDotNetSymbologyTypeGenerated(jsObject);
}
