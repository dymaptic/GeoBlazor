// override generated code in this file
import SymbolUtilsGenerated from './symbolUtils.gb';
import symbolUtils = __esri.symbolUtils;

export default class SymbolUtilsWrapper extends SymbolUtilsGenerated {

    constructor(component: symbolUtils) {
        super(component);
    }
    
}

export async function buildJsSymbolUtils(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsSymbolUtilsGenerated } = await import('./symbolUtils.gb');
    return await buildJsSymbolUtilsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetSymbolUtils(jsObject: any): Promise<any> {
    let { buildDotNetSymbolUtilsGenerated } = await import('./symbolUtils.gb');
    return await buildDotNetSymbolUtilsGenerated(jsObject);
}
