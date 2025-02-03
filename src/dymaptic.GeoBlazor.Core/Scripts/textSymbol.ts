// override generated code in this file
import TextSymbolGenerated from './textSymbol.gb';
import TextSymbol from '@arcgis/core/symbols/TextSymbol';

export default class TextSymbolWrapper extends TextSymbolGenerated {

    constructor(component: TextSymbol) {
        super(component);
    }
    
}

export async function buildJsTextSymbol(dotNetObject: any): Promise<any> {
    let { buildJsTextSymbolGenerated } = await import('./textSymbol.gb');
    return await buildJsTextSymbolGenerated(dotNetObject);
}     

export async function buildDotNetTextSymbol(jsObject: any): Promise<any> {
    let { buildDotNetTextSymbolGenerated } = await import('./textSymbol.gb');
    return await buildDotNetTextSymbolGenerated(jsObject);
}
