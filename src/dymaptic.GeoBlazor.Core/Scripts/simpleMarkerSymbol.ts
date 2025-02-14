// override generated code in this file
import SimpleMarkerSymbolGenerated from './simpleMarkerSymbol.gb';
import SimpleMarkerSymbol from '@arcgis/core/symbols/SimpleMarkerSymbol';

export default class SimpleMarkerSymbolWrapper extends SimpleMarkerSymbolGenerated {

    constructor(component: SimpleMarkerSymbol) {
        super(component);
    }
    
}

export async function buildJsSimpleMarkerSymbol(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsSimpleMarkerSymbolGenerated } = await import('./simpleMarkerSymbol.gb');
    return await buildJsSimpleMarkerSymbolGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetSimpleMarkerSymbol(jsObject: any): Promise<any> {
    let { buildDotNetSimpleMarkerSymbolGenerated } = await import('./simpleMarkerSymbol.gb');
    return await buildDotNetSimpleMarkerSymbolGenerated(jsObject);
}
