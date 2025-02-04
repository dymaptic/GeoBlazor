// override generated code in this file
import SymbolGenerated from './symbol.gb';
import Symbol from '@arcgis/core/symbols/Symbol';

export default class SymbolWrapper extends SymbolGenerated {

    constructor(component: Symbol) {
        super(component);
    }
    
}

export async function buildJsSymbol(dotNetObject: any): Promise<any> {
    let { buildJsSymbolGenerated } = await import('./symbol.gb');
    return await buildJsSymbolGenerated(dotNetObject);
}     

export async function buildDotNetSymbol(jsObject: any): Promise<any> {
    let { buildDotNetSymbolGenerated } = await import('./symbol.gb');
    return await buildDotNetSymbolGenerated(jsObject);
}
