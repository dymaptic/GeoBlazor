// override generated code in this file
import SimpleLineSymbolGenerated from './simpleLineSymbol.gb';
import SimpleLineSymbol from '@arcgis/core/symbols/SimpleLineSymbol';

export default class SimpleLineSymbolWrapper extends SimpleLineSymbolGenerated {

    constructor(component: SimpleLineSymbol) {
        super(component);
    }
    
}              
export async function buildJsSimpleLineSymbol(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsSimpleLineSymbolGenerated } = await import('./simpleLineSymbol.gb');
    return await buildJsSimpleLineSymbolGenerated(dotNetObject, layerId, viewId);
}

export async function buildJsOutline(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsSimpleLineSymbolGenerated } = await import('./simpleLineSymbol.gb');
    return await buildJsSimpleLineSymbolGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetSimpleLineSymbol(jsObject: any): Promise<any> {
    let { buildDotNetSimpleLineSymbolGenerated } = await import('./simpleLineSymbol.gb');
    return await buildDotNetSimpleLineSymbolGenerated(jsObject);
}
