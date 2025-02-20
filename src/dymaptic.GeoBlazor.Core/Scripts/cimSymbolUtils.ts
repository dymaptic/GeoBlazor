// override generated code in this file
import CimSymbolUtilsGenerated from './cimSymbolUtils.gb';
import cimSymbolUtils = __esri.cimSymbolUtils;

export default class CimSymbolUtilsWrapper extends CimSymbolUtilsGenerated {

    constructor(component: cimSymbolUtils) {
        super(component);
    }

}

export async function buildJsCimSymbolUtils(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsCimSymbolUtilsGenerated} = await import('./cimSymbolUtils.gb');
    return await buildJsCimSymbolUtilsGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetCimSymbolUtils(jsObject: any): Promise<any> {
    let {buildDotNetCimSymbolUtilsGenerated} = await import('./cimSymbolUtils.gb');
    return await buildDotNetCimSymbolUtilsGenerated(jsObject);
}
