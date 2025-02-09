// override generated code in this file
import TextSymbolGenerated from './textSymbol.gb';
import TextSymbol from '@arcgis/core/symbols/TextSymbol';

export default class TextSymbolWrapper extends TextSymbolGenerated {

    constructor(component: TextSymbol) {
        super(component);
    }
    
}

export async function buildJsTextSymbol(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsTextSymbolGenerated } = await import('./textSymbol.gb');
    return await buildJsTextSymbolGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetTextSymbol(jsObject: any): Promise<any> {
    let { buildDotNetTextSymbolGenerated } = await import('./textSymbol.gb');
    return await buildDotNetTextSymbolGenerated(jsObject);
}
